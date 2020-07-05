Feature: EmailAlerts
	In order to get property alerts for my desired property
	As a prospective Zoopla customer
	I want to regsister myself to Zoopla website and get property alerts

@registerForPropertyAlert
Scenario: Get Email updates for your property
	Given I have registered on Zoopla with <myprofile> and logged in	
	When I try to search property described in <testcase>
	Then I am able to register for email alerts with frequency of <alertfrequency>
	
	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase         | description                                        | alertfrequency | myprofile            |
	| AC01-EmailAlerts | Rented property priced £800 to £1000 pcm in London | Daily          | I am looking to rent |


@registerAndUpdatePropertyAlert
Scenario: Update existing email alert
	Given I have registered on Zoopla with <myprofile> and logged in		
	When I try to search property described in <testcase>
	Then I am able to register for email alerts with frequency of <alertfrequency>
	And I am able to update <alertfrequency> to new email frequency of <changetoalertfrequency>

	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase         | description                                        | alertfrequency | changetoalertfrequency |myprofile            |
	| AC01-EmailAlerts | Rented property priced £800 to £1000 pcm in London | Weekly         | None                   |I am looking to rent |
