﻿Feature: AmazonPurchase
	Simple amazon purchase

@mytag
Scenario: Amzon purchase
	Given Google I open the google page
	And Google I search
	And Google i open the page from search
	And Amazon I check the site domain
	And Amazon I accept ckookie
	And Amazon I change the language to English
	And Amazon I find product
	And Amazon I change delivery location
	And Amazon I add the first product to cart
	And Amazon I close popup
	And Amazon I check the number of added products
	#When the two numbers are added
	#Then the result should be 120