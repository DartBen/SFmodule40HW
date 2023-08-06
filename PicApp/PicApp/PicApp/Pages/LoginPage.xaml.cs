using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string _pwd;
        public LoginPage()
        {
            InitializeComponent();
            _pwd = Preferences.Get("Pwd", String.Empty);
            if (_pwd != string.Empty)
            {
                lblPwd.Text = "Введите пин-код для входа:";
            }
        }


        private void endPwdButton_Click(object sender, EventArgs e)
        {
            string enterPwd = Password.Text;
            if (_pwd == string.Empty)
            {
                Preferences.Set("Pwd", enterPwd);
            }
            else
            {
                if (_pwd != Password.Text)
                {
                    lblInfoMsg.Text = "Неверный ПИН-код";
                    return;
                }
            }

            Navigation.PushAsync(new DummyPage());
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length != 4)
            {
                lblInfoMsg.Text = "ПИН-код должен состоять из 4 символов";
                endPwdButton.IsEnabled = false;
            }
            else
            {
                endPwdButton.IsEnabled = true;
                lblInfoMsg.Text = string.Empty;
            }
        }
    }
}