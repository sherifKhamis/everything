''' This is the main file of the script where the command line arguments and the links to the key vault
    and the opsgenie alert website are saved.
'''

from src.modules import filter_azure_output, get_api_key, create_alert
import sys
import json
import datetime

# Saves command line arguments in params
params = sys.argv[1:]

# If params is empty, default namespace "DAI-GI9" is used
try:
    namespace = params[0]
except IndexError:
    namespace = "DAI-GI9"

# If params is empty, default days till expire "30" is used
try:
    days_till_expire = int(params[1])
except IndexError:
    days_till_expire = 30
except ValueError:
    days_till_expire = 30

JiraSD_alert_url = "https://api.atlassian.com/jsm/ops/integration/v2/alerts"
secretName_JiraSD = "JiraSDAPIKeySecretExpiryCheck"
opsgenie_alert_url = "https://api.eu.opsgenie.com/v2/alerts"
key_vault_url = "https://DAIM-P-BYOK-KV.vault.azure.net"
secretName = "opsgenieAPIKeySecretExpiryCheck"
alert_message = "Azure App Registrations Secret Expiration"
API_Key = get_api_key(KVUri=key_vault_url, secret=secretName)
API_Key_JiraSD = get_api_key(KVUri=key_vault_url, secret=secretName_JiraSD)
# Takes filtered azure output according to the right number of days and creates the alert in opsgenie
today = datetime.datetime.today()
filteredAzureOutput = json.loads(filter_azure_output(namespace=namespace, days_till_expire=days_till_expire))
for i in range(0, len(filteredAzureOutput)):
    for j in range(0, len(filteredAzureOutput[i]["endDate"])):
        difference = datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S") - today
        difference_in_days = difference / datetime.timedelta(days=1)
        if difference_in_days <= 1:
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key, url=opsgenie_alert_url, priority="P1")
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key_JiraSD, url=JiraSD_alert_url, priority="P1")
        elif difference_in_days <= 3:
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key, url=opsgenie_alert_url, priority="P2")
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key_JiraSD, url=JiraSD_alert_url, priority="P2")
        else:
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key, url=opsgenie_alert_url, priority="P5")
            create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][j][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"][j], API_Key=API_Key_JiraSD, url=JiraSD_alert_url, priority="P5")
