﻿using System;
using MessageBird.Objects;
using MessageBird.Resources;
using MessageBird.Net;

namespace MessageBird
{
    public class Client
    {
        private IRestClient restClient;
        private Client(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public static Client Create(IRestClient restClient)
        {
            return new Client(restClient);
        }

        public static Client CreateDefault(string accessKey)
        {
            return new Client(new RestClient(accessKey));
        }

        public Message SendMessage(string originator, string body, long[] msisdns, MessageOptionalArguments optionalArguments = null)
        {
            Recipients recipients = new Recipients(msisdns);
            Message message = new Message(originator, body, recipients, optionalArguments);

            Messages messages = new Messages(message);
            Messages result = (Messages)restClient.Create(messages);

            return result.Message;
        }

        public Message ViewMessage(string id)
        {
            Messages messageToView = new Messages(id);
            Messages result = (Messages)restClient.Retrieve(messageToView);

            return result.Message;
        }

        public VoiceMessage SendVoiceMessage(string body, long[] msisdns, VoiceMessageOptionalArguments optionalArguments = null)
        {
            Recipients recipients = new Recipients(msisdns);
            VoiceMessage voiceMessage = new VoiceMessage(body, recipients, optionalArguments);

            VoiceMessages voiceMessages = new VoiceMessages(voiceMessage);
            VoiceMessages result = (VoiceMessages)restClient.Create(voiceMessages);

            return result.VoiceMessage;
        }

        public VoiceMessage ViewVoiceMessage(string id)
        {
            VoiceMessages voiceMessageToView = new VoiceMessages(id);
            VoiceMessages result = (VoiceMessages)restClient.Retrieve(voiceMessageToView);

            return result.VoiceMessage;
        }

    }
}