using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("demo")]
        public dynamic AlexaDemo(dynamic request)
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Hello, World."
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Hello World",
                        content = "Hello world!"
                    },
                    shouldEndSession = true
                }
            };
        }
    }
}
