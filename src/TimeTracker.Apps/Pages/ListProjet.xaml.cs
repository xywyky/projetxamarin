using Storm.Mvvm.Forms;
using TimeTracker.Apps.ViewModels;

namespace TimeTracker.Apps.Pages
{
    public partial class ListProjet : BaseContentPage
    {
        public ListProjet()
        {
            InitializeComponent();
            BindingContext = new ListProjetViewModel();
        }
    }
}