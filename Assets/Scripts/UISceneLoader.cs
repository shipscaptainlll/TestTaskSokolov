using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    [SerializeField] string UIScene;
    private void Awake()
    {
        SceneManager.LoadScene(UIScene, LoadSceneMode.Additive);
    }
}
