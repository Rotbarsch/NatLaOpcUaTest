Feature: My first API test

Scenario: Basic functionality
	When the value '$(stage)' is stored in variable 's'
	Then the value of variable 's' is not null
	And the value of variable 's' equals 'Dev'
	And the value of variable 's' does not equal 'PROD'
