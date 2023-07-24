Feature: AmazonPurchase
	Simple amazon purchase

@AmazonSimplePurchase
Scenario: Amzon purchase
	Given I open the search engine
	And I type in the search bar Amazon.de
	And I start a search website
	And I select first search element
	And I click first search element
	And I wait page ready
	And I check the site domain
	And I accept cookie
	And I click on laguage dropdown
	And I select english language
	And I save language chnges
	And I click on search input
	And I type in the search bar
	And I start a search product
	And I go to the first product page
	And I click on location selector
	And I click on country dropdown
	And I select united states option
	And I click save location button
	And I check current product ready to order	
	And I add the first product to basket
	And I close popup
	And I go to the shopping basket
	And I check the correctness of the added product