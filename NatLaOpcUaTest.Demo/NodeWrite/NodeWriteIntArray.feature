Feature: NodeWrite - Array of Int16

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and write array node by id
	When the value '[1,2,3,4,5]' is written to node with id 'ns=2;s=CTT.Static.AllProfiles.Array.Int16Array'
	And the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Array.Int16Array' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '[1,2,3,4,5]'

Scenario: Connect and write array node by path
	When the value '[1,2,3,4,5]' is written to node with path '/Objects/Demo/Array/Int16Array'
	And the value of node with path '/Objects/Demo/Array/Int16Array' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '[1,2,3,4,5]'

Scenario: Connect and write array node by id - multiline input
	When the following value is written to node with id 'ns=2;s=CTT.Static.AllProfiles.Array.Int16Array':
	"""
	[1,2,3,4,5]
	"""
	And the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Array.Int16Array' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '[1,2,3,4,5]'

Scenario: Connect and write array node by path - multiline input
	When the following value is written to node with path '/Objects/Demo/Array/Int16Array':
	"""
	[1,2,3,4,5]
	"""
	And the value of node with path '/Objects/Demo/Array/Int16Array' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '[1,2,3,4,5]'
