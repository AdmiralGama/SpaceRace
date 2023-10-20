using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;

    [HideInInspector]
    public int health;

    void Start()
    {
        health = maxHealth;
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RepairKit" && this.gameObject.name == "Player")
        {
            if (health < maxHealth)
            {
                health++;
                Destroy(collider.gameObject);
            }
        }
        
        if (collider.gameObject.GetComponent<Damage>() != null)
        {
            health -= collider.gameObject.GetComponent<Damage>().damage;

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
