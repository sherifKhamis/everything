import json
import subprocess
import requests
import datetime
from azure.keyvault.secrets import SecretClient
from azure.core.exceptions import ResourceNotFoundError, ServiceRequestError
from azure.identity import AzureCliCredential


def filter_azure_output(namespace: str, days_till_expire: int) -> json:
    '''Runs azure query and filters query result for secrets that
    matches the wanted days till expiry
    Params
        namespace = AppRegistrations Namespace filter to be applied
        days_till_expire = days till expiry of the secret
    Return
        Filtered_json_object
    '''
    azure_output_filtered = []
    azure_output_json = get_azure_output(namespace=namespace)
    print("Gets azure output")

    today = datetime.datetime.today()

    # Filters through azure_output_json and creates a list with the data of the
    # days that match the required expiry date
    for i in range(0, len(azure_output_json)):
        for j in range(0, len(azure_output_json[i]["endDate"])):
            endDate = datetime.datetime.strptime(azure_output_json[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")
            difference = endDate - today
            difference_in_days = difference / datetime.timedelta(days=1)
            if difference_in_days <= days_till_expire:
                azure_output_filtered.append(azure_output_json[i])

    print("Azure Output filtered")
    return json.dumps(azure_output_filtered)


def create_alert(message: str, displayName: str, expiryDate: str, keyID: str, API_Key: str, url: str, priority: str) -> str:
    '''Creates alert in JiraSD / Opsgenie with some information
    Params
        displayName = AppRegistrations / Keyvault Secret display name
        expiryDate = expiry date of the secret
        keyID = keyID of the secret
        API_Key = Opsgenie / JiraSD API Key
        url = Opsgenie / JiraSD alert url

    Return
        requests response message
    '''
    headers = f'''{{
        "Content-Type": "application/json",
        "Authorization": "GenieKey {API_Key}" }}'''

    data = f'''{{
        "message": "{message}",
        "description": "Display Name: {displayName} \\n Expiry Date: {expiryDate} \\n KeyId: {keyID}",
        "priority": "{priority}"}}'''
    try:
        r = requests.post(url, headers=json.loads(headers), json=json.loads(data))
    except ConnectionError as e:
        return "WrongURL " + str(e)
    print(r.text)
    return r.text


def get_api_key(KVUri: str, secret: str) -> str:
    '''Function that retrieves the key value of a secret from the azure key vault

       In our case to retrieve an opsgenie api key to login to the opsgenie site

    Params
       KVUri = link to the azure key vault
       secret = name of the secret that you want
    Return
      key value from secret
    '''

    try:
        credential = AzureCliCredential()
        client = SecretClient(vault_url=KVUri, credential=credential)
        retrieved_secret = client.get_secret(secret)
    except ResourceNotFoundError as e:
        return "SecretNotFound " + str(e)
    except ServiceRequestError as e:
        return "WrongVaultURL " + str(e)
    return retrieved_secret.value


def get_azure_output(namespace: str) -> json:
    '''Runs azure query and returns a respective json object that matches the namespace
    Params
        namespace = AppRegistrations Namespace filter to be applied
    Return
        json_object that matches the azure query
    '''
    return json.loads(subprocess.getoutput(f'''az ad app list --filter "startswith(displayName,'{namespace}')" --query "[].{{displayName:displayName, endDate:passwordCredentials[].endDateTime, keyId:passwordCredentials[].keyId}}"'''))


def filter_azure_output_keyvault(days_till_expiration:int, keyvault: str, type: str, azure_output_filtered: list) -> json:
    '''Runs azure query and filters query result for secrets and certificates that
    matches the wanted days till expiry
    Params
        keyvault= name of the keyvault
        type= Either a secret or certificate
    Return
        Filtered_json_object
    '''

    azure_output_json = get_azure_output_keyvault(keyvault=keyvault, type=type)
    print("Gets azure output")

    today = datetime.datetime.today()

    # Filters through azure_output_json and creates a list with the data of the
    # days that match the required expiry date
    for i in range(0, len(azure_output_json)):
        try:

            endDate = datetime.datetime.strptime(azure_output_json[i]["endDate"][0:19], "%Y-%m-%dT%H:%M:%S")
            difference = endDate - today
            difference_in_days = difference / datetime.timedelta(days=1)
            if difference_in_days <= days_till_expiration:
                azure_output_filtered.append(azure_output_json[i])
        except TypeError:
            endDate = datetime.datetime(3023, 10, 5, 18, 00)

    return json.dumps(azure_output_filtered)


def get_azure_output_keyvault(keyvault: str, type:str) -> json:
    '''Runs azure query and returns a respective json object that matches the keyvault name and object type
    Params
        keyvault = keyvault name to be appplied
        type = Either secret or certificate
    Return
        json_object that matches the azure query
    '''
    return json.loads(subprocess.getoutput(f'''az keyvault {type} list --vault-name {keyvault} --query "[].{{displayName:name, endDate:attributes.expires, keyId:id}}"'''))
