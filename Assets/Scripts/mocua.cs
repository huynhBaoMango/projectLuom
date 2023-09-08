using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mocua : MonoBehaviour
{

    [SerializeField] private AudioClip openSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (chiakhoa.itemCount > 0)
            {
                AudioSource.PlayClipAtPoint(openSound,transform.position);
                chiakhoa.itemCount--;
                Destroy(gameObject);

            }
            else
            {
                // Người chơi chưa nhặt được chiaf khoa
            }

        }
    }
}