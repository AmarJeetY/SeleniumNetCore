Feature: PropertySearch
	In order to get property alerts for my desired property
	As a prospective Zoopla customer
	I want to search property as per my requirement

@searchProperty
Scenario: Get Email updates for your property
	Given I am on Zoopla home page
	When I try to search property described in <testcase>
	Then I get results from my property search
	
	# Please refer to TestData.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase        | description									 | searchselection |
	| AC01-PropSearch | Custom property search in area "NN1 2HS"     | ToRent          |
	| AC02-PropSearch | Houses with attached garage					 | ToRent          |
	| AC03-PropSearch | All properties within 15 minutes of "SE1 2LH"| ToRent    	   |
	
