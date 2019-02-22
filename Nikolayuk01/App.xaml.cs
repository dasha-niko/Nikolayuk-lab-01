using Nikolayuk01;
using System;
using System.Windows;


namespace Nikolayuk0101
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Model();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
