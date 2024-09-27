using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    CapsuleCollider2D board;
    [SerializeField] ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        board = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && board.IsTouching(other.collider))
        {
            dust.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && board.IsTouching(other.collider))
        {
            dust.Pause();
        }
    }
}
