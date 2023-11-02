using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Static
{
    static class PositionableObjectRegistry
    {
        private static List<IPositionable> positionableObjects = new List<IPositionable>();

        public static void Register(IPositionable positionableObject)
        {
            positionableObjects.Add(positionableObject);
        }

        public static List<IPositionable> GetAllPositionableObjects()
        {
            return positionableObjects;
        }
    }
}
