using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcodebox : MonoBehaviour
{
    [SerializeField] GameObject[] ItemPrefab;
    public float Radius;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= 1 * Time.deltaTime;
        }
        else
        {
            SpawnObjectAtRandom();
            waitTime = 2;
        }
    }
    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos.z = 0;
        Instantiate(ItemPrefab[Random.Range(0, 2)], this.transform.position + randomPos, Quaternion.identity);

    }
}
