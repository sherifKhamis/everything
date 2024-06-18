from src.modules import filter_azure_output
from main_appRegistration import namespace, days_till_expire
from jsonschema import validate
import json


class Test_get_azure_output:

    schema = {
        "type": "array",
        "properties": {
            "displayName": {"type": "string"},
            "endDate": {"type": "string"},
            "keyId": {"type": "string"}
        }
    }

    my_json = json.loads(filter_azure_output(namespace, days_till_expire))

    def test_right_schema(self):
        validate(instance=self.my_json, schema=self.schema)
