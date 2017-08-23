using System;
using System.Drawing;
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

namespace JohnCs26Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int NumberOfPeople = 0;
        int state = 0; // 0 = empty, 1 = woman, 2 = man

        public MainWindow()
        {
            InitializeComponent();
            doorImage.Source = new BitmapImage(new Uri(@"Assest/Empty Door.png", UriKind.Relative));
        }

        public void woman_wants_to_enter()
        {
            if ((state == 0) || (state == 1)) {
                state = 1;
                NumberOfPeople++;
            }
            updateScreen();
        }

        public void man_wants_to_enter()
        {
            if ((state == 0) || (state == 2))
            {
                state = 2;
                NumberOfPeople++;
            }
            updateScreen();
        }

        public void woman_leaves()
        {
            if ((state == 1) && (NumberOfPeople !=0 ))
            {
                NumberOfPeople--;
                if(NumberOfPeople == 0)
                {
                    state = 0;
                }
            }
            updateScreen();
        }

        public void man_leaves()
        {
            if ((state == 2) && (NumberOfPeople != 0))
            {
                NumberOfPeople--;
                if (NumberOfPeople == 0)
                {
                    state = 0;
                }
            }
            updateScreen();
        }

        public void updateScreen()
        {
            counterTextBox.Text = NumberOfPeople.ToString();

            if (state == 0)
            {
                doorImage.Source = new BitmapImage(new Uri(@"Assest/Empty Door.png", UriKind.Relative));
            }
            else if(state == 1)
            {
                doorImage.Source = new BitmapImage(new Uri(@"Assest/Woman Door.png", UriKind.Relative));
            }
            else
            {
                doorImage.Source = new BitmapImage(new Uri(@"Assest/Man Door.png", UriKind.Relative));
            }
        }

        private void womanEnterButton_Click(object sender, RoutedEventArgs e)
        {
            woman_wants_to_enter();
        }

        private void manEnterButton_Click(object sender, RoutedEventArgs e)
        {
            man_wants_to_enter();
        }

        private void womanLeavesButton_Click(object sender, RoutedEventArgs e)
        {
            woman_leaves();
        }

        private void manLeavesButton_Click(object sender, RoutedEventArgs e)
        {
            man_leaves();
        }
    }
}
