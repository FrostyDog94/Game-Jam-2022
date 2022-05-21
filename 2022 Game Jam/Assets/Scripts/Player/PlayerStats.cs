using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        healthBar.value = currentHealth / maxHealth;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth -= 10;
        }
    }
    

}
