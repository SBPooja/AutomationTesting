Feature: Employee
	Check API's are working

@mytag
Scenario: Get List of employees
    When : Employee sends GET request
	Then : Employess should able to verify result successfully 

Scenario: POST Employees
     When : Employess sends POST request
	 Then : Employees should  able to verify Id and see success 

Scenario: DELETE Employess
     When : Employess sends DELETE request
	 Then : Employess should abale to the details and see success