using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 五子棋
{
    class Board 
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1,-1);

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        public bool CanBePlaced(int x, int y)
        {
            // TODO: 找出最近的節點(Node)

            // TODO: 如果沒有的話，回傳false

            // TODO: 如果有的話，檢查是否已經旗子存在
        }
        private Point FindTheClosetNode(int x, int y)
        {
            int nodeldX = FindTheClosetNode(x);
            if(nodeldX == -1)
            {
                return
            }
        }
        private int FindTheClosetNode(int pos)
        {
            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;
            
            if(remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if(remainder >= NODE_DISTANCE - NODE_RADIUS)
            {
                return quotient + 1;
            }
            else
            { 
                return -1;
            }
        }
    }
}
