using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotlightToggle : MonoBehaviour {

	private Light Spotlight;
	public Text ToggleText;

	void Start () {
		Spotlight = GetComponent<Light>();
		Spotlight.enabled = false;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.S)) {
			if(Spotlight.enabled) {
				Spotlight.enabled = false;
				ToggleText.color = Color.white;
			} else {
				Spotlight.enabled = true;
				ToggleText.color = Color.black;
			}
		}
	}
}