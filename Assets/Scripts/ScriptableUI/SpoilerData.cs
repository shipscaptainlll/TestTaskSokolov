using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Flexible Spoiler Data")]
public class SpoilerData : ScriptableObject
{
    public Sprite spoiler1Image;
    public GameObject spoiler1;

    public Sprite spoiler2Image;
    public GameObject spoiler2;

    public Sprite spoiler3Image;
    public GameObject spoiler3;
}
