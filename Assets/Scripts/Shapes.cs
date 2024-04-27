using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shapes : MonoBehaviour
{
    private ShapesEnum type;
    private Color color;
    private Quaternion rotation;


    private float speed = 10f;
    public void SetShapeType(ShapesEnum t)
    {
        type = t;
    }
    public ShapesEnum GetShapeType()
    {
        return type;
    }
    /// <summary>
    /// Change material color to given color
    /// </summary>
    /// <param name="c">Color for material</param>
    public void SetColor(Color c)
    {
        color = c;
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
    /// <summary>
    /// Get color of object
    /// </summary>
    /// <returns> current color of object </returns>
    public Color GetColor()
    {
        return color;
    }
    /// <summary>
    /// Set rotation of object
    /// </summary>
    /// <param name="angles"> rotation to be set </param>
    public void SetRotation(Quaternion angles)
    {
        rotation = angles;
        transform.rotation = rotation;
    }
    /// <summary>
    /// Get current rotation of object
    /// </summary>
    /// <returns> rotation (Quaternion)</returns>
    public Quaternion GetRotation() 
    {
        rotation = transform.rotation;
        return rotation;
    }
    /// <summary>
    /// Instantiate different shapes using child classes
    /// </summary>
    /// <param name="color">color of object</param>
    /// <param name="rotation">rotation of object</param>
    /// <returns></returns>
    public abstract Shapes GenerateShape(Color color, Quaternion rotation);
    private void Update()
    {
        if (Input.GetMouseButton(1)) // rotate using right mouse click
        {
            //Debug.Log("Right click");
            float xAxisRotation = Input.GetAxis("Mouse X") * speed;
            float yAxisRotation = Input.GetAxis("Mouse Y") * speed;

            transform.Rotate(Vector3.down, xAxisRotation); 
            transform.Rotate(Vector3.right, yAxisRotation);
        }
    }

}
