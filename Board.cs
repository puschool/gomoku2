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
        private static readonly Point NO_MATCH_NODE = new Point(-1,-1);//用一個Point資料代表不存在的點(要使用不會用到的點)
        public static readonly int NODE_COUNT = 9;  //9*9的棋盤陣列

        private static readonly int OFFSET = 75; // 偏移植
        private static readonly int NODE_RADIUS = 10; // 圓半徑
        private static readonly int NODE_DISTANCE = 75; // 節點距離
        //使用二維陣列紀錄棋子
        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];  //棋盤陣列
        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }
        //判斷這個位置可不可以放棋子
        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x,y); //(nodeId)一個節點的座標位置
            // 如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null) //預設每一個都是=null
            {
                return false; //回傳已經有棋子存在
            }
            return true;
        }
        public Piece PlaceAPiece(int x, int y,PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y); //(nodeId)一個節點的座標位置。//nodeId是第幾個交叉點
            // 如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
            {
                return null; //return Piece的值，Piece是一個class，要指向 沒有任何一個物件
            }
            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X,nodeId.Y] != null)
            {
                return null;
            }
            // 根據type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
            {
                pieces[nodeId.X,nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else if (type == PieceType.WHITE)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);
            }
            // 紀錄最後下棋子的位置
            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];

        }
        private Point convertToFormPosition(Point nodeId)//nodeId轉換成實際座標位置
        {
            Point formPoisition = new Point();//先開個空白的
            formPoisition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPoisition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPoisition;
        }
        private Point FindTheClosetNode(int x, int y) //Point 一個點的位置(座標)
        {
            int nodeIdX = FindTheClosetNode(x);
            if(nodeIdX == -1 || nodeIdX >= NODE_COUNT)  // 避免超出陣列邊界
            {
                return NO_MATCH_NODE;
            }
            int nodeIdY = FindTheClosetNode(y);
            if(nodeIdY == -1 || nodeIdY >= NODE_COUNT) // 避免超出陣列邊界
            {
                return NO_MATCH_NODE;
            }
            return new Point(nodeIdX, nodeIdY); //有的話Return一個Point
        }
        private int FindTheClosetNode(int pos) //對一條線上的座標點判斷
        {
            if(pos < OFFSET - NODE_RADIUS) //讓邊邊不要有手的效果
            {
                return -1;
            }
            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE; //商數:判斷 點的位置 左邊的點是誰
            int remainder = pos % NODE_DISTANCE; //餘數:判斷點的位置範圍是否界在碰撞箱(R)裡面

            if (remainder <= NODE_RADIUS) // 屬於左邊點的範圍
            {
                return quotient;
            }
            else if(remainder >=  NODE_DISTANCE - NODE_RADIUS) //屬於右邊的範圍 若大於等於(全部-右邊碰撞箱)
            {
                return quotient + 1;
            }
            else
            { 
                return -1; //沒有點符合
            }
        }
    }
}
