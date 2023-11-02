using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Interactable.ItemEffects
{
    internal class AtomicBombLauncher : IEffectStrategy
    {
        private string name = "Lanzador Bomba Atómica";
        public void Effect(Entity entity)
        {
            entity.TrowAtomicBomb();
        }
        public override bool Equals(object obj)
        {
            if (obj is AtomicBombLauncher other)
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
