namespace PathTracer;

using System;


public class Vec3
{
    private double ex;
    private double ey;
    private double ez;

    public Vec3(double x, double y, double z)
    {
        ex = x;
        ey = y;
        ez = z;
    }

    public static Vec3 Zero()
    {
        return new Vec3(0,0,0);
    }
    
    public double x
    {
        get => ex; 
        set => ex = value; }
    
    public double y
    {
        get => ey; 
        set => ey = value; }
    
    public double z
    {
        get => ez; 
        set => ez = value; }
    
    public static Vec3 operator -(Vec3 v1) =>
        new Vec3(-v1.x, -v1.y, -v1.z );

    public static Vec3 operator -(Vec3 v1, Vec3 v2) =>
        new Vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

    public static Vec3 operator +(Vec3 v1, Vec3 v2) =>
        new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

    public static Vec3 operator *(Vec3 v1, double i) =>
        new Vec3(v1.x * i, v1.y * i, v1.z * i);

    public static Vec3 operator *(Vec3 v1, Vec3 v2) =>
        new Vec3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

    public static Vec3 operator /(Vec3 v1, double i) => v1 * (1 / i);

    public double length()
    {
        return Math.Sqrt(length_squared());
    }
    
    public double length_squared()
    {
        return ex * ex + ey * ey + ez * ez;
    }

    public bool near_zero()
    {
        var s = 1e-8;
        return Math.Abs(x) < s && Math.Abs(y) < s && Math.Abs(z) < z;
    }

    public double dot(Vec3 v2)
    {
        return x * v2.x + y * v2.y + z * v2.z;
    }

    public Vec3 cross(Vec3 v2)
    {
        return new Vec3(y * v2.z - z * v2.y,
            z * v2.x - x * v2.z,
            x * v2.y - y * v2.x);
    }

    public Vec3 random()
    {
        Random rnd = new Random();
        return new Vec3(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble());
    }

    public Vec3 random(double min, double max)
    {
        Vec3 rnd_vec3 = random();
        rnd_vec3.x = rnd_vec3.x * (max - min) + min;
        rnd_vec3.y = rnd_vec3.y * (max - min) + min;
        rnd_vec3.z = rnd_vec3.z * (max - min) + min;

        return rnd_vec3;
    }
    
    public Vec3 unitVec3()
    {
        return this / length();
    }

    public Vec3 random_in_unit_sphere()
    {
        while (true)
        {
            var p = random(-1, 1);
            if (p.length_squared() < 1)
                return p;
        }
    }

    public Vec3 random_unit_vector()
    {
        return random_in_unit_sphere().unitVec3();
    }

    public Vec3 random_on_hemisphere(Vec3 normal)
    {
        Vec3 on_unit_sphere = random_unit_vector();
        if (on_unit_sphere.dot(normal) > 0.0)
            return on_unit_sphere;
        return -on_unit_sphere;
    }

    public Vec3 reflect(Vec3 v, Vec3 n)
    {
        return v - n * (v.dot(n) * 2.0) ;
    }
}