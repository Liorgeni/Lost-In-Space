using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TMP_Text scoreNumber;
    int score = 0;

    private void Awake()
    {
        Instance = this;
    }



    public void UpdateScoreDisplay(int scoreAmount)
    {
        score += scoreAmount;
        scoreNumber.text = score.ToString();
    }
}
