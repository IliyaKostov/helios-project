using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public static CharStats instance;

    public string charName;
    public int playerLevel = 1;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 10;
    public int baseExp = 0;
    public int availableTalentPoints = 0;

    public int currentHP = 100;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
   
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    public int tempDefence;

    // Start is called before the first frame update
    void Start()
    {
        currentMP = maxMP;
        currentHP = maxHP;

        instance = this;

        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt( expToNextLevel[i - 1] * 1.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tempDefence = 0;
        if (PlayerController.instance.defending)
        {
            tempDefence = 20;
        }

        if (Input.GetKey(KeyCode.E))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
        if (playerLevel < maxLevel)
        {
            if (currentExp >= expToNextLevel[playerLevel])
            {
                currentExp -= expToNextLevel[playerLevel];
                playerLevel++;
                availableTalentPoints++;

                // determine to add str, def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                } else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt( maxHP * 1.05f);
                currentHP = maxHP;

                maxMP = Mathf.FloorToInt(maxMP * 1.10f);
                currentMP = maxMP;
            }
        }

        if (playerLevel >= maxLevel)
        {
            currentExp = 0;
        }
    }
}
