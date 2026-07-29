Feature: NodeWrite - Object

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and write node by id
	When the following value is written to node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.ExtensionObject':
	"""
	{
		"x": 42,
		"value": 24
	}
	"""

	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.x' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.value' in variable 'nodeValue' is stored in variable 'nodeValueValue'

	Then the value of variable 'nodeValueX' equals '42'
	And the value of variable 'nodeValueValue' equals '24'

Scenario: Connect and write node by path
	When the following value is written to node with path '/Objects/Demo/Scalar/ExtensionObject':
	"""
	{
		"x": 42,
		"value": 24
	}
	"""

	When the value of node with path '/Objects/Demo/Scalar/ExtensionObject' is stored in variable 'nodeValue'
	And the value of JSONPath '$.x' in variable 'nodeValue' is stored in variable 'nodeValueX'
	And the value of JSONPath '$.value' in variable 'nodeValue' is stored in variable 'nodeValueValue'
	Then the value of variable 'nodeValueX' equals '42'
	And the value of variable 'nodeValueValue' equals '24'
	

