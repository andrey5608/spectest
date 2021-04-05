Feature: Find nearby restaurants
	In order to get information about some public places
	As a customer
	I want to find nearby restaurants

Background:
	Given I opened the main page

@critical
Scenario Outline: Find nearby restaurants by special keywords
	Given I set up 1 restaurants near my current place
	When I write to the field Query text <Text>
	Then then Results contains more than 0 results

	Examples:
		| Text               |
		| nearby restaurants |
		| restaurants        |
		| restaurant         |

@high
Scenario: Find nearby restaurants by clicking on "Restaurants" button
	Given I set up 1 restaurants near my current place
	When I pressed to Restaurants button
	Then then Results contains more than 0 results

@medium
Scenario: Find nearby restaurants if there is no restaurant nearby
	Given I set up 0 restaurants near my current place
	When I write to the field Query text restaurants
	Then then Results contains more than 0 results