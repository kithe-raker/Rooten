using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    // Trigger when finish typing
    public delegate void FinishTyping();
    public event FinishTyping OnFinishTyping;

    [SerializeField] private float typeSpeed = 50f;

    public void StartTyping(string text, TMP_Text lebel)
    {
        StartCoroutine(TypeText(text, lebel));
    }

    IEnumerator TypeText(string text, TMP_Text lebel)
    {
        lebel.text = string.Empty;
        yield return new WaitForSeconds(2);

        float t = 0;
        int charIndex = 0;

        while (charIndex < text.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            lebel.text = text.Substring(0, charIndex);
            yield return null;
        }

        lebel.text = text;


        if (OnFinishTyping != null)
        {
            yield return new WaitForSeconds(1);
            OnFinishTyping();
        }
    }
}
