Feature: MainSearchAndResults
To verify the Main Search and Results Feature on HomePage

	Background:    
	Given I have navigated to the application
	Then I click Account link
	And  I click SignIn link
	Then I should see the Sign in to your account Page
	When I enter UserName and Password
     | UserName                         | Password  |
     | sartest@email.ghostinspector.com | Test@1234 |
	Then I click Signin button on Signin Page
	And  I click Account link on Home Page



    @smoke
    Scenario: 01_User_Can_Click_On_Search_Box_To_View_Popular_Searches
	Given I Verify User is logged on to his account
	When I  click on Searh box
	Then I should be able to view Popular Searches
	And I click on Close Search Results Box
	And  I click Account link on Home Page
	Then I Verify User is logged on to his account
	And I click logout


	@smoke
    Scenario: 02_User_Can_Click_On_Search_Box_To_View_Popular_Right_Now_Products
	Given I Verify User is logged on to his account
	When I  click on Searh box
	Then I should be able to view popular right now products
	And I click on Close Search Results Box	
	And  I click Account link on Home Page
	Then I Verify User is logged on to his account
	And I click logout
   

	@smoke
    Scenario: 03_User_Can_Click_On_Search_Box_and_Searh_for_a_Product
	Given I Verify User is logged on to his account
	When I  click on Searh box
	Then I search for a Product "saw"
	And I click on Search Icon
	Then I should be able to view "saw" on results Page 
	And  I click Account link on Home Page
	Then I Verify User is logged on to his account
	And I click logout

	@smoke
    Scenario: 04_User_Can_Click_On_Search_Box_and_Clear_Recent_Searches
	Given I Verify User is logged on to his account
	When I  click on Searh box
	Then I search for a Product "timber"
	And  I click on Search Icon
	Then I should be able to view "timber" on results Page
    Then I  click on Searh box
	And  I click on clear recent searches link
	And  I click Account link on Home Page
	Then I Verify User is logged on to his account
	And I click logout 