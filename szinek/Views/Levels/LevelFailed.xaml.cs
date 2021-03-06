﻿using System;
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
using System.Windows.Shapes;

namespace szinek
{
    /// <summary>
    /// Interaction logic for LevelComplete.xaml
    /// </summary>
    public partial class LevelFailed : Window
    {
        public static event EventHandler restartLevel;

        public LevelFailed()
        {
            InitializeComponent();
            kozepreigazit();
        }

        private void kozepreigazit()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btn_RestartLevel_Click(object sender, RoutedEventArgs e)
        {
            if (restartLevel != null)
            {
                restartLevel(this, e);
            }
            this.Hide();
        }
    }
}
