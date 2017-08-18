using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Inventory inventory = new Inventory();
            inventory.Dishes.CollectionChanged += (sender, args) => {  };
            this.DataContext = inventory;
            InitializeComponent();
            dishList.ItemsSource = inventory.Dishes;
            //inventory.Dishes.CollectionChanged += this.OnCollectionChanged;
        }
        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        { }
    }
}
