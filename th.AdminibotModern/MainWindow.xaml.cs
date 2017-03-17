using System.Data.Entity;
using FirstFloor.ModernUI.Windows.Controls;
using th.AdminibotModern.Pages.Settings;
using th.AdminibotModern.Pages.Settings.AdminibotSettings;
using th.AdminibotModern.Properties;

namespace th.AdminibotModern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var settings = new AppearanceViewModel();
            settings.SetThemeAndColor(Settings.Default.SelectedThemeDisplayName,
                  Settings.Default.SelectedThemeSource,
                  Settings.Default.SelectedAccentColor,
                  Settings.Default.SelectedFontSize);
        }
    }
}
