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
            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() { Color = new PovColor(0, 0, 1) });
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
        }

        [Fact(Skip = "true")]
        public void BasicSceneTest()
        {
            scene.Name = "TestBlueSphere";
            var path = engine.Render(scene, options, false);
        }
        [Fact(Skip="true")]
        public void DemoSceneTest()
        {
            scene.Name = "TestDemo";
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

            var path = engine.Render(scene, options, false);
        }
    }
}