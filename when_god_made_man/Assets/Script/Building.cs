// Building
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
	public GameObject goldbuilding;

	public GameObject earnPrefab;

	public int[] buildlv;

	public int timecount;

	public int testgold;

	public int teststr;

	public int testknol;

	public int testcharm;

	public int testskill;

	public bool textcheck;

	public int goldpersec;

	public int strpersec;

	public int knolpersec;

	public int charmpersec;

	public int skillpersec;

	public Text earntimetext;

	public GameObject nomoreclicker;

	public static Building instance;

	private Building()
	{
		this.buildlv = new int[6];
		this.buildlv[5] = 1;
		for (int i = 0; i < this.buildlv.Length-1; i++)
		{
			this.buildlv[i] = 0;
		}
	}

	private void Awake()
	{
		if ((UnityEngine.Object)Building.instance == (UnityEngine.Object)null)
		{
			Building.instance = this;
		}
	}

	private void Start()
	{
		this.BuildingLoad();
		this.textCheck();
		base.StartCoroutine(this.GoldLoop());
	}

	private void Update()
	{
		this.BuildingSave();
		this.buildcheck();
		this.UpdateUI();
		//PlayerPrefs.DeleteAll ();
	}

	private IEnumerator GoldLoop()
	{
		while (true) {
			if (this.textcheck) {
				this.testgold += this.goldpersec*3;
				this.teststr += this.strpersec*3;
				this.testknol += this.knolpersec*3;
				this.testcharm += this.charmpersec*3;
				this.testskill += this.skillpersec*3;
				this.timecount++;
			}
			yield return (object)new WaitForSeconds (1f);
		}
	}

	public void textCheck()
	{
		for (int i = 1; i < 6; i++)
		{
			if (this.buildlv[i] > 0)
			{
				this.textcheck = true;
			}
		}
			if (!this.textcheck)
			{
				this.nomoreclicker.SetActive(false);
			}
			else
			{
				this.nomoreclicker.SetActive(true);
			}
		if (Collection.instance.col[0].data[1] )
		{
			this.goldbuilding.SetActive(true);
		}
	}

	public void buildcheck()
	{
		this.goldpersec = this.buildlv[5];
		this.strpersec = this.buildlv[4];
		this.knolpersec = this.buildlv[2];
		this.charmpersec = this.buildlv[1];
		this.skillpersec = this.buildlv[3];
	}

	public void UpdateUI()
	{
		if (this.textcheck)
		{
			this.earntimetext.text = this.currenttime();
		}
	}

	public void earn()
	{
		DataController.instance.gold += this.testgold;
		DataController.instance.str += this.teststr;
		DataController.instance.knowledge += this.testknol;
		DataController.instance.charm += this.testcharm;
		DataController.instance.skill += this.testskill;
		this.testgold = 0;
		this.teststr = 0;
		this.testskill = 0;
		this.testknol = 0;
		this.testcharm = 0;
		this.timecount = 0;
		OptionManager.Basic(4);
	}

	public string currenttime()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num3 = this.timecount / 3600;
		num2 = this.timecount % 3600 / 60;
		num = this.timecount % 3600 % 60;
		return num3 + "시간 " + num2 + "분 " + num + "초 동안";
	}

	public void panelClose()
	{
		UnityEngine.Object.Destroy(GameObject.Find("UpgradeButton(Clone)"));
		GameObject.Find("BuildingPanel").SetActive(false);
	}

	public void earnbutton()
	{
		UnityEngine.Object.Instantiate(this.earnPrefab).transform.SetParent(GameObject.Find("Building").transform, false);
	}

	public void BuildingLoad()
	{
		for (int i = 0; i < this.buildlv.Length; i++)
		{
			string[] array = PlayerPrefs.GetString("buildlv").Split(',');
			this.buildlv[i] = Convert.ToInt32(Convert.ToInt32(array[i]));
		}
		this.timecount = PlayerPrefs.GetInt("timecount");
		testgold = PlayerPrefs.GetInt ("testgold");
		this.teststr = PlayerPrefs.GetInt("teststr");
		this.testknol = PlayerPrefs.GetInt("testknol");
		this.testcharm = PlayerPrefs.GetInt("testcharm");
		this.testskill = PlayerPrefs.GetInt("testskill");
	}

	public void BuildingSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.buildlv.Length; i++)
		{
			text = ((i >= this.buildlv.Length - 1) ? (text + Convert.ToInt32(this.buildlv[i]).ToString()) : (text + Convert.ToInt32(this.buildlv[i]).ToString() + ","));
		}
		PlayerPrefs.SetString("buildlv", text);
		PlayerPrefs.SetInt("timecount", this.timecount);
		PlayerPrefs.SetInt ("testgold", testgold);
		PlayerPrefs.SetInt("teststr", this.teststr);
		PlayerPrefs.SetInt("testknol", this.testknol);
		PlayerPrefs.SetInt("testcharm", this.testcharm);
		PlayerPrefs.SetInt("testskill", this.testskill);
	}
}
