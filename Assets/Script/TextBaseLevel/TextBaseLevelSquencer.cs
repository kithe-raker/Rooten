using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBaseLevelSquencer : MonoBehaviour
{
    public GameObject dialogCanvas;
    public GameObject buttonRow;
    public TMP_Text textLebel;
    public List<string> dialogList = new List<string>();

    private TypeWriterEffect _effect;
    private bool _isFinishTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        _effect = GetComponent<TypeWriterEffect>();
        _effect.OnFinishTyping += OnFinishTyping;

        RunDialog();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isFinishTyping)
            RunDialog();
    }

    void RunDialog()
    {
        if (dialogList != null && dialogList.Count > 0)
        {
            _isFinishTyping = false;
            _effect.StartTyping(dialogList[0], textLebel);
            dialogList.RemoveAt(0);
        }
        else
        {
            Destroy(dialogCanvas);
            if (buttonRow != null)
            {
                buttonRow.SetActive(true);
            }
        }
    }

    void OnFinishTyping()
    {
        _isFinishTyping = true;
    }
}
