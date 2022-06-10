using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AdjustmentsMode
{
    Color,
    Folder,
    Carpart
}

public class UIElement : MonoBehaviour
{
    [SerializeField] AdjustmentsMode adjustmentsMode;

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
        Debug.Log(adjustmentsMode + "button clicked");
    }
}
