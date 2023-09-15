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

    public Camera cam;
    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10f;
    private float waitTime = 40;
    private float eventTime = 12;
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
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        if (waitTime > 0)
        {
            waitTime -= 1 * Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, zoomLerpSpeed * Time.deltaTime);
            eventTime = 12;

        }
        else
        {
            eventTime -= 1 * Time.deltaTime;
            Debug.Log(eventTime);
            if (eventTime > 6)
            {
                RainEvent(true);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 2.5f, zoomLerpSpeed * Time.deltaTime);

            }
            if (eventTime < 6)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 7, zoomLerpSpeed * Time.deltaTime);
            }
            if (eventTime < 4)
            {
                RainEvent(false);
                LightningEvent(true);
            }
            if (eventTime <= 0)
            {
                LightningEvent(false);
                waitTime = 20;


            }




        }
    }

    public void RainEvent(bool x)
    {
        rainLEN.SetActive(x);
        rainGenerator.SetActive(x);
        cam.fieldOfView = 900;

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
