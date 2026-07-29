Feature: NodeWrite - Scalar

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and write node by id
	When the value '12' is written to node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.Int16'
	And the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Scalar.Int16' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '12'

Scenario: Connect and write node by path
	When the value '12' is written to node with path '/Objects/Demo/Scalar/Int16'
	And the value of node with path '/Objects/Demo/Scalar/Int16' is stored in variable 'updatedValue'
	Then the value of variable 'updatedValue' equals '12'

