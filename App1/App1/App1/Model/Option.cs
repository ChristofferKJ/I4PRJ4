    using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace App1.Model
{
    public class Option : PropertyChangedModel
    {
        private bool _IsRight;
        [JsonProperty(PropertyName = "IsRight")]
        public bool IsRight
        {
            get => _IsRight;
            set
            {

                if (_IsRight == value)
                {
                    return;
                }
                _IsRight = value;
                HandlePropertyChanged();
            }
        }

        private string _OptionText;
        [JsonProperty(PropertyName = "OptionText")]
        public string OptionText
        {
            get => _OptionText;
            set
            {
                if (_OptionText == value)
                {
                    return;
                }
                _OptionText = value;
                HandlePropertyChanged();
            }
        }
    }
}