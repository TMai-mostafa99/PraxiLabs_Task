using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesManager : MonoBehaviour
{

     public ShapesFactory ShapeFactory;
     public Shapes CurrShape;
    // Start is called before the first frame update
    private Color defColor = Color.white;
    private Quaternion defRotation = Quaternion.identity;
    private void Start()
    {
        CurrShape = ShapeFactory.GenerateShape(ShapesEnum.CUBE , defColor,defRotation); //Initial shape to be generated
    }

    //------------Buttons Functions-------------//
    public void GenerateSphereShape()
    {
       Destroy(CurrShape.gameObject);
        CurrShape = ShapeFactory.GenerateShape(ShapesEnum.SPHERE, defColor, defRotation);
    }
    public void GenerateCubeShape()
    {
        Destroy(CurrShape.gameObject);
        CurrShape = ShapeFactory.GenerateShape(ShapesEnum.CUBE, defColor, defRotation);
    }
    public void GenerateCylinderShape()
    {
        Destroy(CurrShape.gameObject);
        CurrShape = ShapeFactory.GenerateShape(ShapesEnum.CYLINDER, defColor, defRotation);
    }

    public void ChangeShapeColorToGreen()
    {
        CurrShape.SetColor(Color.green);
    }
    public void ChangeShapeColorToRed()
    {
        CurrShape.SetColor(Color.red);
    }
    public void ChangeShapeColorToBlue()
    {
        CurrShape.SetColor(Color.blue);
    }

    /// <summary>
    /// Calls SaveLoad Manager to save current shape to xml
    /// </summary>
    public void SaveShape()
    {
        SaveLoadManager.SaveShape(CurrShape);
    }
    /// <summary>
    /// Load properties of shape to be generated from LoadSaveManager and generates it
    /// </summary>
    public void LoadShape()
    {
        Destroy(CurrShape.gameObject);
        (ShapesEnum type, Color c, Quaternion r) = SaveLoadManager.LoadShape();
        CurrShape = ShapeFactory.GenerateShape(type, c, r);
        
    }
}
