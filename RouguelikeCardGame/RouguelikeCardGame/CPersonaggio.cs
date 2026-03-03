using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal enum CharacterType
    {
        Warrior, //100 hp 20 ap
        Mage, //70 hp 30 ap
        Archer, //80 hp 25 ap
        Paladin, //120 hp 15 ap
        Assassin //60 hp 35 ap
    }
    internal class CPersonaggio
    {
        protected string Name;
        protected int HealthPoints;
        protected int AttackPoints;
        protected CharacterType Type;
        public List<string> log;
        public CGame game; // Reference to the game instance

        public CPersonaggio(string name, int healthPoints, int attackPoints, CharacterType type)
        {
            Name = name;
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            Type = type;
            log = new List<string>();
        }

        public void Attack(CPersonaggio target, CGame g)
        {
            target.RecieveDamage(AttackPoints);
            //adding more log to see the attack
            string s = ($"{Name} attacked {target.GetName()} for {AttackPoints} damage.");
            game = g; // Assign the game instance
            g.GameLog.Add(s);
        }

        public void RecieveDamage(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }
        }

        public bool IsAlive()
        {
            if (HealthPoints > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAPString()
        {
            return AttackPoints.ToString();
        }

        public string GetHPString()
        {
            return HealthPoints.ToString();
        }
    }
}
