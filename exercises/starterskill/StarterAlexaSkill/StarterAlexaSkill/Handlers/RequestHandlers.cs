using StarterAlexaSkill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarterAlexaSkill.Handlers
{
    public class RequestHandlers
    {
        public static AlexaResponse LaunchRequestHandler(AlexaRequest request)
        {
            //Alexa, start {name of skill}
            //ALEXA: Welcome
            //ALEXA Reprompt: Please say Help if you need a list of commands

            var response = new AlexaResponse("Welcome.");
            response.Response.Card.Title = "Welcome";
            response.Response.Card.Content = "Please say Help if you need a list of options";

            response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of options.";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public static AlexaResponse IntentRequestHandler(AlexaRequest request)
        {
            AlexaResponse response = null;

            switch (request.Request.Intent.Name)
            {
                case "HelloWorldIntent":

                    if (request.Session.Attributes.LastIntentName == "HelloWorldIntent")
                    {
                        response = IntentHandlers.HelloAgainIntentHandler(request);
                    }
                    else
                    {
                        response = IntentHandlers.HelloWorldIntentHandler(request);
                    }
                    break;
                case "HelloNameIntent":
                    response = IntentHandlers.HelloNameIntentHandler(request);
                    break;
                case "FeelingIntent":
                    response = IntentHandlers.FeelingIntentHandler();
                    break;
                case "IntroductionIntent":
                    response = IntentHandlers.IntroductionIntentHandler();
                    break;
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = IntentHandlers.CancelOrStopIntentHandler();
                    break;
                case "AMAZON.HelpIntent":
                    response = IntentHandlers.HelpIntentHandler();
                    break;
                default:
                    response = IntentHandlers.DefaultIntentHandler(request);
                    break;
            }

            return response;
        }

        public static AlexaResponse SessionEndedRequestHandler(AlexaRequest request)
        {
            return null;
        }
    }
}