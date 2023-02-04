using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCAPE : MonoBehaviour
{
    public GameObject panel;
    public static bool Pause;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pause)
            {
                //Debug.Log("escape was press");
                panel.SetActive(true);
                Pause = false;
                Time.timeScale = 0f;
            }
            else
            {
                panel.SetActive(false);
                Pause = true;
                Time.timeScale = 1f;
            }
            
            

        }
       
        
        
    }
   public void escape()
    {
       
            if (Pause)
            {
                //Debug.Log("escape was press");
                panel.SetActive(true);
                Pause = false;
                Time.timeScale = 0f;
            }
            else
            {
                panel.SetActive(false);
                Pause = true;
                Time.timeScale = 1f;
            }




    }



}
