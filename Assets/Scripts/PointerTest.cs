using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("down");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickDown()
    {
        print("Down");
    }

	public void ClickUp()
    {
        print("Up");
    }


}
