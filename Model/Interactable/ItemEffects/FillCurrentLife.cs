using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Dieta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Interactable.ItemEffects
{
    internal class FillCurrentLife : IEffectStrategy
    {
        private string name = "Llenar vida actual";
        
        public void Effect(Entity entity)
        {
            entity.CurrentLife = entity.MaxLife;
        }
        public override bool Equals(object obj)
        {
            if (obj is FillCurrentLife other)
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
