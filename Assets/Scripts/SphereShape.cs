using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShape : Shapes
{
    public SphereShape SpherePrefab;

    public override Shapes GenerateShape(Color color, Quaternion rotation)
    {
        SphereShape sphere = Instantiate(SpherePrefab);
        sphere.SetShapeType(ShapesEnum.SPHERE);
        sphere.SetColor(color);
        sphere.SetRotation(rotation);
        return sphere;
    }
}
