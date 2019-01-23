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

    public partial class MainWindow : Window
    {
        public LevelComplete levelComplete = new LevelComplete();
        public LevelFailed levelFailed = new LevelFailed();
        public LevelSelect levelSelect = new LevelSelect();
        public MainMenu mainMenu = new MainMenu();
        public LevelEditor levelEditor = new LevelEditor();
        public Level1 level1 = new Level1(1,0);

        public MainWindow()
        {
            InitializeComponent();
            mainGrid.Children.Add(mainMenu);


            MainMenu.exit += new EventHandler(exit);
            MainMenu.selectlevel += new EventHandler(MainMenu_LevelSelect);
            MainMenu.leveleditor += new EventHandler(MainMenu_LevelEditor);
            LevelEditor.exit += new EventHandler(BackToMainMenu);
            LevelEditor.play += new EventHandler(PlayCustomLevel);

            LevelSelect.level1 += new EventHandler(LevelSelect_Level1);
            LevelSelect.level2 += new EventHandler(LevelSelect_Level2);
            LevelSelect.level3 += new EventHandler(LevelSelect_Level3);
            LevelSelect.level4 += new EventHandler(LevelSelect_Level4);
            LevelSelect.level5 += new EventHandler(LevelSelect_Level5);
            LevelSelect.level6 += new EventHandler(LevelSelect_Level6);
            LevelSelect.level7 += new EventHandler(LevelSelect_Level7);
            LevelSelect.level8 += new EventHandler(LevelSelect_Level8);
            LevelSelect.level9 += new EventHandler(LevelSelect_Level9);
            LevelSelect.level10 += new EventHandler(LevelSelect_Level10);
            LevelSelect.level11 += new EventHandler(LevelSelect_Level11);
            LevelSelect.level12 += new EventHandler(LevelSelect_Level12);
            LevelSelect.level13 += new EventHandler(LevelSelect_Level13);
            LevelSelect.level14 += new EventHandler(LevelSelect_Level14);
            LevelSelect.level15 += new EventHandler(LevelSelect_Level15);
            LevelSelect.level16 += new EventHandler(LevelSelect_Level16);
            LevelSelect.level17 += new EventHandler(LevelSelect_Level17);
            LevelSelect.level18 += new EventHandler(LevelSelect_Level18);
            LevelSelect.level19 += new EventHandler(LevelSelect_Level19);
            LevelSelect.level20 += new EventHandler(LevelSelect_Level20);
            LevelSelect.level21 += new EventHandler(LevelSelect_Level21);
            LevelSelect.level22 += new EventHandler(LevelSelect_Level22);
            LevelSelect.level23 += new EventHandler(LevelSelect_Level23);
            LevelSelect.level24 += new EventHandler(LevelSelect_Level24);
            LevelSelect.level25 += new EventHandler(LevelSelect_Level25);
            LevelSelect.level26 += new EventHandler(LevelSelect_Level26);
            LevelSelect.level27 += new EventHandler(LevelSelect_Level27);
            LevelSelect.level28 += new EventHandler(LevelSelect_Level28);
            LevelSelect.level29 += new EventHandler(LevelSelect_Level29);
            LevelSelect.level30 += new EventHandler(LevelSelect_Level30);
            LevelSelect.level31 += new EventHandler(LevelSelect_Level31);
            LevelSelect.level32 += new EventHandler(LevelSelect_Level32);
            LevelSelect.level33 += new EventHandler(LevelSelect_Level33);
            LevelSelect.level34 += new EventHandler(LevelSelect_Level34);
            LevelSelect.level35 += new EventHandler(LevelSelect_Level35);
            LevelSelect.level36 += new EventHandler(LevelSelect_Level36);
            LevelSelect.level37 += new EventHandler(LevelSelect_Level37);
            LevelSelect.level38 += new EventHandler(LevelSelect_Level38);
            LevelSelect.level39 += new EventHandler(LevelSelect_Level39);
            LevelSelect.level40 += new EventHandler(LevelSelect_Level40);
            LevelSelect.mainmenu += new EventHandler(BackToMainMenu);

            Level1.exit += new EventHandler(BackToMainMenu);

            LevelComplete.nextLevel += new EventHandler(LevelComplete_NextLevel);
            LevelFailed.restartLevel += new EventHandler(LevelFailed_RestartLevel);

        }

        public int currentLevel;


        void exit(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        void MainMenu_LevelSelect(object sender, EventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(levelSelect);
        }

        void MainMenu_LevelEditor(object sender, EventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(levelEditor);
        }

        void BackToMainMenu(object sender, EventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(mainMenu);
        }

        void PlayCustomLevel (object sender, EventArgs e)
        {
            int moves;
            int parsedInt;
            if (int.TryParse(levelEditor.tb_moves.Text, out parsedInt))
            {
                moves = parsedInt;
            }
            else moves = 1;

            int palyaszam;
            int parsedInt2;
            if (int.TryParse(levelEditor.tb_palya.Text, out parsedInt2))
            {
                palyaszam = parsedInt2;
            }
            else palyaszam = 2;

            level1 = new Level1(moves, palyaszam-1, true);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 999;
        }

        #region levelselect levels

        void LevelSelect_Level1(object sender, EventArgs e)
        {
            level1 = new Level1(1, 0);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 1;
        }
        void LevelSelect_Level2(object sender, EventArgs e)
        {
            level1 = new Level1(2, 1);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 2;
        }
        void LevelSelect_Level3(object sender, EventArgs e)
        {
            level1 = new Level1(3, 2);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 3;
        }
        void LevelSelect_Level4(object sender, EventArgs e)
        {
            level1 = new Level1(5, 3);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 4;
        }
        void LevelSelect_Level5(object sender, EventArgs e)
        {
            level1 = new Level1(3, 4);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 5;
        }
        void LevelSelect_Level6(object sender, EventArgs e)
        {
            level1 = new Level1(4, 5);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 6;
        }
        void LevelSelect_Level7(object sender, EventArgs e)
        {
            level1 = new Level1(4, 6);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel =7;
        }
        void LevelSelect_Level8(object sender, EventArgs e)
        {
            level1 = new Level1(4, 7);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 8;
        }
        void LevelSelect_Level9(object sender, EventArgs e)
        {
            level1 = new Level1(3, 8);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 9;
        }
        void LevelSelect_Level10(object sender, EventArgs e)
        {
            level1 = new Level1(4, 9);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 10;
        }
        void LevelSelect_Level11(object sender, EventArgs e)
        {
            level1 = new Level1(3, 10);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 11;
        }
        void LevelSelect_Level12(object sender, EventArgs e)
        {
            level1 = new Level1(4, 11);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 12;
        }
        void LevelSelect_Level13(object sender, EventArgs e)
        {
            level1 = new Level1(3, 12);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 13;
        }
        void LevelSelect_Level14(object sender, EventArgs e)
        {
            level1 = new Level1(3, 13);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 14;
        }
        void LevelSelect_Level15(object sender, EventArgs e)
        {
            level1 = new Level1(4, 14);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 15;
        }
        void LevelSelect_Level16(object sender, EventArgs e)
        {
            level1 = new Level1(4, 15);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 16;
        }
        void LevelSelect_Level17(object sender, EventArgs e)
        {
            level1 = new Level1(7, 16);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 17;
        }
        void LevelSelect_Level18(object sender, EventArgs e)
        {
            level1 = new Level1(7, 17);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 18;
        }
        void LevelSelect_Level19(object sender, EventArgs e)
        {
            level1 = new Level1(3, 18);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 19;
        }
        void LevelSelect_Level20(object sender, EventArgs e)
        {
            level1 = new Level1(3, 19);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 20;
        }
        void LevelSelect_Level21(object sender, EventArgs e)
        {
            level1 = new Level1(4, 20);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 21;
        }
        void LevelSelect_Level22(object sender, EventArgs e)
        {
            level1 = new Level1(4, 21);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 22;
        }
        void LevelSelect_Level23(object sender, EventArgs e)
        {
            level1 = new Level1(3, 22);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 23;
        }
        void LevelSelect_Level24(object sender, EventArgs e)
        {
            level1 = new Level1(5, 23);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 24;
        }
        void LevelSelect_Level25(object sender, EventArgs e)
        {
            level1 = new Level1(5, 24);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 25;
        }
        void LevelSelect_Level26(object sender, EventArgs e)
        {
            level1 = new Level1(4, 25);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 26;
        }
        void LevelSelect_Level27(object sender, EventArgs e)
        {
            level1 = new Level1(6, 26);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 27;
        }
        void LevelSelect_Level28(object sender, EventArgs e)
        {
            level1 = new Level1(5, 27);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 28;
        }
        void LevelSelect_Level29(object sender, EventArgs e)
        {
            level1 = new Level1(5, 28);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 29;
        }
        void LevelSelect_Level30(object sender, EventArgs e)
        {
            level1 = new Level1(5, 29);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 30;
        }
        void LevelSelect_Level31(object sender, EventArgs e)
        {
            level1 = new Level1(5, 30);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 31;
        }
        void LevelSelect_Level32(object sender, EventArgs e)
        {
            level1 = new Level1(5, 31);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 32;
        }
        void LevelSelect_Level33(object sender, EventArgs e)
        {
            level1 = new Level1(6, 32);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 33;
        }
        void LevelSelect_Level34(object sender, EventArgs e)
        {
            level1 = new Level1(3, 33);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 34;
        }
        void LevelSelect_Level35(object sender, EventArgs e)
        {
            level1 = new Level1(5, 34);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 35;
        }
        void LevelSelect_Level36(object sender, EventArgs e)
        {
            level1 = new Level1(5, 35);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 36;
        }
        void LevelSelect_Level37(object sender, EventArgs e)
        {
            level1 = new Level1(8, 36);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 37;
        }
        void LevelSelect_Level38(object sender, EventArgs e)
        {
            level1 = new Level1(4, 37);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 38;
        }
        void LevelSelect_Level39(object sender, EventArgs e)
        {
            level1 = new Level1(5, 38);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 39;
        }
        void LevelSelect_Level40(object sender, EventArgs e)
        {
            level1 = new Level1(100, 39);
            mainGrid.Children.Clear();
            mainGrid.Children.Add(level1);
            currentLevel = 40;
        }
        #endregion

        void LevelComplete_NextLevel(object sender, EventArgs e)
        {
            string nextlevel = "level" + (currentLevel + 1);
            mainGrid.Children.Clear();

            switch (currentLevel)
            {
                case 1: LevelSelect_Level2(null, null); break;
                case 2: LevelSelect_Level3(null, null); break;
                case 3: LevelSelect_Level4(null, null); break;
                case 4: LevelSelect_Level5(null, null); break;
                case 5: LevelSelect_Level6(null, null); break;
                case 6: LevelSelect_Level7(null, null); break;
                case 7: LevelSelect_Level8(null, null); break;
                case 8: LevelSelect_Level9(null, null); break;
                case 9: LevelSelect_Level10(null, null); break;
                case 10: LevelSelect_Level2(null, null); break;
                case 11: LevelSelect_Level2(null, null); break;
                case 12: LevelSelect_Level3(null, null); break;
                case 13: LevelSelect_Level4(null, null); break;
                case 14: LevelSelect_Level5(null, null); break;
                case 15: LevelSelect_Level6(null, null); break;
                case 16: LevelSelect_Level7(null, null); break;
                case 17: LevelSelect_Level8(null, null); break;
                case 18: LevelSelect_Level9(null, null); break;
                case 19: LevelSelect_Level10(null, null); break;
                case 20: LevelSelect_Level2(null, null); break;
                case 21: LevelSelect_Level2(null, null); break;
                case 22: LevelSelect_Level3(null, null); break;
                case 23: LevelSelect_Level4(null, null); break;
                case 24: LevelSelect_Level5(null, null); break;
                case 25: LevelSelect_Level6(null, null); break;
                case 26: LevelSelect_Level7(null, null); break;
                case 27: LevelSelect_Level8(null, null); break;
                case 28: LevelSelect_Level9(null, null); break;
                case 29: LevelSelect_Level10(null, null); break;
                case 30: LevelSelect_Level2(null, null); break;
                case 31: LevelSelect_Level2(null, null); break;
                case 32: LevelSelect_Level3(null, null); break;
                case 33: LevelSelect_Level4(null, null); break;
                case 34: LevelSelect_Level5(null, null); break;
                case 35: LevelSelect_Level6(null, null); break;
                case 36: LevelSelect_Level7(null, null); break;
                case 37: LevelSelect_Level8(null, null); break;
                case 38: LevelSelect_Level9(null, null); break;
                case 39: LevelSelect_Level10(null, null); break;
                case 40: BackToMainMenu(null, null); break;
                case 999: MainMenu_LevelEditor(null,null); break;
            }
            
        }
        void LevelFailed_RestartLevel(object sender, EventArgs e)
        {
            if (level1.custom == false)
                level1.btn_restart_Click(null, null);
            else
                level1.btn_custom_betolt();
        }
    }
}
