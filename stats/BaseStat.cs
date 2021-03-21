using System;

namespace GofRPG_API
{
    public class BaseStat
    {
        public int FullAtk {get; set;}
        public int FullDef {get; set;}
        public int FullEva {get; set;}
        public int FullHp {get; set;}
        public int FullSpd {get; set;}
        public int Atk {get; set;}
        public int Def {get; set;}
        public int Eva {get; set;}
        public int Hp {get; set;}
        public int Spd {get; set;}

        //Counstructors
        public BaseStat(int attack, int defense, int evasion, int speed, int hitPoints)
        {
            FullAtk = attack;
            FullDef = defense;
            FullEva = evasion;
            FullSpd = speed;
            FullHp = hitPoints;
            Atk = attack;
            Def = defense;
            Eva = evasion;
            Hp = hitPoints;
        }

        public BaseStat(){
        }

        //Methods
        public int GetBaseStatTotal()
        {
            int total = Atk + Def + Hp + Spd + Eva;
            return total;
        }

        public void ResetBaseStat(){
            Atk = FullAtk;
            Def = FullDef;
            Eva = FullEva;
            Spd = FullSpd;
        }
    }
}