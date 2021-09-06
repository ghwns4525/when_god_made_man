// Upgrade
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
	public Text dmgCostUi;

	public Text dmgUi;

	public Text slotCostUi;

	public Text slotCountUi;

	public Text t;

	public float dmgcost,slotcost;

	private void Start()
	{
		if ((int)PlayerPrefs.GetFloat("slotCost") == 0)
		{
			this.dmgcost = 10f;
			slotcost = 500f;
		}
		else
		{
			this.dmgcost = PlayerPrefs.GetFloat("dmgCost");
			slotcost=PlayerPrefs.GetFloat("slotCost");
		}
		this.dmgUI();
		this.slotUi();
	}
	void Update(){
		PlayerPrefs.SetFloat("dmgCost", this.dmgcost);
		PlayerPrefs.SetFloat ("slotCost", slotcost);
	}
	public void dmgUp()
	{
		OptionManager.Basic(0);
		if (DataController.instance.gold >= (int)this.dmgcost)
		{
			DataController.instance.dmg += 3;
			DataController.instance.gold -= (int)this.dmgcost;
			AchievmentManager.instance.upgradecount++;
			this.dmgcost += 30;
			this.dmgUI();
		}
		else
		{
			this.t.gameObject.SetActive(true);
			this.t.text = "돈이 부족합니다";
		}
	}

	private void dmgUI()
	{
		this.dmgCostUi.text = show((int)this.dmgcost) + "  >  " + show((int)(this.dmgcost + 30));
		this.dmgUi.text = show((int)DataController.instance.dmg) + "  >  " + show((int)(DataController.instance.dmg + 3));
	}

	public void slotUp()
	{
		OptionManager.Basic(0);
		if (AutoSystem.b < 6 && DataController.instance.gold >= slotcost)
		{
			AutoSystem.slotOpen[AutoSystem.b] = true;
			AutoSystem.b++;
			DataController.instance.gold -= (int)slotcost;
			slotcost *= 4;
			this.slotUi();
		}
		else if (AutoSystem.b >= 6)
		{
			this.t.gameObject.SetActive(true);
			this.t.text = "더 이상 슬롯을 구매할 수 없습니다";
		}
		else
		{
			this.t.gameObject.SetActive(true);
			this.t.text = "돈이 부족합니다";
		}
	}

	private void slotUi()
	{
		this.slotCostUi.text = show((int)slotcost) + "  >  " + show((int)slotcost *4);
		if (AutoSystem.b >= 6)
		{
			this.slotCountUi.text = "Max";
		}
		else
		{
			this.slotCountUi.text = show(AutoSystem.b) + "  >  " + show(AutoSystem.b + 1);
		}
	}

	public void close()
	{
		this.t.gameObject.SetActive(false);
	}
	public string show(int a)
	{
		float num = 0f;
		if (a <= 999) {
			num = (float)a;
			return num.ToString ();
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
