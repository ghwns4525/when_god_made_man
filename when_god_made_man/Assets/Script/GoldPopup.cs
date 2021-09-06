// GoldPopup
using UnityEngine;
using UnityEngine.UI;

public class GoldPopup : MonoBehaviour
{
	public Text text;

	public int a;

	private void Start()
	{
		this.text.text = DataController.instance.totalSource / 2 + "$";
		SceneChanger.b = false;
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Object.Destroy(base.gameObject, 0.3f);
			SceneChanger.b = true;
		}
	}

	public void Close()
	{
		Object.Destroy(base.gameObject, 0.3f);
		SceneChanger.b = true;
	}
}
