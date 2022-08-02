using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnd = false;
    float speedMultiPlier  = 1f;
    [SerializeField] float speedIncrease;
    public float SpeedMultiplier => speedMultiPlier;

   public static GameManager Instance;
  

    private void Update()
    {
        if (speedMultiPlier<=3) 
        {
            speedMultiPlier += speedIncrease * Time.deltaTime;
        }
       
    }
    private void Awake()
    {
        if (FindObjectsOfType <GameManager>().Length>1)
        {
           Destroy(gameObject);
           
        }
        Instance = this;
        
    }
    public void EndGame()
    {
       if( gameHasEnd ==false)
        {
            gameHasEnd = true;
            Debug.Log("gameover");
            Restart();


        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
