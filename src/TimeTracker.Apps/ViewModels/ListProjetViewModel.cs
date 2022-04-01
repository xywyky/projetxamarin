using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;

namespace TimeTracker.Apps.ViewModels
{
    public class ListProjetViewModel : ViewModelBase
    {

        private ObservableCollection<Datum> _projet2;


        private Chart _chart;


        public Chart Chart1
        {
            get => _chart;
            set => SetProperty(ref _chart, value);
        }

        public ObservableCollection<Datum> Projets2
        {
            get => _projet2;
            set => SetProperty(ref _projet2, value);
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }

        public ListProjetViewModel()
        {
            Projets2 = new ObservableCollection<Datum>();
            AddCommand = new Command(AddAction);
            EditCommand = new Command(EditAction);
        }


        public List<ChartEntry> CreateEntires(ObservableCollection<Datum> _projet2)
        {


            List<ChartEntry> entries = new List<ChartEntry>();

            Random r = new Random();
            foreach (Datum project in _projet2)
            {
                Color color = Color.FromRgb(r.Next(0, 256), r.Next(0, 256), 0);
                entries.Add(new Entry(project.Total_seconds)
                    {
                        Label = project.Name,
                        Color = SKColor.Parse(color.ToHex())

                    });
                
            }
            return entries;
        }


        private void TaskAction(Datum datum)
        {
            var todoService = DependencyService.Get<ApiService>();
            todoService.getTasks(datum.Id);
            NavigationService.PushAsync<ListTask>(new Dictionary<string, object>()
            {
                ["Index"] = datum.Id
            });
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

            Chart1 = new LineChart {
                Entries = CreateEntires(Projets2)
            };
            return base.OnResume();
        }

    private Datum Create(Datum datum)
        {
            return new Datum(
                    new Command<Datum>(DeleteAction),
                    new Command<Datum>(ModifAction),
                    new Command<Datum>(TaskAction))
            {
                Name = datum._name,
                Description = datum._description,
                Id = datum._id,
                Total_seconds = datum._total_seconds
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
        todoService.getProjects();
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