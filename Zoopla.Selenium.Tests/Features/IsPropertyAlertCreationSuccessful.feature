Feature: EmailAlerts
	In order to get property alerts for my desired property
	As a prospective Zoopla customer
	I want to regsister myself to Zoopla website and get property alerts

@registerForPropertyAlerts
Scenario: Get Email updates for your property
	Given I have registered on Zoopla and logged in	
	When I try to search property described in <testcase>
	Then I am able to register for email alerts with frequency of <alertfrequency>
	
	Examples: 
	| testcase         | description                                         |
	| AC01-EmailAlerts | Rented property costing £800 to £1000 pcm in London |


@updatePropertyAlert
Scenario: Update existing email alert
	Given I have registered on Zoopla and logged in	
	When I try to search property described in <testcase>
	Then I am able to register for email alerts with frequency of <alertfrequency>
	And I am able to update email update frequency to <alertfrequency>

	Examples: 
	| testcase         | description                                         | alertfrequency |
	| AC01-EmailAlerts | Rented property costing £800 to £1000 pcm in London |                |
