using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
    }
}
