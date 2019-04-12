using System.Windows;

namespace LotoResultsViewer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ResultArchiveGrid.ItemsSource = new[]
            {
                new {LastName = "Ivanov", FirstName = "Ivan"},
                new {LastName = "Pertov", FirstName = "Petr"},
                new {LastName = "Russkih", FirstName = "Russkiy"},
                new {LastName = "Testov", FirstName = "Test"}
            };

            phonesGrid.ItemsSource = new[]
            {
                new {LastName = "Ivanov", FirstName = "Ivan"},
                new {LastName = "Pertov", FirstName = "Petr"},
                new {LastName = "Russkih", FirstName = "Russkiy"},
                new {LastName = "Testov", FirstName = "Test"}
            };
        }
    }
}
