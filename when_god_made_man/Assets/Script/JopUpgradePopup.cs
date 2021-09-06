// JopUpgradePopup
using UnityEngine;
using UnityEngine.UI;

public class JopUpgradePopup : MonoBehaviour
{
	public Image img;

	public new Text name;

	public Text level;

	private void Start()
	{
		this.img.sprite = Collection.instance.col[MixSystem.a].img[MixSystem.b];
		this.name.text = Collection.instance.col[MixSystem.a].name[MixSystem.b];
		this.level.text = Collection.instance.col[MixSystem.a].level[MixSystem.b]-1 + "  >  " + (Collection.instance.col[MixSystem.a].level[MixSystem.b]);
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
