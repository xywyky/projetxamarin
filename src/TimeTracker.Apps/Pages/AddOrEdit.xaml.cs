using System;
using System.Collections.Generic;

using TimeTracker.Apps.ViewModels;
using Xamarin.Forms.Xaml;

namespace TimeTracker.Apps.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEdit
    {
        public AddOrEdit()
        {
            InitializeComponent();
            BindingContext = new AddOrEditViewModel();
        }
    }
}