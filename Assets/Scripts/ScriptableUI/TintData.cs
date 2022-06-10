using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Flexible Tint Data")]
public class TintData : ScriptableObject
{

    public Color metallColor;
    public Material metallicMaterial;

    public Color matteColor;
    public Material matteMaterial;
}
