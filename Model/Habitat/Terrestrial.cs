using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Dieta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Habitat
{
    internal class Terrestrial : IHabitat
    {
        private string name = "Terrestre";
        public override bool Equals(object obj)
        {
            if (obj is Terrestrial other)
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
