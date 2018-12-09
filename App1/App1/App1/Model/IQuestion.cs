using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App1.Model
{
    public interface IQuestion
    {
        [JsonProperty(PropertyName = "QuestionText")]
        string QuestionText { get; set; }

        [JsonProperty(PropertyName = "Score")] int Score { get; set; }

        [JsonProperty(PropertyName = "Options")]
        List<IOption> Options { get; set; }

        void RandomizeOptionOrder();

    }
}