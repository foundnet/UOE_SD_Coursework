using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{

    enum CaptainSpec { Wind, Fire, Stone, Water, Forest, Earth};
    enum HeroSpec { Magic, Curses, Dragon, Ghost };


    // The Squad management class, implement most functions of management.
    class ClassSquad
    {
        public string name;
        public int credit;
        public string playerName;
        public bool isPublic;
        public CaptainSpec soldierSpec;
        public List<ClassItem> stashList;
        public List<ClassSoldier> rosterList;
        public string lastErr;

        public ClassCaptain captain = null;
        public ClassHierophant hierophant = null;
        public List<ClassSoldier> memberList;

        public ClassSquad(string newName, string newPlayerName, CaptainSpec newSpec, bool newPublic, CaptainSpec captainSpec, HeroSpec heroSpec)
        {
            if (newName == null || newPlayerName == null)
                throw new Exception("Invalid Parameter!");

            stashList = new List<ClassItem>();
            rosterList = new List<ClassSoldier>();
            memberList = new List<ClassSoldier>();

            EditSquadInfo(newName, newPlayerName, newSpec, newPublic);
            captain = new ClassCaptain();
            captain.specialism = captainSpec;
            hierophant = new ClassHierophant();
            hierophant.specialism = heroSpec;
            credit = 500;
        }
        public ClassSquad()
        {
            stashList = new List<ClassItem>();
            rosterList = new List<ClassSoldier>();
            memberList = new List<ClassSoldier>();

            Random rd = new Random();
            int result = rd.Next(0, 100);
            int spec = rd.Next(0, 5);
            CaptainSpec capSpec = (CaptainSpec)spec;

            EditSquadInfo("NPC_Team_"+result.ToString(), "Host_"+result.ToString(), capSpec, false);
            captain = new ClassCaptain();
            captain.specialism = capSpec;
            hierophant = new ClassHierophant();
            spec = rd.Next(0, 3);
            HeroSpec heroSpec = (HeroSpec)spec;
            hierophant.specialism = heroSpec;
            credit = 500;

            result = rd.Next(1, 8);

            memberList = new List<ClassSoldier>();
            for (int i = 0; i < result; i++)
            {
                ClassSoldier soldier = new ClassSoldier();
                memberList.Add(soldier);
            }


        }



        public void EditSquadInfo(string newName, string newPlayerName, CaptainSpec newSpec, bool newPublic)
        {
            if (newName != null) name = newName;
            if (newPlayerName != null) playerName = newPlayerName;
            soldierSpec = newSpec;
            isPublic = newPublic;
        }

        public int AddSquadMember(int idxofRoster)
        {
            try
            {
                if (idxofRoster < rosterList.Count)
                {
                    if (memberList.Count > 7) throw new Exception("No free space in this squad, can not add more soliders!");
                    memberList.Add(rosterList[idxofRoster]);
                    rosterList.RemoveAt(idxofRoster);
                    return 1;
                }
                throw new Exception("No valid soldier in roster!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int RemoveSquadMember(int idxofMember)
        {
            try
            {
                if (idxofMember < memberList.Count)
                {
                    memberList.RemoveAt(idxofMember);
                    return 1;
                }
                throw new Exception("No valid soldier in member list!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public ClassCaptain UpdateCaptain(ClassCaptain newCaptain)
        {
            try
            {
                if (newCaptain != null)
                {
                    ClassCaptain oldCaptain = captain;
                    captain = newCaptain;
                    return oldCaptain;
                }
                throw new Exception("New captain is not valid!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                throw ex;
            }
        }

        public ClassHierophant UpdateHierophant(ClassHierophant newHero)
        {
            try
            {
                if (newHero != null)
                {
                    ClassHierophant oldHero = hierophant;
                    hierophant = newHero;
                    return oldHero;
                }
                throw new Exception("New captain is not valid!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                throw ex;
            }
        }

        public int RemoveStashItem(int idxofStash)
        {
            try
            {
                if (idxofStash < memberList.Count)
                {
                    stashList.RemoveAt(idxofStash);
                    return 1;
                }
                throw new Exception("No valid soldier in member list!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int BuyStashItem(ClassGameStore store, int idx)
        {
            try
            {
                if (idx >= store.stashList.Count) throw new Exception("Not valid item!");
                if (credit > store.stashList[idx].price)
                {
                    stashList.Add(store.stashList[idx]);
                    credit = credit - store.stashList[idx].price;
                    store.SellItem(idx);

                    return 1;
 
                }
                throw new Exception("No enough credit to buy this item!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int BuyRosterMember(ClassGameStore store, int idx)
        {
            try
            {
                if (idx >= store.soldierList.Count) throw new Exception("Not valid soldier!");
                if (credit > store.soldierList[idx].stats.cost)
                {
                    rosterList.Add(store.soldierList[idx]);
                    credit = credit - store.soldierList[idx].stats.cost;
                    store.SellSoldier(idx);

                    return 1;
                }
                throw new Exception("No enough credit to buy this soldier!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int AddItemToCaptain(int idxofStash)
        {
            try
            {
                if (idxofStash >= stashList.Count) throw new Exception("Invalid stash item!");

                int result = captain.AddItem(stashList[idxofStash]);
                if (result <= 0) throw new Exception(captain.lastErr);

                stashList.RemoveAt(idxofStash);

                return 1;
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int AddItemToHero(int idxofStash)
        {
            try
            {
                if (idxofStash >= stashList.Count) throw new Exception("Invalid stash item!");

                int result = hierophant.AddItem(stashList[idxofStash]);
                if (result <= 0) throw new Exception(hierophant.lastErr);

                stashList.RemoveAt(idxofStash);

                return 1;
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }
    }
}
