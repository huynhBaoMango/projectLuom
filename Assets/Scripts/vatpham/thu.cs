using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class thu : MonoBehaviour
{
    public string itemName;
    public float pickupDistance = 2f;
    public Transform player;
    public Image itemImage;
    public TextMeshProUGUI itemCountText;
    public static int itemCount = 0;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < pickupDistance)
        {
            itemCount++;
            itemImage.enabled = true;
            itemCountText.text = itemCount.ToString();
            Destroy(gameObject);
        }
    }
}
