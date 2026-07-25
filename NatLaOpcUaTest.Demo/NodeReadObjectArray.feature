Feature: NodeRead - Array of Object

Note: Due to the way the OPC/UA library works, and JsonSerialization works, all property names are expected to be CamelCase instead of whatever 
is defined server-side.

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Connect and read node by id
	When the value of node with id 'ns=2;s=CTT.Static.AllProfiles.Array.ExtensionObjectArray' is stored in variable 'nodeValue'
	When the length of collection variable 'nodeValue' is stored in variable 'nodeValueLength'
	Then the value of variable 'nodeValueLength' equals '5'

	When each element of collection in variable 'nodeValue' where the value of JSONPath '$.X' equals '1' is stored in variable 'xItems'
	And each element of collection in variable 'nodeValue' where the value of JSONPath '$.Value' equals '2' is stored in variable 'vItems'
	And the length of collection variable 'xItems' is stored in variable 'xCount'
	And the length of collection variable 'vItems' is stored in variable 'vCount'

	Then the value of variable 'xCount' equals '5'
	And the value of variable 'vCount' equals '5'


Scenario: Connect and read node by path
	When the value of node with path '/Objects/Demo/Array/ExtensionObjectArray' is stored in variable 'nodeValue'
	When the length of collection variable 'nodeValue' is stored in variable 'nodeValueLength'
	Then the value of variable 'nodeValueLength' equals '5'

	When each element of collection in variable 'nodeValue' where the value of JSONPath '$.X' equals '1' is stored in variable 'xItems'
	And each element of collection in variable 'nodeValue' where the value of JSONPath '$.Value' equals '2' is stored in variable 'vItems'
	And the length of collection variable 'xItems' is stored in variable 'xCount'
	And the length of collection variable 'vItems' is stored in variable 'vCount'

	Then the value of variable 'xCount' equals '5'
	And the value of variable 'vCount' equals '5'
	

