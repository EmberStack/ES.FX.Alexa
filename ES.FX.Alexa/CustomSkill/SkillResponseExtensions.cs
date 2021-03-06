﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ES.FX.Alexa.CustomSkill.AudioPlayer;
using ES.FX.Alexa.CustomSkill.Dialog;
using ES.FX.Alexa.CustomSkill.Display;
using ES.FX.Alexa.CustomSkill.VideoApp;

namespace ES.FX.Alexa.CustomSkill
{
    public static class SkillResponseExtensions
    {
        internal static SsmlOutputSpeech ToSsmlSpeech(this string speech)
        {
            var ssml = string.IsNullOrWhiteSpace(speech) ? string.Empty : speech;
            if (ssml.StartsWith("<speak>") && ssml.EndsWith("</speak>"))
                ssml = ssml.Substring(7, ssml.Length - 8).Trim();
            return new SsmlOutputSpeech
            {
                Ssml = $"<speak>{ssml}</speak>"
            };
        }

        public static ResponseBody Speak(this ResponseBody response, StringBuilder speechBuilder)
        {
            response.Speak(speechBuilder.ToString());
            return response;
        }

        public static SkillResponse Speak(this SkillResponse skillResponse, StringBuilder speechBuilder)
        {
            skillResponse.Response.Speak(speechBuilder);
            return skillResponse;
        }


        public static ResponseBody Speak(this ResponseBody response, string speech)
        {
            return response.Speak(speech.ToSsmlSpeech());
        }

        public static SkillResponse Speak(this SkillResponse skillResponse, string speech)
        {
            skillResponse.Response.Speak(speech);
            return skillResponse;
        }


        public static ResponseBody Speak(this ResponseBody response, OutputSpeech speech)
        {
            response.OutputSpeech = speech;
            return response;
        }

        public static SkillResponse Speak(this SkillResponse skillResponse, OutputSpeech speech)
        {
            skillResponse.Response.Speak(speech);
            return skillResponse;
        }


        public static ResponseBody Reprompt(this ResponseBody response, string speech)
        {
            return response.Reprompt(speech.ToSsmlSpeech());
        }

        public static SkillResponse Reprompt(this SkillResponse skillResponse, string speech)
        {
            skillResponse.Response.Reprompt(speech);
            return skillResponse;
        }


        public static ResponseBody Reprompt(this ResponseBody response, OutputSpeech speech)
        {
            response.Reprompt = new Reprompt
            {
                OutputSpeech = speech
            };
            response.ShouldEndSession = false;
            return response;
        }

        public static SkillResponse Reprompt(this SkillResponse skillResponse, OutputSpeech speech)
        {
            skillResponse.Response.Reprompt(speech);
            return skillResponse;
        }


        public static ResponseBody AddDirective<TDirective>(this ResponseBody response,
            Action<TDirective> configure = null) where TDirective : Directive, new()
        {
            var directive = new TDirective();
            configure?.Invoke(directive);
            response.Directives.Add(directive);
            return response;
        }

        public static SkillResponse AddDirective<TDirective>(this SkillResponse skillResponse,
            Action<TDirective> configure = null) where TDirective : Directive, new()
        {
            skillResponse.Response.AddDirective<TDirective>();
            return skillResponse;
        }


        public static ResponseBody AddDirective(this ResponseBody response, Directive directive)
        {
            response.Directives.Add(directive);
            return response;
        }

        public static SkillResponse AddDirective(this SkillResponse skillResponse, Directive directive)
        {
            skillResponse.Response.AddDirective(directive);
            return skillResponse;
        }


        public static ResponseBody ShouldEndSession(this ResponseBody response, bool endSession)
        {
            response.ShouldEndSession = endSession;
            return response;
        }

        public static SkillResponse ShouldEndSession(this SkillResponse skillResponse, bool endSession)
        {
            skillResponse.Response.ShouldEndSession(endSession);
            return skillResponse;
        }


        public static ResponseBody AddAudioPlayerPlayDirective(this ResponseBody response, PlayBehavior behavior)
        {
            return response.AddDirective<AudioPlayerPlayDirective>(
                directive => directive.PlayBehavior = behavior);
        }

