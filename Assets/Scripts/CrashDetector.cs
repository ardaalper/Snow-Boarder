using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;
    [SerializeField] float delaytime= 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool isDead = false;
    private void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            if (isDead == false)
            {
                crashSound();
            }
            Invoke("ReloadScene", delaytime);
             
        }
    }

    void crashSound()
    {
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        isDead = true;
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
