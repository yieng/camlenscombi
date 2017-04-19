using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTable : MonoBehaviour {

    public float rotationSpeed;
    public Rigidbody rb;
	private bool isCollided;
	private bool CameraOn;
	private bool LensOn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isCollided = false;
		CameraOn = false;
		LensOn = false;
		rotationSpeed = 2;
    }

	void OnMouseDrag()
    {
        if (isCollided)
        {
			if (Input.mousePosition.x > Screen.width/2) {
				transform.Rotate (new Vector3 (0, -10, 0) * rotationSpeed);
			} else {
				transform.Rotate (new Vector3 (0, 10, 0) * rotationSpeed);
			}
        }
	}

    private void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.CompareTag ("Camera")) {
			CameraOn = true;
		}

		if (other.gameObject.CompareTag ("Lens")) {
			LensOn = true;
			other.transform.parent = gameObject.transform;
		}

		if (CameraOn || LensOn)
        {
            isCollided = true;
        }

		// demo purpose only
		if (other.gameObject.CompareTag ("specialcamera")) {
			other.transform.parent = gameObject.transform;
			isCollided = true;
		}
    }

    private void OnCollisionExit(Collision other)
    {
		if (other.gameObject.CompareTag ("Camera")) {
			CameraOn = false;
		}

		if (other.gameObject.CompareTag ("Lens")) {
			LensOn = false;
			other.transform.parent = null;
		}
		if (!CameraOn && !LensOn)
        {
            isCollided = false;
        }
    }
}