        public static SkillResponse AddAudioPlayerPlayDirective(this SkillResponse skillResponse, PlayBehavior behavior)
        {
            skillResponse.Response.AddAudioPlayerPlayDirective(behavior);
            return skillResponse;
        }


        public static ResponseBody AddAudioPlayerStopDirective(this ResponseBody response)
        {
            return response.AddDirective<AudioPlayerStopDirective>();
        }

        public static SkillResponse AddAudioPlayerStopDirective(this SkillResponse skillResponse)
        {
            skillResponse.Response.AddAudioPlayerStopDirective();
            return skillResponse;
        }


        public static ResponseBody AddVideoAppLaunchDirective(this ResponseBody response, string source,
            string title = null, string subtitle = null)
        {
            return response.AddDirective<VideoAppLaunchDirective>(directive =>
            {
                directive.VideoItem.Source = source;
                if (!string.IsNullOrWhiteSpace(title) || !string.IsNullOrWhiteSpace(subtitle))
                    directive.VideoItem.Metadata = new VideoItemMetadata
                    {
                        Title = title,
                        Subtitle = subtitle
                    };
            });
        }
        public static SkillResponse AddVideoAppLaunchDirective(this SkillResponse skillResponse, string source,
            string title = null, string subtitle = null)
        {
            skillResponse.Response.AddVideoAppLaunchDirective(source, title, subtitle);
            return skillResponse;
        }


        public static ResponseBody AddAudioPlayerClearQueueDirective(this ResponseBody response)
        {
            return response.AddDirective<AudioPlayerClearQueueDirective>();
        }

        public static SkillResponse AddAudioPlayerClearQueueDirective(this SkillResponse skillResponse)
        {
            skillResponse.Response.AddAudioPlayerClearQueueDirective();
            return skillResponse;
        }


        public static ResponseBody AddDialogDelegate(this ResponseBody response, Intent updatedIntent = null)
        {
            return response
                .AddDirective<DialogDelegateDirective>(
                    directive => { directive.UpdatedIntent = updatedIntent; })
                .ShouldEndSession(false);
        }

        public static SkillResponse AddDialogDelegate(this SkillResponse skillResponse, Intent updatedIntent = null)
        {
            skillResponse.Response.AddDialogDelegate(updatedIntent);
            return skillResponse;
        }


        public static ResponseBody AddDialogElicitSlot(this ResponseBody response, string slotName,
            Intent updatedIntent = null)
        {
            return response.AddDirective<DialogElicitSlotDirective>(directive =>
                {
                    directive.SlotName = slotName;
                    directive.UpdatedIntent = updatedIntent;
                })
                .ShouldEndSession(false);
        }

        public static SkillResponse AddDialogElicitSlot(this SkillResponse skillResponse, string slotName,
            Intent updatedIntent = null)
        {
            skillResponse.Response.AddDialogElicitSlot(slotName, updatedIntent);
            return skillResponse;
        }


        public static ResponseBody AddDialogConfirmSlot(this ResponseBody response, string slotName,
            Intent updatedIntent = null)
        {
            return response.AddDirective<DialogConfirmSlotDirective>(directive =>
                {
                    directive.SlotName = slotName;
                    directive.UpdatedIntent = updatedIntent;
                })
                .ShouldEndSession(false);
        }

        public static SkillResponse AddDialogConfirmSlot(this SkillResponse skillResponse, string slotName,
            Intent updatedIntent = null)
        {
            skillResponse.Response.AddDialogConfirmSlot(slotName, updatedIntent);
            return skillResponse;
        }


        public static ResponseBody AddDialogConfirmIntent(this ResponseBody response, Intent updatedIntent = null)
        {
            return response.AddDirective<DialogConfirmIntentDirective>(directive =>
                {
                    directive.UpdatedIntent = updatedIntent;
                })
                .ShouldEndSession(false);
        }

        public static SkillResponse AddDialogConfirmIntent(this SkillResponse skillResponse,
            Intent updatedIntent = null)
        {
            skillResponse.Response.AddDialogConfirmIntent(updatedIntent);
            return skillResponse;
        }


