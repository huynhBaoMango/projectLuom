using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    GameObject rainGenerator;
    GameObject[] enemy;
    GameObject[] enemyfov;
    private float waitTime = 5;
    private float eventTime = 8;
    // Start is called before the first frame update
    void Start()
    {
        rainGenerator = GameObject.Find("RainGenerator");
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        enemyfov = GameObject.FindGameObjectsWithTag("enemyfov");
        rainGenerator.SetActive(false);
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= 1 * Time.deltaTime;
            Debug.Log(waitTime);
        }
        else
        {
            eventTime -= 1 * Time.deltaTime;
            Debug.Log(eventTime);
            if (eventTime > 3)
            {
                RainEvent(true);
            }
            if (eventTime < 3)
            {
                RainEvent(false);
                LightningEvent(true);
            }
            if (eventTime <= 0)
            {
                LightningEvent(false);
                waitTime = 10;
            }


        }
    }
    
    public void RainEvent(bool x)
    {
        rainGenerator.SetActive(true);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<testmove>().RainEV(x);
        }
    }

    public void LightningEvent(bool x)
    {
        rainGenerator.SetActive(false);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<testmove>().LightningEV(x);
        }
    }
}
