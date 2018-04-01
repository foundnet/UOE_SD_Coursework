using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{
    //The map of battle is 1000 * 1000. This structure record the position of paticipants.
    struct BattleMapNode
    {
        public int posX;
        public int posY;
        public ClassSoldier soldier;
    }

    enum BattleStats { prebattle, fightting, creating, finished }
    enum Direction { Forward, Backward, Left, Right};

    //Battle class , which in charge of fighting and moving
    class ClassBattle
    {
        public string lastErr;

        public ClassSquad hostSide;                 //Host side of battle
        public ClassSquad guestSide;                //Guest side of battle 

        public List<BattleMapNode> hostMapList;
        public List<BattleMapNode> guestMapList;

        ClassNetwork network;
        public BattleStats battleStats;

        bool isOnline;

        //Init this class by inputed parameters
        public ClassBattle(ClassSquad host, bool online, ClassNetwork net)
        {
            hostSide = host;
            isOnline = online;
            battleStats = BattleStats.prebattle;
            hostMapList = new List<BattleMapNode>();
            guestMapList = new List<BattleMapNode>();

            if (online)
            {
                if (net == null || !net.netStats) throw new Exception("Network is not ready.");
                network = net;
                int result = network.SendBattleCreate(hostSide);
                if (result <= 0) throw new Exception("Create online battle faied.");
            }
            else
            {
                foreach (ClassSoldier soldier in hostSide.memberList)
                {
                    Random rd = new Random();
                    int result = rd.Next(0, 999);
                    BattleMapNode node;
                    node.posX = 0;
                    node.posY = result;
                    node.soldier = soldier;
                    hostMapList.Add(node);
                }
                guestSide = new ClassSquad();
                foreach (ClassSoldier gSoldier in guestSide.memberList)
                {
                    Random rd = new Random();
                    int result = rd.Next(0, 999);
                    BattleMapNode node;
                    node.posX = 999;
                    node.posY = result;
                    node.soldier = gSoldier;
                    guestMapList.Add(node);
                }

            }
        }

        //Move a solider
        public int CmdMove(int idxofMap, Direction direction, int steps, bool isHost)
        {
            try
            {
                BattleMapNode node;
                if (battleStats != BattleStats.fightting) throw new Exception("The battle does not begin!");
                if (isHost)
                {
                    if (idxofMap > hostMapList.Count) throw new Exception("Invalid soldier!");
                    if (steps > hostMapList[idxofMap].soldier.stats.move) throw new Exception("The soldier can not move so fast!");
                    node = hostMapList[idxofMap];
                }
                else
                {
                    if (idxofMap > guestMapList.Count) throw new Exception("Invalid soldier!");
                    if (steps > guestMapList[idxofMap].soldier.stats.move) throw new Exception("The soldier can not move so fast!");
                    node = guestMapList[idxofMap];
                }
                if (direction == Direction.Forward) node.posX = node.posX + steps > 999 ? 999 : (node.posX + steps);
                if (direction == Direction.Backward) node.posX = node.posX - steps < 0 ? 0 : (node.posX - steps);
                if (direction == Direction.Left) node.posY = node.posY + steps > 999 ? 999 : (node.posX + steps);
                if (direction == Direction.Right) node.posY = node.posY - steps < 0 ? 0 : (node.posX - steps);

                if (isHost)
                {
                    hostMapList[idxofMap] = node;
                    network.SendBattleMove(idxofMap, direction, steps);
                }
                else guestMapList[idxofMap] = node;

                return 1;
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }

        }


        private int CalcDistance(int x1, int y1, int x2, int y2)
        {
            return (int)(Math.Abs(Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2))));
        }

        //Soldiers shoot, indentify the enemy.
        public int CmdShoot(int idxofMap, int idxofEnemyMap, bool isHost, int hurt)
        {
            try
            {
                BattleMapNode node;
                if (isHost)
                {
                    if (idxofMap > hostMapList.Count || hostMapList[idxofMap].soldier.stats.health <= 0) throw new Exception("Invalid soldier!");
                    if (idxofEnemyMap > guestMapList.Count) throw new Exception("Invalid enemy!");

                    if (CalcDistance(hostMapList[idxofMap].posX, hostMapList[idxofMap].posY, guestMapList[idxofEnemyMap].posX, guestMapList[idxofEnemyMap].posY)
                        > hostMapList[idxofMap].soldier.stats.shoot) throw new Exception("The soldier can not shoot so far away!");
                    node = guestMapList[idxofEnemyMap];

                    if (isOnline)
                    {
                        network.SendBattleShoot(idxofMap, idxofEnemyMap);
                    }
                    else
                    {
                        Random rd = new Random();
                        hurt = rd.Next(0, 100);

                        node.soldier.stats.health = node.soldier.stats.health - hurt < 0 ? 0 : node.soldier.stats.health - hurt;
                        guestMapList[idxofEnemyMap] = node;
                    }
                }
                else
                {
                    if (idxofMap > guestMapList.Count || guestMapList[idxofMap].soldier.stats.health <= 0) throw new Exception("Invalid soldier!");
                    if (idxofEnemyMap > hostMapList.Count) throw new Exception("Invalid enemy!");

                    if (CalcDistance(hostMapList[idxofEnemyMap].posX, hostMapList[idxofEnemyMap].posY, guestMapList[idxofMap].posX, guestMapList[idxofMap].posY)
                        > guestMapList[idxofMap].soldier.stats.shoot) throw new Exception("The soldier can not shoot so far away!");
                    node = hostMapList[idxofEnemyMap];

                    if (!isOnline)
                    {
                        Random rd = new Random();
                        hurt = rd.Next(0, 100);
                    }
                    node.soldier.stats.health = node.soldier.stats.health - hurt < 0 ? 0 : node.soldier.stats.health - hurt;
                    hostMapList[idxofMap] = node;
                }
                return 1;
            }
            catch (Exception ex)
            {
                lastErr = ex.Message;
                return 0;
            }
        }
        public int EndBattle()
        {
            hostSide.captain.isConvetable = true;
            hostSide.hierophant.isConvetable = true;
            hostSide.captain.experience += 10;
            hostSide.hierophant.experience += 10;
            return 1;
        }
    }
}
