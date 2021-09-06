// Popup
using UnityEngine;

public class Popup : MonoBehaviour
{
	public GameObject PopupBackground;

	public int a;

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			this.Close();
		}
	}

	public void Open()
	{
		this.PopupBackground.SetActive(true);
		SceneChanger.b = false;
		OptionManager.Basic(0);
	}
	public void OpenSlot()
	{
		this.PopupBackground.SetActive(true);
		SceneChanger.b = false;
		OptionManager.Basic(0);

		GameObject[] auto= GameObject.FindGameObjectsWithTag ("slot");
		for (int i = 0; i < auto.Length; i++)
			auto [i].SendMessage ("Start");

	}

	public void Close()
	{
		this.PopupBackground.SetActive(false);
		SceneChanger.b = true;
		OptionManager.Basic(0);
	}
}
