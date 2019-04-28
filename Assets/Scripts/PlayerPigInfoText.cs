using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPigInfoText : MonoBehaviour {

    public PiggyBank playerPig;
    private Text currencyLabel;

    // Consider displaying other info (e.g. pigs eaten, hammer damage)

	void Start () {
        currencyLabel = GetComponent<Text>();
	}
	
	void Update () {
        currencyLabel.text = "Currency: " + playerPig.value.ToString("F2");
	}
}
