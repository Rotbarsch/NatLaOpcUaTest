Feature: NodeRead - Object

Note: Due to the way the OPC/UA library works, and JsonSerialization works, all property names are expected to be CamelCase instead of whatever 
is defined server-side.

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and read node by id
	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.X' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.Value' in variable 'nodeValue' is stored in variable 'nodeValueValue'

	Then the value of variable 'nodeValueX' equals '1'
	And the value of variable 'nodeValueValue' equals '2'

Scenario: Connect and read node by path
	When the value of node with path '/Objects/Demo/Scalar/ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.X' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.Value' in variable 'nodeValue' is stored in variable 'nodeValueValue'

	Then the value of variable 'nodeValueX' equals '1'
	And the value of variable 'nodeValueValue' equals '2'
	

