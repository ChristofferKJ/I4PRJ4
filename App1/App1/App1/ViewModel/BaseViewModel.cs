using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace TaskList.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string _title = "";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private int _TotalScore;
        public int TotalScore
        {
            get => _TotalScore;
            set => SetProperty(ref _TotalScore, value);
        }
        
        protected void SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            onChanged?.Invoke();

            HandlePropertyChanged(propertyName);
        }

        protected void HandlePropertyChanged(string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}