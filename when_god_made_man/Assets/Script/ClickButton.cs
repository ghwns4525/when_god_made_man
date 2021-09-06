// ClickButton
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
	public Text hp;

	public Text totalHp;

	private string t;

	public GameObject ballon;

	public GameObject effectpos;
	public GameObject img;

	public Slider hpBar;

	public Text dmgDisplay;

	private void Update()
	{
		this.show((int)DataController.instance.Hpbar, this.hp);
		this.show((int)DataController.instance.totalHp, this.totalHp);
		this.hpBar.maxValue = (float)DataController.instance.totalHp;
		this.hpBar.value = (float)DataController.instance.Hpbar;
		this.dmgDisplay.text = "데미지: " + (int)DataController.instance.dmg;
	}

	public void OnClick()
	{
		DataController.instance.Event((int)DataController.instance.dmg);
		this.Ballon();
		OptionManager.Basic(2);
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
		else if (a >= 1000000000)
		{
			num = (float)a / 1000000000f - 0.05f;
			t.text = num.ToString("F1") + "G";
		}
	}

	public void Ballon()
	{
		Vector3 position = img.transform.position;
		float x = position.x +(float)Random.Range(-100, 100);
		float y = position.y;
		position = new Vector3(x, y, position.z);
		GameObject b = Object.Instantiate(this.ballon, position, Quaternion.identity);
		b.transform.parent = effectpos.transform;
	}
}
