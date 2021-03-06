﻿using System.Runtime.Serialization;

namespace ES.FX.Alexa.CustomSkill
{
    public enum DialogState
    {
        [EnumMember(Value = "STARTED")]
        Started,

        [EnumMember(Value = "IN_PROGRESS")]
        InProgress,

        [EnumMember(Value = "COMPLETED")]
        Completed
    }
}