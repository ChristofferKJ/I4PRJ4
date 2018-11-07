using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App1.Model
{
    public class Quiz : INotifyPropertyChanged
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }

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

        string _option;
        [BsonElement("Option")]
        public string Option
        {
            get => _option;
            set
            {
                if (_option == value)
                    return;

                _option = value;

                HandlePropertyChanged();
            }
        }



        void HandlePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
