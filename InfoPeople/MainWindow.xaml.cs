using InfoPeople.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGridPeople_Loaded(object sender, RoutedEventArgs e)
        {

            List<People> peoples = new List<People>();
            peoples.Add(new People("Гарри","Поттер", "2020-01-17"));
            peoples.Add(new People("Володя", "Поттер", "1997-01-17"));
            peoples.Add(new People("Рон", "Поттер", "2021-01-17"));
            peoples.Add(new People("Джини", "Поттер", "1965-01-17"));
            OpenSaveFiles.SaveFile(peoples);

            dataGridPeople.ItemsSource = OpenSaveFiles.LoadFile<People>();
            dataGridPeople.Columns[0].Header = "Имя";
            dataGridPeople.Columns[1].Header = "Фамилия";
            dataGridPeople.Columns[2].Header = "Возраст";
            dataGridPeople.Columns[3].Header = "День рождения";

        }
    }
}
