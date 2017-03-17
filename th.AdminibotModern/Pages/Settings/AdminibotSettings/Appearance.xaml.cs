using System.Windows.Controls;

namespace th.AdminibotModern.Pages.Settings.AdminibotSettings
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class Appearance : UserControl
    {
        public Appearance()
        {
            InitializeComponent();

            // create and assign the appearance view model
            this.DataContext = new AppearanceViewModel();
        }
    }
}
