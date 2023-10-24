using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject.tag.Equals("Player")) {
                Debug.Log("The player was hit!");
            }
        }
    }
}
