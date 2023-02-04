using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string SelectedScene;
    // Start is called before the first frame update
    public void NewGameButton()
    {
        SceneManager.LoadScene(SelectedScene);
    }
}
