from src.modules import filter_azure_output_keyvault, get_api_key, create_alert
import json
import datetime

JiraSD_alert_url = "https://api.atlassian.com/jsm/ops/integration/v2/alerts"
secretName_JiraSD = "JiraSDAPIKeySecretExpiryCheck"
key_vault_url = "https://DAIM-P-BYOK-KV.vault.azure.net"
alert_message = "Azure Keyvault Secret / Certificate Expiration"

API_Key_JiraSD = get_api_key(KVUri=key_vault_url, secret=secretName_JiraSD)

# Takes filtered azure output according to the right number of days and creates the alert in opsgenie / JiraSD
today = datetime.datetime.today()

types = ["secret", "certificate"]
keyvaults = ["DAIM-P-BYOK-KV", "DAIM-P-EDGE-KV", "DAIM-P-OPS-KV", "WARP-P-MONITORING-KV"]

filteredAzureOutput = []
for i in types:
    for j in keyvaults:
        filteredAzureOutput = json.loads(filter_azure_output_keyvault(days_till_expiration=30, keyvault=j, type=i, azure_output_filtered=filteredAzureOutput))

for i in range(0, len(filteredAzureOutput)):
    difference = datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][0:19], "%Y-%m-%dT%H:%M:%S") - today
    difference_in_days = difference / datetime.timedelta(days=1)
    if difference_in_days <= 7:
        create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"], API_Key=API_Key_JiraSD, url=JiraSD_alert_url, priority="P2")
    else:
        create_alert(message=alert_message, displayName=filteredAzureOutput[i]["displayName"], expiryDate=str(datetime.datetime.strptime(filteredAzureOutput[i]["endDate"][0:19], "%Y-%m-%dT%H:%M:%S")), keyID=filteredAzureOutput[i]["keyId"], API_Key=API_Key_JiraSD, url=JiraSD_alert_url, priority="P5")
