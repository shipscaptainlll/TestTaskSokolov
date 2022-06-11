using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenShot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Canvas mainUICanvas;
    [SerializeField] string screenshotsDataPath;
    [Header("Optional")]
    [SerializeField] bool nonUIScreenshots;
    bool takeScreenshot;
    int screenshotID;


    void Start()
    {
        if (string.IsNullOrEmpty(screenshotsDataPath))
        {
            screenshotsDataPath = (Application.dataPath + "/Screenshots").ToString();
        }
    }

    public void CaptureScreenshot()
    {
        StartCoroutine(MakeScreenshot());
    }

    //Jestli flickering UI vadi, da se to udelat i jinym spusobem
    public IEnumerator MakeScreenshot()
    {
        yield return null;

        while (System.IO.File.Exists(screenshotsDataPath + "/screenshot" + screenshotID + ".png"))
        {
            screenshotID++;
        }

        if (nonUIScreenshots) { mainUICanvas.enabled = false; }

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot(screenshotsDataPath + "/screenshot" + screenshotID + ".png");

        if (nonUIScreenshots) { mainUICanvas.enabled = true; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CaptureScreenshot();
        }
    }
}
