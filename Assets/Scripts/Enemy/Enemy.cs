using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    public void Damage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0) 
        {
            Die();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox"))
            Damage(5);
    }


    [ContextMenu("Die")]
    public void Die()
    {
        Gamemanager.Instance.ToggleWinScreen(true);
        Destroy(this.gameObject);
    }

}
