using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSharingSystem
{
    public partial class LoginForm : Form
    {

        private char[] InvalidChars = {';','/','%','$','(',')'};
        private DatabaseManager DBManager;
        private List<UserData> UserList;
        // Indicates if the user is typing in its credentials
        private bool HintOn = true;

        public LoginForm()
        {
            InitializeComponent();
            DBManager = new DatabaseManager();
            UserList = DBManager.getAllUsers();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            try
            {
                bool validlogin = checkValidCredentials(username, password);
                if (validlogin)
                {
                    UserData user = checkMatchingCredentials(username, password);

                    if (user != null)
                    {
                        WindowManager manager = new WindowManager(user);
                        this.Hide();
                        manager.ShowDialog();
                        this.Show();
                    }
                }

            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private bool checkValidCredentials(string username, string password){
            foreach(char c in InvalidChars){
                if (username.Contains(c) || password.Contains(c))
                {
                    throw new Exception("Your username or password contains invalid characters!");
                }
            }
            return true;
        }

        private UserData checkMatchingCredentials(string username, string password)
        {
            foreach (UserData user in UserList)
            {
                if (username == user.Username && password == user.Password)
                {
                    return user;
                }
            }
            throw new Exception("Your username/password is unknown!");
        }
    }
}
