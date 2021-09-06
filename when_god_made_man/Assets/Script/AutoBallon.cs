// AutoBallon
using UnityEngine;
using UnityEngine.UI;

public class AutoBallon : MonoBehaviour
{
	public Text Tex;

	public float explode = 1.1f;

	public float speed;

	private void Start()
	{
		this.show(AutoAttack.C, this.Tex);
		transform.localScale = new Vector3 (1, 1, 1);
	}

	private void Update()
	{
		base.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
		Object.Destroy(base.gameObject, this.explode);
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
}
