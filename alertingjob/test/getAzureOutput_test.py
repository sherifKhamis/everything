from src.modules import get_azure_output
from jsonschema import validate
from main_appRegistration import namespace


class Test_get_azure_output:

    schema = {
        "type": "array",
        "properties": {
            "displayName": {"type": "string"},
            "endDate": {"type": "string"},
            "keyId": {"type": "string"}
        }
    }

    my_json = get_azure_output(namespace)

    def test_right_schema(self):
        validate(instance=self.my_json, schema=self.schema)
