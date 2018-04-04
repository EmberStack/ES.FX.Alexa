﻿using Newtonsoft.Json;

namespace ES.FX.Alexa.CustomSkill.Core
{
    public class ConfirmIntentDirective : Directive
    {
        public override string Type => "Dialog.ConfirmIntent";

        [JsonProperty("updatedIntent", NullValueHandling = NullValueHandling.Ignore)]
        public Intent UpdatedIntent { get; set; }
    }
}