﻿using Newtonsoft.Json;

namespace ES.FX.Alexa.SmartHomeSkill.TemperatureSensor
{
    public class TemperatureReportProperty : StateReportProperty
    {
        public override string Namespace => "Alexa.TemperatureSensor";
        public override string Name => "temperature";

        [JsonProperty("value")]
        public TemperatureValue Value { get; set; } = new TemperatureValue();
    }
}