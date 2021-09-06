// JopPopup
using UnityEngine;
using UnityEngine.UI;

public class JopPopup : MonoBehaviour
{
	public Image img;

	public new Text name;
	public new Text fish;

	private void Start()
	{
		this.img.sprite = Collection.instance.col[MixSystem.a].img[MixSystem.b];
		this.name.text = Collection.instance.col[MixSystem.a].name[MixSystem.b];
		if (MixSystem.a == 0 && MixSystem.b == 1)
			fish.gameObject.SetActive (true);
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
