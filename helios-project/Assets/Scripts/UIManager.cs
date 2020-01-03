﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    //private PlayerStats thePS;
    public Text LevelText;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.maxValue = playerHealth.maxHealth;
        //healthBar.value = playerHealth.currentHealth;

        healthBar.maxValue = CharStats.instance.maxHP;
        healthBar.value = CharStats.instance.currentHP;
        //HPText.text = "HP: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
        HPText.text = "HP: " + CharStats.instance.currentHP + "/" + CharStats.instance.maxHP;

        //LevelText.text = "Lvl: " + thePS.currentLevel;
        LevelText.text = "Lvl" + CharStats.instance.playerLevel;
    }
}
