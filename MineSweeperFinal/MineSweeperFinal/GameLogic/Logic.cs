using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperFinal.GameLogic
{
    class Logic
    {
        public void calculateNumber(List<Tuple<int, int>> minePos, int[,] grid)
        {
            foreach(Tuple <int,int> t in minePos)
            {
                calculateGridNo(t.Item1, t.Item2, grid);
            }
        }
        private void calculateGridNo(int x, int y, int[,] grid)
        {
            if (grid [x,y] != -1)
            {
                grid[x,y] = -1;
                
                for (int dx = x - 1; dx <= x + 1; dx++)
                    for (int dy = y - 1; dy <= y + 1; dy++)
                        if (dx >= 0 && dx < 3 && dy >= 0 && dy < 3)
                            if (grid[dx, dy] != -1)
                                    grid[dx , dy]++;
            }
        }
    }
}
