using System.Collections.Generic;

namespace ShapeBasedMatching.Models
{
    public class Template
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int TlX { get; set; }
        public int TlY { get; set; }
        public int PyramidLevel { get; set; }
        public List<Feature> Features { get; set; } = new List<Feature>();
    }
}
