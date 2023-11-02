using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.Game
{
    public class Game
    {
        private int p1EntitiesNum, p2EntitiesNum, itemsNum, foodNum, timeGame, timeTurn;
        public int P1EntitiesNum
        {
            get => p1EntitiesNum;
            set
            {
                if (value > 0 ) p1EntitiesNum = value;
                else throw new InvalidOperationException("Jugador 1: valor inválido");
            }
        }
        public int P2EntitiesNum 
        { 
            get => p2EntitiesNum;
            set
            {
                if (value > 0) p2EntitiesNum = value;
                else throw new InvalidOperationException("Jugador 2: valor inválido");
            }
        }
        public int ItemsNum
        {
            get => itemsNum;
            set
            {
                if (value >= 0) itemsNum = value;
                else throw new InvalidOperationException("Items: valor inválido");
            }
        }
        public int FoodNum
        {
            get => foodNum;
            set
            {
                if (value >= 0) foodNum = value;
                else throw new InvalidOperationException("Alimentos: valor inválido");
            }
        }

        public int TimeGame { get => timeGame; set => timeGame = value; }
        public int TimeTurn { get => timeTurn; set => timeTurn = value; }

        public Game(int p1EntitiesNum, int p2EntitiesNum, int itemsNum, int foodNum, int timeGame, int timeTurn)
        {
            P1EntitiesNum = p1EntitiesNum;
            P2EntitiesNum = p2EntitiesNum;
            ItemsNum = itemsNum;
            FoodNum = foodNum;
            TimeGame = timeGame;
            TimeTurn = timeTurn;
        }

        public Game()
        {
        }
    }
}
