using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDanger : MonoBehaviour
{
    HealthComponent health;
    public int sceneIndex;
    public SpriteRenderer sprite;
    public AudioSource audioSourceHit;
    // Start is called before the first frame update
    void Start()
    {
        health = this.gameObject.GetComponent<HealthComponent>();
        health.OnOutOfHealth += LoadScene;
        health.OnTakeDamage += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void TakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
        audioSourceHit.Play();
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
