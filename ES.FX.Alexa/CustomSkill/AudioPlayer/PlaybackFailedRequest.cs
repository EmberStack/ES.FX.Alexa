﻿using ES.FX.Alexa.Common.Json;
using ES.FX.Alexa.CustomSkill.Core;
using Newtonsoft.Json;

namespace ES.FX.Alexa.CustomSkill.AudioPlayer
{
    [HasType("AudioPlayer.PlaybackFailed")]
    public class PlaybackFailedRequest : Request, IAudioPlayerRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("currentPlaybackState")]
        public PlaybackState CurrentPlaybackState { get; set; }

        [JsonProperty("error")]
        public AudioPlayerError Error { get; set; }
    }
}