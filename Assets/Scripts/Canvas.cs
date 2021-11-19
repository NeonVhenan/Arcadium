using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas : MonoBehaviour
{

    public static GameObject canvas;
    public static TextMeshProUGUI canvasMessage;
    public static bool flag = false;

    void Start()
    {
        if (!flag)
        {
            flag = true;
            canvas = GameObject.Find("Canvas");
            canvasMessage = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
        }
    }

}

