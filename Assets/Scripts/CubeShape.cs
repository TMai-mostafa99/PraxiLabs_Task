using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShape : Shapes
{
    public CubeShape CubePrefab; 


    /// <summary>
    /// Instantiate shape and set its initial properties
    /// </summary>
    public override Shapes GenerateShape(Color color, Quaternion rotation)
    {
        CubeShape cube = Instantiate(CubePrefab);
        cube.SetShapeType(ShapesEnum.CUBE);
        cube.SetColor(color);
        cube.SetRotation(rotation);
        return cube;
    }
}
