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
        public static readonly int NODE_COUNT = 9;

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];
        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }
        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x,y);
            // 如果沒有的話，回傳false
            if(nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }
            return true;
        }
        public Piece PlaceAPiece(int x, int y,PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);
            // 如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
            {
                return null;
            }
            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X,nodeId.Y] != null)
            {
                return null;
            }
            // 根據type 產生對應的棋子
            if(type == PieceType.BLACK)
            {
                pieces[nodeId.X,nodeId.Y] = new BlackPiece(x,y);
            }
            else if (type == PieceType.WHITE)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(x, y);
            }
            // 紀錄最後下棋子的位置
            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];
        }
        private Point FindTheClosetNode(int x, int y)
        {
            int nodeIdX = FindTheClosetNode(x);
            if(nodeIdX == -1 || nodeIdX >= NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }
            int nodeIdY = FindTheClosetNode(y);
            if(nodeIdY == -1 || nodeIdY >= NODE_COUNT) 
            {
                return NO_MATCH_NODE;
            }
            return new Point(nodeIdX, nodeIdY);
        }
        private int FindTheClosetNode(int pos)
        {
            if(pos < OFFSET - NODE_RADIUS)
            {
                return -1;
            }
            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;
            
            if(remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if(remainder >=  NODE_DISTANCE - NODE_RADIUS )
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
