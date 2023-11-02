using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Interfaces
{
    internal interface IEntity
    {
        void Feed();

        void Move();

        void RangeAttack();

        void Sleep();
    }
}
