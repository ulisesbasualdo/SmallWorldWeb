using SmallWorld.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Interfaces
{
    public interface IEffectStrategy
    {
        int Id_Effect();
        void Effect(Entity entity);
    }
}
