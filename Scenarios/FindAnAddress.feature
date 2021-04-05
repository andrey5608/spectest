Feature: Find an address in Google Maps
	In order to get main information about some place on the map
	As a customer
	I want to find an address 

Background:
	Given I opened the main page

@critical
Scenario: Find an address by entering full itself
	When I write to the field Query text Saarbrücker Str. 38, 10405 Berlin, Germany
	Then then the field Street is set to Saarbrücker Str. 38

@critical
Scenario: Find an address by place name
	When I write to the field Query text wooga berlin
	Then then the field Street is set to Wooga

@critical
Scenario: Find an address by coordinates
	When I write to the field Query text 52.5288883184481, 13.416143258621464
	Then then the field Address is set to Berliner Innenstadt, 10405 Berlin, Germany

@high
Scenario: Find an address by full address with mistake
	When I write to the field Query text Saarbrücker Str. 38, 10405 Berlinl, Germany
	Then then the field Street is set to Saarbrücker Str. 38

@high
Scenario: Find an address by full address by incomplete address
	When I write to the field Query text berlin Saarbrücker 38
	Then then the field Street is set to Saarbrücker Str. 38

@high
Scenario Outline: Find non-exists addresses
	When I write to the field Query text <Query>
	Then then the field Label is set to <Error text>

	Examples:
		| Query                            | Error text                                              |
		| ' '                              | Google Maps can't find                                  |
		| magna unknown address Saarker 38 | Google Maps can't find magna unknown address Saarker 38 |

@high
Scenario: Find non-exists address by putting long string
	When I write to the field Query query from file 'TestData/longText.txt'
	Then then the field Label is starting with Google Maps can't find