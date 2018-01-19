using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSim
{
    abstract class Effect
    {
        string name;
        abstract public void pingInit(Creature target);
        abstract public void pingRoll(DiceResult roll,Creature target);
        abstract public void pingEnd(Creature target);
    }
}
