using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float lookSpeed;
    private Vector2 rotation = Vector2.zero;

    [SerializeField] private GameObject respawnPointObj;
    [HideInInspector] public Vector3 respawnPoint;

    [SerializeField] private GameObject winObj;
    private Win win;
    public bool hasKey = false;
    [SerializeField] private GameObject key;

    [SerializeField] private TMP_Text keyText;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = respawnPointObj.transform.position;
        win = winObj.GetComponent<Win>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!win.won) {
            Move();
            Look();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    private void Look()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        transform.eulerAngles = rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == key)
        {
            keyText.text = "YOU HAVE THE KEY!";
            hasKey = true;
            Destroy(collision.gameObject);
        }
    }
}
