using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayyerCollision : MonoBehaviour
{
    public PlayerMovment movement;
   
     void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag=="Obstacle")
        {
            
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }
}
