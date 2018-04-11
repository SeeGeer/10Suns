using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	private bool isPull = false;
	private bool isPickUp = true;
	private Vector3 cameraToAim;
	private Vector3 cameraToCenter;

	private float velocityMultipler = 0.0f;
	private float threshold = 0.2f;
    
	public GameObject initialBowSet;
	public GameObject bowPosition;
	public GameObject arrowOnBow;
	private GameObject newArrow;
	public GameObject arrowPrefab;
    public GameObject superArrowPrefab;
    public GameObject aim;
	public GameObject arCamera;

    public GameFlowControl gameFlow;
	// Update is called once per frame
	IEnumerator ResetDelay() {

        if (!gameFlow.end)
        {
            yield return new WaitForSeconds(1.0f);
            arrowOnBow.SetActive(true);
		    bowPosition.SetActive(false);
		    initialBowSet.SetActive(true);
        }
        if (gameFlow.end)
        {
            initialBowSet.SetActive(false);
        }
    }

	void Update () {
		if (!initialBowSet.activeSelf && isPickUp && !isPull) {
			
			//initialBowSet.SetActive(true);
		}
		if (initialBowSet.activeSelf && isPull) {
			initialBowSet.SetActive(false);
			isPickUp = false;
		}

		// if (Input.GetKeyDown(KeyCode.Space) && initialBowSet.activeSelf) {
		// 	isPull = true;
		// 	bowPosition.SetActive(true);
		// 	bowPosition.transform.position = arCamera.transform.position;
		// 	bowPosition.transform.rotation = arCamera.transform.rotation;
		// }

		if (isPull) {
			cameraToAim = aim.transform.position - arCamera.transform.position;              
            GameObject bowGoal = new GameObject();
            bowGoal.transform.position = aim.transform.position + cameraToAim;
			aim.transform.LookAt(bowGoal.transform);
			Destroy(bowGoal);
			// Move Arrow On Bow
			cameraToCenter = bowPosition.transform.position - arCamera.transform.position;
            Vector3 arrowPosition = arrowOnBow.transform.localPosition;
			if (cameraToCenter.magnitude > threshold) {
				arrowPosition.x = -0.0305f + threshold / 5f;
				velocityMultipler = 50.0f;
			} else {
				arrowPosition.x = -0.0305f + cameraToCenter.magnitude / 5f;
				velocityMultipler = cameraToCenter.magnitude * 50.0f / threshold;
			}
			arrowOnBow.transform.localPosition = arrowPosition;
		}

        // if (Input.GetKeyUp(KeyCode.Space)) {
		// 	print("!");
		// 	newArrow = Instantiate(arrowPrefab);
		// 	newArrow.transform.position = arrowOnBow.transform.position;
		// 	newArrow.transform.rotation = arrowOnBow.transform.rotation;
		// 	newArrow.GetComponent<Rigidbody>().velocity = -arrowOnBow.transform.right * velocityMultipler;
		// 	arrowOnBow.SetActive(false);
		// 	StartCoroutine(ResetDelay());
		// }
	}

	public void ClickDown() {
		if (initialBowSet.activeSelf) {
			isPull = true;
			bowPosition.SetActive(true);
			bowPosition.transform.position = arCamera.transform.position;
			bowPosition.transform.rotation = arCamera.transform.rotation;
		}
	}

	public void ClickUp() {
		if (!initialBowSet.activeSelf && isPull) {
            gameFlow.arrowCount++;
            if(gameFlow.arrowCount % 5 == 0)
            {
                print("Super！");
                newArrow = Instantiate(superArrowPrefab);
            }
            else
            {
                newArrow = Instantiate(arrowPrefab);
            }
			
			newArrow.transform.position = arrowOnBow.transform.position;
			newArrow.transform.rotation = arrowOnBow.transform.rotation;
			newArrow.GetComponent<Rigidbody>().velocity = -arrowOnBow.transform.right * velocityMultipler;
			arrowOnBow.SetActive(false);
			StartCoroutine(ResetDelay());
			isPull = false;
		}
	}
}
