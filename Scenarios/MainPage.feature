Feature: MainPage
	In order to get main information of banking services
	As a client
	I want to get main page of Raiffeisen.ru

	#TODO add preconditions

Scenario: Get carousel slides
	When I open the main page
	Then the carousel contains few slides
