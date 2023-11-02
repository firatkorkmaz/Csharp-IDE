using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void browseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                filePath.Text = filename;
            }
        }

        private void loadFile_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = null;

            if (File.Exists(filePath.Text))
            {
                string[] lines = File.ReadAllLines(filePath.Text);
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    if (i != lines.GetLength(0) - 1)
                        textBox1.Text = string.Concat(textBox1.Text, lines[i] + "\n");
                    else
                        textBox1.Text = string.Concat(textBox1.Text, lines[i]);
                }
            }

            else if (filePath.Text == "")
            {
                MessageBox.Show("No file selected!", "Caution");
                //return;
            }
            else
            {
                MessageBox.Show("No such file exists!", "Caution");
            }
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(filePath.Text))
            {
                File.WriteAllText(filePath.Text, textBox1.Text);
                MessageBox.Show("File saved.", "Message");
            }
            else if (filePath.Text == "")
            {
                MessageBox.Show("No file selected!", "Caution");
                //return;
            }
            else
            {
                MessageBox.Show("No such file exists!", "Caution");
            }
        }

        private void filePath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void runCode_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filePath_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }



    }
}