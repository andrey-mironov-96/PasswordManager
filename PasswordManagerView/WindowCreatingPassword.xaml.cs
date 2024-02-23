using MediatR;
using PasswordManager.Application.Feature.UserDatas.Commands.CreateUserData;
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
using System.Windows.Shapes;

namespace PasswordManagerView
{
    /// <summary>
    /// Логика взаимодействия для WindowCreatingPassword.xaml
    /// </summary>
    public partial class WindowCreatingPassword : Window
    {
        private readonly IMediator mediator;

        public WindowCreatingPassword(IMediator mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateUserDataCommand command = new()
                {
                    Login = "Vasya",
                    Password = "123",
                    Resource = "res1",
                    Type = "type1"
                };
                mediator.Send(command);
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
