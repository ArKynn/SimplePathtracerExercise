using System;

namespace PathTracer;

public class Sphere : RayHittable
{
    private Vec3 center;
    private double radius;
    private Material mat;
    
    public Sphere(Vec3 _center, double _radius, Material _material)
    {
        center = _center;
        radius = _radius;
        mat = _material;
    }

    public override bool hit(Ray r, Interval ray_t,
        HitData rec)
    {
        Vec3 oc = r.origin() - center;
        var a = r.direction().length_squared();
        var half_b = oc.dot(r.direction());
        var c = oc.length_squared() - radius * radius;

        var discriminant = half_b * half_b - 4 * a * c;
        if (discriminant < 0) return false;
        var sqrtd = Math.Sqrt(discriminant);

        var root = (-half_b - sqrtd) / a;
        if (!ray_t.Surrounds(root))
        {
            root = (-half_b + sqrtd) / a;
            if (!ray_t.Surrounds(root))
                return false;
        }

        rec.t = root;
        rec.point = r.PointAt(rec.t);
        Vec3 out_normal = (rec.point - center) / radius;
        rec.set_face_normal(r, out_normal);
        rec.mat = mat;

        return true;
    }
}