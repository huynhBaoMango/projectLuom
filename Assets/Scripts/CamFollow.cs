using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float flspeed = 2f;
    public Transform target;
    private Camera mainCamera;
    private Camera cullingCamera;
    [SerializeField] private float extraFrustumCullRange = 10;


    private void Awake()
    {
        mainCamera = GetComponent<Camera>();

        // hàm render FOV ngoài tầm camera
        SetupCullingCamera();
    }
    


    private void SetupCullingCamera()
    {
        var cullingCamGo = new GameObject("CullingCamera");
        cullingCamGo.SetActive(false);
        cullingCamGo.transform.SetParent(transform, false);
        cullingCamera = cullingCamGo.AddComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, flspeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        // Điều chỉnh tầm render
        cullingCamera.fieldOfView = mainCamera.fieldOfView + extraFrustumCullRange;
        mainCamera.cullingMatrix = cullingCamera.cullingMatrix;
    }
}
