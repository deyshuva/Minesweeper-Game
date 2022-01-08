using System;
using System.Collections.Generic;
using System.Text;
using MineSweeperFinal.Backend;

namespace MineSweeperFinal.Controller
{
    class Middleware
    {
        Operation backendOps = new Operation();
        GameOperation gameOps;
       
        public bool saveMinefieldData(List<Tuple<int, int>> values)
        {
          
            backendOps.saveDatainBackend(values);
            return true;
        }

        public void addStep(long gameStartTime, string playerType, string playerID, int row, int col)
        {
            long cuTime = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            gameOps.addStep((int)(cuTime - gameStartTime), playerType, playerID, row, col);
        }
        public void startGame()
        {
            gameOps = new GameOperation();
        }
        public void close()
        {
            gameOps.closeWriter();
            gameOps = null;
        }


        public List<Tuple<int, int>> getMineFieldData()
        {
            return backendOps.takeMineData();
        }
    }
}
