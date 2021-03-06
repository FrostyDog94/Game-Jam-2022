using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;
    public float maxMana = 100.0f;
    public float currentMana;
    public Slider healthBar;
    public Slider manaBar;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
    void Update()
    {
        healthBar.value = currentHealth / maxHealth;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth -= 10;
        }

        manaBar.value = currentMana / maxMana;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (currentMana <= 0)
        {
            currentMana = 0;
        }

    }
    

}
