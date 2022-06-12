using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenShot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string saveDataPath;
    [Header("Optional")]
    [SerializeField] bool turnOffUI;

    static GameObject mainUICanvas;
    static bool takeScreenshot;
    static int screenshotID;
    
    static string screenshotsDataPath;
    static bool nonUIScreenshots;

    static ScreenShot instance;

    void Start()
    {
        instance = this;
        OnAfterDeserialize();
        if (string.IsNullOrEmpty(screenshotsDataPath))
        {
            screenshotsDataPath = (Application.dataPath + "/Screenshots").ToString();
        }
        mainUICanvas = GameObject.FindWithTag("UI");
    }


    //Rychle se objevuje ve folder aplikaci /Assets/Screenshot. Ve stejnem folder v Unity je potreba pockat, az system ho aktualizuje
    public static void TakeScreenshot()
    {
        instance.StartCoroutine(MakeScreenshot());
    }

    //Jestli flickering UI vadi, da se to udelat i jinym spusobem
    public static IEnumerator MakeScreenshot()
    {
        yield return null;

        while (System.IO.File.Exists(screenshotsDataPath + "/screenshot" + screenshotID + ".png"))
        {
            screenshotID++;
        }

        if (nonUIScreenshots) { mainUICanvas.SetActive(false); }

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot(screenshotsDataPath + "/screenshot" + screenshotID + ".png");

        if (nonUIScreenshots) { mainUICanvas.SetActive(true); }
    }

    void OnAfterDeserialize()
    {
        screenshotsDataPath = saveDataPath;
        nonUIScreenshots = turnOffUI;
    }
}
