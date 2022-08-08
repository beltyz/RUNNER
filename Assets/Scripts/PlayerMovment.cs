using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : EndMEnu
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sideWaysForce=500f;
   

    // Update is called once per frame
    void FixedUpdate() 
    {
       

        
           
               var input = new Vector3(Input.GetAxis("Horizontal"),0,0);
            rb.MovePosition(transform.position+input*Time.deltaTime*sideWaysForce);
          
        
       
        if (rb.position.y <= 0)
        {
            movement.enabled = false;

            Time.timeScale = 0f;


            endWindow.SetActive(true);
            diamond.text = $"потратить{HowDiamondLose}";
            HowDiamondLose += 5;


            //   FindObjectOfType<GameManager>().EndGame();
        }
    }
}
