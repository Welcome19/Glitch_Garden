﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D collision)
    {
        Attackers attacker = collision.gameObject.GetComponent<Attackers>();
        if(attacker)
        {
            animator.SetTrigger("UnderAttackTrigger");
        }
    }
}
