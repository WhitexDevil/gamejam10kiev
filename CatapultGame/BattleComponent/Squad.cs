using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CatapultGame
{
    public class Squad 
    {
        public readonly Unit Unit;
        private int amount;
        public int DamageLeft;
        private Point position;
        private bool alive;

        public bool Alive
        {
            get { return alive; }
            private set { alive = value; }
        }

        public void Draw(GameTime gameTime)
        {

        }
        public void Update(GameTime gameTime)
        {

        }



        public int Amount
        {
            get { return amount; }
            set
            {
                if (value < 1)
                {
                    alive = false;
                    amount = 0;

                }
                else

                    amount = value;
            }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Squad(Unit unit)
        {
            Unit = unit;
            amount = unit.MaxAmount;
            DamageLeft = 0;
            Position = new Point();
            alive = true;
        }

        public void Attack(Squad target)
        {
            int Damage = 0;
            for (int i = 0; i < Amount; i++)
            {
                if ((1 + Random.Next(20) + Unit.Attack) >= target.Unit.Defense)
                    Damage += Unit.Damage;
            }

            target.TakeDamage(Damage);
        }

        public void TakeDamage(int Damage)
        {
            Damage += DamageLeft;
            Amount -= (Damage / Unit.MaxHitpoints);
            DamageLeft = Damage % Unit.MaxHitpoints;


        }
     
        public object Clone()
        {
            return new Squad(Unit) { DamageLeft = 0, Amount = amount, Position = position };
        }
    }
}
