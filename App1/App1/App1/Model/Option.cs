using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App1.Model
{
    public class Option : PropertyChangedModel
    {

        string _optionText;
        [BsonElement("OptionText")]
        public string OptionText
        {
            get => _optionText;
            set
            {
                if (_optionText == value)
                    return;

                _optionText = value;

                HandlePropertyChanged();
            }
        }

        bool _isRight; //den her behøver måske ikke være propertychanged
        [BsonElement("IsRight")]
        public bool IsRight
        {
            get => _isRight;
            set
            {
                if (_isRight == value)
                    return;

                _isRight = value;

                HandlePropertyChanged();
            }
        }

        int _optionIndex;
        [BsonElement("OptionIndex")]
        public int QuestionIndex
        {
            get => _optionIndex;
            set
            {
                if (_optionIndex == value)
                    return;

                _optionIndex = value;

                HandlePropertyChanged();
            }

        }

        public void print()
        {
            Console.WriteLine($"Option: {OptionText}");
            Console.WriteLine($"Right Choice: {IsRight}");
            Console.WriteLine("----------------------");
        }
    }
}