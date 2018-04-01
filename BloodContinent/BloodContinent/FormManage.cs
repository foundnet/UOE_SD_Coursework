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
    public partial class FormManage : Form
    {
        FormAddRoster form;
        FormAddWeapon weaponForm;
        FormAddEquipment equipmentForm;

        GameSession curSession;

        public FormManage(GameSession session)
        {
            InitializeComponent();
            form = new FormAddRoster();
            weaponForm = new FormAddWeapon();
            equipmentForm = new FormAddEquipment();

            curSession = session;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            weaponForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            equipmentForm.Show();
        }

        private void Manage_Load(object sender, EventArgs e)
        {

        }
    }
}
