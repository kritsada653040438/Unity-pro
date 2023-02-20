using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform Player;
    private Animator animator;

    public float Health 
    {
        set 
        {
            health = value;
            if(value > 0)
            {
                animator.SetTrigger("Hit");
            }
            if(health <= 0) 
            {
                Defeated();
            }
        }
        get 
        {
            return health;
        }
    }

    private float health = 10;
    
    public void OnHit(float damage)
    {
        Debug.Log("Enemy hit for" +damage);
        Health -= damage;
    }

    private void Start() 
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the direction to move towards the player
        Vector3 direction = (Player.position - transform.position).normalized;

        // Move towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if the enemy is close enough to the player to attack
        float distance = Vector3.Distance(transform.position, Player.position);
            if (distance <= 0.01f)
        {
            Attack();
        }
    }


    private void Attack()
    {
        Debug.Log("Attack Player!!");
    }


    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() 
    {
        Destroy(gameObject);
    }
}