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
        //Добавление данных в таблицу
        private void FillDatarid(List<Human> humans, DataGrid dataGrid)
        {
            foreach (var item in humans)
            {
                dataGrid.Items.Add(item);
            }
        }
        private void DataGridPeople_Loaded(object sender, RoutedEventArgs e)
        {
            FillDatarid(LoadSaveFiles.LoadFile<Human>(), dataGridPeople);
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            var humans = new List<Human>();
            Human.AddHumanToList(humans, dataGridPeople);
            LoadSaveFiles.SaveFile(humans);
        }

        private void ButtonAddHuman_Click(object sender, RoutedEventArgs e)
        {
            var humans = new List<Human>();
            Human.AddHumanToList(humans, dataGridPeople);

            humans.Add(new Human(textBoxFirstName.Text, textBoxLastName.Text, datePickerBirthday.Text)); //Добавление нового человека

            dataGridPeople.Items.Clear();
            FillDatarid(humans, dataGridPeople);

        }
    }
}
