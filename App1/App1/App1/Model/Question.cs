using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace App1.Model
{
    public class Question : PropertyChangedModel
    {

        private static System.Random nrg => new System.Random();

        int _questionIndex;
        [BsonElement("QuestionIndex")]
        public int QuestionIndex
        {
            get => _questionIndex;
            set
            {
                if (_questionIndex == value)
                    return;

                _questionIndex = value;

                HandlePropertyChanged();
            }

        }

        string _questionText;
        [BsonElement("QuestionText")]
        public string QuestionText
        {
            get => _questionText;
            set
            {
                if (_questionText == value)
                    return;

                _questionText = value;

                HandlePropertyChanged();
            }

        }

        Option[] _options;

        [BsonElement("Option0")]
        public Option Option0
        {
            get => _options[0];
            set
            {
                if (_options[0] == value)
                    return;

                _options[0] = value;

                HandlePropertyChanged();
            }
        }

        [BsonElement("Option1")]
        public Option Option1
        {
            get => _options[1];
            set
            {
                if (_options[1] == value)
                    return;

                _options[1] = value;

                HandlePropertyChanged();
            }
        }

        [BsonElement("Option2")]
        public Option Option2
        {
            get => _options[2];
            set
            {
                if (_options[2] == value)
                    return;

                _options[2] = value;

                HandlePropertyChanged();
            }
        }


        [BsonElement("Option3")]
        public Option Option3
        {
            get => _options[3];
            set
            {
                if (_options[3] == value)
                    return;

                _options[3] = value;

                HandlePropertyChanged();

            }
        }

        public void RandomizeOptionOrder()
        {

            int n = _options.Length;
            while (n > 1)
            {
                n--;
                int k = nrg.Next(n + 1);
                Option opt = _options[k];
                _options[k] = _options[n];
                _options[n] = opt;
            }
        }

        public void print()
        {
            Console.WriteLine($"Question: {QuestionText}");
            Console.WriteLine("----------------------");
            Console.WriteLine("     Options");
            Console.WriteLine("----------------------");
            foreach (var o in _options)
            {
                o.print();
            }
            Console.WriteLine("----------------------");
        }
    }
}