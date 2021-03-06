﻿using Newtonsoft.Json;

namespace ES.FX.Alexa.SmartHomeSkill
{
    public class TypedToken
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}