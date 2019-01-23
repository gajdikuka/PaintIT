using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace szinek
{
    /// <summary>
    /// Interaction logic for Level1.xaml
    /// </summary>
    public partial class LevelEditor : UserControl
    {
        public static event EventHandler play;
        public static event EventHandler exit;

        public LevelEditor()
        {
            InitializeComponent();
            szinek_init();
        }

        List<string> megvizsgalt;

        #region szinek

        SolidColorBrush szin = new SolidColorBrush(Colors.Transparent);
        SolidColorBrush atlatszo = new SolidColorBrush(Colors.Transparent);
        SolidColorBrush piros = new SolidColorBrush(Colors.Red);
        SolidColorBrush zold = new SolidColorBrush(Colors.Green);
        SolidColorBrush kek = new SolidColorBrush(Colors.Blue);
        SolidColorBrush cian = new SolidColorBrush(Colors.Cyan);
        SolidColorBrush magenta = new SolidColorBrush(Colors.Magenta);
        SolidColorBrush sarga = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush barna = new SolidColorBrush(Colors.Brown);
        SolidColorBrush szurke = new SolidColorBrush(Colors.Gray);
        SolidColorBrush fekete = new SolidColorBrush(Colors.Black);

        private void szinek_init()
        {
            foreach (Rectangle r in myGrid.Children.OfType<Rectangle>())
            {
                r.Fill = atlatszo;
            }
        }

        private void btn_piros_Click(object sender, RoutedEventArgs e)
        {
            szin = piros;
        }

        private void btn_zold_Click(object sender, RoutedEventArgs e)
        {
            szin = zold;
        }

        private void btn_kek_Click(object sender, RoutedEventArgs e)
        {
            szin = kek;
        }

        private void btn_cian_Click(object sender, RoutedEventArgs e)
        {
            szin = cian;
        }

        private void btn_magenta_Click(object sender, RoutedEventArgs e)
        {
            szin = magenta;
        }

        private void btn_sarga_Click(object sender, RoutedEventArgs e)
        {
            szin = sarga;
        }

        private void btn_barna_Click(object sender, RoutedEventArgs e)
        {
            szin = barna;
        }

        private void btn_szurke_Click(object sender, RoutedEventArgs e)
        {
            szin = szurke;
        }

        private void btn_fekete_Click(object sender, RoutedEventArgs e)
        {
            szin = fekete;
        }
        #endregion

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            var recs = from r in myGrid.Children.OfType<Rectangle>()
                       select r;
            string line;
            string kiolvasott = "";
            string elmenteni = "";
            List<string> palyak = new List<string>();
            int palyaszam = -1;
            using (StreamReader reader = new StreamReader("..\\Data\\Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    palyak.Add(line);
                }

                int parsedInt;
                if (int.TryParse(tb_palya.Text, out parsedInt))
                {
                    palyaszam = parsedInt;
                }
                else palyaszam = 1;

                if (palyaszam > 0 && palyaszam <= palyak.Count)
                {
                    kiolvasott = palyak[palyaszam - 1];
                }
            }
            using (StreamWriter writer = new StreamWriter("..\\Data\\Data.csv"))
            {
                foreach (var r in recs)
                {
                    if (r.Fill == sarga)
                        elmenteni+="s;";
                    else if (r.Fill == kek)
                        elmenteni += "k;";
                    else if (r.Fill == piros)
                        elmenteni += "p;";
                    else if (r.Fill == zold)
                        elmenteni += "z;";
                    else if (r.Fill == cian)
                        elmenteni += "c;";
                    else if (r.Fill == magenta)
                        elmenteni += "m;";
                    else if (r.Fill == barna)
                        elmenteni += "b;";
                    else if (r.Fill == szurke)
                        elmenteni += "g;";
                    else if (r.Fill == fekete)
                        elmenteni += "f;";
                    else
                        elmenteni += "a;";
                }

                if (palyaszam - 1 < palyak.Count && palyaszam > 0)
                    palyak[palyaszam - 1] = elmenteni;
                else if (palyaszam  > palyak.Count)
                    palyak.Add(elmenteni);
                for (int i = 0; i < palyak.Count; i++)
                {
                    writer.WriteLine(palyak[i]);
                }
            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            var recs = from r in myGrid.Children.OfType<Rectangle>()
                       select r;
            foreach (var r in recs)
            {
                r.Fill = atlatszo;
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            var recs = from r in myGrid.Children.OfType<Rectangle>()
                       select r;
            string line;
            string kiolvasott ="";
            List<string> palyak = new List<string>();
            int palyaszam = -1;
            using (StreamReader reader = new StreamReader("..\\Data\\Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    palyak.Add(line);
                }

                int parsedInt;
                if (int.TryParse(tb_palya.Text, out parsedInt))
                {
                    palyaszam = parsedInt;
                }
                else palyaszam = 1;
                
                if (palyaszam > 0 && palyaszam <= palyak.Count)
                {
                    kiolvasott = palyak[palyaszam-1];
                    string[] szinek = kiolvasott.Split(';');
                    int i = 0;
                    foreach (var r in recs)
                    {
                        if (szinek[i] == "s")
                            r.Fill = sarga;
                        else if (szinek[i] == "k")
                            r.Fill = kek;
                        else if (szinek[i] == "p")
                            r.Fill = piros;
                        else if (szinek[i] == "z")
                            r.Fill = zold;
                        else if (szinek[i] == "c")
                            r.Fill = cian;
                        else if (szinek[i] == "m")
                            r.Fill = magenta;
                        else if (szinek[i] == "b")
                            r.Fill = barna;
                        else if (szinek[i] == "g")
                            r.Fill = szurke;
                        else if (szinek[i] == "f")
                            r.Fill = fekete;
                        else
                            r.Fill = atlatszo;
                        i++;
                    }

                }
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string line;
            List<string> palyak = new List<string>();
            int palyaszam = -1;
            using (StreamReader reader = new StreamReader("..\\Data\\Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    palyak.Add(line);
                }

                int parsedInt;
                if (int.TryParse(tb_palya.Text, out parsedInt))
                {
                    palyaszam = parsedInt;
                }
                else palyaszam = 1;

                if (palyaszam > 0 && palyaszam <= palyak.Count)
                {
                    palyak.RemoveAt(palyaszam - 1);
                }
            }
            
            using (StreamWriter torlo = new StreamWriter("..\\Data\\Data.csv"))
            {
                    for (int i = 0; i < palyak.Count; i++)
                    {
                        torlo.WriteLine(palyak[i]);
                    }
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (exit != null)
            {
                exit(this, e);
            }
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            if (play != null)
            {
                play(this, e);
            }
        }

        private void Szinez(Rectangle CurrentRectangle)
        {
            CurrentRectangle.Fill = szin;
        }

        #region negyzetek
        private void c00r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r00);
        }

        private void c07r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }
        private void c10r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r00);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r01);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r02);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }


        private void c00r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r03);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r04);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r05);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r06);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r07);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r08);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c00r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c00r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c01r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c01r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c02r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c02r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c03r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c03r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c04r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c04r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c05r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c05r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c06r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c06r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c07r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c07r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c08r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c08r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c09r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c09r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c10r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c10r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c11r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c11r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c12r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c12r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c13r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c13r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c14r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c14r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c15r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c15r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c16r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c16r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c17r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c17r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c18r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c18r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c19r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c19r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c20r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c20r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c21r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c21r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c22r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c22r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c23r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c23r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void c24r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szinez(c24r09);
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }
        #endregion

        
    }
}
