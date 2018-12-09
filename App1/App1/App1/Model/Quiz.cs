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

        string _question;
        [BsonElement("Question")]
        public string Question
        {
            get => _question;
            set
            {
                if (_question == value)
                    return;

                _question = value;

                HandlePropertyChanged();
            }
        }

        string _option1;
        [BsonElement("Option1")]
        public string Option1
        {
            get => _option1;
            set
            {
                if (_option1 == value)
                    return;

                _option1 = value;

                HandlePropertyChanged();
            }
        }

        /* Question[] _questions;
         [BsonElement("Questions")]
         public Question[] Questions
         {
             get => _questions;

             set
             {
                 if (_questions == value)
                     return;

                 _questions = value;

                 HandlePropertyChanged();
             }
         }

         //getNextQuestion
         public Question GetNextQuestion()
         {
             return new Question();
         }

         public void print()
         {
             Console.WriteLine($"-----------QUIZ-------");
             Console.WriteLine($"Quizname: {QuizName}");
             Console.WriteLine($"Category: {Category}");
             Console.WriteLine("----------------------");
             Console.WriteLine("     Questions");
             Console.WriteLine("----------------------");
             foreach (var q in Questions)
             {
                 q.print();
             }
             Console.WriteLine("----------------------");
         }*/
    }
}
