using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Textures;
using PovSharp.Transformations;
using PovSharp.Values;

namespace PovSharp.Demos.Droid
{
    public class DroidBody : CsgUnion
    {
        private readonly int rBody = 1;
        private readonly double rOutterSide = 0.6;
        private readonly double rInnerSide = 0.45;

        public DroidBody(Pigment mainPigment, Pigment decoPigmentMajor, Pigment decoPigmentMinor)
        {
            // Main Body
            Add(new Sphere() { Radius = rBody });

            // Sides
            var ring = new CsgDifference(
                new Cylinder { BasePoint = _V(0), CapPoint = _V(0, 0, rBody), Radius = rOutterSide }
                )
                .Add(new Cylinder { BasePoint = _V(0), CapPoint = _V(0, 0, rBody + 0.1), Radius = rInnerSide })
            ;

            Local(nameof(ring), ring);
            var bidule = new Prism{Height1=0, Height2=rBody}.Add(-0.1,0).Add(-0.05,0.2).Add(0.05,0.2).Add(0.1, 0).TranslateZ(-rInnerSide).RotateX(90);
            Local(nameof(bidule), bidule);
            var side = new CsgUnion()
                .Add(ring)
                .Add(new PovObject(bidule).RotateZ(0*90))
                .Add(new PovObject(bidule).RotateZ(1*90))
                .Add(new PovObject(bidule).RotateZ(2*90))
                .Add(new PovObject(bidule).RotateZ(3*90))
                ;

            var sides = new CsgUnion()
                .Add(new PovObject(side).RotateY(0*90))
                .Add(new PovObject(side).RotateY(1*90))
                .Add(new PovObject(side).RotateY(2*90))
                .Add(new PovObject(side).RotateY(3*90))
                .Add(new PovObject(side).RotateY(3*90))
                .Add(new PovObject(side).RotateX(90))
                .Add(new PovObject(side).RotateX(-90))
                ;

            Add(new CsgIntersection().Add(new Sphere {Radius = rBody*1.0001}).Add(sides).AddModifiers(decoPigmentMajor));
            this.TranslateY(rBody);
            AddModifiers(mainPigment);
        }

        public PovNumber Height => 2 * rBody;
    }
}