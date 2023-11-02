using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace CsharpEditor
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

        private void txtStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCompile_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Clear();
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", txtFramework.Text } });
            CompilerParameters parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, txtOutput.Text, true);
            parameters.GenerateExecutable = true;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters, txtSource.Text);
            if (results.Errors.HasErrors)
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => txtStatus.Text += error.ErrorText + "\r\n");
            else
            {
                txtStatus.Text = "-------Build Succeeded-------";

                if (txtOutput.Text.Split('\\').Length == 1)
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + txtOutput.Text);
                }
                else
                {
                    Process.Start(txtOutput.Text);
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void txtSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFramework_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
