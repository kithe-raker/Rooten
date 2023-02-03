using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueLine : MonoBehaviour
{
    private Text textHolder;
    public bool finished {get; private set;}

    [Header("Text Options")]
    [SerializeField] private string input;


    [Header("Time parameters")]
    [SerializeField] private float delay;
    

    [Header("Sound")]
    [SerializeField] private AudioClip sound;

    
    private void Awake()
    {
        textHolder = GetComponent<Text>();
        
        textHolder.text = "";

        
    }

    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, delay, sound));
    }

    protected IEnumerator WriteText(string input, Text textHolder, float delay, AudioClip sound)
    {
        for (int i = 0; i < input?.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);
        }

        finished = true;
        
        
    }
}

