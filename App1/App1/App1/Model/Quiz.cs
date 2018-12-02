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
        private int questionIndex_;
        private static System.Random nrg => new System.Random();

        Quiz()
        {
            questionIndex_ = 0;
        }

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

        public Question NextQuestion()
        {
            if ((questionIndex_ + 1) >= Question.Count)
                return null;

            var nextQuestion =  Question[++questionIndex_];
            return nextQuestion;


        }

        public void RandomizeQuestionOrder()
        {

            int n = _Question.Count;
            while (n > 1)
            {
                n--;
                int k = nrg.Next(n + 1);
                Question question = _Question[k];
                _Question[k] = _Question[n];
                _Question[n] = question;
            }
        }


    }
}
