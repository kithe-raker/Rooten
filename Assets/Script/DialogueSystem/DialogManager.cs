using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text textLebel;

    private TypeWriterEffect _effect;

    // Start is called before the first frame update
    void Start()
    {
        _effect = GetComponent<TypeWriterEffect>();
        _effect.OnFinishTyping += OnFinish;
        _effect.StartTyping("Hello Test Test", textLebel);
    }

    void OnFinish()
    {
        textLebel.text = "Fin.";
    }
}
