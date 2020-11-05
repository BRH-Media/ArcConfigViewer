using ArcAuthentication.Security;
using System;
using System.Windows.Forms;

namespace ArcAuthentication.UI
{
    public partial class LoginForm : Form
    {
        public bool Success { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                if (ArcLogin.DoLogin(new ArcCredential(txtUsername.Text, txtPassword.Text)))
                {
                    Success = true;
                    /*MessageBox.Show(@"Success!", @"Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); */
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show(@"Login failed; check values and try again.", @"Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(@"Please correctly enter all required values", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static bool ShowLogin()
        {
            var frm = new LoginForm();
            frm.ShowDialog();

            return frm.Success && frm.DialogResult == DialogResult.OK;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}