Feature: Smoke
	Basic functionality on the site

Background:
	Given I am on the 'Home' page

@High
Scenario: Search on the site through the header
	Given I click on Search icon in top header menu
	When I enter 'Ukraine' into the 'Search' field on the 'Search' form
	And I click 'Find' button on the 'Search' form
	Then Url equals to 'https://www.epam.com/search?q=Ukraine'

@Medium
Scenario: Availability of links in the footer
	When I scroll to the bottom of the page
	Then I see next links
		| linkName                 | linkHref                     |
		| INVESTORS                | /about/investors             |
		| OPEN SOURCE              | /open-source                 |
		| PRIVACY POLICY           | /privacy-policy              |
		| COOKIE POLICY            | /cookie-policy               |
		| APPLICANT PRIVACY NOTICE | /applicant-privacy-notice    |
		| WEB ACCESSIBILITY        | /web-accessibility-statement |