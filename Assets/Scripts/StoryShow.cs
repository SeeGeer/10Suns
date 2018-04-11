using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryShow : MonoBehaviour {


    public GameObject storyText;
    private bool show = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StorySwitch()
    {
        show = !show;
        if (show)
        {
            storyText.SetActive(false);
        }

        if (!show)
        {
            storyText.SetActive(true);
        }
    }
}
