Feature: PropertySearch
	In order to get property alerts for my desired property
	As a Zoopla website user
	I want to search property as per my requirement

@searchProperty
Scenario: Get Email updates for your property
	Given I am on Zoopla home page
	When I try to search property described in <testcase>	
	
	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase        | description									 | 
	| AC01-PropSearch | Custom property search in area "NN1 2HS"     | 
	| AC02-PropSearch | Houses with attached garage in London    	 | 