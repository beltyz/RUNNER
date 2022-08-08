using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject menu;

    [SerializeField] private float speed = 10f;
    void Start()
    {
       
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
  
    void FixedUpdate()
    {
        
        var updatedSpeed = speed * GameManager.Instance.SpeedMultiplier;
        transform.Translate(-transform.forward* updatedSpeed * Time.deltaTime);

        

    }
}
