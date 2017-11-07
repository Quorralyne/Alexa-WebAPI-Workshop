using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSMLAlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("ssmldemo")]
        public dynamic AlexaSSMLDemo(dynamic request)
        {
            return new
            {
                version = "1.0",
                response = new
                {
                    shouldEndSession = true,
                    outputSpeech = new
                    {
                        type = "SSML",
                        ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> Hello Counselor. </speak>"
                    }
                }
            };
        }

        [HttpPost, Route("german")]
        public dynamic AlexaGermanLanguageDemo(dynamic request)
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
                        text = "Hallo du dumme Person. Hast du versucht, mich aus- und wieder einzuschalten?"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Hallo in German",
                        content = "Hallo werlt!"
                    },
                    shouldEndSession = true
                }
            };
        }
    }
}
