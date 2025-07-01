using System;
using System.Numerics;

namespace ShapeBasedMatching.ImageProcessing
{
    public static class Utils
    {
        public static void OrUnaligned(byte[] src, int srcStride, byte[] dst, int dstStride, int width, int height)
        {
            for (int r = 0; r < height; ++r)
            {
                int srcOffset = r * srcStride;
                int dstOffset = r * dstStride;
                int c = 0;
                // align to vector boundary
                while (((srcOffset + c) % Vector<byte>.Count) != 0 && c < width)
                {
                    dst[dstOffset + c] |= src[srcOffset + c];
                    c++;
                }
                for (; c <= width - Vector<byte>.Count; c += Vector<byte>.Count)
                {
                    var vSrc = new Vector<byte>(src, srcOffset + c);
                    var vDst = new Vector<byte>(dst, dstOffset + c);
                    var vRes = Vector.BitwiseOr(vSrc, vDst);
                    vRes.CopyTo(dst, dstOffset + c);
                }
                for (; c < width; c++)
                    dst[dstOffset + c] |= src[srcOffset + c];
            }
        }
    }
}
