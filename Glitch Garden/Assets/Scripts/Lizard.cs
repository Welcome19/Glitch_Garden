using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class Lizard : MonoBehaviour
{

    private Animator anim;
    private Attackers attacker;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attackers>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Fox collided with " + collider);
        GameObject obj = collider.gameObject;
        //Leave the method if not colliding with a defender
        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
         
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        
    }

}
