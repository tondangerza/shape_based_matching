using System;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ShapeBasedMatching.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Feature
    {
        public int X;
        public int Y;
        public int Label;
        public float Theta;
    }
}
