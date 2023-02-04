using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverNavigator : MonoBehaviour
{
    public GameObject sceneLoader;

    public void LoadScene(int TargetSceneIndex)
    {
        SceneLoader obj = sceneLoader.GetComponent<SceneLoader>();
        if (obj != null)
        {
            StartCoroutine(obj.LoadTargetScene(TargetSceneIndex));
        }
    }
}
