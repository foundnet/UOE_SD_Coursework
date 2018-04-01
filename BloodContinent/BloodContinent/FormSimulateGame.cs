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
    public partial class FormSimulateGame : Form
    {
        ClassSquad mySquad, NPCSquad;
        ClassGameStore store;
        ClassBattle battle;

        public FormSimulateGame()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("----------Battle Start------------ ");
            battle = new ClassBattle(mySquad, false, null);

            listBox1.Items.Add("Host's name is " + battle.hostSide.name + ",owned by "+ battle.hostSide.playerName);
            listBox1.Items.Add("Enemy's name is " + battle.guestSide.name + ",owned by " + battle.guestSide.playerName);

            listBox1.Items.Add("Host's solider count:" + battle.hostMapList.Count.ToString());
            listBox1.Items.Add("Enemy's solider count:" + battle.guestMapList.Count.ToString());

            battle.CmdMove(0, Direction.Forward, 20, true);
            battle.CmdShoot(1, 1, true,5);
            listBox1.Items.Add("The host moves" );
            listBox1.Items.Add("The host shoot" );




        }

        private void button3_Click(object sender, EventArgs e)
        {
            battle.EndBattle();
            listBox1.Items.Add("-----------The batle end---------");

            listBox1.Items.Add("Captain's experience:" + mySquad.captain.experience.ToString() + "Hero's :" + mySquad.hierophant.experience.ToString());
            
            mySquad.captain.ConvertExperience("move");
            mySquad.hierophant.ConvertExperience("skill");

            listBox1.Items.Add("Convert experience");

            listBox1.Items.Add("Captain's experience:" + mySquad.captain.experience.ToString() + "Hero's :" + mySquad.hierophant.experience.ToString());




        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySquad = new ClassSquad("TestNewSquad", "KaiLiu", CaptainSpec.Forest, true, CaptainSpec.Water, HeroSpec.Curses);
            NPCSquad = new ClassSquad();

            listBox1.Items.Add("Add a squad " + mySquad.name);
            listBox1.Items.Add("Add a squad " + NPCSquad.name);

            store = new ClassGameStore();
            listBox1.Items.Add("Add a gamestore have " + store.soldierList.Count.ToString() + " soldiers and " + store.stashList.Count.ToString() + " items.");

            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", count of roster: "+ mySquad.rosterList.Count.ToString());
            mySquad.BuyRosterMember(store, 5);
            listBox1.Items.Add("Buy a member to roster" );

            mySquad.BuyRosterMember(store, 5);
            listBox1.Items.Add("Buy a member to roster");

            mySquad.BuyRosterMember(store, 5);
            listBox1.Items.Add("Buy a member to roster");

            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have roster:  " + mySquad.rosterList.Count.ToString());

            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have stash items " + mySquad.stashList.Count.ToString());
            mySquad.BuyStashItem(store, 5);
            listBox1.Items.Add("Buy an item to stash");
            mySquad.BuyStashItem(store, 5);
            listBox1.Items.Add("Buy an item to stash");
            mySquad.BuyStashItem(store, 5);
            listBox1.Items.Add("Buy an item to stash");
            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have stash items " + mySquad.stashList.Count.ToString());

            mySquad.AddItemToCaptain(1);
            listBox1.Items.Add("Add an item to Captain, now the captain have items:" + (mySquad.captain.equipList.Count + mySquad.captain.weaponList.Count).ToString());
            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have stash items " + mySquad.stashList.Count.ToString());

            mySquad.AddItemToCaptain(0);
            listBox1.Items.Add("Add an item to Captain, now captain have items: " + (mySquad.captain.equipList.Count + mySquad.captain.weaponList.Count).ToString());
            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have stash items " + mySquad.stashList.Count.ToString());

            mySquad.AddSquadMember(0);
            listBox1.Items.Add("Add an item to squad, now have members:" + mySquad.memberList.Count.ToString());
            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have roster:  " + mySquad.rosterList.Count.ToString());

            mySquad.AddSquadMember(0);
            listBox1.Items.Add("Add an item to squad, now have members:" + mySquad.memberList.Count.ToString());
            listBox1.Items.Add("Have credit " + mySquad.credit.ToString() + ", have roster:  " + mySquad.rosterList.Count.ToString());







        }
    }
}
