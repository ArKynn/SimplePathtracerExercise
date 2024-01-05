namespace PathTracer;

public abstract class RayHittable
{
    public virtual bool hit(Ray r, Interval ray_t,
        HitData hitData)
    {
        return false;
    }
}