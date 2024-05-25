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

        }
        private int FindTheClosetNode(int pos)
        {

        }
    }
}
