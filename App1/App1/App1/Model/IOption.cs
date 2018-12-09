using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace App1.Model
{
    public interface IOption
    {
        [JsonProperty(PropertyName = "IsRight")]
        bool IsRight { get; set; }
        [JsonProperty(PropertyName = "OptionText")]
        string OptionText { get; set; }

    }
}
