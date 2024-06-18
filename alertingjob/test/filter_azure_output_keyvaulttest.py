from src.modules import filter_azure_output_keyvault
from main_keyvault import types, keyvaults
from jsonschema import validate
import json


class Test_filter_azure_output_keyvault:

    schema = {
        "type": "array",
        "properties": {
            "displayName": {"type": "string"},
            "endDate": {"type": "string"},
            "keyId": {"type": "string"}
        }
    }

    my_json = []
    for i in types:
        for j in keyvaults:
            my_json = json.loads(filter_azure_output_keyvault(days_till_expiration=30, keyvault=j, type=i, azure_output_filtered=my_json))

    def test_right_schema(self):
        validate(instance=self.my_json, schema=self.schema)
