// ballonScript
using UnityEngine;
using UnityEngine.UI;

public class ballonScript : MonoBehaviour
{
	public Text ballontext;

	public float explode;

	private DataController DC;

	public float speed;

	private void Start()
	{
		this.DC = DataController.instance;
		this.show((int)this.DC.dmg, this.ballontext);
		transform.parent.transform.localScale = new Vector3(1,1,1);
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

	private void Update()
	{
		base.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
		Object.Destroy(base.gameObject, this.explode);
	}
}
