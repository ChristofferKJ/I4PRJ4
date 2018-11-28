using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace App1.Model
{
    public class Question : PropertyChangedModel
    {
        private string _QuestionText;
        [JsonProperty(PropertyName = "QuestionText")]
        public string QuestionText
        {
            get => _QuestionText;
            set
            {
                if (_QuestionText == value)
                {
                    return;
                }
                _QuestionText = value;
                HandlePropertyChanged();
            }
        }

        private int _Score;
        [JsonProperty(PropertyName = "Score")]
        public int Score
        {
            get => _Score;
            set
            {
                if (_Score == value)
                {
                    return;
                }
                _Score = value;
                HandlePropertyChanged();
            }
        }

        private List<Option> _Options;
        [JsonProperty(PropertyName = "Options")]
        public List<Option> Options
        {
            get => _Options;
            set
            {
                if (_Options == value)
                {
                    return;
                }
                _Options = value;
                HandlePropertyChanged();
            }
        }
    }
}