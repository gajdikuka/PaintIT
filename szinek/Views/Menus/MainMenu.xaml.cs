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

namespace szinek
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static event EventHandler selectlevel;
        public static event EventHandler leveleditor;
        public static event EventHandler exit;


        private void click_SelectLevel(object sender, RoutedEventArgs e)
        {
            if (selectlevel != null)
            {
                selectlevel(this, e);
            }
        }

        private void click_LevelEditor(object sender, RoutedEventArgs e)
        {
            if (leveleditor != null)
            {
                leveleditor(this, e);
            }
        }

        private void click_Exit(object sender, RoutedEventArgs e)
        {
            if (exit != null)
            {
                exit(this, e);
            }
        }
    }
}
