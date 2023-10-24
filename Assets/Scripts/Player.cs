using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    //[SerializeField] private float speed;
    //[SerializeField] private float lookSpeed;

    [SerializeField] private GameObject respawnPointObj;
    [HideInInspector] public Vector3 respawnPoint;

    [SerializeField] private GameObject winObj;
    private Win win;
    [HideInInspector] public bool hasKey = false;
    [SerializeField] private GameObject key;

    [SerializeField] private TMP_Text keyText;

    [SerializeField] private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = respawnPointObj.transform.position;
        win = winObj.GetComponent<Win>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!win.won)
        {
            AnimMovement();
        }
    }

    private void AnimMovement() {
        if (transform.position.y < -8 && transform.position.y > -45)
            anim.SetBool("Falling", true);
        else
            anim.SetBool("Falling", false);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            anim.SetBool("Running", true);
        if(Input.GetKeyUp(KeyCode.LeftShift))
            anim.SetBool("Running", false);

        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
    }

    /* From old movement
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
    */

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
