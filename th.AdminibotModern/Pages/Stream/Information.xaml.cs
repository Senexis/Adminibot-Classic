using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace th.AdminibotModern.Pages.Stream
{
    /// <summary>
    /// Interaction logic for StreamInfo.xaml
    /// </summary>
    public partial class StreamInfo : UserControl
    {
        public class DataObject
        {
            public string StreamInformationTitle { get; set; }
            public string StreamInformationContent { get; set; }
        }
        
        public StreamInfo()
        {
            InitializeComponent();

            var list = new ObservableCollection<DataObject>();
            list.Add(new DataObject() { StreamInformationTitle = "Online", StreamInformationContent = "False" });
            list.Add(new DataObject() { StreamInformationTitle = "Title", StreamInformationContent = "Punday Monday: Playing Random Indie Games" });
            list.Add(new DataObject() { StreamInformationTitle = "Game", StreamInformationContent = "Holy Potatoes! A Weapon Shop?!" });
            this.StreamInformationGrid.ItemsSource = list;
        }
    }
}
