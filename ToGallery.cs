using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGallery : MonoBehaviour {

	public GameObject MainCam;
	public Camera MainCamCam;
	static bool GF;

	public GameObject ShowroomButtons;
	public GameObject DescriptionCanvas;
	public GameObject ExteriorCanvas;

	// Use this for initialization
	void Start () {
		GF = true;
		MainCamCam = MainCam.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)){
			if (GF) {
				MainCam.transform.position = new Vector3 (0, -10, 0);
				MainCam.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				GF = false;
				ShowroomButtons.SetActive (false);
				DescriptionCanvas.SetActive (false);
				ExteriorCanvas.SetActive (false);
			} else {
				MainCam.transform.position = new Vector3 (0,19,-15);
				MainCam.transform.rotation = Quaternion.Euler(new Vector3 (30,0,0));
				GF = true;
				ShowroomButtons.SetActive (true);
				DescriptionCanvas.SetActive (true);
				ExteriorCanvas.SetActive (true);
			}
		}

		// movement of camera
		if (Input.GetKeyUp (KeyCode.LeftArrow) && !GF) {
			MainCam.transform.Rotate (new Vector3 (0, -90, 0));
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) && !GF) {
			MainCam.transform.Rotate (new Vector3 (0, 90, 0));
		}

		if (Input.GetKey (KeyCode.UpArrow) && !GF) {
			MainCamCam.fieldOfView -= 1;
			if (MainCamCam.fieldOfView < 20) {
				MainCamCam.fieldOfView = 20;
			}
		}

		if (Input.GetKey (KeyCode.DownArrow) && !GF) {
			MainCamCam.fieldOfView += 1;
			if (MainCamCam.fieldOfView > 60) {
				MainCamCam.fieldOfView = 60;
			}
		}

	}
}
