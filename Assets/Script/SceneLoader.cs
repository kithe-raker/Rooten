using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator CrossFade;
    public int TargetSceneIndex;


    public IEnumerator LoadTargetScene()
    {
        CrossFade.SetTrigger("StartFade");
        yield return new WaitForSeconds(1f);

        Scene scene = SceneManager.GetActiveScene();
        int nextLevelBuildIndex = TargetSceneIndex;
        SceneManager.LoadScene(nextLevelBuildIndex);
    }
}
