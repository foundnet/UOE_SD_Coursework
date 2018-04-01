using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{
    //The ClassHierophant class inherited from Soldier
    class ClassHierophant : ClassSoldier
    {
        public string lastErr;
        public HeroSpec specialism;
        public int experience;
        public bool isConvetable;

        public List<string> skillList;
        public List<ClassItem> equipList;
        public List<ClassItem> weaponList;

        public ClassHierophant()
        {
            skillList = new List<string>();
            equipList = new List<ClassItem>();
            weaponList = new List<ClassItem>();
        }

        public ClassItem RemoveItem(ItemType type, int idx)
        {
            try
            {
                if (type == ItemType.equip)
                {
                    if (idx < equipList.Count)
                    {
                        ClassItem item = equipList[idx];
                        equipList.RemoveAt(idx);
                        return item;
                    }
                    throw new Exception("No valid equipment in equipment list!");
                }
                else if (type == ItemType.weapon)
                {
                    if (idx < weaponList.Count)
                    {
                        ClassItem item = weaponList[idx];
                        weaponList.RemoveAt(idx);
                        return item;
                    }
                    throw new Exception("No valid weapon in weapon list!");
                }
                throw new Exception("Invalid item type!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return null;
            }
        }

        public int AddItem(ClassItem item)
        {
            try
            {
                if (item.type == ItemType.equip)
                {
                    if (equipList.Count < 4)
                    {
                        equipList.Add(item);
                        return 1;
                    }
                    throw new Exception("The equipment list is full!");
                }
                else if (item.type == ItemType.weapon)
                {
                    if (weaponList.Count < 1)
                    {
                        weaponList.Add(item);
                        return 1;
                    }
                    throw new Exception("The weapon  list is full!");
                }
                throw new Exception("Invalid item type!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int ConvertExperience(string stat)
        {
            try
            {
                if (isConvetable && experience >= 10)
                {
                    switch (stat)
                    {
                        case "move":
                            this.stats.move += 1;
                            break;
                        case "shoot":
                            this.stats.shoot += 1;
                            break;
                        case "morale":
                            this.stats.morale += 1;
                            break;
                        case "flight":
                            this.stats.flight += 1;
                            break;
                        case "armour":
                            this.stats.armour += 1;
                            break;
                        case "health":
                            this.stats.health += 1;
                            break;
                        case "skill":
                            this.skillList.Add("Skill"+ (skillList.Count+1).ToString());
                            break;
                        default:
                            throw new Exception("The stats is wrong!");
                    }
                    experience -= 10;
                    return 1;
                }
                throw new Exception("Can not convert now!");
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

        public int ConvertExperienceToSkill(string stat)
        {
            try
            {
                if (isConvetable && experience >= 10)
                {
                    switch (stat)
                    {
                        case "move":
                            this.stats.move += 1;
                            break;
                        case "shoot":
                            this.stats.shoot += 1;
                            break;
                        case "morale":
                            this.stats.morale += 1;
                            break;
                        case "flight":
                            this.stats.flight += 1;
                            break;
                        case "armour":
                            this.stats.armour += 1;
                            break;
                        case "health":
                            this.stats.health += 1;
                            break;
                        default:
                            throw new Exception("The stats is wrong!");
                    }
                    experience -= 10;
                    return 1;
                }
                throw new Exception("No enough experience!");

            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }

    }
}
