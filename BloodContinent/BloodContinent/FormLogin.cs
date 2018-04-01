using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodContinent
{
    public partial class FormLogin : Form
    {
        FormMain mainForm;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("Please input user name","Warning", MessageBoxButtons.OK);
                return;
            }
            mainForm = new FormMain(textBox1.Text, checkBox1.Checked);
            mainForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormSimulateGame form = new FormSimulateGame();
            form.Show();

        }
    }
}      