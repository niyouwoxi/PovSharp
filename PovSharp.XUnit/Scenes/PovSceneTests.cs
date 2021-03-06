using System;
using NFluent;
using PovSharp.Core;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovSceneTests
    {
            private string  myScene = @"#include ""colors.inc""
camera {
 location < 7, 7, 7>
 look_at < 0, 0, 0>
}
light_source {
 < 5, 5, 5>, rgb < 1, 1, 1>
}
#declare MySphere = sphere {
 < 0, 0, 0>, 1

pigment {
 color rgb < 1, 1, 1>
}
};
MySphere".Replace("\r", string.Empty);
        [Fact]
        public void TestScene1()
        {
            PovScene scene = new PovScene();
            scene.Add(new Camera() {Location = new PovVector(7), LookAt = new PovVector(0)});
            scene.Add(new Light());

            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() {Color = new PovColor(1)});
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
            string povCode = string.Join("\n", scene.ToPovCode());
            Check.That(povCode).IsEqualTo(myScene);
        }
    
        [Fact]
        public void TestScene2()
        {
            BasicDemoScene scene = new BasicDemoScene();
            string povCode = string.Join("\n", scene.ToPovCode());
            Check.That(povCode).IsEqualTo(myScene);
        }
    }

    public class BasicDemoScene : PovScene
    {
        public BasicDemoScene()
        {
            Add(new Camera() {Location = _V(7), LookAt = _V(0)});
            Add(new Light());

            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() {Color = new PovColor(1)});
            Declare("MySphere", sphere);
            Add(sphere);
        }
    }
}