using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeStart = 5;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
        timerText.text =timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStart>=0)
        {
            timeStart-=Time.deltaTime;
            timerText.text=Mathf.Round(timeStart).ToString();
        }


             



}
}
