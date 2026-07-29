Feature: NodeRead - Node attributes

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Node attributes by id
	When the node with id 'ns=0;i=17634' is stored in variable 'localTimeNode'

	And the value of JSONPath '$.BrowseName' in variable 'localTimeNode' is stored in variable 'browseName'
	And the value of JSONPath '$.Description' in variable 'localTimeNode' is stored in variable 'description'
	And the value of JSONPath '$.DisplayName' in variable 'localTimeNode' is stored in variable 'displayName'
	And the value of JSONPath '$.NodeClass' in variable 'localTimeNode' is stored in variable 'nodeClass'
	And the value of JSONPath '$.NodeId' in variable 'localTimeNode' is stored in variable 'nodeId'
	And the value of JSONPath '$.TypeId' in variable 'localTimeNode' is stored in variable 'typeId'
	And the value of JSONPath '$.StatusCode' in variable 'localTimeNode' is stored in variable 'statusCode'

	Then the value of variable 'browseName' equals 'LocalTime'
	And the value of variable 'description' is null
	And the value of variable 'displayName' equals 'LocalTime'
	And the value of variable 'nodeClass' equals 'Variable'
	And the value of variable 'nodeId' equals 'ns=0;i=17634'
	And the value of variable 'typeId' equals 'ns=0;i=267'
	And the value of variable 'statusCode' equals 'Good'

Scenario: Node attributes by path
	When the node with path 'Objects/Server/LocalTime' is stored in variable 'localTimeNode'

	And the value of JSONPath '$.BrowseName' in variable 'localTimeNode' is stored in variable 'browseName'
	And the value of JSONPath '$.Description' in variable 'localTimeNode' is stored in variable 'description'
	And the value of JSONPath '$.DisplayName' in variable 'localTimeNode' is stored in variable 'displayName'
	And the value of JSONPath '$.NodeClass' in variable 'localTimeNode' is stored in variable 'nodeClass'
	And the value of JSONPath '$.NodeId' in variable 'localTimeNode' is stored in variable 'nodeId'
	And the value of JSONPath '$.TypeId' in variable 'localTimeNode' is stored in variable 'typeId'
	And the value of JSONPath '$.StatusCode' in variable 'localTimeNode' is stored in variable 'statusCode'

	Then the value of variable 'browseName' equals 'LocalTime'
	And the value of variable 'description' is null
	And the value of variable 'displayName' equals 'LocalTime'
	And the value of variable 'nodeClass' equals 'Variable'
	And the value of variable 'nodeId' equals 'ns=0;i=17634'
	And the value of variable 'typeId' equals 'ns=0;i=267'
	And the value of variable 'statusCode' equals 'Good'