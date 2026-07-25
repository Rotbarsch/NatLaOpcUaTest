# ![Icon](./icon64.png) NatLaOpcUaTest

*Natural Language OPC/UA Testing Framework*

## Mission Statement
This project aims to simplify the process of testing OPC/UA endpoints by leveraging natural language processing techniques, 
powered by the excellent [Reqnroll](https://github.com/reqnroll/Reqnroll). 
It allows testers to write test cases in plain English, making it easier for non-technical stakeholders to understand and contribute to the testing process.

It uses the shared binding from [Rotbarsch.Reqnroll.BaseBindings](https://github.com/Rotbarsch/Rotbarsch.Reqnroll.BaseBindings) for variables etc. See there for further info.

**TL;DR: A set of Reqnroll Bindings for writing REST API tests in Natural Language.**

## Minimal Usage Example
```
Given the endpoint 'opc.tcp://my.opc.ua.server'
When the value of node 'ns=1;i=3' is stored in variable 'firstNodeValue'
Then the value of 'firstNodeValue' equals 'Ok'
```

See the NatLaOpcUaTest.Demo project for more usage examples or the full listing of [implemented bindings](https://github.com/Rotbarsch/NatLaOpcUaTest/wiki/Bindings).
The common bindings (Assert, Variable operations, etc) are documented in the wiki of [Rotbarsch.Reqnroll.BaseBindings](https://github.com/Rotbarsch/Rotbarsch.Reqnroll.BaseBindings/wiki/Bindings).

## Advantages of using NatLaOpcUaTest
- **Natural Language**: Write tests in plain English, making them accessible to non-technical team members.
- **Version control compatible**: Test cases can be easily managed and tracked using standard version control systems.
- **Ease of Use**: Simplifies the process of creating and maintaining OPC/UA tests.
- **Integration with Reqnroll**: Leverages the powerful features of Reqnroll and its various integrations for REST API testing.
- **Flexibility**: Easily adaptable to various OPC/UA testing scenarios.
- **Ready for AI**: The natural language used for describing tests is well-suited for AI-driven test generation and analysis.

## Getting Started
NatLaOpcUaTest provides a project template. Install and use it as follows:
```
dotnet new install NatLaOpcUaTest.Template
dotnet new NatLaOpcUaTest -n MyTestProject
```
This will create a new test project with the necessary dependencies and a sample test case named `MyTestProject`.
Check if it runs correctly via `dotnet test`, and then start writing your own test cases.

## Running tests
You can run tests created with this framework using your preferred test runner that supports NUnit, such as the built-in test explorer in Visual Studio, or via command line using the `dotnet test` command.
Currently, only NUnit is supported as the test framework.

## About variables
NatLaOpcUaTest provides a system to work with variables in your test cases. Usage of variables in parameters (aka everything enclosed by single quotes in binding expressions) is indicated by the syntax `$(variableName)`.

Do not confuse NatLaOpcUaTest variables with [Gherkin Scenario Outlines](https://docs.reqnroll.net/latest/gherkin/gherkin-reference.html#scenario-outline).
They are combinable, though. The Demo project provides an example for this in the `ScenarioOutlineAndExamples.feature` file.

There are several ways to define variables for usage in your tests:

### Global variables
Global variables are defined in the `globalVariables` section of your `NatLaOpcUaTestSettings.json` configuration file. For example:
```
    "globalVariables": [
        {
          "name": "demoEndpoint",
          "value": "opc.tcp://my.server"
        }
    ]
```

and in your test case:
```
Then the value of variable 'demoEndpoint' equals 'opc.tcp://my.server'
```

or, as another example:

```
Given the endpoint '$(demoEndpoint)'
```

Global variables are available in all scenarios, and are loaded before test execution starts.

### Variable files
You can also define variables in separate JSON files, and load them during the execution of your tests using the [LoadVariablesFile](./Bindings.md#LoadVariablesFile) step binding.

For example, a file `variables.json`:
```
{
    "testVariables":[
        {
            "name": "exampleNumber",
            "value": 42
        }
    ]
}
```

Make sure this file is copied to your output directory during build (set the `Copy to Output Directory` property of the file to `Copy if newer` or `Copy always`) and load these variables during a test scenario by adding the following to your test:
```
Given the variables file 'variables.json' is loaded
Then the value of variable 'exampleNumber' equals '42'
```

### Setting variables during test execution
There are several step bindings available, which allow you to set variables during test execution, e.g. by extracting values from responses or reading a file. See the [Bindings](./Bindings.md) for more information.

### Resolving variables
As mentioned before, variables are referenced using the syntax `$(variableName)` for usage in all parameters (again, indicated by single quotes) or are asked for explicitly by specific bindings like comparisons and mutations. Consider the following example to get a feeling for the capabilities of the system:
```
When the value 'abc' is stored in variable 'firstParameter'
And the value 'def' is stored in variable 'secondParameter'
And a request to '$(firstParameter)/$(secondParameter)' is made
```
The above example will result in a request to `abc/def`.

Furthermore, variables in this syntax are resolved recursively, meaning you can have variables depending on other variables:
```
When the value 'variableValue' is stored in variable 'varName'
And the value '42' is stored in variable 'variableValue'
And the value '$($(varName))' is stored in variable 'result'
Then the value of variable 'result' equals '42'
```

## rotbarsch.reqnroll.json
NatLaOpcUaTest uses a configuration file named `rotbarsch.reqnroll.json` to manage several settings.

Consider the following example:
```
{
  "additionalConfigurationFiles": [
    "./NatLaOpcUaTestSettings.Development.json"
  ],
  "globalVariables": [
    {
      "name": "stage",
      "value": "Development"
    }
  ],
  "fileRedirects": [
    {
      "originalFileName": "settings.json",
      "redirect": "settings.$(stage).json"
    }
  ]
}
  
```

### AdditionalConfigurationFiles Block
This block allows you to specify additional configuration files to be loaded by NatLaOpcUaTest. These files can contain environment-specific settings or overrides for the default configuration.
All files (and the default entry file) are loaded and merged together before test execution starts. In case of conflicts, the last loaded file wins, meaning that you can use this mechanism to override settings from the default configuration file.
This allows you to have both a 'NatLaOpcUaTestSettings.json' file with default settings and additional files like 'NatLaOpcUaTestSettings.Development.json' or 'NatLaOpcUaTestSettings.Production.json' with environment-specific overrides, which can also be included in a .gitignore file to keep secrets like API keys from being committed.

Compare to appsettings.json files in ASP.NET Core applications, which work in a similar way.

### GlobalVariables Block
This block allows you to define global variables that can be used throughout your tests. Global variables are accessible from any test and can be used to store values that need to be shared across multiple test cases.
They are initialized before test execution starts, so they are available right from the beginning of your tests.

### FileRedirects Block
This block allows you to defined file redirects. Consider the following test case:

```
Given the variables file 'variables.json' is loaded
```

Without any file redirects, NatLaOpcUaTest would try to load the file `variables.json` directly. However, with the following file redirect defined in the configuration file:
```
  "fileRedirects": [
    {
      "originalFileName": "variables.json",
      "redirect": "variables.$(stage).json"
    }
  ]
```
NatLaOpcUaTest will instead try to load the file `variables.Development.json`, assuming the global variable `stage` is set to `Development`.

This allows you to easily switch between different files based on the current environment or other criteria defined by your global variables.

In contrast to the mechanism for additional configuration files, file-redirects are not additive. Meaning, no file merging takes place and only the file defined in the redirect is loaded.

## Recommended workflow

### Using the Reqnroll IDE integrations
For an optimal experience when working with NatLaOpcUaTest, it is recommended to use one of the Reqnroll IDE integrations, such as the [Visual Studio Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-visual-studio), the [Visual Studio Code Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-visual-studio-code) or the [JetBrains Rider Extension](https://docs.reqnroll.net/latest/installation/setup-ide.html#setup-rider). These integrations provide features like syntax highlighting, autocompletion, and easy test execution directly from the IDE.

Also see [my Visual Studio Code Extension](https://github.com/Rotbarsch/RotbarschReqnroll-vscode) which was created with NatLaOpcUaTest in mind, but not bound to it and should work with any Reqnroll based test suite.

### Using AI agents to generate tests
Given the natural language basis of NatLaOpcUaTest, it is well-suited for usage with AI agents like GitHub Copilot or others. It has proven effective to "feed" either the [Bindings.md](./Bindings.md) or the `NatLaOpcUaTest.Bindings.xml` to the agent, to familiarize it with the available step bindings. Alternatively, check out this repository and ask GitHub Copilot to create your tests using the bindings in this repository.

*Also check out another of my projects, the [ReqnRoll MCP Server](https://github.com/Rotbarsch/ReqnRoll-MCP-Server).*

## Debugging your tests
You can use the special `Then enter debug mode` binding to enter NatLaOpcUaTestDebug mode during test execution, provided a debugger is attached.
In this state, a property named `Debug` is provided in your debug content. Use the Immediate Window (Visual Studio) or the Debug Console (Visual Studio Code) to execute commands against this property. 
See [the debug service](https://github.com/Rotbarsch/Rotbarsch.Reqnroll.BaseBindings/blob/main/Rotbarsch.Reqnroll.Services.Interfaces/IDebugUtilityService.cs) for the available commands.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

### Third-Party Dependencies
Information about the licenses of dependencies can be found in the [THIRD-PARTY_NOTICES.txt](./THIRD-PARTY_NOTICES.txt) file.
