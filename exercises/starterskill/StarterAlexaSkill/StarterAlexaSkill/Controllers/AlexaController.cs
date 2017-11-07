using StarterAlexaSkill.Models;
using StarterAlexaSkill.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarterAlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa")]
        public AlexaResponse AlexaStarterSkill(AlexaRequest request)
        {
            //if (request.Session.Application.ApplicationId != ApplicationId)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            //var totalSeconds = (DateTime.UtcNow - request.Request.Timestamp).TotalSeconds;
            //if (totalSeconds <= 0 || totalSeconds > 150)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            AlexaResponse response = null;

            if (request != null)
            {
                switch (request.Request.Type)
                {
                    case "LaunchRequest":
                        response = RequestHandlers.LaunchRequestHandler(request);
                        break;
                    case "IntentRequest":
                        response = RequestHandlers.IntentRequestHandler(request);
                        break;
                    case "SessionEndedRequest":
                        response = RequestHandlers.SessionEndedRequestHandler(request);
                        break;
                }
            }

            return response;

        }
    }
}
