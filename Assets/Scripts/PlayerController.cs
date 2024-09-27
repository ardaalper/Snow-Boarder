using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D SurfaceEffector2D;
    bool canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SurfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }
    public void DisableControls()
    {
        canMove = false;
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SurfaceEffector2D.speed = boostSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SurfaceEffector2D.speed = baseSpeed;
        }
    }
}
