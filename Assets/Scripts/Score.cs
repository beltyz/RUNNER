using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentScore;
    [SerializeField]  private TextMeshProUGUI BestScore;
    private int BestScoreInt=0;
    const string BEST_SCORE = "Best Score";
    float Distance;
    void Start()
    {
        BestScoreInt = PlayerPrefs.GetInt(BEST_SCORE);
        BestScore.text = $"Best Score:{BestScoreInt.ToString()}";
    }
    void Update()
    {
        Distance += Time.deltaTime;
        CurrentScore.text = Mathf.Round(Distance).ToString();
        if(BestScoreInt< Mathf.Round(Distance))
        {
            BestScore.text =$"Best Score:{Mathf.Round(Distance).ToString()}" ;
            PlayerPrefs.SetInt(BEST_SCORE,(int) Mathf.Round(Distance));
        }
      
    }
}
