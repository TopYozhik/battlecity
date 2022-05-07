using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    float h, v;
    Rigidbody2D rb2d;
    WeaponController weapon_controller;

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
    {
        weapon_controller.Fire();
    }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weapon_controller = GetComponentInChildren<WeaponController>();
    }

    void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }
}
