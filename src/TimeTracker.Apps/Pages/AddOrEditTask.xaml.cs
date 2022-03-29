using System;
using System.Collections.Generic;
using Storm.Mvvm.Forms;
using TimeTracker.Apps.ViewModels;
using Xamarin.Forms;

namespace TimeTracker.Apps.Pages
{
    public partial class AddOrEditTask : BaseContentPage
    {
        public AddOrEditTask()
        {
            InitializeComponent();
            BindingContext = new AddOrEditTaskModel();
        }
    }
}
