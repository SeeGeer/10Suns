using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.W)) {
			this.transform.position += new Vector3(0f, 0f, 0.01f);
		}
		if (Input.GetKey(KeyCode.S)) {
			this.transform.position += new Vector3(0f, 0f, -0.01f);
		}
		if (Input.GetKey(KeyCode.A)) {
			this.transform.position += new Vector3(-0.01f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.D)) {
			this.transform.position += new Vector3(0.01f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.Q)) {
			this.transform.position += new Vector3(0f, 0.01f, 0f);
		}
		if (Input.GetKey(KeyCode.E)) {
			this.transform.position += new Vector3(0f, -0.01f, 0f);
		}
	}
}
