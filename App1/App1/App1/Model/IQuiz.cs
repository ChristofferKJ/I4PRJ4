using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App1.Model
{
    public interface IQuiz
    {
        [JsonProperty(PropertyName = "id")]
        string Id { get; set; }

        [JsonProperty(PropertyName = "Category")]
        string Category { get; set; }

      
        [JsonProperty(PropertyName = "QuizName")]
         string QuizName { get; set; }
    
        [JsonProperty(PropertyName = "Question")]
        List<IQuestion> Question { get; set; }
        IQuestion NextQuestion();
        void RandomizeQuestionOrder();

    }
}
