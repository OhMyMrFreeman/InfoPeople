using InfoPeople.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //Добавление данных в таблицу
        
        private void DataGridPeople_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Human> human = new ObservableCollection<Human>(LoadSaveFiles.LoadFile<Human>());
            dataGridPeople.ItemsSource = human;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            LoadSaveFiles.SaveFile(dataGridPeople.ItemsSource.Cast<Human>());
        }

        private void ButtonAddHuman_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Human> human = new ObservableCollection<Human>(dataGridPeople.ItemsSource.Cast<Human>());
            human.Add(new Human(textBoxFirstName.Text, textBoxLastName.Text,textBoxMiddleName.Text, datePickerBirthday.Text));
            dataGridPeople.ItemsSource = human;

        }
    }
}
