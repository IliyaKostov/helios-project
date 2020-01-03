using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/ Armor Details")]
    public int weaponStrength;

    public int armorStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    { 
        if (isItem)
        {
            if (affectHP)
            {
                CharStats.instance.currentHP += Mathf.Min(amountToChange, CharStats.instance.maxHP - CharStats.instance.currentHP);
            }

            if (affectMP)
            {
                CharStats.instance.currentMP += Mathf.Min(amountToChange, CharStats.instance.maxMP - CharStats.instance.currentHP);
            }

            if (affectStr)
            {
                CharStats.instance.strength += amountToChange;
            }
        }

        if (isWeapon)
        {
            if (CharStats.instance.equippedWpn != "")
            {
                GameManager.instance.AddItem(CharStats.instance.equippedWpn);
            }

            CharStats.instance.equippedWpn = itemName;
            CharStats.instance.wpnPwr = weaponStrength;
        }

        if (isArmor)
        {
            if (CharStats.instance.equippedArmr != "")
            {
                GameManager.instance.AddItem(CharStats.instance.equippedArmr);
            }

            CharStats.instance.equippedArmr = itemName;
            CharStats.instance.armrPwr = armorStrength;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
