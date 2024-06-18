from src.modules import get_api_key, create_alert
from main_appRegistration import key_vault_url, secretName, opsgenie_alert_url, json


class Test_get_api_key:
    def test_wrongKeyVault(self):
        assert "WrongVaultURL" not in get_api_key(key_vault_url, secretName)

    def test_wrongSecretName(self):
        assert "SecretNotFound" not in get_api_key(key_vault_url, secretName)

    def test_rightKey(self):
        assert json.loads(create_alert(message="Test", displayName="TestDiplayName", expiryDate="TestDate", keyID="TestKeyID", API_Key=get_api_key(KVUri=key_vault_url, secret=secretName), url=opsgenie_alert_url, priority="P5")).get("result") == "Request will be processed"
