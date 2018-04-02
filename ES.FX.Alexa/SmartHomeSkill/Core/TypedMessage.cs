﻿using Newtonsoft.Json;

namespace ES.FX.Alexa.SmartHomeSkill.Core
{
    public class TypedMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}