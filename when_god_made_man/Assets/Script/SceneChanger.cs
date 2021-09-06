// SceneChanger
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public string cutScene;

	public GameObject MainScene;
	public GameObject CraftScene;
	public GameObject CharaterScene;
	public GameObject BuildingScene;
	public GameObject pageHide;
	public GameObject charHide;
	public GameObject BuidingHide;
	public static bool b;
	private void Start()
	{
		SceneChanger.b = true;
	}

	private void Update()
	{
		if (SceneChanger.b && Input.GetKeyUp(KeyCode.Escape))
		{
			SceneChange (0);
		}
	}

	public void OnClick()
	{
		OptionManager.Basic(0);
		if (DataController.instance.CS)
		{
			SceneManager.LoadScene("Main");

		}
		else
		{
			DataController.instance.CS = true;
			PlayerPrefs.SetInt("collection", Convert.ToInt32(DataController.instance.CS));
			SceneManager.LoadScene(this.cutScene);
		}
	}
	public void SceneChange(int a){
		OptionManager.Basic(0);
		if (a == 0) {
			MainScene.SetActive (true);
			CraftScene.SetActive (false);
			CharaterScene.SetActive (false);
			BuildingScene.SetActive (false);
			GameObject[] auto= GameObject.FindGameObjectsWithTag ("autoAtt");
			for (int i = 0; i < auto.Length; i++)
				auto [i].SendMessage ("Start");
			GameObject.Find ("AchievmentManager").SendMessage ("Start");
			pageHide.SetActive (false);
			charHide.SetActive (false);
			BuidingHide.SetActive (false);
			Building.instance.textCheck ();
			bgm.mainBgm.volume = 1;
		} else if (a == 1) {
			MainScene.SetActive (false);
			CraftScene.SetActive (true);
			CharaterScene.SetActive (false);
			BuildingScene.SetActive (false);
			bgm.mainBgm.volume = 1;
		}
		else if (a == 2) {
			MainScene.SetActive (false);
			CraftScene.SetActive (false);
			CharaterScene.SetActive (true);
			BuildingScene.SetActive (false);
			GameObject[] auto= GameObject.FindGameObjectsWithTag ("page");
			for (int i = 0; i < auto.Length; i++)
				auto [i].SendMessage ("levelLoad");
			bgm.mainBgm.volume = 1;
		}
		else if (a == 3) {
			MainScene.SetActive (false);
			CraftScene.SetActive (false);
			CharaterScene.SetActive (false);
			BuildingScene.SetActive (true);
			GameObject.Find ("bgmBuilding").SendMessage ("Start");
			bgm.mainBgm.volume = 0;
		}
	}
}
