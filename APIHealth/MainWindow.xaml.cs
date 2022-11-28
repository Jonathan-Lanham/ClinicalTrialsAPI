using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using HealthAPILibrary;

namespace APIHealth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int minStudy = 1;
        private int rankNumber = 1;
        private string studyType;

        public MainWindow()
        {
            InitializeComponent();
            APIHelper.IntializeClient();
            previousImageButton.IsEnabled = false;
        }

        private void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            rankNumber--;
            if(rankNumber == 1)
            {
                LoadHealthInfo(rankNumber, studyType);
                previousImageButton.IsEnabled = false;
            }
            else
            {
                LoadHealthInfo(rankNumber, studyType);
            }
            Console.WriteLine(rankNumber);
        }

        private void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            rankNumber++;
            LoadHealthInfo(rankNumber,studyType);
            previousImageButton.IsEnabled = true;
            Console.WriteLine(rankNumber);
        }

        private async void LoadHealthInfo(int num, string study)
        {
            await HealthProcessorI2.LoadHealthInformation(num, study);

            string filePath = @"..\..\..\test.csv";

            List<string> healthInfo = File.ReadAllLines(filePath).ToList();

            IDtb.Text = $"{healthInfo[2]}";

            BriefTitle.Text = $"{healthInfo[0]}";

            BriefSummary.Text = $"{healthInfo[1]}";

            Condition.Text = $"{healthInfo[3]}";

            URL.Text = $"https://www.clinicaltrials.gov/ct2/show/{healthInfo[2]}?cond={studyType}&draw=2";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           //LoadHealthInfo(minStudy);

        }

        private void HealthInformation_Click(object sender, RoutedEventArgs e)
        {
            if (UserInput.Text == "")
            {
                MessageBox.Show("Please Input a Clinical Trial Study Type");
            }
            else
            {
                string userInput = UserInput.Text;
                userInput.Replace(" ", "+");
                studyType = userInput;
                LoadHealthInfo(minStudy, studyType);
                previousImageButton.IsEnabled = false;

            }

            
        }
    }
}
