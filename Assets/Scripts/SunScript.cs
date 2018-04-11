using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunScript : MonoBehaviour {

    public MarkCountScript markCountScript;
    public Text markText;
    public Image redMask;
    public GameObject myCamera;
    public GameObject flame;
    public bool down = false;

    private void Update()
    {
        transform.LookAt(myCamera.transform);
    }
    private void OnTriggerEnter(Collider other) {

		if(other.tag == "Arrow"){

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            down = true;
            markCountScript.count--;
            flame.SetActive(true);

            markText = markText.GetComponent<Text>();
            string markCountText = "There are "+ markCountScript.count.ToString() +
                " Suns dropped\nThe temperature is: "+ (70 + 9 * markCountScript.count).ToString() + "℉";
            markText.text = markCountText;
			this.GetComponent<Rigidbody>().useGravity = true;

            redMask = redMask.GetComponent<Image>();
            Color newColor = redMask.color;
            markCountScript.alpha = markCountScript.alpha - 0.06f;

            newColor.a = markCountScript.alpha;
            redMask.color = newColor;
        }
	}
}
