using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentButton : MonoBehaviour
{
    public Text amountText;
    public int valueAmount;

    public Talent selectedTalent;

    // Start is called before the first frame update
    void Start()
    {
        valueAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Press()
    {
        if (TalentPoints.instance.pointsToSpend > 0)
        {
            valueAmount += 1;
            amountText.text = "" + valueAmount;
            selectedTalent.SpendTalentPoint();
            TalentPoints.instance.pointsToSpend--;
        } else
        {
            return;
        }
        
    }
}
