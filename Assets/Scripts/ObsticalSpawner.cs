using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float minX,maxX;
    [SerializeField] private float spawnTime;
    void GenerateObstacle()
    {
        var x=Random.Range(minX+obstaclePrefab.transform.GetChild(0).localScale.x/2,maxX- +obstaclePrefab.transform.GetChild(0).localScale.x / 2);
        transform.position = new Vector3(x,obstaclePrefab.transform.localScale.y/2, transform.position.z);
        Instantiate(obstaclePrefab,transform.position,Quaternion.identity);
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
