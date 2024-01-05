using System.Collections.Generic;

namespace PathTracer;

public class RayHittableList : RayHittable
{
    private List<RayHittable> list;
    
    public RayHittableList()
    {
        list = new List<RayHittable>();
    }

    public RayHittableList(RayHittable obj)
    {
        list = new List<RayHittable> ();
        Add(obj);
    }

    public void Add(RayHittable obj)
    {
        list.Add(obj);
    }

    public override bool hit(Ray r, Interval ray_t, HitData hitData)
    {
        HitData temp_data = new HitData();
        bool hit_anything = false;
        var closest = ray_t.max;
        

        foreach (var rayHittable in list)
        {
            if (rayHittable.hit(r, new Interval(ray_t.min, closest), temp_data))
            {
                hit_anything = true;
                closest = temp_data.t;
                hitData = temp_data;
            }
        }

        return hit_anything;
    }
}