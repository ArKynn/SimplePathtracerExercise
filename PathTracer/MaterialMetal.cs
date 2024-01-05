namespace PathTracer;

public class MaterialMetal : Material
{
    private Color albedo;
    public Ray scattered;
    public Color attenuation;

    public MaterialMetal(Color a)
    {
        albedo = a;
    }

    public override bool Scatter(Ray r_in, HitData rec)
    {
        Vec3 reflected = Vec3.Zero().reflect(r_in.direction().unitVec3(), rec.normal);
        scattered = new Ray(rec.point, reflected);
        attenuation = albedo;
        return true;
    }
}