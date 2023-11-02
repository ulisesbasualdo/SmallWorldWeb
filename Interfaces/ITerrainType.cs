using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Interfaces
{
    public interface ITerrainType
    {
        int Id_TerrainType();
        Color getColor();
        List<IHabitat> getHabitatsSupported();
    }
}
