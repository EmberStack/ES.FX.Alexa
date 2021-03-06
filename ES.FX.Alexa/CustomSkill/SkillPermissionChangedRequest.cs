﻿using ES.FX.Alexa.Json;
using Newtonsoft.Json;

namespace ES.FX.Alexa.CustomSkill
{
    [HasType("AlexaSkillEvent.SkillPermissionChanged")]
    public class SkillPermissionChangedRequest : Request, ICoreRequest
    {
        [JsonProperty("body")]
        public PermissionBody Body { get; set; }
    }
}