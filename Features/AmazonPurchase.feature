Feature: AmazonPurchase
	Simple amazon purchase

@mytag
Scenario: Amzon purchase
	Given Google I open the google page
	And Google I search Amazon.de
	And Google i open the page from search
	And Amazon I check the site domain
	And Amazon I accept cookie
	And Amazon I change the language to English
	And Amazon I find some product 
	And Amazon I go to the first product page
	And Amazon I change delivery location
	And Amazon I check current product ready to order	
	And Amazon I close popup
	And Amazon i go to the shopping basket
	#And Amazon I check the number of added products
	#When the two numbers are added
	#Then the result should be 120