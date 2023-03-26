using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
        private CircularLinkedList linkedList;

        public MainWindow()
        {
            InitializeComponent();
            linkedList = new CircularLinkedList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(addItemTextBox.Text, out int data))
            {
                linkedList.Add(data);
                UpdateListBox();
                addItemTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(removeItemTextBox.Text, out int data))
            {
                linkedList.Remove(data);
                UpdateListBox();
                removeItemTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value.");
            }
        }

        private void AddBeforeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(valueTextBox.Text, out int value) && int.TryParse(newValueTextBox.Text, out int newData))
            {
                linkedList.AddBefore(value, newData);
                UpdateListBox();
                valueTextBox.Clear();
                newValueTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid integer values.");
            }
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(firstValueTextBox.Text, out int firstValue) && int.TryParse(secondValueTextBox.Text, out int secondValue))
            {
                linkedList.SwapElements(firstValue, secondValue);
                UpdateListBox();
                firstValueTextBox.Clear();
                secondValueTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid integer values.");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            linkedList.Clear();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            LinkedListBox.Items.Clear();

            if (linkedList.Size > 0)
            {
                Node current = linkedList.Head;

                do
                {
                    LinkedListBox.Items.Add(current.Data);
                    current = current.Next;
                } while (current != linkedList.Head);
            }
            else
            {
                LinkedListBox.Items.Add("List is empty");
            }
        }
    }

}

