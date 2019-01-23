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

namespace szinek
{

    public partial class Level1 : UserControl
    {
        LevelComplete levelcomplete = new LevelComplete();
        LevelFailed Levelfailed = new LevelFailed();
        public static event EventHandler exit;

        public Level1(int Maxmoves, int Sor)
        {
            InitializeComponent();
            maxmoves = Maxmoves;
            moves = Maxmoves;
            currentSoraFajlban = Sor;
            lbl_counter.Text = "Moves: " + moves;
            btn_restart_Click(null, null);
        }

        public Level1(int Maxmoves, int Sor, bool Custom)
        {
            InitializeComponent();
            maxmoves = Maxmoves;
            custom = true;
            moves = Maxmoves;
            currentSoraFajlban = Sor;
            lbl_counter.Text = "Moves: " + moves;
            btn_custom_betolt();
        }
        public bool custom = false;
        int maxmoves;
        int moves;
        bool complete = false;
        public int currentSoraFajlban =1;
        List<string> megvizsgalt;

        private void LepesSzamCsokkenes()
        {
            int allCount = 0;
            int goodCount = 0;
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                if (r.Fill == c00r00.Fill)
                    goodCount++;
                allCount++;
            }
            if (allCount == goodCount)
            {
                complete = true;
                lbl_counter.Text = "Nyertél";
                levelcomplete.ShowDialog();
            }
            else
            {
                moves--;
                if (moves < 1 && !complete)
                {
                    lbl_counter.Text = "Moves: " + moves;
                    Levelfailed.ShowDialog();
                    moves = maxmoves;
                }
                lbl_counter.Text = "Moves: " + moves;
            }
            

        }

        private void winChecker()
        {
            int allCount = 0;
            int goodCount = 0;
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                if (r.Fill == c00r00.Fill)
                    goodCount++;
                allCount++;
            }
            if (allCount == goodCount)
            {
                complete = true;
                lbl_counter.Text = "Nyertél";
                levelcomplete.ShowDialog();
            }

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (exit != null)
            {
                exit(this, e);
            }
        }

        public void btn_restart_Click(object sender, RoutedEventArgs e)
        {
            moves = maxmoves;
            lbl_counter.Text = "Moves: " + moves;
            string line;
            string kiolvasott = "";
            List<string> palyak = new List<string>();

            var recs = from r in myGrid.Children.OfType<Rectangle>()
                        select r;

            using (StreamReader reader = new StreamReader("..\\Data\\Campaign.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    palyak.Add(line);
                }
                kiolvasott = palyak[currentSoraFajlban];
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

        public void btn_custom_betolt()
        {
            string line;
            string kiolvasott = "";
            List<string> palyak = new List<string>();

            var recs = from r in myGrid.Children.OfType<Rectangle>()
                       select r;

            using (StreamReader reader = new StreamReader("..\\Data\\Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    palyak.Add(line);
                }
                kiolvasott = palyak[currentSoraFajlban];
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


        private void kiszinez()
        {
            foreach (var r in myGrid.Children.OfType<Rectangle>())
            {
                foreach (var p in megvizsgalt)
                {
                    if (r.Name == p)
                        r.Fill = szin;
                }
            }
        }

        private void Szineketvizsgal(Rectangle CurrentRectangle)
        {

            Brush oldFill = CurrentRectangle.Fill;

            megvizsgalt.Add(CurrentRectangle.Name);

            int currentColoumnNumber = int.Parse(CurrentRectangle.Name.Substring(1, 2));
            int currentRowNumber = int.Parse(CurrentRectangle.Name.Substring(4, 2));

            string balraNeve = "", jobbraNeve = "", felettiNeve = "", alattiNeve = "";

            var cubes = from cube in myGrid.Children.OfType<Rectangle>()
                        select cube;

            if (currentColoumnNumber > 0)
                balraNeve = "c" + (currentColoumnNumber - 1).ToString("D2") + "r" + currentRowNumber.ToString("D2");


            if (currentColoumnNumber < 24)
                jobbraNeve = "c" + (currentColoumnNumber + 1).ToString("D2") + "r" + currentRowNumber.ToString("D2");

            if (currentRowNumber > 0)
                felettiNeve = "c" + currentColoumnNumber.ToString("D2") + "r" + (currentRowNumber - 1).ToString("D2");

            if (currentRowNumber < 15)
                alattiNeve = "c" + currentColoumnNumber.ToString("D2") + "r" + (currentRowNumber + 1).ToString("D2");

            var recs = from r in myGrid.Children.OfType<Rectangle>()
                       where ((r.Name == felettiNeve && oldFill == r.Fill)
                       || (r.Name == alattiNeve && oldFill == r.Fill)
                       || (r.Name == balraNeve && oldFill == r.Fill)
                       || (r.Name == jobbraNeve && oldFill == r.Fill)
                       )
                       select r;
            CurrentRectangle.Fill = szin;
            foreach (var r in recs)
            {
                if (!megvizsgalt.Contains(r.Name))
                    Szineketvizsgal(r);
            }

        }

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

        #region n

        private void c00r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r00); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r00); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r01); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r01); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r02); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r02); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r03); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r03); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r04); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r04); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r05); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r05); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r06); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r06); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r07); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r07); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r08); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r08); kiszinez(); LepesSzamCsokkenes();
        }

        private void c00r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c00r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c01r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c01r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c02r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c02r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c03r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c03r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c04r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c04r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c05r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c05r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c06r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c06r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c07r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c07r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c08r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c08r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c09r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c09r09); kiszinez(); LepesSzamCsokkenes();
        }
        private void c10r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c10r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c11r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c11r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c12r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c12r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c13r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c13r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c14r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c14r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c15r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c15r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c16r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c16r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c17r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c17r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c18r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c18r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c19r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c19r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c20r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c20r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c21r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c21r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c22r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c22r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c23r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c23r09); kiszinez(); LepesSzamCsokkenes();
        }

        private void c24r09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            megvizsgalt = new List<string>();
            Szineketvizsgal(c24r09); kiszinez(); LepesSzamCsokkenes();
        }


        #endregion
    }
}
