using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {
	
	// Update is called once per frame
	public void Reset () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitApp () {
		Application.Quit ();
	}
}
