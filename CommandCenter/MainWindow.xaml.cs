using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;

namespace BDOAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    //flotsdrue123 told me to turn everything into a map for C#
    //which is apparently a sorted dictionary in C#, we want to use time as the key

    public static class Extensions
    {
        public static SolidColorBrush ToBrush(this string HexColorString)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(HexColorString));
        }
    }



    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        int number = 1; //used to change compact mode
        bool displayed = true;

        public MainWindow()
        {
            InitializeComponent();
            _time = TimeSpan.FromSeconds(10);
            String CurrentTime;


            if (Properties.Settings.Default.FirstRun == 0)
            {
                MessageBox.Show("This is your first time running this version, please update your setttings!");
            }
            Properties.Settings.Default.FirstRun = 1;
            Properties.Settings.Default.Save();

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {

                //MessageBox.show("text");
                MainWindow1.Topmost = Properties.Settings.Default.StayOnTopMain;


                if (Properties.Settings.Default.Theme == 0)
                {
                    Theme1.Visibility = Visibility.Visible;
                    Theme2.Visibility = Visibility.Hidden;
                    Theme3.Visibility = Visibility.Hidden;
                }
                if (Properties.Settings.Default.Theme == 1)
                {
                    Theme2.Visibility = Visibility.Visible;
                    Theme1.Visibility = Visibility.Hidden;
                    Theme3.Visibility = Visibility.Hidden;
                }
                if (Properties.Settings.Default.Theme == 2)
                {
                    Theme3.Visibility = Visibility.Visible;
                    Theme2.Visibility = Visibility.Hidden;
                    Theme1.Visibility = Visibility.Hidden;
                }
                if (Properties.Settings.Default.Theme == 3)
                {
                    Theme2.Visibility = Visibility.Hidden;
                    Theme1.Visibility = Visibility.Hidden;
                    Theme3.Visibility = Visibility.Hidden;
                }




                String CustomColor = Properties.Settings.Default.Color;
                Twitch.Foreground = CustomColor.ToBrush();
                label_PreviousBoss.Foreground = CustomColor.ToBrush();
                Label_Boss.Foreground = CustomColor.ToBrush();
                Label1.Foreground = CustomColor.ToBrush();
                Label_Night.Foreground = CustomColor.ToBrush();
                PreviousBossNameBox.Foreground = CustomColor.ToBrush();
                BossNameBox.Foreground = CustomColor.ToBrush();
                BossTimeBox.Foreground = CustomColor.ToBrush();
                ImperialBox.Foreground = CustomColor.ToBrush();
                NightBox.Foreground = CustomColor.ToBrush();





                DateTime CurrentTime1 = DateTime.UtcNow;
                CurrentTime = CurrentTime1.ToString("HH:mm:ss");
                String CurrentDay = CurrentTime1.ToString("dddd", new CultureInfo("en-GB"));
                DateTime moment = CurrentTime1;




                int SummerTime = 0; //change value in case needed for +1 hour or -1 hour

                double ImperialMinutes = 59 - moment.Minute;
                double ImperialSeconds = 59 - moment.Second;

                double NightSeconds = 59 - moment.Second;
                double NightMinutes = 39 - moment.Minute;

                double BossSeconds = 59 - moment.Second;
                double BossMinutes = 59 - moment.Minute;

                int BossHours = 0;

                Boolean Condition = false;





                int NightHours = 0;
                int ImperialHours = 0;
                Boolean RemindForImperial = false;


                if (NightMinutes < 0)
                {
                    NightMinutes = NightMinutes + 60;
                }


                switch (moment.Hour)
                {
                    case 0:
                        NightHours = 3;
                        ImperialHours = 2;
                        break;
                    case 1:
                        NightHours = 2;
                        ImperialHours = 1;
                        break;
                    case 2:
                        NightHours = 1;
                        ImperialHours = 0;
                        break;
                    case 3:
                        NightHours = 0;
                        ImperialHours = 2;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        RemindForImperial = Properties.Settings.Default.Imperial3;
                        break;
                    case 4:
                        NightHours = 3;
                        ImperialHours = 1;
                        break;
                    case 5:
                        NightHours = 2;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial6;
                        break;
                    case 6:
                        NightHours = 1;
                        ImperialHours = 2;
                        break;
                    case 7:
                        NightHours = 0;
                        ImperialHours = 1;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        break;
                    case 8:
                        NightHours = 3;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial9;
                        break;
                    case 9:
                        NightHours = 2;
                        ImperialHours = 2;
                        break;
                    case 10:
                        NightHours = 1;
                        ImperialHours = 1;
                        break;
                    case 11:
                        NightHours = 0;
                        ImperialHours = 0;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        RemindForImperial = Properties.Settings.Default.Imperial12;
                        break;
                    case 12:
                        NightHours = 3;
                        ImperialHours = 2;
                        break;
                    case 13:
                        NightHours = 2;
                        ImperialHours = 1;
                        break;
                    case 14:
                        NightHours = 1;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial15;
                        break;
                    case 15:
                        NightHours = 0;
                        ImperialHours = 2;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        break;
                    case 16:
                        NightHours = 3;
                        ImperialHours = 1;
                        break;
                    case 17:
                        NightHours = 2;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial18;
                        break;
                    case 18:
                        NightHours = 1;
                        ImperialHours = 2;
                        break;
                    case 19:
                        NightHours = 0;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        ImperialHours = 1;
                        break;
                    case 20:
                        NightHours = 3;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial21;
                        break;
                    case 21:
                        NightHours = 2;
                        ImperialHours = 2;
                        break;
                    case 22:
                        NightHours = 1;
                        ImperialHours = 1;
                        break;
                    case 23:
                        NightHours = 0;
                        ImperialHours = 0;
                        RemindForImperial = Properties.Settings.Default.Imperial0;
                        if (moment.Minute >= 40)
                        {
                            NightHours = 4;
                        }
                        break;
                }

                if (moment.Minute >= 40)
                {
                    NightHours -= 1;
                }
                if (NightHours < 0)
                {
                    NightHours = 0;
                }

                CurrentTime1 = DateTime.UtcNow;
                CurrentTime1 = CurrentTime1.AddHours(0); //time changes
                CurrentDay = CurrentTime1.ToString("dddd", new CultureInfo("en-GB"));
                CurrentTime = CurrentTime1.ToString("HH:mm:ss");
                moment = CurrentTime1;

                if (Properties.Settings.Default.Region == 0)
                {
                    if (moment.Hour == 23 && moment.Minute < 15)
                    {
                        Condition = true;
                    }
                    else
                    {
                        Condition = false;
                    }


                    if (moment.Hour >= 18 || Condition)
                    {
                        BossMinutes = 45 - moment.Minute;
                        if (BossMinutes < 0)
                        {
                            BossMinutes = 15;
                        }
                        if (moment.Minute < 15)
                        {
                            BossMinutes = 15 - moment.Minute;
                        }
                        if (moment.Hour != 23)
                        {
                            if (moment.Minute >= 15)
                            {
                                BossMinutes = 74 - moment.Minute;
                            }
                        }
                        else
                        {
                            BossMinutes = 15 - moment.Minute;
                        }
                    }
                }

                if (Properties.Settings.Default.Region == 1)
                {
                    CurrentTime1 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Pacific Standard Time");
                    CurrentTime = CurrentTime1.ToString("HH:mm:ss");
                    CurrentDay = CurrentTime1.ToString("dddd", new CultureInfo("en-GB")); ;
                    moment = CurrentTime1;
                }

                int BossNumber = 0;

                if (Properties.Settings.Default.Region == 0)
                {
                    switch (CurrentDay)
                    {

                        case "Monday":
                            BossNumber = -1;
                            break;
                        case "Tuesday":
                            BossNumber = 7;
                            break;
                        case "Wednesday":
                            BossNumber = 15;
                            break;
                        case "Thursday":
                            BossNumber = 24;
                            break;
                        case "Friday":
                            BossNumber = 32;
                            break;
                        case "Saturday":
                            BossNumber = 40;
                            break;
                        case "Sunday":
                            BossNumber = 48;
                            break;
                    }
                }

                if (Properties.Settings.Default.Region == 1)
                {
                    switch (CurrentDay)
                    {

                        case "Monday":
                            BossNumber = -1;
                            break;
                        case "Tuesday":
                            BossNumber = 7;
                            break;
                        case "Wednesday":
                            BossNumber = 15;
                            break;
                        case "Thursday":
                            BossNumber = 24;
                            break;
                        case "Friday":
                            BossNumber = 32;
                            break;
                        case "Saturday":
                            BossNumber = 40;
                            break;
                        case "Sunday":
                            BossNumber = 48;
                            break;
                    }
                }


                if (Properties.Settings.Default.Region == 0) //eu, working!
                {
                    switch (moment.Hour)
                    {
                        case 0:
                            BossNumber += 1;
                            BossHours = 0;
                            break;
                        case 1:
                            BossNumber += 2;
                            BossHours = 2;
                            break;
                        case 2:
                            BossNumber += 2;
                            BossHours = 1;
                            break;
                        case 3:
                            BossNumber += 2;
                            BossHours = 0;
                            break;
                        case 4:
                            BossNumber += 3;
                            BossHours = 3;
                            break;
                        case 5:
                            BossNumber += 3;
                            BossHours = 2;
                            break;
                        case 6:
                            BossNumber += 3;
                            BossHours = 1;
                            break;
                        case 7:
                            BossNumber += 3;
                            BossHours = 0;
                            break;
                        case 8:
                            BossNumber += 4;
                            BossHours = 2;
                            break;
                        case 9:
                            BossNumber += 4;
                            BossHours = 1;
                            break;
                        case 10:
                            BossNumber += 4;
                            BossHours = 0;
                            break;
                        case 11:
                            BossNumber += 5;
                            BossHours = 3;
                            break;
                        case 12:
                            BossNumber += 5;
                            BossHours = 2;
                            break;
                        case 13:
                            BossNumber += 5;
                            BossHours = 1;
                            break;
                        case 14:
                            BossNumber += 5;
                            BossHours = 0;
                            break;
                        case 15:
                            BossNumber += 6;
                            BossHours = 2;
                            break;
                        case 16:
                            BossNumber += 6;
                            BossHours = 1;
                            break;
                        case 17:
                            BossNumber += 6;
                            BossHours = 0;
                            break;
                        case 18:
                            BossNumber += 7;
                            BossHours = 3;
                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 5;
                            }
                            if (moment.Minute >= 15)
                            {
                                BossHours = BossHours - 1;
                            }
                            break;
                        case 19:
                            BossNumber += 7;
                            BossHours = 2;
                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 4;
                            }
                            if (moment.Minute >= 15)
                            {
                                BossHours = BossHours - 1;
                            }
                            break;
                        case 20:
                            BossNumber += 7;
                            BossHours = 1;
                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 3;
                            }
                            if (moment.Minute >= 15)
                            {
                                BossHours = BossHours - 1;
                            }

                            break;
                        case 21:
                            BossNumber += 7;
                            BossHours = 0;
                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 2;
                                if (moment.Minute >= 15)
                                {
                                    BossNumber -= 1;
                                }
                            }
                            if (moment.Minute >= 15)
                            {
                                BossNumber += 1;
                                BossHours = BossHours - 1;
                                if (CurrentDay != "Wednesday")
                                {
                                    BossHours = 1;
                                }
                                if (BossHours < 0)
                                {
                                    BossHours = 0;
                                }
                            }

                            break;
                        case 22:
                            BossNumber += 8;
                            BossHours = 1;
                            if (CurrentDay == "Wednesday")
                            {
                                BossHours = 0;
                            }
                            if (moment.Minute >= 15)
                            {
                                if (CurrentDay == "Wednesday")
                                {
                                    BossNumber += 1;
                                }
                                BossHours = 0;
                                if (BossHours < 0)
                                {
                                    BossHours = 0;
                                }
                            }

                            break;
                        case 23:

                            BossNumber += 8;
                            BossHours = 0;
                            if (CurrentDay == "Wednesday")
                            {
                                BossNumber += 1;
                            }
                            if (moment.Minute >= 15)
                            {
                                BossNumber += 1;
                                BossHours = 1;
                                BossMinutes = 59 - moment.Minute;
                            }
                            break;
                    }
                }





                if (Properties.Settings.Default.Region == 1) //NA not working (just like their damage)
                {
                    switch (moment.Hour)
                    {
                        case 0:
                            BossNumber += 2;
                            BossHours = 2;
                            break;
                        case 1:
                            BossNumber += 2;
                            BossHours = 1;
                            break;
                        case 2:
                            BossNumber += 2;
                            BossHours = 0;
                            break;
                        case 3:
                            BossNumber += 3;
                            BossHours = 3;
                            break;
                        case 4:
                            BossNumber += 3;
                            BossHours = 2;
                            break;
                        case 5:
                            BossNumber += 3;
                            BossHours = 1;
                            break;
                        case 6:
                            BossNumber += 3;
                            BossHours = 0;
                            break; //correct
                        case 7:
                            BossNumber += 4;
                            BossHours = 2;
                            break;
                        case 8:
                            BossNumber += 4;
                            BossHours = 1;
                            break;
                        case 9:
                            BossNumber += 4;
                            BossHours = 0;
                            break; //correct?
                        case 10:
                            BossNumber += 5;
                            BossHours = 3;
                            break;
                        case 11:
                            BossNumber += 5;
                            BossHours = 2;
                            break;
                        case 12:
                            BossNumber += 5;
                            BossHours = 1;
                            break;
                        case 13:
                            BossNumber += 5;
                            BossHours = 0;
                            break; //correct?
                        case 14:
                            BossNumber += 6;
                            BossHours = 2;
                            break;
                        case 15:
                            BossNumber += 6;
                            BossHours = 1;
                            break;
                        case 16:
                            BossNumber += 6;
                            BossHours = 0;
                            break; //correct?
                        case 17:
                            BossNumber += 7;
                            BossHours = 3;
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;
                            }
                            else
                            {
                                BossHours -= 1;
                            }

                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 5;
                                if (moment.Minute >= 15)
                                {
                                    BossMinutes = 74 - moment.Minute;
                                    BossHours -= 1;
                                }
                            }

                            break; //this is where it goes dumb dumb
                        case 18:
                            BossNumber += 7;
                            BossHours = 2;
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;
                            }
                            else
                            {
                                BossHours -= 1;
                            }

                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 4;
                                if (moment.Minute >= 15)
                                {
                                    BossMinutes = 74 - moment.Minute;
                                    BossHours -= 1;
                                }
                            }

                            break;
                        case 19:
                            BossNumber += 7;
                            BossHours = 1;
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;
                            }
                            else
                            {
                                BossHours -= 1;
                            }
                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 3;
                                if (moment.Minute >= 15)
                                {
                                    BossMinutes = 74 - moment.Minute;
                                    BossHours -= 1;
                                }
                            }
                            break;
                        case 20:
                            BossNumber += 7;
                            BossHours = 0;
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;
                                if (CurrentDay == "Saturday")
                                {
                                    BossHours = 2;
                                    BossNumber += 1;
                                }
                            }
                            else
                            {
                                BossMinutes = 74 - moment.Minute;
                                BossNumber += 1;
                                BossHours = 1;
                            }
                            if (CurrentDay == "Wednesday")
                            {
                                BossHours = 0;
                            }


                            break;
                        case 21:
                            BossNumber += 8;
                            BossHours = 1;
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;

                                if (CurrentDay == "Wednesday")
                                {
                                    BossHours = 0;
                                }
                            }
                            else
                            {
                                BossMinutes = 74 - moment.Minute;
                                BossHours = 0;
                                if (CurrentDay == "Wednesday")
                                {
                                    BossNumber += 1;
                                }
                            }

                            break;
                        case 22:
                            BossNumber += 8;
                            BossHours = 0;
                            if (CurrentDay == "Wednesday")
                            {
                                BossNumber += 1;
                            }
                            if (moment.Minute < 15)
                            {
                                BossMinutes = 15 - moment.Minute;
                            }
                            else
                            {
                                BossNumber += 1;
                                BossHours = 1;
                            }

                            if (CurrentDay == "Saturday")
                            {
                                BossNumber += 1;
                                BossHours = 0;
                            }
                            break;
                        case 23:
                            BossNumber += 9;
                            BossHours = 0;
                            if (CurrentDay == "Wednesday")
                            {
                                BossNumber += 1;
                            }
                            break;
                    }
                }



                NightHours = NightHours + SummerTime;
                ImperialHours = ImperialHours + SummerTime; // adds or removes an hour incase needed for summer time

                String fillerMinutes = "";
                String fillerSeconds = "";
                String fillerHours = "0";

                if (ImperialMinutes < 10)
                {
                    fillerMinutes = "0";
                }
                else
                {
                    fillerMinutes = "";
                }
                if (ImperialSeconds < 10)
                {
                    fillerSeconds = "0";
                }
                else
                {
                    fillerSeconds = "";
                }


                String fillerMinutes1 = "";
                String fillerSeconds1 = "";
                String fillerHours1 = "0";

                if (NightMinutes < 10)
                {
                    fillerMinutes1 = "0";
                }
                else
                {
                    fillerMinutes1 = "";
                }
                if (NightSeconds < 10)
                {
                    fillerSeconds1 = "0";
                }
                else
                {
                    fillerSeconds1 = "";
                }

                String fillerMinutes2 = "";
                String fillerSeconds2 = "";
                String fillerHours2 = "0";



                if (BossMinutes < 10)
                {
                    fillerMinutes2 = "0";
                }
                else
                {
                    fillerMinutes2 = "";
                }
                if (BossSeconds < 10)
                {
                    fillerSeconds2 = "0";
                }
                else
                {
                    fillerSeconds2 = "";
                }


                String ImperialTime = $"{fillerHours}{ImperialHours}:{fillerMinutes}{ImperialMinutes}:{fillerSeconds}{ImperialSeconds}";
                String BossTime = $"{fillerHours2}{BossHours}:{fillerMinutes2}{BossMinutes}:{fillerSeconds2}{BossSeconds}";
                String NightTime = $"{fillerHours1}{NightHours}:{fillerMinutes1}{NightMinutes}:{fillerSeconds1}{NightSeconds}";

                if (Properties.Settings.Default.Seconds == true)
                {
                    ImperialBox.Text = $"{fillerHours}{ImperialHours}:{fillerMinutes}{ImperialMinutes}:{fillerSeconds}{ImperialSeconds}";
                    BossTimeBox.Text = $"{fillerHours2}{BossHours}:{fillerMinutes2}{BossMinutes}:{fillerSeconds2}{BossSeconds}";
                    if (NightHours == 3 && NightMinutes >= 20)
                    {
                        NightBox.Text = "Now";
                    }
                    else
                    {
                        NightBox.Text = $"{fillerHours1}{NightHours}:{fillerMinutes1}{NightMinutes}:{fillerSeconds1}{NightSeconds}";
                    }
                }
                else
                {
                    ImperialBox.Text = $"{fillerHours}{ImperialHours}:{fillerMinutes}{ImperialMinutes}";
                    BossTimeBox.Text = $"{fillerHours2}{BossHours}:{fillerMinutes2}{BossMinutes}";
                    if (NightHours == 3 && NightMinutes >= 20)
                    {
                        NightBox.Text = "Now";
                    }
                    else
                    {
                        NightBox.Text = $"{fillerHours1}{NightHours}:{fillerMinutes1}{NightMinutes}";
                    }
                }


                String[] ImperialReminderTimes = { "00:10:01", "00:10:99", "00:01:01", "00:01:99" };
                String[] NightReminderTimes = { "00:00:02", "00:00:99" };

                List<String> timeList = new List<String>();

                if (Properties.Settings.Default.Mins10 == true)
                {
                    timeList.Add("00:10:99");
                    timeList.Add("00:10:01");
                }
                else
                {
                    timeList.Add("99:99:99");
                    timeList.Add("99:99:99");
                }
                if (Properties.Settings.Default.Mins5 == true)
                {
                    timeList.Add("00:05:99");
                    timeList.Add("00:05:01");
                }
                else
                {
                    timeList.Add("99:99:99");
                    timeList.Add("99:99:99");
                }
                if (Properties.Settings.Default.OnSpawn == true)
                {
                    timeList.Add("00:00:02");
                    timeList.Add("00:00:99");
                }
                else
                {
                    timeList.Add("99:99:99");
                    timeList.Add("99:99:99");
                }

                String[] BossReminderTimes = timeList.ToArray();
                String BossName = "DaSe";
                int PrevBossNumber = BossNumber - 1;
                if (PrevBossNumber == -1)
                {
                    PrevBossNumber = 57;
                }
                String PrevBossName = NextBoss(PrevBossNumber);
                BossName = NextBoss(BossNumber);
                BossNameBox.Text = BossName;
                PreviousBossNameBox.Text = PrevBossName;


                Properties.Settings.Default.RemindNextBoss = false;

                if (Properties.Settings.Default.Karanda == true)
                {
                    if (BossName.Contains("Karanda"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Kzarka == true)
                {
                    if (BossName.Contains("Kzarka"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Offin == true)
                {
                    if (BossName.Contains("Offin"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Kutum == true)
                {
                    if (BossName.Contains("Kutum"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Nouver == true)
                {
                    if (BossName.Contains("Nouver"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Vell == true)
                {
                    if (BossName.Contains("Vell"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Garmoth == true)
                {
                    if (BossName.Contains("Garmoth"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }
                if (Properties.Settings.Default.Quint == true)
                {
                    if (BossName.Contains("Quint"))
                    {
                        Properties.Settings.Default.RemindNextBoss = true;
                        Properties.Settings.Default.Save();

                    }
                }

                //boss reminder notifications
                if (Properties.Settings.Default.PopupBosses == true && Properties.Settings.Default.RemindNextBoss == true)
                {
                    for (int counter = 0; counter < 6; counter++)
                    {
                        if (BossName == "Vell" && BossTime == "00:30:01")
                        {
                            SendNotification(BossName, BossName + " spawns in 30! Set sail!");
                        }

                        if (BossName == "Vell" && BossTime == "00:15:01")
                        {
                            SendNotification(BossName, BossName + "spawned, last chance to leave!");
                        }
                        if (BossName != "Vell")
                        {
                            if (BossTime == BossReminderTimes[counter])
                            {
                                if (BossReminderTimes[counter] == "00:10:01" || BossReminderTimes[counter] == "00:10:02")
                                {
                                    SendNotification(BossName, BossName + " spawns in 10 minutes!");
                                }
                                if (BossReminderTimes[counter] == "00:05:01" || BossReminderTimes[counter] == "00:05:02")
                                {
                                    SendNotification(BossName, BossName + " spawns in 5 minutes!");
                                }
                                if (BossReminderTimes[counter] == "00:00:01" || BossReminderTimes[counter] == "00:00:02")
                                {
                                    SendNotification(BossName, BossName + " is spawning!");
                                }
                            }
                            Properties.Settings.Default.RemindNextBoss = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                }

                // night time reminder notifications
                if (Properties.Settings.Default.Night == true)
                {
                    for (int counter = 0; counter < 2; counter++)
                    {
                        if (NightTime == NightReminderTimes[counter])
                        {
                            SendNotification("Night time", "Night time has just started!");
                            Properties.Settings.Default.Night = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                }

                //RemindForImperial = true;

                // imperial reminder notifications!
                if (Properties.Settings.Default.PopupImperial == true && displayed == true && RemindForImperial == true)
                {
                    for (int counter = 0; counter < 2; counter++)
                    {
                        if (ImperialTime == ImperialReminderTimes[counter])
                        {
                            SendNotification("Imperial reminder", "Imperial in 10 minutes!");
                            displayed = false;

                        }
                    }
                    for (int counter = 2; counter < 4; counter++)
                    {
                        if (ImperialTime == ImperialReminderTimes[counter])
                        {
                            SendNotification("Imperial reminder", "Imperial in 1 minute!");
                            displayed = false;
                        }
                    }
                }


                //resets the ability to display the imperial reminder window
                String[] ImperialReminderResetTimes = { "00:09:01", "00:09:00", "00:00:10", "00:00:11" };
                for (int counter2 = 0; counter2 < 4; counter2++)
                {
                    if (ImperialTime == ImperialReminderResetTimes[counter2])
                    {
                        displayed = true;
                    }
                }

                DebugTime.Text = CurrentTime;
                DebugBossNumber.Text = Convert.ToString(BossNumber);
                DebugDay.Text = CurrentDay;

            }, Application.Current.Dispatcher);

            _timer.Start();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (number == 3)
            {
                Application.Current.MainWindow.Height = 548;
                ImperialBox.Margin = new System.Windows.Thickness(74, 279, 0, 0);
                BossTimeBox.Margin = new System.Windows.Thickness(74, 201, 0, 0);
                BossNameBox.Margin = new System.Windows.Thickness(56, 151, 0, 0);
                NightBox.Margin = new System.Windows.Thickness(74, 372, 0, 0);
                Label1.Content = "Time until next imperial";
                Label1.Margin = new System.Windows.Thickness(30, 237, 0, 0);
                Label_Night.Content = "Time until next night";
                Label_Night.Margin = new System.Windows.Thickness(30, 325, 0, 0);
                Label_Boss.Content = "Next boss info";
                Label_Boss.Margin = new System.Windows.Thickness(66, 104, 0, 0);
                Compacter.Content = "Compact";
                number = 0;
                label_PreviousBoss.Visibility = Visibility.Visible;
                PreviousBossNameBox.Visibility = Visibility.Visible;
            }
            if (number == 2)
            {
                Application.Current.MainWindow.Height = 60;
                Compacter.Content = "Uncompact";
            }
            if (number == 1)
            {
                Application.Current.MainWindow.Height = 295;

                ImperialBox.Margin = new System.Windows.Thickness(113, 121, 0, 0);
                BossTimeBox.Margin = new System.Windows.Thickness(113, 80, 0, 0);
                BossNameBox.Margin = new System.Windows.Thickness(92, 39, 0, 0);
                NightBox.Margin = new System.Windows.Thickness(113, 162, 0, 0);
                Label1.Content = "Imperial";
                Label1.Margin = new System.Windows.Thickness(12, 118, 0, 0);
                Label_Night.Content = "Night";
                Label_Night.Margin = new System.Windows.Thickness(12, 159, 0, 0);
                Label_Boss.Content = "Boss";
                Label_Boss.Margin = new System.Windows.Thickness(12, 52, 0, 0);
                label_PreviousBoss.Visibility = Visibility.Hidden;
                PreviousBossNameBox.Visibility = Visibility.Hidden;


                Compacter.Content = "Compacter";
            }
            number++;
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }



        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            {
                s.Show();
            }

        }

        public void SendNotification(String Title, String Message)
        {
            if (Properties.Settings.Default.Sound == true)
            {
                SystemSounds.Beep.Play();
            }
            Notification notification = new Notification();
            notification.ShowNotification(Title, Message);
        }



        public String NextBoss(int BossNumber)
        {
            String NextBossName = "DaSe";
            //string[] NextBoss = File.ReadAllLines(@".\BossSchedule.txt", Encoding.UTF8);


            String[] Nextboss = { "1", "2" };

            if (Properties.Settings.Default.Region == 0)
            {
                Nextboss = new string[] { "Karanda", "Kzarka", "Kzarka", "Offin", "Kutum", "Nouver", "Kzarka", "Karanda", "Kutum", "Kzarka", "Nouver", "Kutum", "Nouver", "Karanda", "Garmoth", "Kzarka/Kutum", "Karanda", "Kzarka", "Karanda", "Maintenance", "Kutum", "Offin", "Karanda/Kzarka", "Quint/Muraka", "Nouver", "Kutum", "Nouver", "Kutum", "Nouver", "Kzarka", "Kutum", "Garmoth", "Karanda/Kzarka", "Nouver", "Karanda", "Kutum", "Karanda", "Nouver", "Kzarka", "Kzarka/Kutum", "Karanda", "Offin", "Nouver", "Kutum", "Nouver", "Quint/Muraka", "Karanda/Kzarka", "N/A", "Nouver/Kutum", "Kzarka", "Kutum", "Nouver", "Kzarka", "Vell", "Garmoth", "Kzarka/Nouver", "Karanda/Kutum", "Karanda" };
            }
            if (Properties.Settings.Default.Region == 1)
            {
                Nextboss = new string[] { "Karanda", "Kzarka", "Kzarka", "Offin", "Kutum", "Nouver", "Kzarka", "Karanda", "Kutum", "Kzarka", "Nouver", "Kutum", "Nouver", "Karanda", "Garmoth", "Kzarka/Kutum", "Karanda", "Maintenance", "Karanda", "Nouver", "Kutum", "Offin", "Karanda/Kzarka", "Quint/Muraka", "Nouver", "Kutum ", "Kzarka", "Kutum", "Nouver", "Kzarka", "Kutum", "Garmoth", "Karanda/Kzarka", "Nouver", "Karanda", "Kutum", "Karanda", "Nouver", "Kzarka", "Kzarka/Kutum", "Karanda", "Offin", "Nouver", "Kutum", "Nouver", "Quint/Muraka", "Karanda/Kzarka", "N/A", "Kutum/Nouver", "Kzarka", "Kutum", "Nouver", "Kzarka", "Vell", "Garmoth", "Kzarka/Nouver", "Karanda/Kutum", "Karanda" };
            }

            return NextBossName = Nextboss[BossNumber];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitch.com/Tanker_DaSe");
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/fkEpW7Z");
        }

        private async void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckNet() == true && Properties.Settings.Default.Update == true)
            {
                await Task.Delay(1000);
                dynamic doc = webBrowser.Document;
                var htmlText = doc.documentElement.InnerHtml;
                String NewestVersion = Convert.ToString(htmlText);

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                string currentVersion = fileVersionInfo.ProductVersion;


                if (NewestVersion.Contains(currentVersion))
                {

                }
                else
                {
                    MessageBox.Show("Your version is outdated, update available on https://discord.gg/fkEpW7Z");
                }
            }
        }

        private bool CheckNet()
        {
            bool stats;

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                stats = true;
            }
            else
            {
                stats = false;
            }
            return stats;
        }
    }
}
