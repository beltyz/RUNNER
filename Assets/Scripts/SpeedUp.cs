using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Obstacle
{
    [SerializeField] private float time;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ( "Player"))
        {
            GameManager.Instance.SpeedUp(time);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
