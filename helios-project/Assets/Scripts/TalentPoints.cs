using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentPoints : MonoBehaviour
{

    public static TalentPoints instance;

    public Text pointsToSpendText;
    public int pointsToSpend;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        pointsToSpendText.text = "" + pointsToSpend;
    }
}
