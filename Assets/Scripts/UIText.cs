using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    GameObject player;

    int maxHealth;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        maxHealth = player.GetComponent<Health>().maxHealth;
        health = player.GetComponent<Health>().health;

        this.GetComponent<TextMeshProUGUI>().text = "Health: " + health + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health != player.GetComponent<Health>().health)
        {
            health = player.GetComponent<Health>().health;

            this.GetComponent<TextMeshProUGUI>().text = "Health: " + health + "/" + maxHealth;
        }
    }
}
