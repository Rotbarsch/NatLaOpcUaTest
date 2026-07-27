Feature: NodeRead - Node children

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Get node children by id
	When the children of node with id 'ns=0;i=2253' are stored in variable 'children'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Method' is stored in variable 'methods'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Variable' is stored in variable 'variables'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Object' is stored in variable 'objects'
	And each element of collection in variable 'children' where the value of JSONPath '$.StatusCode' does not equal 'Good' is stored in variable 'badNodes'
	
	And the length of collection variable 'methods' is stored in variable 'methodCount'
	And the length of collection variable 'variables' is stored in variable 'variableCount'
	And the length of collection variable 'objects' is stored in variable 'objectCount'
	And the length of collection variable 'badNodes' is stored in variable 'badNodeCount'

	Then the value of variable 'methodCount' equals '3'
	And the value of variable 'variableCount' equals '8'
	And the value of variable 'objectCount' equals '19'
	And the value of variable 'badNodeCount' equals '1'

Scenario: Get node children by path
	When the children of node with path 'Objects/Server' are stored in variable 'children'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Method' is stored in variable 'methods'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Variable' is stored in variable 'variables'
	And each element of collection in variable 'children' where the value of JSONPath '$.NodeClass' equals 'Object' is stored in variable 'objects'
	And each element of collection in variable 'children' where the value of JSONPath '$.StatusCode' does not equal 'Good' is stored in variable 'badNodes'
	
	And the length of collection variable 'methods' is stored in variable 'methodCount'
	And the length of collection variable 'variables' is stored in variable 'variableCount'
	And the length of collection variable 'objects' is stored in variable 'objectCount'
	And the length of collection variable 'badNodes' is stored in variable 'badNodeCount'

	Then the value of variable 'methodCount' equals '3'
	And the value of variable 'variableCount' equals '8'
	And the value of variable 'objectCount' equals '19'
	And the value of variable 'badNodeCount' equals '1'
