using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;
using System.Windows.Forms;
public class SaveLoadManager :MonoBehaviour
{
    private static string filePath;

    // Start is called before the first frame update
    /// <summary>
    /// Convert Shape data to string in XMl format
    /// </summary>
    /// <param name="curr"></param>
    private static void SaveShapeXmlToFile(Shapes curr)
    {
        XmlDocument xmlDocument = new XmlDocument();

        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("FileName", "Shape_Data");

        XmlElement typeElement = xmlDocument.CreateElement("ShapeType");
        typeElement.InnerText = curr.GetShapeType().ToString();
        root.AppendChild(typeElement);

        XmlElement colorElement = xmlDocument.CreateElement("ShapeColor");
        colorElement.InnerText = curr.GetColor().ToString(); ;
        root.AppendChild(colorElement);

        XmlElement rotationElementX = xmlDocument.CreateElement("ShapeRotationX");
        rotationElementX.InnerText = curr.GetRotation().x.ToString(); ;
        root.AppendChild(rotationElementX);

        XmlElement rotationElementY = xmlDocument.CreateElement("ShapeRotationY");
        rotationElementY.InnerText = curr.GetRotation().y.ToString(); ;
        root.AppendChild(rotationElementY);

        XmlElement rotationElementZ = xmlDocument.CreateElement("ShapeRotationZ");
        rotationElementZ.InnerText = curr.GetRotation().z.ToString(); ;
        root.AppendChild(rotationElementZ);

        XmlElement rotationElementW = xmlDocument.CreateElement("ShapeRotationW");
        rotationElementW.InnerText = curr.GetRotation().w.ToString(); ;
        root.AppendChild(rotationElementW);

        xmlDocument.AppendChild(root);

        xmlDocument.Save(filePath);
    }
    public static  void SaveShape(Shapes curr)
    {
        //open dialogue to choose save place
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //save as xml
        saveFileDialog.Filter = "XML files (*.xml)|*.xml";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            //enter file name
            filePath = saveFileDialog.FileName;

            // Save shape XML data to the selected file
            SaveShapeXmlToFile(curr);
            Debug.Log("XML SAVED");
        }


    }
    public static  (ShapesEnum , Color , Quaternion ) LoadShape()
    {
        //open dialogue to choose load place
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "XML files (*.xml)|*.xml";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = openFileDialog.FileName;

            // Load XML data from the selected file
            Debug.Log("File OPENED");
            return LoadXmlShapeData();
           
        }
        else
        {
            Debug.Log("file not found");
            //return default shape
            return (ShapesEnum.CUBE, Color.white, Quaternion.identity); 
        }
    }
    /// <summary>
    /// Load Data from XML file
    /// </summary>
    /// <returns>Type of obj , Color of obj , rotation of obj</returns>
    public static (ShapesEnum, Color, Quaternion) LoadXmlShapeData()
    {
        ShapesEnum shapeEnumType;
        Color shapeColor;
        Quaternion shapeRotation;


        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);
        XmlNode saveNode = xmlDocument.SelectSingleNode("Save");

        shapeEnumType = (ShapesEnum)Enum.Parse(typeof(ShapesEnum), saveNode.SelectSingleNode("ShapeType").InnerText);
        shapeColor = ParseColor(saveNode.SelectSingleNode("ShapeColor").InnerText);

        float x = float.Parse(saveNode.SelectSingleNode("ShapeRotationX").InnerText);
        float y = float.Parse(saveNode.SelectSingleNode("ShapeRotationY").InnerText);
        float z = float.Parse(saveNode.SelectSingleNode("ShapeRotationZ").InnerText);
        float w = float.Parse(saveNode.SelectSingleNode("ShapeRotationW").InnerText);
        shapeRotation = new Quaternion(x, y, z, w);

        return (shapeEnumType, shapeColor, shapeRotation);
    }
    /// <summary>
    /// Convert RGBA Text to actual Color
    /// </summary>
    /// <param name="colorString">string containing rgba values</param>
    /// <returns>Color </returns>
    private static Color ParseColor(string colorString)
    {
        // Remove 'RGBA(' and ')' from the string
        colorString = colorString.Replace("RGBA(", "").Replace(")", "");
        string[] components = colorString.Split(',');//Split

        // Parse the components into floats
        float r = float.Parse(components[0]);
        float g = float.Parse(components[1]);
        float b = float.Parse(components[2]);
        float a = float.Parse(components[3]);

        // Create and return the color
        Color color = new Color(r, g, b, a);
        return color;
    }
}
