using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorElement : MonoBehaviour
{
    [SerializeField] UIVariationsBase.ColorMode colorMode;

    Button elementButton;
    

    // Start is called before the first frame update
    void Start()
    {
        elementButton = GetComponent<Button>();
        elementButton.onClick.AddListener(NotifyClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NotifyClicked()
    {
        Debug.Log(colorMode + " button clicked");
    }
}
