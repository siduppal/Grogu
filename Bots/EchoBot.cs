// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.10.3

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grogu.Bots
{
    public class EchoBot : TeamsActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var message = turnContext.Activity.RemoveMentionText(turnContext.Activity.Recipient.Id);

            var replyText = string.Empty;

            if (message.StartsWith("/details"))
            {
                var teamDetails = await TeamsInfo.GetTeamDetailsAsync(turnContext, turnContext.Activity.TeamsGetTeamInfo().Id, cancellationToken);
                replyText = $"Name = {teamDetails.Name}, ID = {teamDetails.Id}, MemberCount = {teamDetails.MemberCount}, ChannelCount = {teamDetails.ChannelCount}, AADGroupId = {teamDetails.AadGroupId}";
            }
            else if (message.StartsWith("/role"))
            {
                var senderRole = await TeamsInfo.GetMeetingParticipantAsync(turnContext);
                replyText = $"Your role is: {senderRole.Meeting.Role}";
            }
            else if (message.StartsWith("/bubble"))
            {
                Activity activity = MessageFactory.Text("This is a meeting signal test");
           
                activity.ChannelData = new TeamsChannelData
                {
                    Notification = new NotificationInfo()
                    {
                        AlertInMeeting = true,
                        ExternalResourceUrl = "https://teams.microsoft.com/l/bubble/8b279b54-c3f4-4012-a30a-7cbe1c9ff53a?url=https://08cf625d1ef3.ngrok.io/bubble.html&height=200&width=300&title=Bubble&completionBotId=4e506077-a319-4f3e-861f-5b2be2a31938"
                    }
                };
                await turnContext.SendActivityAsync(activity).ConfigureAwait(false);
            }
            else
            {
                replyText = $"Echo: {turnContext.Activity.Text}";
            }

            if (! string.IsNullOrEmpty(replyText))
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
            }

        }

        private static string GetEchoText(IActivity activity)
        {
           return new StringBuilder().AppendLine("Heard: \n").AppendLine(JsonConvert.SerializeObject(activity, Formatting.Indented)).ToString();
        }

        protected async override Task OnEventActivityAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnEventAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task<HealthCheckResponse> OnHealthCheckAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);

            return new HealthCheckResponse()
            {
                HealthResults = new HealthResults()
                {
                    Success = true
                }
            };
        }

        protected async override Task OnInstallationUpdateActivityAsync(ITurnContext<IInstallationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnInstallationUpdateAddAsync(ITurnContext<IInstallationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnInstallationUpdateRemoveAsync(ITurnContext<IInstallationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected override async Task<InvokeResponse> OnInvokeActivityAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);

            return new InvokeResponse()
            {
                Status = 200
            };
        }

        protected async override Task OnMessageReactionActivityAsync(ITurnContext<IMessageReactionActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnReactionsAddedAsync(IList<MessageReaction> messageReactions, ITurnContext<IMessageReactionActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnReactionsRemovedAsync(IList<MessageReaction> messageReactions, ITurnContext<IMessageReactionActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task OnSignInInvokeAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);
        }

        protected async override Task<MessagingExtensionResponse> OnTeamsAppBasedLinkQueryAsync(ITurnContext<IInvokeActivity> turnContext, AppBasedLinkQuery query, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text(GetEchoText(turnContext.Activity)), cancellationToken);

            return new MessagingExtensionResponse()
            {
                ComposeExtension = new MessagingExtensionResult()
                {
                    Text = "Worked"
                }
            };
        }

        protected override Task<InvokeResponse> OnTeamsCardActionInvokeAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        {
            return base.OnTeamsCardActionInvokeAsync(turnContext, cancellationToken);
        }

        protected override Task OnTeamsFileConsentAcceptAsync(ITurnContext<IInvokeActivity> turnContext, FileConsentCardResponse fileConsentCardResponse, CancellationToken cancellationToken)
        {
            return base.OnTeamsFileConsentAcceptAsync(turnContext, fileConsentCardResponse, cancellationToken);
        }

        protected override Task<InvokeResponse> OnTeamsFileConsentAsync(ITurnContext<IInvokeActivity> turnContext, FileConsentCardResponse fileConsentCardResponse, CancellationToken cancellationToken)
        {
            return base.OnTeamsFileConsentAsync(turnContext, fileConsentCardResponse, cancellationToken);
        }

        protected override Task OnTeamsFileConsentDeclineAsync(ITurnContext<IInvokeActivity> turnContext, FileConsentCardResponse fileConsentCardResponse, CancellationToken cancellationToken)
        {
            return base.OnTeamsFileConsentDeclineAsync(turnContext, fileConsentCardResponse, cancellationToken);
        }

        protected override Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionBotMessagePreviewEditAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionBotMessagePreviewEditAsync(turnContext, action, cancellationToken);
        }

        protected override Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionBotMessagePreviewSendAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionBotMessagePreviewSendAsync(turnContext, action, cancellationToken);
        }

        protected override Task OnTeamsMessagingExtensionCardButtonClickedAsync(ITurnContext<IInvokeActivity> turnContext, JObject cardData, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionCardButtonClickedAsync(turnContext, cardData, cancellationToken);
        }

        protected override Task<MessagingExtensionResponse> OnTeamsMessagingExtensionConfigurationQuerySettingUrlAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionQuery query, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionConfigurationQuerySettingUrlAsync(turnContext, query, cancellationToken);
        }

        protected override Task OnTeamsMessagingExtensionConfigurationSettingAsync(ITurnContext<IInvokeActivity> turnContext, JObject settings, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionConfigurationSettingAsync(turnContext, settings, cancellationToken);
        }

        protected override Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionFetchTaskAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionFetchTaskAsync(turnContext, action, cancellationToken);
        }

        protected override Task<MessagingExtensionResponse> OnTeamsMessagingExtensionQueryAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionQuery query, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionQueryAsync(turnContext, query, cancellationToken);
        }

        protected override Task<MessagingExtensionResponse> OnTeamsMessagingExtensionSelectItemAsync(ITurnContext<IInvokeActivity> turnContext, JObject query, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionSelectItemAsync(turnContext, query, cancellationToken);
        }

        protected override Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionSubmitActionAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionSubmitActionAsync(turnContext, action, cancellationToken);
        }

        protected override Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionSubmitActionDispatchAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            return base.OnTeamsMessagingExtensionSubmitActionDispatchAsync(turnContext, action, cancellationToken);
        }

        protected override Task OnTeamsO365ConnectorCardActionAsync(ITurnContext<IInvokeActivity> turnContext, O365ConnectorCardActionQuery query, CancellationToken cancellationToken)
        {
            return base.OnTeamsO365ConnectorCardActionAsync(turnContext, query, cancellationToken);
        }

        protected override Task OnTeamsSigninVerifyStateAsync(ITurnContext<IInvokeActivity> turnContext, CancellationToken cancellationToken)
        {
            return base.OnTeamsSigninVerifyStateAsync(turnContext, cancellationToken);
        }

        protected override Task<TaskModuleResponse> OnTeamsTaskModuleFetchAsync(ITurnContext<IInvokeActivity> turnContext, TaskModuleRequest taskModuleRequest, CancellationToken cancellationToken)
        {
            return base.OnTeamsTaskModuleFetchAsync(turnContext, taskModuleRequest, cancellationToken);
        }

        protected override Task<TaskModuleResponse> OnTeamsTaskModuleSubmitAsync(ITurnContext<IInvokeActivity> turnContext, TaskModuleRequest taskModuleRequest, CancellationToken cancellationToken)
        {
            return base.OnTeamsTaskModuleSubmitAsync(turnContext, taskModuleRequest, cancellationToken);
        }

      
        protected override Task OnTokenResponseEventAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            return base.OnTokenResponseEventAsync(turnContext, cancellationToken);
        }

        public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            return base.OnTurnAsync(turnContext, cancellationToken);
        }

        protected override Task OnTypingActivityAsync(ITurnContext<ITypingActivity> turnContext, CancellationToken cancellationToken)
        {
            return base.OnTypingActivityAsync(turnContext, cancellationToken);
        }

        protected override Task OnUnrecognizedActivityTypeAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            return base.OnUnrecognizedActivityTypeAsync(turnContext, cancellationToken);
        }
    }
}
