using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToVirtualSceneryAndBack : MonoBehaviour {

	public GameObject MainCam;
	public GameObject ShowroomButtons;
	public Text DescriptionCanvas1;
	public Text DescriptionCanvas2;
	public GameObject ExteriorCanvas;
	public GameObject Door;
	static bool Interior;
	static bool Moved;
	public Vector3 movedPosition;
	public Quaternion movedRotation;
	public int Speed;
	private int maxSpeed;
	private int minSpeed;
	public Camera MainCamCam;
	//private bool Captured;

	// find the camera and lens that was chosen, and then put their settings here

	// Use this for initialization
	void Start () {
		Interior = true;
		Moved = false;
		Speed = 1;
		maxSpeed = 7;
		minSpeed = 1;
		MainCamCam = MainCam.GetComponent<Camera>();
		//Captured = false;
	}
	
	// Update is called once per frame
	void Update () {
		// switch from inside to outside of room
		if (Input.GetKeyDown(KeyCode.D) && Door.activeSelf) {
			if (Interior) {
				if (!Moved) {
					MainCam.transform.position = new Vector3 (0, 10, 50);
					MainCam.transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));
				} else {
					MainCam.transform.position = movedPosition;
					MainCam.transform.rotation = movedRotation;
				}

				Interior = false;
				ShowroomButtons.SetActive (false);
				ExteriorCanvas.SetActive (false);
				DescriptionCanvas1.color = Color.white;
				DescriptionCanvas2.color = Color.white;
			} else {
				MainCam.transform.position = new Vector3 (0, 19, -15);
				MainCam.transform.rotation = Quaternion.Euler(new Vector3 (30, 0, 0));
				Interior = true;
				ShowroomButtons.SetActive (true);
				ExteriorCanvas.SetActive (true);
				DescriptionCanvas1.color = Color.black;
				DescriptionCanvas2.color = Color.black;
			}
		}
			
		// movement of camera
		if (Input.GetKey (KeyCode.LeftArrow) && !Interior) {
			MainCam.transform.Rotate (new Vector3 (0, -1, 0) * Speed);
			movedPosition = MainCam.transform.position;
			movedRotation = MainCam.transform.rotation;
			Moved = true;
		}

		if (Input.GetKey (KeyCode.RightArrow) && !Interior) {
			MainCam.transform.Rotate (new Vector3 (0, 1, 0) * Speed);
			movedPosition = MainCam.transform.position;
			movedRotation = MainCam.transform.rotation;
			Moved = true;
		}

		if (Input.GetKey (KeyCode.UpArrow) && !Interior) {
			if (MainCam.transform.position.z <= 30) {
				MainCam.transform.position = new Vector3 (0, 10, 50);
			} else {
				MainCam.transform.Translate (new Vector3 (0, 0, 1) * Speed);
			}
			movedPosition = MainCam.transform.position;
			movedRotation = MainCam.transform.rotation;
			Moved = true;
		}

		if (Input.GetKey (KeyCode.DownArrow) && !Interior) {
			if (MainCam.transform.position.z <= 30) {
				MainCam.transform.position = new Vector3 (0, 10, 50);
			} else {
				MainCam.transform.Translate (new Vector3 (0, 0, -1) * Speed);
			}
			movedPosition = MainCam.transform.position;
			movedRotation = MainCam.transform.rotation;
			Moved = true;
		}

		// speed up or slow down motion of camera
		if (Input.GetKey (KeyCode.Period) && !Interior) {
			if (Speed <= maxSpeed) {
				Speed += 1;
				if (Speed > maxSpeed) {
					Speed = maxSpeed;
				}
			} else {
				Speed = maxSpeed;
			}
		}

		if (Input.GetKey (KeyCode.Comma) && !Interior) {
			if (Speed >= minSpeed) {
				Speed -= 1;
				if (Speed < minSpeed) {
					Speed = minSpeed;
				}
			} else {
				Speed = minSpeed;
			}
		}
			
		//take picture
		if (Input.GetKey (KeyCode.Space) && !Interior) {
			Application.CaptureScreenshot (Application.dataPath + "/" + "screenshot" + Time.time.ToString() + ".png");
			//Captured = true;
		}

		//reset camera position
		if (Input.GetKey (KeyCode.R) && !Interior) {
			Moved = false;
			MainCam.transform.position = new Vector3 (0, 10, 50);
			MainCam.transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));
		}

		// zoom in and zoom out effect
		if (Input.GetKey (KeyCode.F) && Interior) {
			ShowroomButtons.SetActive (false);
			ExteriorCanvas.SetActive (false);
			MainCamCam.fieldOfView -= 1;
			if (MainCamCam.fieldOfView < 20) {
				MainCamCam.fieldOfView = 20;
			}
		}
		if (Input.GetKey (KeyCode.G) && Interior) {
			MainCamCam.fieldOfView += 1;
			if (MainCamCam.fieldOfView > 60) {
				MainCamCam.fieldOfView = 60;
				ShowroomButtons.SetActive (true);
				ExteriorCanvas.SetActive (true);
			}
		}

		/*
		// look at all pictures taken
		if (Input.GetKey (KeyCode.P) && Captured) {
			string[] files = System.IO.Directory.GetFiles(Application.dataPath, "screenshot*.png");
			// display in console the paths of the screenshots
			for (int c = 0; c < files.Length; c++) {
				Debug.Log (files [c]);
			}
		}*/
	}
}
