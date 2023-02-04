using System.Collections;
using UnityEngine;
    public class DialogueHolder : MonoBehaviour
    {
    public GameObject[] scences;
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            
            for(int i = 0; i < scences.Length;i++)
            {
                Deactivate();
                scences[i].SetActive(true);
                yield return new WaitUntil(() => scences[i].GetComponent<DialogueLine>().finished);
                //yield return new WaitUntil(() => Input.GetMouseButton(0));
                scences[i].SetActive(false);
            }
            
            //yield return new WaitForSeconds(7f);
            
            
            
            //transform.GetChild(i).gameObject.SetActive(false);
            }
            
        //gameObject.SetActive(false);
        

 private void Deactivate()
 {
     for (int i = 0; i < scences.Length; i++)
     {
         scences[i].SetActive(false);

      }

}
    }

