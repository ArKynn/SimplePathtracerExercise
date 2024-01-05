namespace PathTracer;

public class MaterialLambertian : Material
{
    private Color albedo;
    public Ray scattered;
    public Color attenuation;
    
    public MaterialLambertian(Color a)
    {
        albedo = a;
    }

    public override bool Scatter(Ray r_in, HitData rec)
    {
        var scatter_direction = rec.normal + Vec3.Zero().random_unit_vector();

        if (scatter_direction.near_zero())
            scatter_direction = rec.normal;
        
        scattered = new Ray(rec.point, scatter_direction);
        attenuation = albedo;
        return true;    
    }
}