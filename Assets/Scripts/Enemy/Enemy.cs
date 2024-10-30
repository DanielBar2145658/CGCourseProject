using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    float maxHealth;

    float _currentHealth { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float amount, Vector3 force)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0) 
        {
            Die();
        }

    }

    [ContextMenu("Die")]
    public void Die()
    {
        Destroy(this.gameObject);
    }

}
