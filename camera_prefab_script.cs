using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_prefab_script : MonoBehaviour {

	private Vector3 TableCenter;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (-16f, 15.5f, 16f);
		//transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
		TableCenter.x = 0f;
		TableCenter.y = 10f;
		TableCenter.z = 4f;
	}

	void OnMouseDown(){
		transform.position = TableCenter;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
