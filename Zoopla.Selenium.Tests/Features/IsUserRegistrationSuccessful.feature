Feature: RegisterUser
	In order to get property alerts for my desired property
	As a Zoopla customer
	I want to regsister myself to Zoopla website

@registerUserTest
Scenario: Register New User
	Given I am in need of a <typeof> property
	When I register myself on zoopla website
	Then I get <result> of registration

	Examples: 
	| testCase      | typeof  | result |
	| HappyPath     | Rented  | true   |
