using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2Table : MonoBehaviour {
	
	public Rigidbody rb;
	private Vector3 TableCenterCam;
	private Vector3 TableCenterLens;
	static bool CameraOn;
	static bool LensOn;
	static bool OnTable;
	public GameObject Door;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		// after a lot of meticulous calculations, got these numbers
		TableCenterCam.x = 0f;
		TableCenterCam.y = 11.3f;
		TableCenterCam.z = 3f;
		TableCenterLens.x = -1f;
		TableCenterLens.y = 11.4f;
		TableCenterLens.z = 2f;
		CameraOn = false;
		LensOn = false;
		OnTable = false;
		Door.SetActive (false);
	}

	void OnMouseDown(){
		if (gameObject.CompareTag ("Camera") && !CameraOn && !OnTable) {
			transform.position = TableCenterCam;
			CameraOn = true;
		}
		if (gameObject.CompareTag ("Lens") && CameraOn && !OnTable) {
			transform.position = TableCenterLens;
			LensOn = true;
		}
		if (CameraOn && LensOn) {
			OnTable = true;
			Door.SetActive (true);
		}

	}

	private void OnCollisionEnter(Collision other){
		if (gameObject.CompareTag("Camera") && other.gameObject.CompareTag("Table"))
		{
			transform.parent = other.transform;
		}

		if (gameObject.CompareTag("Lens") && other.gameObject.CompareTag("Camera"))
		{
			rb.isKinematic = true;
			transform.parent = other.transform;
		}
	}
}
	/* for drag-and-drop
	Vector3 dist;
    public Rigidbody rb;
	Vector3 startPos;
	Vector3 startScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
		startPos = transform.position;
		startScale = transform.localScale;
    }

    void OnMouseDown() {
		dist = Camera.main.WorldToScreenPoint (transform.position);
	}

	void OnMouseDrag() {
		Vector3 curPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.position = worldPos;
	}

    private void OnCollisionEnter(Collision other)
    {
		if (gameObject.CompareTag("Camera") && other.gameObject.CompareTag("Table"))
        {
            transform.parent = other.transform;
        }

		if (gameObject.CompareTag("Lens") && other.gameObject.CompareTag("Camera"))
		{
			rb.isKinematic = true;
			transform.parent = other.transform;
		}

		if (gameObject.CompareTag ("Camera") && other.gameObject.CompareTag ("Shelf"))
		{
			transform.parent = null;
			transform.position = startPos;
			transform.rotation = Quaternion.identity;
			transform.localScale = startScale;
		}

		if (gameObject.CompareTag ("Lens") && other.gameObject.CompareTag ("Shelf"))
		{
			rb.isKinematic = false;
			transform.parent = null;
			transform.position = startPos;
			transform.rotation = Quaternion.Euler(new Vector3(90,90,0));
			transform.localScale = startScale;
		}
    }

    private void OnCollisionExit(Collision other)
    {
		if (gameObject.CompareTag("Camera") && other.gameObject.CompareTag("Table"))
		{
			transform.parent = null;
			transform.localScale = startScale;
		}

		if (gameObject.CompareTag("Lens") && other.gameObject.CompareTag("Camera"))
		{
			rb.isKinematic = false;
			transform.parent = null;
			transform.localScale = startScale;
		}
    }*/