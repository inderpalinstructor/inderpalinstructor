Feature: FlightSearch

A short summary of the feature

@tag1
Scenario: Verify search criteria on the flight listing page
Given user enters flight search criteria on the flight landing page
| From             | To          | DepartureDate | ReturDate | Travellers |
| New Delhi, India | Pune, India | 2M            |           | 1-1        |
When user navigates to flight listing page
Then user verifies search criteria on the flight listing page
