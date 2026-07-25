Feature: NodeRead - Scalar

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and read node by id
	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.Int16' is stored in variable 'nodeValue'
	Then the value of variable 'nodeValue' equals '12'

Scenario: Connect and read node by path
	When the value of node with path '/Objects/Demo/Scalar/Int16' is stored in variable 'nodeValue'
	Then the value of variable 'nodeValue' equals '12'

