using System;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Windows;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        private int counter = 0;
        private const string FileName = "counter.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadCounterValue();
        }

        private void CounterButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            CounterText.Text = $"Нажатий: {counter}";
            SaveCounterValue();
        }

        private void LoadCounterValue()
        {
            if (File.Exists(FileName))
            {
                string value = File.ReadAllText(FileName);
                if (int.TryParse(value, out int loadedCounter))
                {
                    counter = loadedCounter;
                    CounterText.Text = $"Нажатий: {counter}";
                }
            }
        }

        private void SaveCounterValue()
        {
            File.WriteAllText(FileName, counter.ToString());
        }
    }
}
