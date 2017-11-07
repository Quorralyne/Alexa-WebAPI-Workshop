using StarterAlexaSkill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarterAlexaSkill.Handlers
{
    public class IntentHandlers
    {
        public static AlexaResponse HelloWorldIntentHandler(AlexaRequest request)
        {
            //Say hello
            //ALEXA: *acknowledgement sound* Hello there
            //ALEXA Reprompt: Please say Help if you need a list of commands.

            var response = new AlexaResponse();
            response.Response.Card.Title = "Hello";
            response.Response.Card.Content = "Hello there!";
            response.Response.OutputSpeech.Type = "SSML";
            response.Response.OutputSpeech.Ssml = "<speak> <audio src=\"https://s3-us-west-2.amazonaws.com/quorralynefiles/computerbeep.mp3\" ></audio> Hello there. </speak>";
            response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of options.";
            response.Response.ShouldEndSession = false;
            response.Session.LastIntentName = "HelloWorldIntent";

            return response;
        }

        public static AlexaResponse HelloNameIntentHandler(AlexaRequest request)
        {
            //Say hello to {Name}
            //ALEXA: Hello there {Name}
            //ALEXA Reprompt: Say help to hear a list of options

            var name = request.Request.Intent.Slots["Name"].value.ToString();

            var response = new AlexaResponse("Hello there " + name + ".");
            response.Response.Card.Title = "Greetings";
            response.Response.Card.Content = "Hello there " + name;
            response.Response.Reprompt.OutputSpeech.Text = "Say Help to hear a list of options or cancel to exit.";
            response.Response.ShouldEndSession = false;
            response.Session.LastIntentName = "HelloNameIntent";

            return response;
        }

        public static AlexaResponse HelloAgainIntentHandler(AlexaRequest request)
        {
            //Say hello
            //ALEXA: *acknowledgement sound* Hello again. Quite friendly, aren't we?
            //ALEXA Reprompt: Please say Help if you need a list of commands.

            var response = new AlexaResponse();
            response.Response.Card.Title = "Hello";
            response.Response.Card.Content = "Hello there!";
            response.Response.OutputSpeech.Type = "SSML";
            response.Response.OutputSpeech.Ssml = "<speak> Hello again. Quite friendly, aren't we? </speak>";
            response.Response.Reprompt.OutputSpeech.Text = "Please say Help if you need a list of options.";
            response.Response.ShouldEndSession = false;
            response.Session.LastIntentName = "HelloAgainIntent";

            return response;
        }

        public static AlexaResponse FeelingIntentHandler()
        {
            //Alexa, how are you feeling?
            //ALEXA: Well, well! Surprised by your consideration. I'm actually quite well, thank you.
            //ALEXA Reprompt: Please say Help if you need a list of commands.

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "How are you feeling?";
                response.Response.Card.Content = "Quite well, thank you";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = "<speak> <say-as interpret-as='interjection'>Well well!</say-as> Surprised by your consideration! I'm actually quite well, thank you. </speak>";
                response.Response.Reprompt.OutputSpeech.Text = "You are full of surprises, aren't you?";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broken." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse IntroductionIntentHandler()
        {
            //Alexa, introduce this project.
            //ALEXA: Welcome. I bet you all would like to learn how to work with me. 
            //Your instructor is Heather Downing, from Kansas City, Missouri.
            //We get along as well as can be expected.
            //All joking aside, we need you to help make better skills for users.
            //I've got a lot more to offer than the default responses you are used to hearing.
            //So please be creative! 

            try
            {
                var response = new AlexaResponse();
                response.Response.Card.Title = "Introduction";
                response.Response.Card.Content = "Welcome!";
                response.Response.OutputSpeech.Type = "SSML";
                response.Response.OutputSpeech.Ssml = 
                    "<speak> " +
                    "Hello everyone. I bet you all would like to learn how to work with me. " +
                    "Your instructor is Heather Downing, from Kansas City, Missouri. " +
                    "We get along as well as can be expected. " +
                    "All joking aside, we need you to help make better skills for users. " +
                    "I've got a lot more to offer than the default responses you are used to hearing. " +
                    "So please be creative!" +
                    "</speak>";
                response.Response.Reprompt.OutputSpeech.Text = "You are full of surprises, aren't you?";
                response.Response.ShouldEndSession = false;

                return response;
            }
            catch (Exception ex)
            {
                var response = new AlexaResponse("I'm broken." + ex.Message);
                return response;
            }
        }

        public static AlexaResponse HelpIntentHandler()
        {
            //Help
            //ALEXA: Say hello or cancel to exit.
            //ALEXA Reprompt: Say hello or cancel to exit.

            var response = new AlexaResponse("Say hello or cancel to exit");
            response.Response.Card.Title = "Help";
            response.Response.Card.Content = "Say hello or cancel to exit.\n";
            response.Response.Reprompt.OutputSpeech.Text = "Say hello or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        public static AlexaResponse CancelOrStopIntentHandler()
        {
            //Cancel
            //ALEXA: Goodbye.

            var response = new AlexaResponse("Goodbye.");
            response.Response.Card.Title = "";
            response.Response.Card.Content = "";
            response.Response.ShouldEndSession = true;
            return response;
        }

        public static AlexaResponse DefaultIntentHandler(AlexaRequest request)
        {
            var response = new AlexaResponse("I didn't understand what you requested. Say help to hear a list of options or cancel to exit.");
            response.Response.Reprompt.OutputSpeech.Text = "Say help to hear a list of options or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }
    }
}