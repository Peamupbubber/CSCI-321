using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 
                                         player.transform.position.y + 2,
                                         player.transform.position.z);

        transform.eulerAngles = player.transform.eulerAngles;
    }
}
