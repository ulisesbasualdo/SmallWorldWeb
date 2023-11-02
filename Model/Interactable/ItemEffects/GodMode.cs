using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmallWorld.src.Model.Interactable.ItemEffects
{
    internal class GodMode : IEffectStrategy
    {
        private string name = "Modo Dios";
        public void Effect(Entity entity)
        {
            entity.MaxLife = 9999;
            entity.MaxEnergy = 9999;
            entity.CurrentLife = 9999;
            entity.AttackPoints = 9999;
            entity.DefensePoints = 9999;
            entity.CurrentEnergy = 9999;
        }
        public override bool Equals(object obj)
        {
            if (obj is GodMode other)
            {
                return name == other.name;
            }
            return false;
        }
        public override string ToString()
        {
            return name;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
