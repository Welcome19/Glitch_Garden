using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attackers : MonoBehaviour {
    
    [Tooltip("Average number of seconds between appearances")]
    public float SeenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            animator.SetBool("IsAttacking", false); 
        }
        //print(Button.selectedDefender);
    }
    void OnTriggerEnter2D()
    {
        Debug.Log(name + " trigger enter");   
    }
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // called at the time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        //Debug.Log(name + " caused damage " + damage);
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
    }
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
