using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesManager : MonoBehaviour
{

    [SerializeField] private ShapesFactory shapeFactory; // Factory for generation
    private Shapes currShape; // current shape on display
    private Color defColor = Color.white;
    private Quaternion defRotation = Quaternion.identity;

    private void Start()
    {
        currShape = shapeFactory.GenerateShape(ShapesEnum.CUBE , defColor,defRotation); //Initial shape to be generated
    }

    //------------Buttons Functions-------------//
    public void GenerateSphereShape()
    {
       Destroy(currShape.gameObject);
        currShape = shapeFactory.GenerateShape(ShapesEnum.SPHERE, defColor, defRotation);
    }
    public void GenerateCubeShape()
    {
        Destroy(currShape.gameObject);
        currShape = shapeFactory.GenerateShape(ShapesEnum.CUBE, defColor, defRotation);
    }
    public void GenerateCylinderShape()
    {
        Destroy(currShape.gameObject);
        currShape = shapeFactory.GenerateShape(ShapesEnum.CYLINDER, defColor, defRotation);
    }

    public void ChangeShapeColorToGreen()
    {
        currShape.SetColor(Color.green);
    }
    public void ChangeShapeColorToRed()
    {
        currShape.SetColor(Color.red);
    }
    public void ChangeShapeColorToBlue()
    {
        currShape.SetColor(Color.blue);
    }

    /// <summary>
    /// Calls SaveLoad Manager to save current shape to xml
    /// </summary>
    public void SaveShape()
    {
        SaveLoadManager.SaveShape(currShape);
    }
    /// <summary>
    /// Load properties of shape to be generated from LoadSaveManager and generates it
    /// </summary>
    public void LoadShape()
    {
        Destroy(currShape.gameObject);
        (ShapesEnum type, Color c, Quaternion r) = SaveLoadManager.LoadShape();
        currShape = shapeFactory.GenerateShape(type, c, r);
        
    }
}
