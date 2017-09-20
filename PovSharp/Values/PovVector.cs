using PovSharp.Core;

namespace PovSharp.Values
{
    public class PovVector : AbstractPovValue
    {
        [PovField(0, Before="<", After=",")]
        public PovNumber X { get; set; }
        [PovField(1, After=",")]
        public PovNumber Y { get; set; }
        [PovField(2, After=">")]
        public PovNumber Z { get; set; }
        
        public PovVector() : base(null) {}
        public PovVector(string name, PovNumber x, PovNumber y, PovNumber z) : base(name)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PovVector(double x, double y, double z) : this(null, x, y, z) {}
        public PovVector(string name) : this(name, 0, 0, 0) {}
        public PovVector(string name, double d): this(name, d, d, d) {}
        public PovVector(double d): this(null, d, d, d) {}

        public override string ToPovCode() => this.BuildPovCode();
    }
}