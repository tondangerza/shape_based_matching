using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ShapeBasedMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple demo of loading image and writing output using Emgu
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: dotnet run <image>");
                return;
            }

            string path = args[0];
            using var img = new Mat(path, ImreadModes.Grayscale);
            if (img.IsEmpty)
            {
                Console.WriteLine("cannot open " + path);
                return;
            }

            // Example processing: just save the image back without imshow
            string outPath = System.IO.Path.ChangeExtension(path, "_out.png");
            img.Save(outPath);
            Console.WriteLine($"Saved result to {outPath}");
        }
    }
}
