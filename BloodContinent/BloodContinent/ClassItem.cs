using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{
    public enum ItemType { equip, weapon }

    class ClassItem
    {
        public ItemType type;
        public string name;
        public int price;

        public ClassItem(ItemType _type, string _name, int _price)
        {
            type = _type;
            name = _name;
            price = _price;
        }
        public ClassItem()
        {
            Random rd = new Random();
            int result = rd.Next(1, 2);
            type = (ItemType)result;
            result = rd.Next(1, 10000);
            name = "Item"+result.ToString();
            result = rd.Next(1, 100);
            price = result;
        }
    }

}
