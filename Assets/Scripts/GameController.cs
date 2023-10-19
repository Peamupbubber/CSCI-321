using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject winObj;
    private Win win;

    [SerializeField] private TMP_Text winText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        win = winObj.GetComponent<Win>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    private void CheckWin()
    {
        if (win.won)
            winText.text = "YOU WIN! CONGRATS!";
    }
}
