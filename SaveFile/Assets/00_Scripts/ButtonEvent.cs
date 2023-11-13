using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Button StartButton;

    public GameObject StartTop;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(HideButton);
    }
    
    private void HideButton()
    {
        StartButton.gameObject.SetActive(false);
        StartTop.SetActive(false);
    }

    
}
