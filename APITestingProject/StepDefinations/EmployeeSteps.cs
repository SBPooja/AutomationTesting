using APITestingProject.CommonMethodObjects;
using System;
using TechTalk.SpecFlow;

namespace APITestingProject.StepDefinations
{
    [Binding]
    public class EmployeeSteps
    {
        EmployeeObjects apiobj = new EmployeeObjects();
        [When(@": Employee sends GET request")]
        public void WhenEmployeeSendsGETRequest()
        {
            apiobj.GetRequest();
        }
        
        [When(@": Employess sends POST request")]
        public void WhenEmployessSendsPOSTRequest()
        {
            apiobj.PostRequest();
        }
        
        [When(@": Employess sends DELETE request")]
        public void WhenEmployessSendsDELETERequest()
        {
            apiobj.DeleteRequest();  
        }
        
        [Then(@": Employess should able to verify result successfully")]
        public void ThenEmployessShouldAbleToVerifyResultSuccessfully()
        {
            apiobj.VerifyGetResult();
        }

        [Then(@": Employees should  able to verify Id and see success")]
        public void ThenEmployeesShouldAbleToVerifyIdAndSeeSuccess()
        {
            apiobj.VerifyPostResult();
        }
                
        
        [Then(@": Employess should abale to the details and see success")]
        public void ThenEmployessShouldAbaleToTheDetailsAndSeeSuccess()
        {
            apiobj.verifyDeleteRequest();
        }
    }
}
