using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    int actualHealth;
    int currentHealth;
    void Start()
    {
        SetHealth();    
    }	
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void SetHealth()
    {
        currentHealth = actualHealth;
    }
    public void SetInvincible()
    {
        currentHealth = 1000;
    }
    void Death()
    {
        if (gameObject.CompareTag("Player"))
        {
            // gotta spawn the player here
        }
        //else{
        //    if (gameObject.CompareTag("Fast")) GameMaster.fastGuyDestroyed++;
        //    else if (gameObject.CompareTag("Armored")) GameMaster.armoredGuyDestroyed++;
        //    else if (gameObject.CompareTag("Bonus")) GameMaster.bonusGuyDestroyed++;
        //}
        Destroy(gameObject);
    }
}
