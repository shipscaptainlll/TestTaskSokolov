using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Flexible Tint Data")]
public class TintData : ScriptableObject
{

    public Material metallImage;
    [Range(0.0f, 1.0f)]
    public float metallicMaterial;

    public Material matteImage;
    [Range(0.0f, 1.0f)]
    public float matteMaterial;
}
