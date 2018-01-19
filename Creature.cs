using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSim
{
    class Creature
    {
        string name;
        int fight;
        int body;
        int wits;
        int spirit;
        int rot;
        int gold;
        int magic;
        int priestege;
        int dice;
        Time affinity;
        bool isAttacking;
        int followers;
        Tile tile;
        Stack<DiceResult> attackDeck = new Stack<DiceResult>();
        Stack<DiceResult> defenceDeck = new Stack<DiceResult>();
        Stack<DiceResult> missedDeck = new Stack<DiceResult>();
        Effect[] effects;

        Face_value[] faceTable = new Face_value[6];
        bool[] explodeTable = new bool[6];

        public bool isCorrupt()
        {
            return rot >= 5;
        }

        public void init()
        {
            faceTable[(int)Face_type.SUN] = Face_value.HIT;
            faceTable[(int)Face_type.MOON] = Face_value.MISS;
            faceTable[(int)Face_type.SWORD] = Face_value.HIT;
            faceTable[(int)Face_type.SHIELD] = Face_value.BLOCK;
            faceTable[(int)Face_type.WYLD] = !isCorrupt() ? Face_value.HIT : Face_value.MISS;
            faceTable[(int)Face_type.ROT] = isCorrupt() ? Face_value.HIT : Face_value.MISS;

            explodeTable[(int)Face_type.SUN] = false;
            explodeTable[(int)Face_type.MOON] = false;
            explodeTable[(int)Face_type.SWORD] = false;
            explodeTable[(int)Face_type.SHIELD] = false;
            explodeTable[(int)Face_type.WYLD] = !isCorrupt();
            explodeTable[(int)Face_type.ROT] = isCorrupt();
        }

        public void addEffect()
        {

        }
        public void removeEffect()
        {

        }

        public void initEffects()
        {
            dice = fight;
        }
        public void initBurned()
        {

        }
        private void explode()
        {
            ++dice;
        }
        private void handleRoll(Face_type roll)
        {
            DiceResult result = new DiceResult
            {
                face = roll,
                mod = Mod.NONE,
                value = faceTable[(int)roll]
            };
            foreach(Effect e in effects)
            {
                e.pingRoll(result, this);
            }
            
        }
        public void roll()
        {
            Random rand = new Random();
            initEffects();
            initBurned();

            for(int i = 0; i < dice; ++i)
            {
                Face_type roll = (Face_type)rand.Next(0, 6);
                handleRoll(roll);
            }
            
        }
    }
}
