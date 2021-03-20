using System;

namespace GofRPG_API
{
    public class BaseStats
    {
        //Data Members
        int fullAtk;
        int fullDef;
        int fullEva;
        int fullSpd;
        int fullHP;
        int atk;
        int def;
        int eva;
        int spd;
        int hp;

        //Counstructors
        public BaseStats(int attack, int defense, int evasion, int speed, int hitPoints)
        {
            this.fullAtk = attack;
            this.fullDef = defense;
            this.fullEva = evasion;
            this.fullSpd = speed;
            this.fullHP = hitPoints;
            this.atk = fullAtk;
            this.def = fullDef;
            this.eva = fullEva;
            this.spd = fullSpd;
            this.hp = fullHP;
        }

        public BaseStats(){
        }

        //Methods
        public int getBaseStatTotal()
        {
            int total = atk + def + hp + spd + eva;
            return total;
        }

        public void resetBaseStat(){
            this.atk = fullAtk;
            this.def = fullDef;
            this.eva = fullEva;
            this.spd = fullSpd;
        }
    }
}