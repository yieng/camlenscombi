using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraConfig : MonoBehaviour {

	public Rigidbody Camera;
	public Text description;
	private bool Chosen;
	public GameObject MainCamera;

	private string Cam1;
	private string Cam2;
	private string Cam3;

	private Vector3 Interior;

	private UnityStandardAssets.ImageEffects.CameraMotionBlur CameraMotionBlur;

	// Use this for initialization
	void Start () {
		Camera = GetComponent<Rigidbody>();
		Chosen = false;
		description.text = "";
		Cam1 = "Leica M10 Black";
		Cam2 = "Leica M7 Silver";
		Cam3 = "Zeiss Ikon";
		Interior = new Vector3 (0, 19, -15);
		CameraMotionBlur = MainCamera.GetComponent<UnityStandardAssets.ImageEffects.CameraMotionBlur>();

	}

	void OnMouseOver () {
		if (!Chosen) {
			description.text = Camera.name;
		}
	}

	void OnMouseExit () {
		if (!Chosen) {
			description.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.transform.parent != null) {
			Chosen = true;
			description.text = Camera.name;
		}

		// for different cameras, put different settings into the Main Camera of the Scene

		//shutter speed <-> camera motion blur

		if (Camera.name == Cam1 && Chosen) {
			CameraMotionBlur.enabled = true;
			CameraMotionBlur.velocityScale = 0.375f;
			CameraMotionBlur.jitter = 0.05f;
		}

		if (Camera.name == Cam2 && Chosen) {
			CameraMotionBlur.enabled = true;
			CameraMotionBlur.velocityScale = 0.75f;
			CameraMotionBlur.jitter = 0.3f;
		}

		if (Camera.name == Cam3 && Chosen) {
			CameraMotionBlur.enabled = true;
			CameraMotionBlur.velocityScale = 0.001f;
			CameraMotionBlur.jitter = 0.01f;
		}

		if (MainCamera.transform.position == Interior){
			CameraMotionBlur.enabled = false;
		}
	}
		
}
