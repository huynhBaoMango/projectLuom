using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float Radius = 1000;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnObjectAtRandom();
    }
    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        Instantiate(ItemPrefab, this.transform.position + randomPos, Quaternion.identity);
       // Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}