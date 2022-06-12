using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FlexibleUIInstance : Editor
{
    [MenuItem("GameObject/Flexible UI/ColorElement", priority = 0)]
    public static void AddColorElement()
    {
        Create("ColorElement");
    }

    [MenuItem("GameObject/Flexible UI/TintElement", priority = 0)]
    public static void AddTintElement()
    {
        Create("TintElement");
    }

    [MenuItem("GameObject/Flexible UI/SpoilerElement", priority = 0)]
    public static void AddSpoilerElement()
    {
        Create("SpoilerElement");
    }

    [MenuItem("GameObject/Flexible UI/WheelElement", priority = 0)]
    public static void AddWheelElement()
    {
        Create("WheelElement");
    }

    [MenuItem("GameObject/Flexible UI/ExhaustElement", priority = 0)]
    public static void AddExhaustElement()
    {
        Create("ExhaustElement");
    }

    [MenuItem("GameObject/Flexible UI/UIGroupElement", priority = 0)]
    public static void AddUIGroupElement()
    {
        Create("UIGroupElement");
    }

    [MenuItem("GameObject/Flexible UI/AdditionalUIButton", priority = 0)]
    public static void AddAdditionalUIButton()
    {
        Create("AdditionalUIButton");
    }

    [MenuItem("GameObject/Flexible UI/UITable", priority = 0)]
    public static void AddAdditionalUITable()
    {
        Create("AdditionalUITable");
    }


    static GameObject clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = objectName;
        clickedObject = UnityEditor.Selection.activeObject as GameObject;

        if (clickedObject != null)
        {
            instance.transform.SetParent(clickedObject.transform, false);

        }
        return instance;
    }
    
}
