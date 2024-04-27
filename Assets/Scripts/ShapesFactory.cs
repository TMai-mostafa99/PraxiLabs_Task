using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Responsible for Controlling and Generaing Shapes
/// </summary>
public class ShapesFactory : MonoBehaviour
{
    public List<Shapes> ShapesPrefabs;//List of all shapes

    /// <summary>
    /// Return generated shape
    /// </summary>
    /// <param name="shape">shape type</param>
    /// <param name="c"> color  </param>
    /// <param name="r"> rotation </param>
    /// <returns></returns>
    public Shapes GenerateShape(ShapesEnum shape,Color c , Quaternion r)
    {
        switch (shape)
        {
            case ShapesEnum.CUBE:
                return ShapesPrefabs[0].GenerateShape(c,r);
 
            case ShapesEnum.CYLINDER:
                return ShapesPrefabs[1].GenerateShape(c,r);

            case ShapesEnum.SPHERE:
                return ShapesPrefabs[2].GenerateShape(c,r);

        }
        return null;
    }

}
