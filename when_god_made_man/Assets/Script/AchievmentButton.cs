// AchievmentButton
using System;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentButton : MonoBehaviour
{
	public string[] atext;

	public Text achievtext;

	private string b;

	private void Start()
	{
		this.achievtext = GameObject.Find("acText").GetComponent<Text>();
	}

	public void OnClick()
	{
		OptionManager.Basic(0);
		this.b = base.gameObject.GetComponent<Image>().sprite.name.Substring(0, 2);
		this.achievtext.text = this.atext[Convert.ToInt32(this.b) - 1];
	}
}
