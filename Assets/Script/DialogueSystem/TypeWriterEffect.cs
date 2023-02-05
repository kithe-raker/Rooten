using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    // Trigger when finish typing
    public delegate void FinishTyping();
    public event FinishTyping OnFinishTyping;

    private string totalText = string.Empty;

    [SerializeField] private float typeSpeed = 50f;

    public void StartTyping(string text, TMP_Text lebel)
    {
        StartCoroutine(TypeText(text, lebel));
    }

    IEnumerator TypeText(string text, TMP_Text lebel)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < text.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            lebel.text = totalText + text.Substring(0, charIndex);
            yield return null;
        }

        totalText += text;
        lebel.text = totalText;


        if (OnFinishTyping != null)
        {
            yield return new WaitForSeconds(0.5f);
            OnFinishTyping();
        }
    }

    public void ClearText(TMP_Text lebel)
    {
        totalText = string.Empty;
        lebel.text = string.Empty;
    }
}
