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

        List<Option> _optionList;
        [BsonElement("OptionList")]
        public List<Option> OptionList
        {
            get => _optionList;
            set
            {
                if (_optionList == value)
                    return;

                _optionList = value;

                HandlePropertyChanged();
            }
        }

        public void RandomizeOptionOrder()
        {

            int n = _optionList.Count;
            while (n > 1)
            {
                n--;
                int k = nrg.Next(n + 1);
                Option opt = _optionList[k];
                _optionList[k] = _optionList[n];
                _optionList[n] = opt;
            }
        }
    }
}
