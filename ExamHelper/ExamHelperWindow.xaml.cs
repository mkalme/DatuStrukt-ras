using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace ExamHelper
{
    /// <summary>
    /// Interaction logic for ExamHelperWindow.xaml
    /// </summary>
    public partial class ExamHelperWindow : Window
    {
        public ExamHelperWindow()
        {
            InitializeComponent();
        }

        //Tree
        private void TreeClearButton_Click(object sender, RoutedEventArgs e)
        {
            TreeInputTextBox.Clear();
            TreeQuestionComboBox.SelectedItem = null;
            TreeResultRichTextBox.Document.Blocks.Clear();
        }
        private void TreeExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] parsedArray = ParseArrayAsIntegers(TreeInputTextBox.Text);
                TreeTask? task = GetTreeTask();
                if (task is null) throw new ArgumentNullException();

                string result = TreeTaskHelper.Execute(parsedArray, task.Value);

                TreeResultRichTextBox.Document.Blocks.Clear();
                TreeResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result)
                {
                    FontWeight = FontWeights.SemiBold
                }));
            }
            catch(Exception exception)
            {
                TreeResultRichTextBox.Document.Blocks.Clear();
                TreeResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run($"Error: {exception.Message}")
                {
                    Foreground = Brushes.DarkRed,
                    FontWeight = FontWeights.SemiBold
                }));
            }
        }
        private TreeTask? GetTreeTask()
        {
            int index = TreeQuestionComboBox.SelectedIndex;
            return index < 0 ? null : (TreeTask)index;
        }

        //Stack
        private void StackClearButton_Click(object sender, RoutedEventArgs e)
        {
            StackInputTextBox.Clear();
            StackCommandTextBox.Clear();
            StackResultRichTextBox.Document.Blocks.Clear();
        }
        private void StackExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parsedArray = ParseArray(StackInputTextBox.Text);
                string result = StackTaskHelper.Execute(new Stack<object>(parsedArray.Cast<object>()), StackCommandTextBox.Text);

                StackResultRichTextBox.Document.Blocks.Clear();
                StackResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result)
                {
                    FontWeight = FontWeights.SemiBold
                }));
            }
            catch(Exception exception)
            {
                StackResultRichTextBox.Document.Blocks.Clear();
                StackResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run($"Error: {exception.Message}")
                {
                    Foreground = Brushes.DarkRed,
                    FontWeight = FontWeights.SemiBold
                }));
            }
        }

        //List
        private void ListClearButton_Click(object sender, RoutedEventArgs e)
        {
            ListInputTextBox.Clear();
            ListCommandTextBox.Clear();
            ListResultRichTextBox.Document.Blocks.Clear();
        }
        private void ListExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parsedArray = ParseArray(ListInputTextBox.Text);
                string result = ListTaskHelper.Execute(new List<object>(parsedArray.Cast<object>()), ListCommandTextBox.Text);

                ListResultRichTextBox.Document.Blocks.Clear();
                ListResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result)
                {
                    FontWeight = FontWeights.SemiBold
                }));
            }
            catch (Exception exception)
            {
                ListResultRichTextBox.Document.Blocks.Clear();
                ListResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run($"Error: {exception.Message}")
                {
                    Foreground = Brushes.DarkRed,
                    FontWeight = FontWeights.SemiBold
                }));
            }
        }

        //PriorityQueue
        private void PriorityQueueClearButton_Click(object sender, RoutedEventArgs e)
        {
            PriorityQueueInputTextBox.Clear();
            PriorityQueueCommandTextBox.Clear();
            PriorityQueueResultRichTextBox.Document.Blocks.Clear();
        }
        private void PriorityQueueExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] parsedArray = ParseArrayAsIntegers(PriorityQueueInputTextBox.Text);
                string result = PriorityQueueTaskHelper.Execute(new List<int>(parsedArray), PriorityQueueCommandTextBox.Text);

                PriorityQueueResultRichTextBox.Document.Blocks.Clear();
                PriorityQueueResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result)
                {
                    FontWeight = FontWeights.SemiBold
                }));
            }
            catch (Exception exception)
            {
                PriorityQueueResultRichTextBox.Document.Blocks.Clear();
                PriorityQueueResultRichTextBox.Document.Blocks.Add(new Paragraph(new Run($"Error: {exception.Message}")
                {
                    Foreground = Brushes.DarkRed,
                    FontWeight = FontWeights.SemiBold
                }));
            }
        }

        //Utilities
        private static string[] ParseArray(string input) 
        {
            input = input.Trim();
            if (string.IsNullOrEmpty(input)) return Array.Empty<string>();

            string[] split = input.Split(',');
            return split;

        }
        private static int[] ParseArrayAsIntegers(string input)
        {
            input = input.Trim();
            if (string.IsNullOrEmpty(input)) return Array.Empty<int>();
            
            string[] split = input.Split(',');

            int[] output = new int[split.Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = int.Parse(split[i]);
            }

            return output;
        }
    }
}
