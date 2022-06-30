using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using System.Net; 
using TechTalk.SpecFlow;
using System.IO;

namespace APITestingProject.CommonMethodObjects
{    [Binding]
    public class EmployeeObjects
    {
        public string baseURL = "https://dummy.restapiexample.com/api";
        public RestResponse response;          
        public dynamic id;

        public void GetRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/v1/employees", Method.Get);
            response = client.Execute(request);
        }
        
        public void VerifyGetResult()

        {
            dynamic deserializerAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var value = deserializerAPI.data[0].employee_name;
            Assert.AreEqual("Tiger Nixon", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void PostRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/v1/create", Method.Post);
            // request.AddBody(("{\"id\": \"1\", \"employee_name\": \"Pooja\", \"employee_salary\": \"320800\", \"employee_age\": \"22\"}")); 
            request.AddBody("{\"id\": \"1\", \"employee_name\": \"Pooja\", \"employee_salary\": \"320800\", \"employee_age\": \"22\"}");
            response = client.Execute(request);
        }
        public void VerifyPostResult()
        {
            dynamic deserializerAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var value = deserializerAPI.data.employee_name;
            Assert.AreEqual("Pooja", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //id = deserializerAPI.data.id.Value;
            CreateTextFile();
        }
        public void CreateTextFile()
        {
            string filepath = (@"C:\Users\mindtreejanedge232\Desktop\APITestingProject\APITestingProject\Id.txt");
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                //create new file
                using (FileStream fs = File.Create(filepath))
                {
                    //add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    Byte[] author = new UTF8Encoding(true).GetBytes("Automation");
                    fs.Write(title, 0, author.Length);

                }
                //create a text
                using (StreamWriter sq = File.CreateText(filepath))
                {
                    sq.WriteLine(id);
                }
            }
            catch
            {

            }
        }

        public void DeleteRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/v1/delete/2" + id, Method.Delete);
            response = client.Execute(request);
        }

        public void verifyDeleteRequest()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}


    

