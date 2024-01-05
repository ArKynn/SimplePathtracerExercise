namespace PathTracer;

public class HitData
{
    public Vec3 point = new Vec3(0 ,0, 0);
    public Vec3 normal = new Vec3(0, 0, 0);
    public Material mat;
    public double t;
    private bool front_face;

    public void set_face_normal(Ray ray, Vec3 outward_normal)
    {
        front_face = ray.direction().dot(outward_normal) < 0;
        normal = front_face ? outward_normal : -outward_normal;
    }
}