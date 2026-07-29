Feature: Method invocation

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Call method by id - no parameters, with result
	When the method on node with id 'ns=0;i=11492' is invoked and the result is stored in variable 'methodInvokationResult'

Scenario: Call method by path - no parameters, with result
	When the method on node with path 'Objects/Server/GetMonitoredItems' is invoked and the result is stored in variable 'localTimeNode'