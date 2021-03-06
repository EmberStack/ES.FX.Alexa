﻿using Newtonsoft.Json;

namespace ES.FX.Alexa.SmartHomeSkill
{
    public abstract class Property
    {
        [JsonProperty("namespace")]
        public abstract string Namespace { get; }

        [JsonProperty("name")]
        public abstract string Name { get; }
    }
}