Feature: PropertySearch
	In order to get property alerts for my desired property
	As a prospective Zoopla customer
	I want to search property as per my requirement

@searchProperty
Scenario: Get Email updates for your property
	Given I have visited Zoopla home page and selected option <searchselection>
	When I try to search property described in <testcase>
	
	# Please refer to TestData.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testCase        |description									 | 
	| AC01-PropSearch | Custom property "NN1 2HS"					 | 
	| AC02-PropSearch | Houses with attached garage					 | 
	| AC03-PropSearch | All properties within 15 minutes of "SE1 2LH"| 
	
