using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObsticalSpawner : MonoBehaviour
{

    [SerializeField] private List<Obstacle> obstaclePrefabs=new List<Obstacle>();
    [SerializeField] private float minX,maxX;
    [SerializeField] private float spawnTime;
    [Serializable] 
    private struct Obstacle
    {
        public GameObject obstacle;
        public int spawnPercentage;
    };
    void GenerateObstacle()
    {
        var randomNumber = UnityEngine.Random.Range(0, 101);
        foreach (var obstacle in obstaclePrefabs)
        {
          
      
            if (randomNumber > obstacle.spawnPercentage)
            {
                
                continue;
            }
            var obstaclePrefab = obstacle.obstacle;
            var x = UnityEngine.Random.Range(minX + obstaclePrefab.transform.GetChild(0).localScale.x / 2, maxX - +obstaclePrefab.transform.GetChild(0).localScale.x / 2);
            transform.position = new Vector3(x, obstaclePrefab.transform.localScale.y / 2, transform.position.z);
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            return;
        }
        
    }

   IEnumerator StartGenerating()
    {
        GenerateObstacle();
        yield return new WaitForSeconds(spawnTime/GameManager.Instance.SpeedMultiplier);
        StartCoroutine(StartGenerating());
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(StartGenerating());
    }
    void Update()
    {

    }
}
