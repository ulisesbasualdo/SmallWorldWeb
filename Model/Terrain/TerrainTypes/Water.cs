using SmallWorld.src.Interfaces;
using SmallWorld.src.Model.Habitat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Terreno
{
    internal class Water : ITerrainType
    {
        private string name = "Agua";
        private Color color = Color.Blue;
        private List<IHabitat> habitatsSupported = new List<IHabitat>() { new Aquatic(), new Aerial() };
        public Color Color { get => color; set => color = value; }
        public List<IHabitat> getHabitatsSupported() { return habitatsSupported; }
        public override string ToString()
        {
            return name;
        }
        public Color getColor()
        {
            return Color;
        }
    }
}
