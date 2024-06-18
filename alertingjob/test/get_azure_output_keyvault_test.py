from src.modules import get_azure_output_keyvault
from jsonschema import validate


class Test_get_azure_output:

    schema = {
        "type": "array",
        "properties": {
            "displayName": {"type": "string"},
            "endDate": {"type": "string"},
            "keyId": {"type": "string"}
        }
    }

    my_json = get_azure_output_keyvault("DAIM-P-BYOK-KV", "secret")

    def test_right_schema(self):
        validate(instance=self.my_json, schema=self.schema)
