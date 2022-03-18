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

        public ObservableCollection<Projet> Projets
        {
            get => _projet;
            set => SetProperty(ref _projet, value);
        }

        public ICommand AddCommand { get; }

        public ListProjetViewModel()
        {
            Projets = new ObservableCollection<Projet>();


            AddCommand = new Command(AddAction);
        }

        public override Task OnResume()
        {
            Projets.Clear();
            List<string> items = DependencyService.Get<ProjetService>().Projet;
            foreach (string item in items)
            {
                Projets.Add(Create(item));
            }

            return base.OnResume();
        }

        private Projet Create(string text)
        {
            return new Projet(
                new Command<Projet>(DeleteAction),
                new Command<Projet>(EditAction)
            )
            {
                Text = text
            };
        }

        private void EditAction(Projet projet)
        {
            int index = Projets.IndexOf(projet);

            NavigationService.PushAsync<AddOrEdit>(new Dictionary<string, object>()
            {
                ["Index"] = index
            });
        }

        private void DeleteAction(Projet projet)
        {
            int index = Projets.IndexOf(projet);
            var todoService = DependencyService.Get<ProjetService>();
            List<string> items = todoService.Projet;
            items.RemoveAt(index);
            Projets.RemoveAt(index);
            todoService.Save();
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