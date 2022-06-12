using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Flexible AdditionalUI Data")]
public class AdditionalUIData : ScriptableObject
{
    public Sprite backButtonImage;

    public Sprite carLightsImage;
    public String carLightsText;

    public Sprite engFlagImage;
    public String englishLanguageName;

    public Sprite czFlagImage;
    public String czechLanguageName;

    public Sprite screenShotImage;
    public String screenShotName;
}
