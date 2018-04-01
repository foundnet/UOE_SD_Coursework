using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{
    //The Gamestore that in charge of sell goods to player
    class ClassGameStore
    {
        public int credit;
        public string lastErr;

        public List<ClassItem> stashList;
        public List<ClassSoldier> soldierList;

        public ClassGameStore()
        {
            stashList = new List<ClassItem>();
            soldierList = new List<ClassSoldier>();

            for (int i = 0; i < 50; i++)
            {
                ClassItem item = new ClassItem();
                stashList.Add(item);
            }
            for (int i = 0; i < 50; i++)
            {
                ClassSoldier soldier = new ClassSoldier();
                soldierList.Add(soldier);
            }
        }

        public ClassItem SellItem(int idx)
        {
            try
            {
                ClassItem item;
                if (idx < stashList.Count)
                {
                    credit = credit + stashList[idx].price;
                    item = stashList[idx];
                    stashList.RemoveAt(idx);
                    return item;
                }
                throw new Exception("Invalid item!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return null;
            }
        }

        public ClassSoldier SellSoldier(int idx)
        {
            try
            {
                ClassSoldier soldier;
                if (idx < soldierList.Count)
                {
                    credit = credit + soldierList[idx].stats.cost;
                    soldier = soldierList[idx];
                    soldierList.RemoveAt(idx);
                    return soldier;
                }
                throw new Exception("Invalid item!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return null;
            }
        }
    }
}
