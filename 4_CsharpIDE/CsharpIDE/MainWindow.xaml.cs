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

namespace CsharpIDE
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

        private void programPath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void programBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.DefaultExt = ".txt";
            //dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# Source Files (.cs)|*.cs";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                programPath.Text = filename;
            }
        }

        private void loadProgram_Click(object sender, RoutedEventArgs e)
        {
            if (programPath.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Load!");
            }

            else
            {
                programText.Text = null;
                string[] lines = File.ReadAllLines(programPath.Text);
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    if (i != lines.GetLength(0) - 1)
                        programText.Text = string.Concat(programText.Text, lines[i] + "\n");
                    else
                        programText.Text = string.Concat(programText.Text, lines[i]);
                }

                programBlock.Text = "Program File : " + System.IO.Path.GetFileName(programPath.Text);

                /*foreach (string lines in File.ReadLines(programPath.Text))
                {
                    programText.Text = string.Concat(programText.Text, lines + "\n");
                }*/
            }
        }


        private void programSave_Click_1(object sender, RoutedEventArgs e)
        {
            programPath.Text = programPath.Text.Trim(new char[] { ' ', '\t', '\n' });
            if (programPath.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Program"; // Default file name
                dlg.DefaultExt = ".cs"; // Default file extension
                dlg.Filter = "C# Source File (.cs)|*.cs"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    programPath.Text = filename;
                    File.WriteAllText(programPath.Text, programText.Text);
                    //programBlock.Text = "Program File : " + System.IO.Path.GetFileName(programPath.Text);

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                }
            }
            else
            {
                File.WriteAllText(programPath.Text, programText.Text);
            }
        }

        private void programReset_Click(object sender, RoutedEventArgs e)
        {
            programPath.Clear();
            // programText.Clear();
            // programBlock.Clear();
        }

        private void programClear_Click(object sender, RoutedEventArgs e)
        {
            programText.Clear();
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        private void classPath1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void classBrowse1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.DefaultExt = ".txt";
            //dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# Source Files (.cs)|*.cs";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                classPath1.Text = filename;
            }
        }

        private void classLoad1_Click(object sender, RoutedEventArgs e)
        {
            if (classPath1.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Load!");
            }

            else
            {
                classText1.Text = null;

                string[] lines = File.ReadAllLines(classPath1.Text);
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    if (i != lines.GetLength(0) - 1)
                        classText1.Text = string.Concat(classText1.Text, lines[i] + "\n");
                    else
                        classText1.Text = string.Concat(classText1.Text, lines[i]);
                }

                classBlock1.Text = "Class-1 File : " + System.IO.Path.GetFileName(classPath1.Text);

                /*foreach (string lines in File.ReadLines(programPath.Text))
                {
                    programText.Text = string.Concat(programText.Text, lines + "\n");
                }*/
            }
        }

        private void classText1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void classReset1_Click(object sender, RoutedEventArgs e)
        {
            classPath1.Clear();
            //classText1.Clear();
            //classBlock1.Clear();
        }

        private void classClear1_Click(object sender, RoutedEventArgs e)
        {
            classText1.Clear();
        }

        private void classSave1_Click(object sender, RoutedEventArgs e)
        {
            classPath1.Text = classPath1.Text.Trim(new char[] { ' ', '\t', '\n' });
            if (classPath1.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Class-1"; // Default file name
                dlg.DefaultExt = ".cs"; // Default file extension
                dlg.Filter = "C# Class File (.cs)|*.cs"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    classPath1.Text = filename;
                    File.WriteAllText(classPath1.Text, classText1.Text);
                    //classBlock1.Text = "Class-1 File : " + System.IO.Path.GetFileName(classPath1.Text);

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                }
            }
            else
            {
                File.WriteAllText(classPath1.Text, classText1.Text);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        private void classPath2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void classBrowse2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.DefaultExt = ".txt";
            //dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# Source Files (.cs)|*.cs";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                classPath2.Text = filename;
            }
        }

        private void classLoad2_Click(object sender, RoutedEventArgs e)
        {
            if (classPath2.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Load!");
            }

            else
            {
                classText2.Text = null;

                string[] lines = File.ReadAllLines(classPath2.Text);
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    if (i != lines.GetLength(0) - 1)
                        classText2.Text = string.Concat(classText2.Text, lines[i] + "\n");
                    else
                        classText2.Text = string.Concat(classText2.Text, lines[i]);
                }

                classBlock2.Text = "Class-2 File : " + System.IO.Path.GetFileName(classPath2.Text);

                /*foreach (string lines in File.ReadLines(programPath.Text))
                {
                    programText.Text = string.Concat(programText.Text, lines + "\n");
                }*/
            }
        }

        private void classText2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void classReset2_Click(object sender, RoutedEventArgs e)
        {
            classPath2.Clear();
            //classText2.Clear();
            //classBlock2.Clear();
        }

        private void classClear2_Click(object sender, RoutedEventArgs e)
        {
            classText2.Clear();
        }

        private void classSave2_Click(object sender, RoutedEventArgs e)
        {
            classPath2.Text = classPath2.Text.Trim(new char[] { ' ', '\t', '\n' });
            if (classPath2.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Class-2"; // Default file name
                dlg.DefaultExt = ".cs"; // Default file extension
                dlg.Filter = "C# Class File (.cs)|*.cs"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    classPath2.Text = filename;
                    File.WriteAllText(classPath2.Text, classText2.Text);
                    //classBlock2.Text = "Class-2 File : " + System.IO.Path.GetFileName(classPath2.Text);

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                }
            }
            else
            {
                File.WriteAllText(classPath2.Text, classText2.Text);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        private void statusText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////

        private void allReset_Click(object sender, RoutedEventArgs e)
        {
            programPath.Clear();
            //programText.Clear();
            //programBlock.Clear();

            classPath1.Clear();
            //classText1.Clear();
            //classBlock1.Clear();

            classPath2.Clear();
            //classText2.Clear();
            //classBlock2.Clear();

            //statusText.Clear();
        }

        private void allClear_Click(object sender, RoutedEventArgs e)
        {
            programText.Clear();
            classText1.Clear();
            classText2.Clear();
            statusText.Clear();
        }

        private void allSave_Click(object sender, RoutedEventArgs e)
        {
            bool processSave = true;

            if (processSave == true && programText.Text.Trim(new char[] { ' ', '\t', '\n' }) != "")
            {
                programPath.Text = programPath.Text.Trim(new char[] { ' ', '\t', '\n' });
                if (programPath.Text == "")
                {
                    //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Program"; // Default file name
                    dlg.DefaultExt = ".cs"; // Default file extension
                    dlg.Filter = "C# Source File (.cs)|*.cs"; // Filter files by extension

                    // Show save file dialog box
                    Nullable<bool> result = dlg.ShowDialog();

                    // Process save file dialog box results
                    if (result == true)
                    {
                        // Save document
                        string filename = dlg.FileName;
                        programPath.Text = filename;
                        File.WriteAllText(programPath.Text, programText.Text);
                        //programBlock.Text = "Program File : " + System.IO.Path.GetFileName(programPath.Text);

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                        processSave = false;
                    }
                }
                else
                {
                    File.WriteAllText(programPath.Text, programText.Text);
                }
            }
            else { }

            if (processSave == true && classText1.Text.Trim(new char[] { ' ', '\t', '\n' }) != "")
            {
                classPath1.Text = classPath1.Text.Trim(new char[] { ' ', '\t', '\n' });
                if (classPath1.Text == "")
                {
                    //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Class-1"; // Default file name
                    dlg.DefaultExt = ".cs"; // Default file extension
                    dlg.Filter = "C# Class File (.cs)|*.cs"; // Filter files by extension

                    // Show save file dialog box
                    Nullable<bool> result = dlg.ShowDialog();

                    // Process save file dialog box results
                    if (result == true)
                    {
                        // Save document
                        string filename = dlg.FileName;
                        classPath1.Text = filename;
                        File.WriteAllText(classPath1.Text, classText1.Text);
                        //classBlock1.Text = "Class-1 File : " + System.IO.Path.GetFileName(classPath1.Text);

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                        processSave = false;
                    }
                }
                else
                {
                    File.WriteAllText(classPath1.Text, classText1.Text);
                }
            }
            else { }

            if (processSave == true && classText2.Text.Trim(new char[] { ' ', '\t', '\n' }) != "")
            {
                classPath2.Text = classPath2.Text.Trim(new char[] { ' ', '\t', '\n' });
                if (classPath2.Text == "")
                {
                    //System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Class-2"; // Default file name
                    dlg.DefaultExt = ".cs"; // Default file extension
                    dlg.Filter = "C# Class File (.cs)|*.cs"; // Filter files by extension

                    // Show save file dialog box
                    Nullable<bool> result = dlg.ShowDialog();

                    // Process save file dialog box results
                    if (result == true)
                    {
                        // Save document
                        string filename = dlg.FileName;
                        classPath2.Text = filename;
                        File.WriteAllText(classPath2.Text, classText2.Text);
                        //classBlock2.Text = "Class-2 File : " + System.IO.Path.GetFileName(classPath2.Text);

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("You Have Not Selected Any File to Save!");
                        processSave = false;
                    }
                }
                else
                {
                    File.WriteAllText(classPath2.Text, classText2.Text);
                }
            }
            else { }

        }

        private void executeButton_Click(object sender, RoutedEventArgs e)
        {
            statusText.Clear();
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", frameworkText.Text } });
            CompilerParameters parameters = new CompilerParameters(new string[] { "mscorlib.dll", "System.Core.dll", "System.Xml.Linq.dll",
            "System.Xml.dll", "System.Data.DataSetExtensions.dll", "System.Data.dll", "System.dll" }, outputText.Text + extensionLabel.Text, true);
            parameters.GenerateExecutable = true;

            programText.Text = programText.Text.Trim(new char[] { ' ', '\t', '\n' });
            classText1.Text = classText1.Text.Trim(new char[] { ' ', '\t', '\n' });
            classText2.Text = classText2.Text.Trim(new char[] { ' ', '\t', '\n' });
            string[] mydata = { programText.Text, classText1.Text, classText2.Text };

            CompilerResults results = csc.CompileAssemblyFromSource(parameters, mydata);
            if (results.Errors.HasErrors)
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => statusText.Text += error.ErrorText + "\r\n");
            else
            {
                statusText.Text = "-------Build Succeeded-------";
                //Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "/" + outputText.Text + extensionLabel.Text);
                if (outputText.Text.Split('\\').Length == 1)
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + outputText.Text + extensionLabel.Text);
                }
                else
                {
                    Process.Start(outputText.Text + extensionLabel.Text);
                }
            }

        }

        private void programExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        ////////////////////////////////////////////////////////////////////////////////////////

    }
}
