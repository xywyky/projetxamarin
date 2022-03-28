using System;
using System.Collections.Generic;
using Storm.Mvvm.Forms;
using TimeTracker.Apps.ViewModels;
using Xamarin.Forms;

namespace TimeTracker.Apps.Pages
{
    public partial class EditPass : BaseContentPage
    {
        public EditPass()
        {
            InitializeComponent();
            BindingContext = new EditPassModel();
        }
    }
}
