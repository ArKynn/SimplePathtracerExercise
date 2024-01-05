using System;
using System.IO;

namespace PathTracer;

public class Camera
{
    private const double infinity = double.PositiveInfinity;
    private const double pi = 3.141592653589792385;

    private double Degrees_to_radians(double degrees) => degrees * pi / 180;

    private Random rnd = new Random();
    
    private Vec3 pixel_delta_u;
    private Vec3 pixel_delta_v;
    private Vec3 pixel00_loc;
    
    public float aspectRatio = 16.0f / 9.0f;
    public int imageWidth = 400;
    private int imageHeight;
    private int max_ray_bounces = 10;
    private int samples_per_pixel = 10;
    
    private Vec3 camera_center;

    public Camera()
    {
        imageHeight = (int)(imageWidth / aspectRatio);
        imageHeight = imageHeight < 1 ? 1 : imageHeight;
        
        float focal_length = 1.0f;
        float viewport_height = 2.0f;
        float viewport_width =
            viewport_height * (imageWidth / imageHeight);
        
        camera_center = new Vec3(0, 0, 0);

        Vec3 viewport_u = new Vec3(viewport_width, 0, 0);
        Vec3 viewport_v = new Vec3(0, -viewport_height, 0);

       
        pixel_delta_u = viewport_u / imageWidth;
        
        pixel_delta_v = viewport_v / imageHeight;

        Vec3 viewport_upper_left = camera_center -
                                   new Vec3(0, 0, focal_length) -
                                   viewport_u / 2 - viewport_v / 2;
        
        pixel00_loc = viewport_upper_left +
                      (pixel_delta_u + pixel_delta_v) * 0.5;
    }
    
    private double random_double()
    {
        return rnd.NextDouble();
    }

    private double random_double(double min, double max)
    {
        return min + (max - min) * random_double();
    }
    
    private Color ray_color(Ray r, int depth, RayHittable world)
    {
        HitData rec = new HitData();

        if (depth <= 0)
            return new Color(0, 0, 0);
        
        if (world.hit(r, new Interval(0.001, infinity), rec))
        {
            if (rec.mat.Scatter(r, rec))
                return rec.mat.attenuation *
                       ray_color(rec.mat.scattered, depth - 1, world);
            return new Color(0, 0, 0);
        }

        Vec3 unit_direction = r.direction().unitVec3();
        var a = (unit_direction.y + 1.0) * 0.5;
        return new Color(1.0, 1.0, 1.0) * (1.0 - a) +
               new Color(0.5, 0.7, 1.0) * a;
    }

    private Ray Get_Ray(int i, int j)
    {
        Vec3 pixel_center = pixel00_loc + pixel_delta_u * j +
                            pixel_delta_v * i;
        Vec3 pixel_sample = pixel_center + pixel_sample_square();
        
        Vec3 ray_origin = camera_center;
        Vec3 ray_direction = pixel_sample - camera_center;
        
        return new Ray(ray_origin, ray_direction);
        
    }

    private Vec3 pixel_sample_square()
    {
        var px = random_double() + -0.5;
        var py = random_double() + -0.5;
        return pixel_delta_u * px + pixel_delta_v * py;
    }
    
    public void render(RayHittableList World)
    {
        string outputPath =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
        using StreamWriter outputFile =
            new StreamWriter(Path.Combine(outputPath,
                "PathTracerImage.ppm"));
        
        outputFile.WriteLine("P3");
        outputFile.WriteLine($"{imageWidth} {imageHeight}");
        outputFile.WriteLine("255");

        
        for (int i = 0; i < imageHeight; i++)
        {
            Console.WriteLine($"Scanlines remaining: {imageHeight - i}");
            for (int j = 0; j < imageWidth; j++)
            {
                Color pixelColor = new Color(0, 0, 0);
                for (int s = 0; s < samples_per_pixel; s++)
                {
                    Ray r = Get_Ray(i, j);
                    pixelColor += ray_color(r, max_ray_bounces, World);
                }

                outputFile.WriteLine(pixelColor.write_color(pixelColor, samples_per_pixel));
            }
        }
    }
}