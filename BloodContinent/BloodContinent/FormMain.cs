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
    public struct GameSession
    {
        public string curName;
        public bool isOffline;
        public string serverAddress;
    }



  


    public partial class FormMain : Form
    {

        FormManage manageForm;
        FormBattle battleForm;

        GameSession curSession;        

        public FormMain(string name, bool offline)
        {
            InitializeComponent();
            curSession.curName = name;
            curSession.isOffline = offline;
            curSession.serverAddress = "127.0.0.1";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            manageForm = new FormManage(curSession);
            battleForm = new FormBattle();
            label1.Text = curSession.curName;
            if (curSession.isOffline)
            {
                toolStripStatusMode.Text = "Mode:Offline";
                toolStripStatusMode.BackColor = Color.Red;
            } else
            {
                toolStripStatusMode.Text = "Mode:Online";
                toolStripStatusMode.BackColor = Color.Green;
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("New Messge", "Ask questions", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.No) {
                this.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems) 
            {
                listView1.Items.RemoveAt(lvi.Index); 
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            battleForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
