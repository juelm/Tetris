//using System;
//using System.Collections.Generic;
//using System.Drawing;

//namespace Tetris
//{
//    public class L : Shape
//    {

//        //private static ConsoleColor color = ConsoleColor.Green;
//        //private int configuration = 1;

//        public L(int x, int y)
//        {
//            this.x = x;
//            this.y = y;
//            this.color = ConsoleColor.Green;

//            int[] pos1 ={
//                0, 0, 0, 0, 0,
//                0, 0, 1, 1, 0,
//                0, 0, 0, 1, 0,
//                0, 0, 0, 1, 0,
//                0, 0, 0, 0, 0 };

//            int[] pos2 = {
//                0, 0, 0, 0, 0,
//                0, 0, 0, 1, 0,
//                0, 1, 1, 1, 0,
//                0, 0, 0, 0, 0,
//                0, 0, 0, 0, 0 };

//            int[] pos3 = {
//                0, 0, 1, 0, 0,
//                0, 0, 1, 0, 0,
//                0, 1, 1, 0, 0,
//                0, 0, 0, 0, 0,
//                0, 0, 0, 0, 0 };

//            int[] pos4 = {
//                0, 0, 0, 0, 0,
//                0, 0, 1, 0, 0,
//                0, 0, 1, 1, 1,
//                0, 0, 0, 0, 0,
//                0, 0, 0, 0, 0 };

//            configurations.Add(1, pos1);
//            configurations.Add(2, pos2);
//            configurations.Add(3, pos3);
//            configurations.Add(4, pos4);


//        }

//        //public override void Arrange(int[] arr)
//        //{

//        //    prior = blocks;

//        //    int posX = x;
//        //    int posY = y;

//        //    Block bk = new Block(posX, y, color);

//        //    int addHeight = bk.Height;
//        //    int addWidth = bk.Width;

//        //    int blockIndex = 0;

//        //    for (int i = 0; i < arr.Length; i++)
//        //    {
//        //        if (i % 5 == 0)
//        //        {
//        //            posY += addHeight;
//        //            posX = x;
//        //        }

//        //        else
//        //        {
//        //            posX += addWidth;
//        //        }

//        //        if (arr[i] == 1)
//        //        {
//        //            Block blk = new Block(posX, posY, color);
//        //            blk.inflate();
//        //            blocks[blockIndex] = blk;
//        //            blockIndex++;
//        //        }

//        //    }
//        //}

//        //public override void Mutate()
//        //{
//        //    int[] pos1 ={
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 1, 1, 0,
//        //        0, 0, 0, 1, 0,
//        //        0, 0, 0, 1, 0,
//        //        0, 0, 0, 0, 0 };

//        //    int[] pos2 = {
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 0, 1, 0,
//        //        0, 1, 1, 1, 0,
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 0, 0, 0 };

//        //    int[] pos3 = {
//        //        0, 0, 1, 0, 0,
//        //        0, 0, 1, 0, 0,
//        //        0, 1, 1, 0, 0,
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 0, 0, 0 };

//        //    int[] pos4 = {
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 1, 0, 0,
//        //        0, 0, 1, 1, 1,
//        //        0, 0, 0, 0, 0,
//        //        0, 0, 0, 0, 0 };

//        //    switch (configuration)
//        //    {
//        //        case 0:
//        //            Arrange(pos1);
//        //            break;
//        //        case 1:
//        //            Arrange(pos2);
//        //            break;
//        //        case 3:
//        //            Arrange(pos3);
//        //            break;
//        //        case 4:
//        //            Arrange(pos4);
//        //            break;
//        //    }

//        //    delete();
//        //    render();

//        //    configuration++;

//        //}
//    }
//}
