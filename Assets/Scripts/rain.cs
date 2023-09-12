using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    GameObject rainGenerator;
    private float waitTime = 5;
    private float eventTime = 7;
    [SerializeField] fieldofview enemyFov;
    // Start is called before the first frame update
    void Start()
    {
        rainGenerator = GameObject.Find("RainGenerator");
        rainGenerator.SetActive(false);
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime> 0)
        {
            waitTime -= Random.Range(1, 2) * Time.deltaTime;
        }
        else
        {
            eventTime -= 1 * Time.deltaTime;
        }
        Debug.Log(waitTime);
        if (waitTime <= 0)
        {
            RainEvent();
        }
        if(eventTime <= 0)
        {

        }
        
    }
    
    private void RainEvent()
    {
        rainGenerator.SetActive(true);
        GameObject enemyfov = GameObject.FindWithTag("enemyfov");
        enemyFov.viewDistance -= 1;
    }
}
