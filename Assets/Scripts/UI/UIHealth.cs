using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    public static Action<Slider, TextMeshProUGUI> UIReady;
    void Start()
    {
        UIReady?.Invoke(healthBar, healthText); // UI 준비 이벤트 
    }
}
