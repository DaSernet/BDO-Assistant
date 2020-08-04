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
using System.Windows.Shapes;

namespace BDOAssistant
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            ImperialPopup.IsChecked = Properties.Settings.Default.PopupImperial;
            BossesPopup.IsChecked = Properties.Settings.Default.PopupBosses;
            Update.IsChecked = Properties.Settings.Default.Update;
            Karanda.IsChecked = Properties.Settings.Default.Karanda;
            Kzarka.IsChecked = Properties.Settings.Default.Kzarka;
            Offin.IsChecked = Properties.Settings.Default.Offin;
            Kutum.IsChecked = Properties.Settings.Default.Kutum;
            Nouver.IsChecked = Properties.Settings.Default.Nouver;
            Vell.IsChecked = Properties.Settings.Default.Vell;
            Quint.IsChecked = Properties.Settings.Default.Quint;
            Garmoth.IsChecked = Properties.Settings.Default.Garmoth;
            Imperial0.IsChecked = Properties.Settings.Default.Imperial0;
            Imperial3.IsChecked = Properties.Settings.Default.Imperial3;
            Imperial6.IsChecked = Properties.Settings.Default.Imperial6;
            Imperial9.IsChecked = Properties.Settings.Default.Imperial9;
            Imperial12.IsChecked = Properties.Settings.Default.Imperial12;
            Imperial15.IsChecked = Properties.Settings.Default.Imperial15;
            Imperial18.IsChecked = Properties.Settings.Default.Imperial18;
            Imperial21.IsChecked = Properties.Settings.Default.Imperial21;
            OnTopMainwindow.IsChecked = Properties.Settings.Default.StayOnTopMain;
            //Sound.IsChecked = Properties.Settings.Default.Sound;
            Night.IsChecked = Properties.Settings.Default.Night;
            mins10.IsChecked = Properties.Settings.Default.Mins10;
            mins5.IsChecked = Properties.Settings.Default.Mins5;
            comboBox1.SelectedIndex = Properties.Settings.Default.Theme;
            RegionBox.SelectedIndex = Properties.Settings.Default.Region;
            OnSpawn.IsChecked = Properties.Settings.Default.OnSpawn;
            Seconds.IsChecked = Properties.Settings.Default.Seconds;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveExit_Click(object sender, RoutedEventArgs e)
        {
            //pop ups
            if (ImperialPopup.IsChecked == true)
            {
                Properties.Settings.Default.PopupImperial = true;
            }
            else
            {
                Properties.Settings.Default.PopupImperial = false;
            }
            if (BossesPopup.IsChecked == true)
            {
                Properties.Settings.Default.PopupBosses = true;
            }
            else
            {
                Properties.Settings.Default.PopupBosses = false;
            }
            if (Update.IsChecked == true)
            {
                Properties.Settings.Default.Update = true;
            }
            else
            {
                Properties.Settings.Default.Update = false;
            }

            //bosses
            if (Karanda.IsChecked == true)
            {
                Properties.Settings.Default.Karanda = true;
            }
            else
            {
                Properties.Settings.Default.Karanda = false;
            }
            if (Kzarka.IsChecked == true)
            {
                Properties.Settings.Default.Kzarka = true;
            }
            else
            {
                Properties.Settings.Default.Kzarka = false;
            }
            if (Offin.IsChecked == true)
            {
                Properties.Settings.Default.Offin = true;
            }
            else
            {
                Properties.Settings.Default.Offin = false;
            }
            if (Kutum.IsChecked == true)
            {
                Properties.Settings.Default.Kutum = true;
            }
            else
            {
                Properties.Settings.Default.Kutum = false;
            }
            if (Nouver.IsChecked == true)
            {
                Properties.Settings.Default.Nouver = true;
            }
            else
            {
                Properties.Settings.Default.Nouver = false;
            }
            if (Vell.IsChecked == true)
            {
                Properties.Settings.Default.Vell = true;
            }
            else
            {
                Properties.Settings.Default.Vell = false;
            }
            if (Quint.IsChecked == true)
            {
                Properties.Settings.Default.Quint = true;
            }
            else
            {
                Properties.Settings.Default.Quint = false;
            }
            if (Garmoth.IsChecked == true)
            {
                Properties.Settings.Default.Garmoth = true;
            }
            else
            {
                Properties.Settings.Default.Garmoth = false;
            }


            //Imperial times
            if (Imperial0.IsChecked == true)
            {
                Properties.Settings.Default.Imperial0 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial0 = false;
            }
            if (Imperial3.IsChecked == true)
            {
                Properties.Settings.Default.Imperial3 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial3 = false;
            }
            if (Imperial6.IsChecked == true)
            {
                Properties.Settings.Default.Imperial6 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial6 = false;
            }
            if (Imperial9.IsChecked == true)
            {
                Properties.Settings.Default.Imperial9 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial9 = false;
            }
            if (Imperial12.IsChecked == true)
            {
                Properties.Settings.Default.Imperial12 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial12 = false;
            }
            if (Imperial15.IsChecked == true)
            {
                Properties.Settings.Default.Imperial15 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial15 = false;
            }
            if (Imperial18.IsChecked == true)
            {
                Properties.Settings.Default.Imperial18 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial18 = false;
            }
            if (Imperial21.IsChecked == true)
            {
                Properties.Settings.Default.Imperial21 = true;
            }
            else
            {
                Properties.Settings.Default.Imperial21 = false;
            }

            //stay on top
            if (OnTopMainwindow.IsChecked == true)
            {
                Properties.Settings.Default.StayOnTopMain = true;
            }
            else
            {
                Properties.Settings.Default.StayOnTopMain = false;
            }

            //sound
            /*if (Sound.IsChecked == true)
            {
                Properties.Settings.Default.Sound = true;
            }
            else
            {
                Properties.Settings.Default.Sound = false;
            }*/

            //night
            if (Night.IsChecked == true)
            {
                Properties.Settings.Default.Night = true;
            }
            else
            {
                Properties.Settings.Default.Night = false;
            }


            //Boss timers when to remind
            if (mins5.IsChecked == true)
            {
                Properties.Settings.Default.Mins5 = true;
            }
            else
            {
                Properties.Settings.Default.Mins5 = false;
            }

            if (mins10.IsChecked == true)
            {
                Properties.Settings.Default.Mins10 = true;
            }
            else
            {
                Properties.Settings.Default.Mins10 = false;
            }

            if (OnSpawn.IsChecked == true)
            {
                Properties.Settings.Default.OnSpawn = true;
            }
            else
            {
                Properties.Settings.Default.OnSpawn = false;
            }


            //seconds
            if (Seconds.IsChecked == true)
            {
                Properties.Settings.Default.Seconds = true;
            }
            else
            {
                Properties.Settings.Default.Seconds = false;
            }

            //color
            bool StringEmpty = string.IsNullOrEmpty(ClrPcker_Background.SelectedColor.ToString());

            if (StringEmpty != true)
            { 
            Properties.Settings.Default.Color = ClrPcker_Background.SelectedColor.ToString();
            }

            //theme
            Properties.Settings.Default.Theme = comboBox1.SelectedIndex;

            //Region
            Properties.Settings.Default.Region = RegionBox.SelectedIndex;

            //save
            Properties.Settings.Default.Save();
            Close();
        }

        private void DefaultClick(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.IsDropDownOpen = false;
        }

        private void DragonballClick(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox1.IsDropDownOpen = false;
        }

        private void PrincessClick(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = 2;
            comboBox1.IsDropDownOpen = false;
        }
        private void GreyClick(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = 3;
            comboBox1.IsDropDownOpen = false;
        }

        private void EUClick(object sender, RoutedEventArgs e)
        {
            RegionBox.SelectedIndex = 0;
            RegionBox.IsDropDownOpen = false;
        }

        private void NAClick(object sender, RoutedEventArgs e)
        {
            RegionBox.SelectedIndex = 1;
            RegionBox.IsDropDownOpen = false;
        }

        private void ClrPcker_Background_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ClrPcker_Background.SelectedColor.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height = 680;
        }
    }
}
