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

            List<Human> Humans = new List<Human>();
            

            dataGridPeople.ItemsSource = OpenSaveFiles.LoadFile<Human>();
            dataGridPeople.Columns[0].Header = "Имя";
            dataGridPeople.Columns[1].Header = "Фамилия";
            dataGridPeople.Columns[2].Header = "Возраст";
            dataGridPeople.Columns[3].Header = "День рождения(дд-мм-гггг)";

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var humans = dataGridPeople.ItemsSource.Cast<Human>();
            OpenSaveFiles.SaveFile(humans);
        }
    }
}
