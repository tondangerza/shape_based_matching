using System;
using System.Numerics;

namespace ShapeBasedMatching.ImageProcessing
{
    public static class Spread
    {
        public static byte[,] Compute(byte[,] src, int T)
        {
            int height = src.GetLength(0);
            int width = src.GetLength(1);
            byte[,] dst = new byte[height, width];
            byte[] srcLine = new byte[width];
            byte[] dstLine = new byte[width];

            for (int r = 0; r < T; ++r)
            {
                for (int c = 0; c < T; ++c)
                {
                    for (int y = 0; y < height - r; ++y)
                    {
                        Buffer.BlockCopy(src, ((r + y) * width + c) * sizeof(byte), srcLine, 0, (width - c));
                        Buffer.BlockCopy(dst, (y * width) * sizeof(byte), dstLine, 0, width);
                        Utils.OrUnaligned(srcLine, width, dstLine, width, width - c, 1);
                        Buffer.BlockCopy(dstLine, 0, dst, (y * width) * sizeof(byte), width);
                    }
                }
            }
            return dst;
        }
    }
}
