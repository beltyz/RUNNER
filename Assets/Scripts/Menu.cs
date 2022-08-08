 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public GameObject menu;
    public void StartGame()
    {

      menu.SetActive(false);
        Time.timeScale = 1.0f;  
    }
}
