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

namespace BarCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtGenerate_Click(object sender, RoutedEventArgs e)
        {
            SPCode.Children.Clear();
            string code = Generator();
            //MessageBox.Show(code);

            string summ = (((int)code[0] + (int)code[2] + (int)code[4] + (int)code[6] + (int)code[8] + (int)code[10]) * 3 + (int)code[1] + (int)code[3] + (int)code[5] + (int)code[7] + (int)code[9] + (int)code[11]).ToString();            
            char controlSumm = (summ[summ.Length - 1]);

            TextBlock TbControlSumm = new TextBlock()
            {
                Text = "" + controlSumm,
                FontSize = 16,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 100, 1, 0)
            };
            SPCode.Children.Add(TbControlSumm);

            string binCode = "101";
            for (int i = 0; i < 3; i++)
            {
                SPCode.Children.Add(Draw(binCode[i], true));
            }

            StackPanel SPLeft = new StackPanel() 
            {
                Orientation = Orientation.Vertical,
                Height = 150
            };
            StackPanel SPLeftCode = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };
            SPCode.Children.Add(SPLeft);
            SPLeft.Children.Add(SPLeftCode);
            string gString = EAN_13.GetG(controlSumm);
            TextBlock TbLeftNumber = new TextBlock()
            {
                Text = "",
                FontSize = 16,
                TextAlignment = TextAlignment.Center,
            };
            SPLeft.Children.Add(TbLeftNumber);

            for (int i = 0; i < 6; i++)
            {
                string codeTemp = "";
                if (gString[i] == 'L')
                {
                    codeTemp = EAN_13.GetLeftG(code[i]);
                }
                if (gString[i] == 'G')
                {
                    codeTemp = EAN_13.GetLeftL(code[i]);
                }
                for(int j = 0; j < codeTemp.Length; j++)
                {
                    SPLeftCode.Children.Add(Draw(codeTemp[j], false));
                }
                TbLeftNumber.Text += " " + code[i];
            }



            binCode = "01010";
            for (int i = 0; i < 5; i++)
            {
                SPCode.Children.Add(Draw(binCode[i], true));
            }



            StackPanel SPRight = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Height = 150
            };
            SPCode.Children.Add(SPRight);

            StackPanel SPRightCode = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };
            SPRight.Children.Add(SPRightCode);

            TextBlock TbRightNumber = new TextBlock()
            {
                Text = "",
                FontSize = 16,
                TextAlignment = TextAlignment.Center,
            };
            SPRight.Children.Add(TbRightNumber);

            for (int i = 6; i < code.Length; i++)
            {
                string codeTemp = "";
                codeTemp = EAN_13.GetRight(code[i]);
                for (int j = 0; j < codeTemp.Length; j++)
                {
                    SPRightCode.Children.Add(Draw(codeTemp[j], false));
                }
                TbRightNumber.Text += " " + code[i];
            }

            binCode = "101";
            for (int i = 0; i < 3; i++)
            {
                SPCode.Children.Add(Draw(binCode[i], true));
            }
        }

        public static Rectangle Draw(char number, bool IsShield)
        {
            if (number == '1')
            {
                if(IsShield == true)
                {
                    Rectangle rec = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 120,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    return rec;
                }
                else
                {
                    Rectangle rec = new Rectangle()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    return rec;
                }            
            }
            else
            {
                if (IsShield == true)
                {
                    Rectangle rec = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 120,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    return rec;
                }
                else
                {
                    Rectangle rec = new Rectangle()
                    {
                        Stroke = Brushes.White,
                        StrokeThickness = 2,
                        SnapsToDevicePixels = true,
                        Height = 100
                    };
                    return rec;
                }
            }
        }
        public static string Generator()
        {
            Random randCode = new Random();
            string code = "";

            int dayTemp = randCode.Next(31);
            if (dayTemp < 10)
            {
                code += "0" + dayTemp.ToString();
            }
            else
            {
                code += dayTemp.ToString();
            }

            int mounthTemp = randCode.Next(12);
            if (mounthTemp < 10)
            {
                code += "0" + mounthTemp.ToString();
            }
            else
            {
                code += mounthTemp.ToString();
            }

            int yearTemp = randCode.Next(1, 22);
            if (yearTemp < 10)
            {
                code += "0" + yearTemp.ToString();
            }
            else
            {
                code += yearTemp.ToString();
            }

            for (int i = 0; i < 6; i++)
            {
                int numberTemp = randCode.Next(9);
                code += numberTemp.ToString();
            }
            return code;
        }

    }
}
