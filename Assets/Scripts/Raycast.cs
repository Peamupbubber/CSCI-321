using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float rayDistance = 10f;
    
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.distance < rayDistance) {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
