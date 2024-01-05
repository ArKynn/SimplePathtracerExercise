namespace PathTracer;

public class Ray 
{
    private Vec3 orig;
    private Vec3 dir;
    
    public Ray(Vec3 _origin, Vec3 _direction)
    {
        orig = _origin;
        dir = _direction;
    }

    public Vec3 origin() => orig;
    public Vec3 direction() => dir;

    public Vec3 PointAt(double t)
    {
        return orig + dir * t;
    }
}