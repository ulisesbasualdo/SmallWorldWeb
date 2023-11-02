using SmallWorld.src.Model.MapModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Interfaces
{
    internal interface IPositionable
    {
        List<IHabitat> HabitatsCompatible();
    }
}
