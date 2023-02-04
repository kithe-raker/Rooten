using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleObject : MonoBehaviour
{
    public GameObject sceneLoader;
    public int targetSceneIndex;

    SceneLoader _sceneLoader;


    // Start is called before the first frame update
    void Start()
    {
        _sceneLoader = sceneLoader.GetComponent<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_sceneLoader != null && collision.tag == "Player")
        {
            StartCoroutine(_sceneLoader.LoadTargetScene(targetSceneIndex));
        }
    }
}
