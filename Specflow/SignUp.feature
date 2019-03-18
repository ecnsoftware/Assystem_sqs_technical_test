Feature: SignUp
	
	#Use the Evironment Key in App.config to switch between test and prod.
	#Note tha if the user is already registered, the system will attempt to sign them in instead.
Scenario: Create a new account
Given I am not logged in
When I complete the sign up form:
| UserName     | Email         | Password     |
| EdwinNwosisi | edwin@sqs.com | Password123! |
Then I am logged in
And my username is displayed 


