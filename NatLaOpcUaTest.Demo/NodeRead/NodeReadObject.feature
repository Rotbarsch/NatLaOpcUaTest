Feature: NodeRead - Object

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'
	When the following value is written to node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.ExtensionObject':
	"""
	{
		"x": 12,
		"value": 24
	}
	"""

Scenario: Connect and read node by id
	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.x' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.value' in variable 'nodeValue' is stored in variable 'nodeValueValue'

	Then the value of variable 'nodeValueX' equals '12'
	And the value of variable 'nodeValueValue' equals '24'

Scenario: Connect and read node by path
	When the value of node with path '/Objects/Demo/Scalar/ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.x' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.value' in variable 'nodeValue' is stored in variable 'nodeValueValue'

	Then the value of variable 'nodeValueX' equals '12'
	And the value of variable 'nodeValueValue' equals '24'
	

