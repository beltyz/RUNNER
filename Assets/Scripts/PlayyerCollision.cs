using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayyerCollision : EndMEnu
{
   


    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag=="Obstacle")
        {
           
            movement.enabled = false;
            
            Time.timeScale = 0f;


            endWindow.SetActive(true);
            diamond.text = $"���������{HowDiamondLose}";

            //diamond.text = "���������:"+ HowDiamondLose;
            //FindObjectOfType<GameManager>().EndGame();

        }
    }
}
