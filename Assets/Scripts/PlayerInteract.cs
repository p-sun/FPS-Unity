using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float raycastDist = 3f;
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * raycastDist);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, raycastDist, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
