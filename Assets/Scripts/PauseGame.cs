using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public bool pause;

    public Canvas myCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pause)
            {
                pause = true;
                Time.timeScale = 0;
                myCanvas.gameObject.SetActive(true);
            }
            else
            {
                pause = false;
                Time.timeScale = 1;
                myCanvas.gameObject.SetActive(false);
            }
        }
    }
}
