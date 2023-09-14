using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cucda3 : MonoBehaviour
{
    private float timedestroy;
    // Start is called before the first frame update
    void Start()
    {
        timedestroy = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("enemy") != null)
        {

            if (Vector3.Distance(transform.position, GameObject.FindWithTag("enemy").transform.position) < 3)
            {
                
            }
            else
            {
                timedestroy -= 1 * Time.deltaTime;

                if(timedestroy <= 0)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}
