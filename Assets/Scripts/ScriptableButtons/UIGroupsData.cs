using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Flexible UIGroups Data")]
public class UIGroupsData : ScriptableObject
{
    public GameObject wheelsGroupImage;
    public String wheelsGroupName;

    public GameObject spoilersGroupImage;
    public String spoilersGroupName;

    public GameObject exhaustsGroupImage;
    public String exhaustsGroupName;

    public Material materialsGroupImage;
    public String materialsGroupName;
}
