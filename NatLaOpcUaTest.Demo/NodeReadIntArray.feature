Feature: NodeRead - Array of Int16

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and read node by id
	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Array.Int16Array' is stored in variable 'nodeValue'
	And the length of collection variable 'nodeValue' is stored in variable 'nodeValueLength'
	Then the value of variable 'nodeValueLength' equals '5'

Scenario: Connect and read node by path
	When the value of node with path '/Objects/Demo/Array/Int16Array' is stored in variable 'nodeValue'
	And the length of collection variable 'nodeValue' is stored in variable 'nodeValueLength'
	Then the value of variable 'nodeValueLength' equals '5'

