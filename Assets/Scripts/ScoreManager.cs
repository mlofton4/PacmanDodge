using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;

    public static int scores = 0;

    void Update()
    {
        scoreText.text = scores.ToString();
    }

}
