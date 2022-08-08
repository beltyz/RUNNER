using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMEnu : MonoBehaviour
{
    public Button button;
    public PlayerMovment movement;
    public GameObject endWindow;
    public GameObject nodiamond;
    public Transform player;
    public Rigidbody rigidbody;
    public TextMeshProUGUI diamond;
    private float time = 5.0f;
    public Timer Timer;




    public int HowDiamondLose=1;

    public IEnumerator InvisibleForSecond(float time)
    {
        player.rotation = Quaternion.identity;
        player.gameObject.layer = 7;
        rigidbody.useGravity = false;
     rigidbody.velocity = Vector3.zero;
        Timer.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        player.gameObject.layer = 0;
        rigidbody.useGravity = true;
        Timer.gameObject.SetActive(false);
        Timer.timeStart = 5;
        
    }

    public void EndMenu()
    {

        if (GameManager.Instance.money >= HowDiamondLose)

        {
            if(player.position.y<=0)
            {

                player.position = new Vector3(0, 1, 0);

                StartCoroutine(InvisibleForSecond(time));
              
                

                GameManager.Instance.money = GameManager.Instance.money - HowDiamondLose;
                HowDiamondLose += 5;
                endWindow.SetActive(false);
                movement.enabled = true;
                Time.timeScale = 1.0f;
            }
            else
            {
                StartCoroutine(InvisibleForSecond(time));
               

                GameManager.Instance.money = GameManager.Instance.money - HowDiamondLose;
                HowDiamondLose += 5;

                endWindow.SetActive(false);
                movement.enabled = true;
                Time.timeScale = 1.0f;
            }



        }
        else
        {
            nodiamond.SetActive(true);

        }

    }
    
    public void NoMoney()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
