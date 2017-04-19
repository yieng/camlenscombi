using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaLightToggle : MonoBehaviour {

	private Light Arealight;
	public Text ToggleText;

	void Start () {
		Arealight = GetComponent<Light>();
		Arealight.enabled = true;
		ToggleText.color = Color.black;
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.A)) {
			if(Arealight.enabled) {
				Arealight.enabled = false;
				ToggleText.color = Color.white;
			} else {
				Arealight.enabled = true;
				ToggleText.color = Color.black;
			}
		}
	}
}
