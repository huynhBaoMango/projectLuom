using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldofview : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        fov = 90f;
        origin = Vector3.zero;
        GetComponent<MeshFilter>().mesh = mesh;
    }

        

    // Update is called once per frame
    void Update()
    {
       
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycasthit2d = Physics2D.Raycast(origin, getVectorFromAngle(angle), viewDistance, layerMask);
            if (raycasthit2d.collider == null)
            {
                vertex = origin + getVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycasthit2d.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    

    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void setAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }
    float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
    Vector3 getVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
