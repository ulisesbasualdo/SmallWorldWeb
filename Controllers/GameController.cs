using SmallWorld.src.Model;
using SmallWorld.src.Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Controllers
{
    internal class GameController
    {
        private static GameController instance;
        private readonly Game game = new Game(200,200,200,200,600,30); //Default values if user not configure options.
        private GameController() { }

        public static GameController GetInstance()
        {
            if (instance == null)
            {
                instance = new GameController();
            }
            return instance;
        }

        public void SetGameOptions(int p1NumEntities, int p2NumEntities, int itemsNum, int foodNum)
        {
            game.P1EntitiesNum = p1NumEntities;
            game.P2EntitiesNum = p2NumEntities;
            game.ItemsNum = itemsNum;
            game.FoodNum = foodNum;
        }
        public void SetGameDefaultOptions()
        {
        }
        public Game getGameOptions()
        {
            return game;
        }

    }
}
