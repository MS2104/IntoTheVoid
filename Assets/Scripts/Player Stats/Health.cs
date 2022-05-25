using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    [HideInInspector]
    public bool isDead = false;

    private void Update()
    {
        if (!isDead)
        {
            if (healthAmount <= 0)
            {
                Debug.Log("Player reached 0 health");
                isDead = true;
            }
        }            

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage1(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isDead)
            {
                isDead = false;
            }
            Healing(50);
        }
    }

    public void TakeDamage1(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100f;

    }

    public void Healing (float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100f);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