        public static ResponseBody AddHintDirective(this ResponseBody response, string hint)
        {
            return response.AddDirective(new HintDirective
            {
                Hint = new PlainTextHint
                {
                    Text = hint
                }
            });
        }

        public static SkillResponse AddHintDirective(this SkillResponse skillResponse, string hint)
        {
            skillResponse.Response.AddHintDirective(hint);
            return skillResponse;
        }


        public static ResponseBody WithCard(this ResponseBody response, Card card)
        {
            response.Card = card;
            return response;
        }

        public static SkillResponse WithCard(this SkillResponse skillResponse, Card card)
        {
            skillResponse.Response.WithCard(card);
            return skillResponse;
        }


        public static ResponseBody WithSimpleCard(this ResponseBody response, string title, string content)
        {
            return response.WithCard(new SimpleCard
            {
                Title = title,
                Content = content
            });
        }

        public static SkillResponse WithSimpleCard(this SkillResponse skillResponse, string title, string content)
        {
            skillResponse.Response.WithSimpleCard(title, content);
            return skillResponse;
        }


        public static ResponseBody WithStandardCard(this ResponseBody response, string title, string content,
            string smallImageUrl = null, string largeImageUrl = null)
        {
            return response.WithCard(new StandardCard
            {
                Title = title,
                Content = content,
                Image = new CardImage
                {
                    SmallImageUrl = smallImageUrl,
                    LargeImageUrl = largeImageUrl
                }
            });
        }

        public static SkillResponse WithStandardCard(this SkillResponse skillResponse, string title, string content,
            string smallImageUrl = null, string largeImageUrl = null)
        {
            skillResponse.Response.WithSimpleCard(title, content);
            return skillResponse;
        }


        public static ResponseBody WithLinkAccountCard(this ResponseBody response)
        {
            return response.WithCard(new LinkAccountCard());
        }

        public static SkillResponse WithLinkAccountCard(this SkillResponse skillResponse)
        {
            skillResponse.Response.WithLinkAccountCard();
            return skillResponse;
        }


        public static ResponseBody WithAskForPermissionsConsentCard(this ResponseBody response,
            IEnumerable<string> permissions)
        {
            return response.WithCard(new AskForPermissionsConsentCard
            {
                Permissions = permissions?.ToList()
            });
        }

        public static ResponseBody WithAskForPermissionsConsentCard(this ResponseBody response,
            params string[] permissions)
        {
            return response.WithAskForPermissionsConsentCard(permissions as IEnumerable<string>);
        }


        public static SkillResponse WithAskForPermissionsConsentCard(this SkillResponse skillResponse,
            IEnumerable<string> permissions)
        {
            skillResponse.Response.WithAskForPermissionsConsentCard(permissions);
            return skillResponse;
        }

        public static SkillResponse WithAskForPermissionsConsentCard(this SkillResponse skillResponse,
            params string[] permissions)
        {
            skillResponse.Response.WithAskForPermissionsConsentCard(permissions);
            return skillResponse;
        }


        public static ResponseBody AddRenderTemplateDirective<TDisplayTemplate>(this ResponseBody response,
            TDisplayTemplate template) where TDisplayTemplate : DisplayTemplate
        {
            response.AddDirective(new DisplayRenderTemplateDirective
            {
                Template = template
            });
            return response;
        }

        public static SkillResponse AddRenderTemplateDirective<TDisplayTemplate>(this SkillResponse skillResponse,
            TDisplayTemplate template) where TDisplayTemplate : DisplayTemplate
        {
            skillResponse.Response.AddRenderTemplateDirective(template);
            return skillResponse;
        }


        public static ResponseBody AddVideoAddLaunchDirective(this ResponseBody response,
            string source, string title = null, string subtitle = null)
        {
            return response.AddDirective(new VideoAppLaunchDirective
            {
                VideoItem =
                {
                    Source = source,
                    Metadata =
                    {
                        Title = title,
                        Subtitle = subtitle
                    }
                }
            });
        }

        public static SkillResponse AddVideoAddLaunchDirective(this SkillResponse skillResponse,
            string source, string title = null, string subtitle = null)
        {
            skillResponse.Response.AddVideoAddLaunchDirective(source, title, subtitle);
            return skillResponse;
        }
    }
}