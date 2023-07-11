Feature: AmazonPurchase
	Simple amazon purchase

@mytag
Scenario: Amzon purchase
	Given the google page https://www.google.com
	And i search Amazon.de
	And go to the page
	And checking the site domain
	And accept ckookie
	And change the language to English	
	And find product mouse
	And chnge delivery location
	And add first product to cart
	And close popup
	And checking the number of added products
	#When the two numbers are added
	#Then the result should be 120