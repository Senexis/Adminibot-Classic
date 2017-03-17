using System;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FirstFloor.ModernUI.Windows.Controls;
using th.AdminibotModern.Classes;

namespace th.AdminibotModern.Pages.Connection
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : UserControl
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
            if (Validation.GetHasError(TxtUsername) || string.IsNullOrWhiteSpace(TxtPassword.Password) ||
                Validation.GetHasError(TxtChannel))
            {
                string messageBody =
                    "To ensure that we can connect to the Twitch chat services, we must make sure that all data is valid. In your case, some data you filled in wasn't valid. Please resolve the following issue(s):" +
                    Environment.NewLine + Environment.NewLine;
                if (Validation.GetHasError(TxtUsername))
                {
                    messageBody += "• " + Validation.GetErrors(TxtUsername).First().ErrorContent + Environment.NewLine;
                }
                if (string.IsNullOrWhiteSpace(TxtPassword.Password))
                {
                    messageBody += "• Token cannot be empty." + Environment.NewLine;
                }
                else if (!TxtPassword.Password.StartsWith("oauth:"))
                {
                    messageBody += "• Token has to begin with \"oauth:\"." + Environment.NewLine;
                }
                if (Validation.GetHasError(TxtChannel))
                {
                    messageBody += "• " + Validation.GetErrors(TxtChannel).First().ErrorContent + Environment.NewLine;
                }
                MessageBox.Show(messageBody, "Adminibot - Validation Failed", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                // This actually works (minus actual receiving chat messages), but it doesn't automagically get rid of itself of Disconnect().
                ChatClient twitchChatClient = new ChatClient(TxtUsername.Text, TxtPassword.Password, TxtChannel.Text);
            }
        }
    }
}
