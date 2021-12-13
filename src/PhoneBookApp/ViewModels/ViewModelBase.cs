﻿namespace PhoneBookApp.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
