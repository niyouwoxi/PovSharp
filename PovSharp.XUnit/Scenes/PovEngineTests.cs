using PovSharp.Csg;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovEngineTests : AbstractPovEngineTests
    {
        public PovEngineTests()
        {
        }

        public void AddBlueSphere()
        {
            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() { Color = new PovColor(0, 0, 1) });
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
        }

        [Fact(Skip = "true")]
        public void BasicSceneTest()
        {
            scene.Name = "TestBlueSphere";
            AddBlueSphere();
            var path = engine.Render(scene, options, false);
        }

        [Fact]//(Skip = "true")]
        public void DemoObjectsTest()
        {
            scene.Name = "DemoObjects";
            AddBlueSphere();

            var cone = new Cone();
            cone.AddModifiers(new Pigment() { Color = new PovColor(0, 1, 1) });
            cone.AddModifiers(new Translation(2, 0, 0));
            scene.Add(cone);

            var cylinder = new Cylinder();
            cylinder.AddModifiers(new Pigment() { Color = new PovColor(1, 0, 1) });
            cylinder.AddModifiers(new Translation(-2, 0, 0));
            scene.Add(cylinder);

            var ovus = new Ovus();
            ovus.AddModifiers(new Pigment() { Color = new PovColor(1, 1, 0) });
            ovus.AddModifiers(new Translation(0, 0, 2));
            scene.Add(ovus);

            var torus = new Torus();
            torus.AddModifiers(new Pigment() { Color = new PovColor(0, 1, 0) });
            torus.AddModifiers(new Translation(0, 0, 5));
            scene.Add(torus);

            var box = new Box();
            box.AddModifiers(new Pigment() { Color = new PovColor(1, 0, 0) });
            box.AddModifiers(new Translation(0, 0, -2));
            scene.Add(box);

            var plane = new Plane() { Distance = -1 };
            plane.AddModifiers(new Pigment() { Color = new PovColor(1, 0.5, 0.25) });
            scene.Add(plane);

            var lathe = new Lathe();
            lathe.Add(2, 0).Add(3, 0).Add(3, 1).Add(2, 5).Add(2, 0);
            lathe.AddModifiers(new Pigment() { Color = new PovColor(1, 1, 0.5) });
            lathe.AddModifiers(new Scale(new PovVector(0.25, 0.25, 0.25)));
            lathe.AddModifiers(new Translation(2, 0, -2));
            scene.Add(lathe);

            var sor = new SurfaceOfRevolution();
            sor.Add(2, 0).Add(3, 0).Add(1, 1).Add(2, 5).Add(2, 0);
            sor.AddModifiers(new Pigment() { Color = new PovColor(0.5, 1, 0.5) });
            sor.AddModifiers(new Scale(new PovVector(0.25, 0.25, 0.25)));
            sor.AddModifiers(new Translation(2, 0, 2));
            scene.Add(sor);

            var path = engine.Render(scene, options, false);
        }
        [Fact]//(Skip="true")]
        public void CsgDemoTest()
        {
            scene.Name = "TestCsg";

            var cylinderX = new Cylinder() { BasePoint = new PovVector(-2, 0, 0), CapPoint = new PovVector(2, 0, 0), Radius = 0.5 };
            var cylinderY = new Cylinder() { BasePoint = new PovVector(0, -2, 0), CapPoint = new PovVector(0, 2, 0), Radius = 0.5 };
            var cylinderZ = new Cylinder() { BasePoint = new PovVector(0, 0, -2), CapPoint = new PovVector(0, 0, 2), Radius = 0.5 };

            var csgUnion = new CsgUnion();
            csgUnion.Add(cylinderX).Add(cylinderY).Add(cylinderZ);
            csgUnion.AddModifiers(new Pigment(new PovColor(1, 0, 0)));
            scene.Add(csgUnion);

            var csgIntersection = new CsgIntersection();
            csgIntersection
                .Add(cylinderX)
                .Add(cylinderY)
                .Add(cylinderZ)
                .AddModifiers(new Pigment(new PovColor(0, 1, 0)))
                .AddModifiers(new Translation(new PovVector(0, 0, 3)));

            scene.Add(csgIntersection);

            var csgDifference = new CsgDifference(cylinderX);
            csgDifference
                .Add(cylinderY)
                .Add(cylinderZ)
                .AddModifiers(new Pigment(new PovColor(0, 0, 1)))
                .AddModifiers(new Translation(new PovVector(3, 0, -3)));

            scene.Add(csgDifference);
            var path = engine.Render(scene, options, false);
        }
    }
}