using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class rain : MonoBehaviour
{
    GameObject rainGenerator;
    GameObject[] enemy;
    GameObject[] enemyfov;
    GameObject rainLEN;
    GameObject lightningLEN;
    private float waitTime = 5;
    private float eventTime = 8;
    // Start is called before the first frame update
    void Start()
    {
        rainGenerator = GameObject.Find("RainGenerator");
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        enemyfov = GameObject.FindGameObjectsWithTag("enemyfov");
        rainLEN = GameObject.Find("rainlen");
        lightningLEN = GameObject.Find("lightninglen");
        rainGenerator.SetActive(false);
        rainLEN.SetActive(false);
        lightningLEN.SetActive(false);
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= 1 * Time.deltaTime;
            Debug.Log(waitTime);
            eventTime= 8;
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
        rainLEN.SetActive(x);
        rainGenerator.SetActive(x);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<testmove>().RainEV(x);
        }
    }

    public void LightningEvent(bool x)
    {
        rainGenerator.SetActive(false);
        lightningLEN.SetActive(x);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<testmove>().LightningEV(x);
        }
    }
}
