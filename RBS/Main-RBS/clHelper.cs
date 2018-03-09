using System.Linq;
using System.Windows.Forms;

namespace Main_RBS
{
    internal class clHelper
    {
        // method to get the main home form in order to interact with it from other forms
        public frmHome getHomeForm()
        {
            return Application.OpenForms.OfType<frmHome>().First();
        }

        // method to refresh the main form
        public void refreshHomeForm()
        {
            getHomeForm().refreshForm();
        }
    }
}