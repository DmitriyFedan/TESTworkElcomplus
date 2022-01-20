using System;
using System.Collections.Generic;
using System.IO;
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
using TESTworkElcomplus;

namespace TESTworkElcomplus
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
        // На данный момент  за выделенное время удалось реализовать функционал только
        // совсем примитивным способом , посчитал что плохое решение лучше чем никакого  =) )
        // C WPF мне еще конечно нужно много разбираться )
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string dirPath = textBoxPath.Text.ToString();
            ApplicationViewModel vm = new ApplicationViewModel();
            vm.DirPath = dirPath;
            if (Directory.Exists(dirPath))
                Label1.Content = vm.UpdateValues();
            else
                MessageBox.Show($"Директория {dirPath} не найдена  укажите другой путь");

            foreach (var item in vm.fileNameList)
                Listbox1.Items.Add(item);
        }

       
    }
}
