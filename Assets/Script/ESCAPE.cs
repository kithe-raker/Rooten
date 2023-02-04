using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCAPE : MonoBehaviour
{
    public GameObject panel;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause)
            {
                pause = false;
                panel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pause = true;
                panel.SetActive(true);
                Time.timeScale = 0f;    
            }
        }
    }

    public void Escape()
    {
        if (pause)
        {
            pause = false;
            panel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pause = true;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
