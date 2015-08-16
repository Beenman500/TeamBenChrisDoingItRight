using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressionManager : MonoBehaviour {

	public int progressScore = 100;
	public Text levelText;
	public Text progressText;
	public static bool isProgressing = false;

	public static int currentLevel;
	int nextLevel;
	int nextLevelScore;
	int lastScore;
	Animator animHud;

	// Use this for initialization
	void Awake () {
		currentLevel = 1;
		nextLevel = currentLevel + 1;
		nextLevelScore = progressScore;
		//levelText = GetComponent <Text> ();
		lastScore = 0;
		isProgressing = false;
		animHud = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lastScore < nextLevelScore && ScoreManager.score >= nextLevelScore) {
			ProgressLevel();
		}
		if (Input.GetKeyDown (KeyCode.Return) && isProgressing) {
			isProgressing = false;
			animHud.SetBool("Progressing", isProgressing);
			if (currentLevel == 2){
				progressScore = 200;
			}
			else if (currentLevel == 4){
				progressScore = 300;
			}
			else if (currentLevel == 6){
				progressScore = 500;
			}
		}
		levelText.text = "Level: " + currentLevel;
		lastScore = ScoreManager.score;
	}

	public void ProgressLevel(){
		currentLevel ++;
		nextLevel ++;
		nextLevelScore = progressScore * (nextLevel - 1);
		progressText.text = "You've made it to level " + currentLevel + "!!! Press Enter to continue";
		isProgressing = true;
		animHud.SetBool ("Progressing", isProgressing);
	}

}
