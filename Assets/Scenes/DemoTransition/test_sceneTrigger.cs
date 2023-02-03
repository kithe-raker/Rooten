using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_sceneTrigger : MonoBehaviour
{
    public GameObject sceneLoader;
    public int TargetSceneIndex;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           SceneLoader obj =  sceneLoader.GetComponent<SceneLoader>();
           if(obj != null)
            {
                StartCoroutine(obj.LoadTargetScene(TargetSceneIndex));
            }

        }
    }

}
