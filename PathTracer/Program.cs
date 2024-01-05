using System;
using System.Collections.Generic;
using static PathTracer.Vec3;
using System.IO;

namespace PathTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            var MetalMaterial = new MaterialMetal(new Color(0.8, 0.8, 0.8));
            var LambertianMaterial =
                new MaterialLambertian(new Color(0.7, 0.3, 0.3));
            
            
            
            
            RayHittableList World = new RayHittableList();
            World.Add(new Sphere(new Vec3(0,0, -1), 0.5, MetalMaterial));
            World.Add(new Sphere(new Vec3(0, -100.5, -1), 100, LambertianMaterial));

            Camera cam = new Camera();
            

            cam.render(World);
        }
    }
}