using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;

    public int[] HPLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;
    public int tempDefence;

    private PlayerHealthManager thePlayerHealth;
    private PlayerController thePC;

    // Start is called before the first frame update
/*
void Start()
{
    currentHP = HPLevels[1];
    currentAttack = 0;
    currentDefence = 0;

    thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    thePC = FindObjectOfType<PlayerController>();
}

// Update is called once per frame
void Update()
{
    if (currentExp >= toLevelUp[currentLevel])
    {
        LevelUp();
    }

    tempDefence = 0;
    if (thePC.defending)
    {
        tempDefence = 20;
    }
}

public void LevelUp()
{
    currentLevel++;
    currentHP = HPLevels[currentLevel];

    thePlayerHealth.maxHealth = currentHP;
    thePlayerHealth.currentHealth += currentHP - HPLevels[currentLevel - 1];
}

public void AddExperience(int experienceToAdd)
{
    currentExp += experienceToAdd;
}
*/
}
