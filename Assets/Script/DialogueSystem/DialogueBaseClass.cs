using System.Collections;
using UnityEngine;
using UnityEngine.UI;
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, Text textHolder, float delay, AudioClip sound)
        {
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitUntil(() => Input.GetMouseButton(0));

            finished = true;
        
        }
    }

