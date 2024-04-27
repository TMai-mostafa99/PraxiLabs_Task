using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderShape : Shapes
{
    public CylinderShape CylinderPrefab;

    public override Shapes GenerateShape(Color color, Quaternion rotation)
    {
        CylinderShape cylinder = Instantiate(CylinderPrefab);
        cylinder.SetShapeType(ShapesEnum.CYLINDER);
        cylinder.SetColor(color);
        cylinder.SetRotation(rotation);

        return cylinder;
    }
}
