using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameFlowControl : MonoBehaviour {

    public GameObject initialBow;
	public GameObject realBowSet;
    public GameObject sunGroup;
    public GameObject UIGameContent;
    public GameObject UIEndText;
    public GameObject startButton;
    public GameObject storyButton;
	public GameObject countdownText;
    public MarkCountScript markCountScript;
    private int gameDuration = 20;
    public bool end = false;
    private int finalMark = 0;
    public int arrowCount = 0;

    IEnumerator GameTime()
    {
		for (int i = gameDuration; i >= 0; i--) {
			yield return new WaitForSeconds (1.0f);
			countdownText.GetComponent<Text> ().text = i.ToString();
		}
        end = true;
    }


    // Update is called once per frame
    void Update () {
        if (end)
        {
            finalMark = markCountScript.count;
            initialBow.SetActive(false);
			realBowSet.SetActive(false);
            // sunGroup.SetActive(false);
            UIGameContent.SetActive(false);
            UIEndText.GetComponent<Text>().text = "Your mark is " + (10 *(10 - finalMark)).ToString() + 
                "!\nThe temperature is:\n " + (70 + 9 * markCountScript.count).ToString() + "℉";

            UIEndText.SetActive(true);
            storyButton.SetActive(false);
            end = false;
        }

	}

    public void GameStart()
    {
        StartCoroutine(GameTime());
        initialBow.SetActive(true);
        sunGroup.SetActive(true);
        UIGameContent.SetActive(true);
        storyButton.SetActive(true);
        Destroy(startButton, 0.1f);
    }
}
