def pytest_addoption(parser):
    parser.addoption("--namespace", action="store", default="DAI-GI9")


def pytest_generate_tests(metafunc):
    # This is called for every test. Only get/set command line arguments
    # if the argument is specified in the list of test "fixturenames".
    option_value = metafunc.config.option.namespace
    if 'namespace' in metafunc.fixturenames and option_value is not None:
        metafunc.parametrize("namespace", [option_value])
