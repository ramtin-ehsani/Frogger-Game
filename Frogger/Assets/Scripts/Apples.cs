using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apples : MonoBehaviour
{
    public Text AppleText;
    public static int apples;
    // Start is called before the first frame update
    void Start()
    {
        AppleText.text = apples.ToString();
    }

    private void Update()
    {
        AppleText.text = apples.ToString();
    }
}
