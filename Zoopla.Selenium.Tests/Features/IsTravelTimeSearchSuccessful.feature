Feature: IsTravelTimeSearchSuccessful
	In order to get property alerts for my desired property
	As a Zoopla user
	I want to search Zoopla website based on travel time from specified postcode

@searchPropertyBasedOnTimeToTravel
Scenario: Property Search Based on Travel Time	
	Given I goto travel search page
	When I try to search property based on travel time described in <testcase>
		
	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase         | description                                          | myprofile            |
	| AC01-TravelTime  | All properties within 15 minutes drive of "SE1 2LH"  | I am looking to rent |


