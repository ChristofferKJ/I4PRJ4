using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace App1.Model
{
    public class Quiz : PropertyChangedModel
    {
        string _Id;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get => _Id;
            set
            {
                if (_Id == value)
                {
                    return;
                }
                _Id = value;
                HandlePropertyChanged();
            }
        }

        string _Category;
        [JsonProperty(PropertyName = "Category")]
        public string Category
        {
            get => _Category;
            set
            {
                if (_Category == value)
                {
                    return;
                }

                _Category = value;
                HandlePropertyChanged();
            }

        }

        private string _QuizName;
        [JsonProperty(PropertyName = "QuizName")]
        public string QuizName
        {
            get => _QuizName;
            set
            {
                if (_QuizName == value)
                {
                    return;
                }

                _QuizName = value;
                HandlePropertyChanged();
            }

        }

        private List<Question> _Question;
        [JsonProperty(PropertyName = "Question")]
        public List<Question> Question
        {
            get => _Question;
            set
            {
                if (_Question == value)
                {
                    return;
                }

                _Question = value;
                HandlePropertyChanged();
            }

        }

    }
}
