// BuildingRepair
using UnityEngine;
using UnityEngine.UI;

public class BuildingRepair : MonoBehaviour
{
	public Sprite[] s1;

	private void Start()
	{
		Invoke("sprites", 0.001f);
	}

	public void sprites()
	{
		for (int i = 1; i < 5; i++)
		{
			if (Building.instance.buildlv[i] > 0)
			{
				GameObject.Find(i + "ButtonImage").GetComponent<Image>().sprite = this.s1[i - 1];
				OptionManager.Basic(0);
			}
		}
	}
}
