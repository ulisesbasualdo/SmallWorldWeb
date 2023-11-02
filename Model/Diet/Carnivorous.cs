using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Reino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Dieta
{
    internal class Carnivorous : IDiet
    {
        private string name = "Carnívoro";
        public override bool Equals(object obj)
        {
            if (obj is Carnivorous other)
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
