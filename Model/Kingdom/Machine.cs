using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Reino
{
    internal class Machine : IKingdom
    {
        /*
        public int Id { get => Id; set => Id = value; }
        public string Name { get => Name; set => Name = value; }
        public bool Deleted { get => Deleted; set => Deleted = value; }*/

        private string name = "Maquina";
        public override bool Equals(object obj)
        {
            if (obj is Machine other)
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
