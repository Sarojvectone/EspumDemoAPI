using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EspumDemoAPI.Controllers
{
    public class TestAPIMethodController : ApiController
    {
        public static class ErrorMessage
        {
            public static Dictionary<int, string> Errors = new Dictionary<int, string>()
                                                {
                                                    {1001,"Success"},
                                                    {1002, "Failure"},
                                                };
        }
        public class RequestTokenOutput
        {
            public string AccessToken { get; set; }
            public string Message { get; set; }
            public int Code { get; set; }
        }
        public class RequestTokenInput
        {
            public string SecretId { get; set; }
            public string SecretPassword { get; set; }
        }
        public bool CheckUser(string username, string password)
        {
            // for demo purpose, I am simply checking username and password with predefined strings. you can have your own logic as per requirement.
            //if (username == "unifiedringapp" && password == "abc123")
            string validusername = "Test";
            string validPassword = "1234";
            if (username == validusername && password == validPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        ////https://localhost:44392/api/TestAPIMethod

        //Input :- 
        //{
        //"SecretId": "Test",
        //"SecretPassword":"1234"
        //}

        //Output:-
        //{"AccessToken":"12344566","Message":"Success","Code":1001}
        [HttpPost]
        public async Task<HttpResponseMessage> Post(RequestTokenInput req)
        {
            List<RequestTokenOutput> OutputList = new List<RequestTokenOutput>();
            RequestTokenOutput objRequestTokenOutput = new RequestTokenOutput();
            if (CheckUser(req.SecretId, req.SecretPassword))
            {
                string accesstoken = "12344566";
                objRequestTokenOutput.AccessToken = accesstoken;
                objRequestTokenOutput.Code = 1001;
                objRequestTokenOutput.Message = ErrorMessage.Errors[1001];
                return Request.CreateResponse(HttpStatusCode.OK, objRequestTokenOutput);
            }
            else
            {
                objRequestTokenOutput.AccessToken = "";
                objRequestTokenOutput.Code = 1002;
                objRequestTokenOutput.Message = ErrorMessage.Errors[1002];
                return Request.CreateResponse(HttpStatusCode.OK, objRequestTokenOutput);
            }
        }

    }
}
