Feature: NodeRead - Node exists

Background:
	Given the endpoint '$(demoEndpoint)'
	And the credentials as username '$(username)' and password '$(password)'

Scenario: Node exits by id
	Then a node with id 'ns=0;i=17634' exists

Scenario: Node exists by path
	Then a node with path 'Objects/Server/LocalTime' exists

Scenario: Node does not exist by id
	Then a node with id 'ns=0;i=0' does not exist

Scenario: Node does not exist by path
	Then a node with path 'Objects/Server/Humbug' does not exist