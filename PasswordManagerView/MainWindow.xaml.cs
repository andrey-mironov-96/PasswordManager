using System.Windows;

namespace PasswordManagerView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WindowCreatingPassword windowCreatingPassword;

        public MainWindow(WindowCreatingPassword windowCreatingPassword)
        {
            InitializeComponent();
            this.windowCreatingPassword = windowCreatingPassword;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            this.windowCreatingPassword.ShowDialog();
        }
    }
}