using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Interactable.ItemEffects
{
    internal class MaxAttackPoints : IEffectStrategy
    {
        private string name = "Ataque al máximo";
        public void Effect(Entity entity)
        {
            entity.AttackPoints = 9999;
        }
        public override bool Equals(object obj)
        {
            if (obj is MaxAttackPoints other)
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
