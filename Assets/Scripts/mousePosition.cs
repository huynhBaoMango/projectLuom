using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Vector3 mouseWorldPosition;

    // Update is called once per frame
    void Update()
    {
      mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }
}
