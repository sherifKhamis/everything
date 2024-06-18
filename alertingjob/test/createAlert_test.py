from src.modules import create_alert
from main_appRegistration import API_Key, opsgenie_alert_url
import json


class Test_create_alert:
    def test_bad_url(self):
        assert "WrongURL" not in create_alert(message="Test", displayName="TestDiplayName", expiryDate="TestDate", keyID="TestKeyID", API_Key=API_Key, url=opsgenie_alert_url, priority="P5")

    def test_no_success(self):
        assert json.loads(create_alert(message="Test", displayName="TestDiplayName", expiryDate="TestDate", keyID="TestKeyID", API_Key=API_Key, url=opsgenie_alert_url, priority="P5")).get("result") == "Request will be processed"

    def test_wrong_api_key(self):
        assert json.loads(create_alert(message="Test", displayName="TestDiplayName", expiryDate="TestDate", keyID="TestKeyID", API_Key=API_Key, url=opsgenie_alert_url, priority="P5")).get("message") != "Could not authenticate"
