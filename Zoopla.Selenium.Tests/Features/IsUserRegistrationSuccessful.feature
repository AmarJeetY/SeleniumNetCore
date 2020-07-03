Feature: UserRegistration
	In order to get property alerts for my desired property
	As a prospective Zoopla customer
	I want to regsister myself to Zoopla website

@registerUserTest
Scenario: RegisterOnWebsite
	Given I have registered on Zoopla and logged in		
	Then I get <result> of registration