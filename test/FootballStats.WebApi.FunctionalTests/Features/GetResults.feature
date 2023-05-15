Feature: GetResults
	Simple calculator for adding two numbers

@mytag
Scenario: Get latest results
	When a http GET request is made to the football stats api
	Then the response code should be 200
	And the response should contain 10 games
	