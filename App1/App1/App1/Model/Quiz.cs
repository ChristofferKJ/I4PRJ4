using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace App1.Model
{
    public class Quiz : PropertyChangedModel
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

        string _quizName;
        [BsonElement("QuizName")]
        public string QuizName
        {
            get => _quizName;
            set
            {
                if (_quizName == value)
                    return;

                _quizName = value;

                HandlePropertyChanged();
            }
        }



        string _category;
        [BsonElement("Category")]
        public string Category
        {
            get => _category;
            set
            {
                if (_category == value)
                    return;

                _category = value;

                HandlePropertyChanged();
            }
        }

        List<Question> _questionList;
        [BsonElement("QuestionList")]
        public List<Question> QuestionList
        {
            get => _questionList;
            set
            {
                if (_questionList == value)
                    return;

                _questionList = value;

                HandlePropertyChanged();
            }
        }

        //getNextQuestion
        public Question GetNextQuestion()
        {
            return new Question();
        }
    }
}
