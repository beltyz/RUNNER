using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent Save;
    [SerializeField] private float speedUpMultiplier;
    public int money;
    private int bestScore = 0;
    public int BestScore => bestScore;
    float distance;
    public float Distance => distance;
    public int Money => money;
    bool gameHasEnd = false;
    float speedMultiPlier  = 1f;
    [SerializeField] float speedIncrease;

    public float SpeedMultiplier => speedMultiPlier;

   public static GameManager Instance;
    public UnityEvent UpdateUI;
    private IEnumerator StartSpeedUp(float time)
    {
        var speedMultiPlierSaved = speedMultiPlier;
        speedMultiPlier += speedUpMultiplier;
        yield return new WaitForSeconds(time);
        speedMultiPlier=speedMultiPlierSaved;
    }
    public void Load(int money,int bestScore)
    {
        
        this.money = money;
        this.bestScore = bestScore;
    }
    public void CollectDiamond()
    {
        money++;
        
        UpdateUI?.Invoke();

    }
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void SpeedUp(float time)
    {
        if (speedMultiPlier<=3.5)
        {
            StartCoroutine(StartSpeedUp(time));
        }
    }
    private void Update()
    {
        distance += Time.deltaTime;
        if (distance>bestScore)
        {
            bestScore = (int)distance;
        }

        if (speedMultiPlier<=3) 
        {
            speedMultiPlier += speedIncrease * Time.deltaTime;
        }
        UpdateUI?.Invoke();
    }
    private void Awake()
    {
        if (FindObjectsOfType <GameManager>().Length>1)
        {
           Destroy(gameObject);
           
        }
        Instance = this;

    }
    public void StartGame()
    {
        Time.timeScale = 1;

      
    }
    public void EndGame()
    {
       if( gameHasEnd ==false)
        {
            gameHasEnd = true;
            Save?.Invoke();
            Restart();


        }
    }

 

    void Restart()
    {

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
