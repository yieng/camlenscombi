using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LensConfig : MonoBehaviour {

	public Rigidbody Lens;
	public Text description;
	private bool Chosen;
	public GameObject MainCamera;

	private string Len1;
	private string Len2;
	private string Len3;

	static float Len1focallength;
	static float Len1focalsize;
	static float Len1aperture;
	static float Len1aperturemax;

	static float Len2focallength;
	static float Len2focalsize;
	static float Len2aperture;
	static float Len2aperturemax;

	static float Len3focallength;
	static float Len3focalsize;
	static float Len3aperture;
	static float Len3aperturemax;

	private Vector3 Interior;

	private UnityStandardAssets.ImageEffects.DepthOfField DepthOfField;

	// Use this for initialization
	void Start () {
		Lens = GetComponent<Rigidbody>();
		Chosen = false;
		description.text = "";
		Len1 = "Leica Normal 50mm f/1.4 Summilux M Apsherical Manual Focus Lens (6-Bit, updated for digital) (Black)";
		Len2 = "Voigtlander Nokton 50mm f/1.5 Aspherical Lens (Silver)";
		Len3 = "Zeiss 35mm f/1.4 Distagon T* ZM Lens for M-Mount (Black)";
		Interior = new Vector3 (0, 19, -15);
		DepthOfField = MainCamera.GetComponent<UnityStandardAssets.ImageEffects.DepthOfField>();

		Len1focallength = 0.50f;
		Len1focalsize = 0.05f;
		Len1aperture = 0.1f;
		Len1aperturemax = 0.14f;

		Len2focallength = 0.50f;
		Len2focalsize = 0.05f;
		Len2aperture = 0.1f;
		Len2aperturemax = 0.15f;

		Len3focallength = 0.35f;
		Len3focalsize = 0.05f;
		Len3aperture = 0.1f;
		Len3aperturemax = 0.14f;
	}

	void OnMouseOver () {
		if (!Chosen) {
			description.text = Lens.name;
		}
	}

	void OnMouseExit () {
		if (!Chosen) {
			description.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if (Lens.transform.parent != null) {
			Chosen = true;
			description.text = Lens.name;
		}

		// for different lenses, put different settings into the Main Camera of the Scene
		// out of focus effect for different lenses


		if (Lens.name == Len1 && Chosen) {
			DepthOfField.enabled = true;
			if (Input.GetKey (KeyCode.D)) {
				DepthOfField.focalLength = Len1focallength;
				DepthOfField.focalSize = Len1focalsize;
				DepthOfField.aperture = Len1aperture;
			}
			Commandz(out Len1focalsize,Len1aperture,out Len1aperture, Len1aperturemax);
		}

		if (Lens.name == Len2 && Chosen) {
			DepthOfField.enabled = true;
			if (Input.GetKey (KeyCode.D)) {
				DepthOfField.focalLength = Len2focallength;
				DepthOfField.focalSize = Len2focalsize;
				DepthOfField.aperture = Len2aperture;
			}
			Commandz(out Len2focalsize,Len2aperture,out Len2aperture, Len2aperturemax);
		}

		if (Lens.name == Len3 && Chosen) {
			DepthOfField.enabled = true;
			if (Input.GetKey (KeyCode.D)) {
				DepthOfField.focalLength = Len3focallength;
				DepthOfField.focalSize = Len3focalsize;
				DepthOfField.aperture = Len3aperture;
			}
			Commandz(out Len3focalsize,Len2aperture,out Len3aperture, Len3aperturemax);
		}

		if (MainCamera.transform.position == Interior){
			DepthOfField.enabled = false;
		}


	}

	void Commandz (out float focalsize, float aperture0, out float aperture, float aperturemax){
		if (Input.GetKey (KeyCode.H) && Chosen) {
			DepthOfField.focalSize -= 0.05f;
			focalsize = DepthOfField.focalSize;
		} else {
			focalsize = DepthOfField.focalSize;
		}
		if (Input.GetKey (KeyCode.J) && Chosen) {
			DepthOfField.focalSize += 0.05f;
			focalsize = DepthOfField.focalSize;
		} else {
			focalsize = DepthOfField.focalSize;
		}

		if (Input.GetKey (KeyCode.K) && Chosen) {
			if (aperture0 >= 0.02f) {
				DepthOfField.aperture -= 0.01f;
				aperture = DepthOfField.aperture;
			} else {
				aperture = DepthOfField.aperture;
			}
			if (aperture0 <= 0.01f) {
				DepthOfField.aperture = 0.01f;
				aperture = 0.01f;
			} else {
				aperture = DepthOfField.aperture;
			}
		} else {
			aperture = DepthOfField.aperture;
		}

		if (Input.GetKey (KeyCode.L) && Chosen) {
			if (aperture0 < aperturemax) {
				DepthOfField.aperture += 0.01f;
				aperture = DepthOfField.aperture;
			}

			if (aperture0 >= aperturemax) {
				DepthOfField.aperture = aperturemax;
				aperture = aperturemax;
			} 
		} else {
			aperture = DepthOfField.aperture;
		}
	}
}
