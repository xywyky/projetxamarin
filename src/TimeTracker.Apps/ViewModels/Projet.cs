using System;
using Xamarin.Forms;
using System.Windows.Input;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{
    public class Projet : NotifierBase
    {

        private string _text;
        private string _description;

        public Projet(ICommand deleteCommand, ICommand editCommand)
        {
            DeleteCommand = deleteCommand;
            EditCommand = editCommand;
        }


        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public ICommand DeleteCommand { get; }

        public ICommand EditCommand { get; }
    }
}

