using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public static PlayerHealthManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = CharStats.instance.currentHP;
        maxHealth = CharStats.instance.maxHP;

        if (CharStats.instance.currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        //currentHealth -= damageToGive;
        CharStats.instance.currentHP -= damageToGive;
    }

    public void SetMaxHealth()
    {
        //currentHealth = maxHealth;
        CharStats.instance.currentHP = CharStats.instance.maxHP;
    }
}
