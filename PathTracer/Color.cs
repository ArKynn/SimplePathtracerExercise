using System;
using System.Runtime.Intrinsics.Arm;

namespace PathTracer;

public class Color : Vec3
{
    public Color(double x, double y, double z) : base(x, y, z)
    {
    }

    public string write_color(Color pixelColor, int samples_per_pixel)
    {
        var r = pixelColor.x;
        var g = pixelColor.y;
        var b = pixelColor.z;

        var scale = 1.0 / samples_per_pixel;
        r *= scale;
        g *= scale;
        b *= scale;

        return
            $"{Math.Clamp(r, 0, 0.999) * 256} {Math.Clamp(g, 0, 0.999) * 256} {Math.Clamp(b, 0, 0.999) * 256}";
    }
    
    public static Color operator -(Color v1, Color v2) =>
        new Color(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

    public static Color operator +(Color v1, Color v2) =>
        new Color(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

    public static Color operator +(Color c1, Vec3 v1) =>
        new Color(c1.x + v1.x, c1.y + v1.y, c1.z + v1.z);

    public static Color operator *(Color v1, double i) =>
        new Color(v1.x * i, v1.y * i, v1.z * i);

    public static Color operator *(Color v1, Color v2) =>
        new Color(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

    public static Color operator /(Color v1, double i) => v1 * (1 / i);
    
}