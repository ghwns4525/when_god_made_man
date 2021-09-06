// BuildingEarn
using UnityEngine;
using UnityEngine.UI;

public class BuildingEarn : MonoBehaviour
{
	public Text strtext;

	public Text knoltext;

	public Text skilltext;

	public Text charmtext;

	public Text goldtext;

	private void Start()
	{
		this.show(Building.instance.teststr, this.strtext);
		this.show(Building.instance.testknol, this.knoltext);
		this.show(Building.instance.testskill, this.skilltext);
		this.show(Building.instance.testcharm, this.charmtext);
		this.show(Building.instance.testgold, this.goldtext);
		Building.instance.earn();
	}

	public void show(int a, Text t)
	{
		float num = 0f;
		if (a <= 999)
		{
			num = (float)a;
			t.text = num.ToString();
		}
		else if (a >= 1000 && a <= 999999)
		{
			num = (float)a / 1000f - 0.05f;
			t.text = num.ToString("F1") + "K";
		}
		else if (a >= 1000000)
		{
			num = (float)a / 1000000f - 0.05f;
			t.text = num.ToString("F1") + "M";
		}
	}

	public void Close()
	{
		Object.Destroy(base.gameObject, 0.3f);
	}
}
