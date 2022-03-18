using System;
using System.Collections.Generic;
using Storm.Mvvm.Forms;
using TimeTracker.Apps.ViewModels;

namespace TimeTracker.Apps.Pages
{
    public partial class PageInscription : BaseContentPage
    {


        public PageInscription()
        {
            InitializeComponent();
            BindingContext = new InscriptionModel();
        }
    }
}