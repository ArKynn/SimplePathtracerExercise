namespace PathTracer;

public class Material
{
    private Color albedo;
    public Ray scattered;
    public Color attenuation;
    
    
    public virtual bool Scatter(Ray r_in, HitData rec) => false;
}