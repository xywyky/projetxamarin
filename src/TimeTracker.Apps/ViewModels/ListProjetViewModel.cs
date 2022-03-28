using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class ListProjetViewModel : ViewModelBase
    {
        private ObservableCollection<Projet> _projet;

        private ObservableCollection<Datum> _projet2;

        public ObservableCollection<Datum> Projets2
        {
            get => _projet2;
            set => SetProperty(ref _projet2, value);
        }

        public ObservableCollection<Projet> Projets
        {
            get => _projet;
            set => SetProperty(ref _projet, value);
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public ListProjetViewModel()
        {
            Projets = new ObservableCollection<Projet>();
            Projets2 = new ObservableCollection<Datum>();

            AddCommand = new Command(AddAction);
            EditCommand = new Command(EditAction);
        }

        private void EditAction()
        {
            NavigationService.PushAsync<EditProfil>();
        }

        //fonction a adapter
        public override Task OnResume()
        {
            Projets2.Clear();
            List<Datum> iems2 = DependencyService.Get<ApiService>().Projet;

            foreach (Datum i in iems2)
            {
                Projets2.Add(Create(i));
            }

            return base.OnResume();
        }

    private Datum Create(Datum datum)
        {
            return new Datum(
                    new Command<Datum>(DeleteAction),
                    new Command<Datum>(ModifAction))
            {
                Name = datum._name,
                Description = datum._description,
                Id = datum._id
            }
                ;

        }

    private void ModifAction(Datum datum)
    {
            NavigationService.PushAsync<AddOrEdit>(new Dictionary<string, object>()
            {
                ["Index"] = datum.Id
            });
        }

    private void DeleteAction(Datum projet)
    {
        int index = projet.Id;
        var todoService = DependencyService.Get<ApiService>();
        todoService.deleteProjects(index);
    }

    private void AddAction()
    {
            NavigationService.PushAsync<AddOrEdit>(new Dictionary<string, object>()
        {
            ["Index"] = -1
        });
    }
}
}