using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentScore;
    [SerializeField]  private TextMeshProUGUI BestScore;
    [SerializeField] private TextMeshProUGUI Diamond;
    
    
    const string BEST_SCORE = "Best Score";
    const string DIAMOND= "Diamond";
    private void UpdateUI()
    {
                Diamond.text = $" {GameManager.Instance.Money}";

        BestScore.text = $"Best Score:{GameManager.Instance.BestScore}";
        CurrentScore.text = Mathf.Round(GameManager.Instance.Distance).ToString();

    }
    void Save()
    {
        PlayerPrefs.SetInt(DIAMOND, GameManager.Instance.Money);
        if (GameManager.Instance.Distance>PlayerPrefs.GetInt(BEST_SCORE))
        {
         
            PlayerPrefs.SetInt(BEST_SCORE, (int)Mathf.Round(GameManager.Instance.Distance));

        }

    }

    void Start()
    {
        UpdateUI();
        GameManager.Instance.UpdateUI.AddListener(UpdateUI);
        GameManager.Instance.Save.AddListener(Save);

        GameManager.Instance.Load(PlayerPrefs.GetInt(DIAMOND),PlayerPrefs.GetInt(BEST_SCORE));

       
    }
    private void OnApplicationQuit()
    {
        Save();
    }
}
