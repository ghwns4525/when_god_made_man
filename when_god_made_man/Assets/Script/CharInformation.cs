// CharInformation
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharInformation : MonoBehaviour
{
	public Image img;

	private Collection Col;

	public Text txt;

	public Text str;

	public Text kol;

	public Text charm;

	public Text skill;

	public Text cname;

	public Text att;

	public Text attSpeed;

	public Text cost;

	public Text[] level;

	public Color c;

	public Color nc;

	public GameObject charinfo;

	public GameObject pagestat;

	public int page;
	public GameObject setting, upgrade;

	CharInformation(){
		AutoSystem.num1 = 0;
		AutoSystem.page1 = 0;
	}
	public void Start()
	{
		this.Col = Collection.instance;
		levelLoad ();
	}

	public void Onclick(int n)
	{
		OptionManager.Basic(0);
		this.pagestat.SetActive(false);
		this.charinfo.SetActive(true);
		AutoSystem.num1 = n;
		this.Ui();
	}

	private void levelLoad()
	{
		for (int i = 0; i < this.level.Length; i++)
		{
			this.level[i].text =show(Col.col[AutoSystem.page1].level[i]);
		}
	}

	private void Ui()
	{
		if (this.Col.col[AutoSystem.page1].data[AutoSystem.num1])
		{
			this.img.sprite = this.Col.col[AutoSystem.page1].img[AutoSystem.num1];
			this.img.color = this.c;
			this.txt.text = this.Col.col[AutoSystem.page1].sp[AutoSystem.num1];
			this.str.text = this.Col.col[AutoSystem.page1].str[AutoSystem.num1];
			this.kol.text = this.Col.col[AutoSystem.page1].kol[AutoSystem.num1];
			this.charm.text = this.Col.col[AutoSystem.page1].charm[AutoSystem.num1];
			this.skill.text = this.Col.col[AutoSystem.page1].skill[AutoSystem.num1];
			this.cname.text = this.Col.col[AutoSystem.page1].name[AutoSystem.num1];
			this.att.text = show((float)Col.col[AutoSystem.page1].att[AutoSystem.num1]);
			this.attSpeed.text = Col.col[AutoSystem.page1].attSpeed[AutoSystem.num1].ToString();
			this.cost.text = show(Col.col[AutoSystem.page1].cost[AutoSystem.num1]);
			setting.SetActive (true);
			upgrade.SetActive (true);
		}
		else
		{
			this.img.sprite = this.Col.col[AutoSystem.page1].img[AutoSystem.num1];
			this.img.color = this.nc;
			this.txt.text = this.Col.col[AutoSystem.page1].sp[AutoSystem.num1];
			this.str.text = this.Col.col[AutoSystem.page1].str[AutoSystem.num1];
			this.kol.text = this.Col.col[AutoSystem.page1].kol[AutoSystem.num1];
			this.charm.text = this.Col.col[AutoSystem.page1].charm[AutoSystem.num1];
			this.skill.text = this.Col.col[AutoSystem.page1].skill[AutoSystem.num1];
			this.att.text = this.Col.col[AutoSystem.page1].att[AutoSystem.num1].ToString();
			this.attSpeed.text = this.Col.col[AutoSystem.page1].attSpeed[AutoSystem.num1].ToString();
			this.cost.text = this.Col.col[AutoSystem.page1].cost[AutoSystem.num1].ToString();
			this.cname.text = "???";
			setting.SetActive (false);
			upgrade.SetActive (false);
		}
	}

	public void Upgrade()
	{
		if (page == AutoSystem.page1)
		{
			if (DataController.instance.gold >= Collection.instance.col[AutoSystem.page1].cost[AutoSystem.num1])
			{
				Collection.instance.col[AutoSystem.page1].att[AutoSystem.num1] += Collection.instance.col[AutoSystem.page1].attAdd[AutoSystem.num1];
				Collection.instance.col[AutoSystem.page1].level[AutoSystem.num1]++;
				DataController.instance.gold -= Collection.instance.col[AutoSystem.page1].cost[AutoSystem.num1];
				Collection.instance.col[AutoSystem.page1].cost[AutoSystem.num1] += Convert.ToInt32(Collection.instance.col[AutoSystem.page1].total[AutoSystem.num1])/2;
				this.Ui();
				levelLoad ();
			}
			else
			{
				this.txt.text = "돈이 부족합니다";
			}
		}
	}
	public string show(float a)
	{
		float num = 0f;
		if (a <= 999) {
			if (a == (int)a) {
				num = (float)a;
				return num.ToString ();
			} else {
				num = (float)a;
				return num.ToString ("N1");
			}
		} else if (a >= 1000 && a <= 999999) {
			num = (float)a / 1000f - 0.05f;
			return num.ToString ("F1") + "K";
		} else if (a >= 1000000) {
			num = (float)a / 1000000f - 0.05f;
			return num.ToString ("F1") + "M";
		} else
			return a.ToString ();
	}
}
