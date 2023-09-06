using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGround : MonoBehaviour
{
    public Vector3 hitPosition;
    public LayerMask layerMask; // Define the layer mask in the Inspector.
    public float rayDistance = 10f;
    Vector3 normal;
    Ray ray;
    void Update()
    {
        // Create a ray from the camera to the mouse cursor position.
         ray = new Ray((transform.position + Vector3.up * rayDistance), transform.up); ;


        RaycastHit hit;

        // Perform the raycast and check if it hits an object on the specified layer mask.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // The ray hit an object on the specified layer mask.
            // You can now access the hit point like this:
            hitPosition = hit.point;
            normal = hit.normal;

            // Do something with the hit position.
        }

        
    }
    public Vector3 GetHitPoint()
    {
        return hitPosition;
    }

    public Vector3 GetHitNormal()
    {
        return normal;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray.origin, ray.direction * rayDistance);
    }
}
