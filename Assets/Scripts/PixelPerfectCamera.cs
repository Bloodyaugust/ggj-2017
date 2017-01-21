using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

	Camera worldCam;

	// Use this for initialization
	void Start () {
		worldCam = GetComponent<Camera>();
		worldCam.orthographicSize = Screen.height / 2f;
	}

	// Update is called once per frame
	void Update () {

	}
}
