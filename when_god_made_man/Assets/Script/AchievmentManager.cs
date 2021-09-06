// AchievmentManager
using System;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentManager : MonoBehaviour
{
	public Text actx_1;

	public Text actx_2;

	public GameObject acearn;

	public Button achievmentPrefab;

	public Sprite[] sprites;

	public int earncheck;

	public bool[] unlocked;

	public float playtime;

	public int upgradecount;

	public int mixcount;

	public int buildcount;

	private Collection Col;

	private DataController DC;

	private int i;

	private bool n = true;

	public static AchievmentManager instance;

	private AchievmentManager()
	{
		this.unlocked = new bool[30];
		for (int i = 0; i < this.unlocked.Length; i++)
		{
			this.unlocked[i] = false;
		}
	}

	private void Awake()
	{
		if ((UnityEngine.Object)AchievmentManager.instance == (UnityEngine.Object)null)
		{
			AchievmentManager.instance = this;
		}
	}

	private void Start()
	{
		this.Col = Collection.instance;
		this.DC = DataController.instance;
		this.AchievLoad();
		if (Application.loadedLevel == 2)
		{
			this.earnCheck();
		}
	}

	private void Update()
	{
		this.AchievSave();
		this.Allach();
		if (this.playtime < 86401f)
		{
			this.playtime += Time.deltaTime;
		}
	}

	public void OnClick()
	{
		for (int i = 0; i < 30; i++)
		{
			if (!this.unlocked[i])
			{
				GameObject.Find("mask").GetComponentsInChildren<Image>()[i + 1].sprite = this.sprites[30];
			}
			else
			{
				GameObject.Find("mask").GetComponentsInChildren<Image>()[i + 1].sprite = this.sprites[i];
			}
		}
	}

	public void earn(int num)
	{
		if (Application.loadedLevel == 2)
		{
			this.earnCheck();
		}
		if (!this.unlocked[num - 1])
		{
			this.unlocked[num - 1] = true;
			GameObject gameObject = UnityEngine.Object.Instantiate(this.acearn);
			gameObject.GetComponentsInChildren<Image>()[1].sprite = this.sprites[num - 1];
			gameObject.transform.SetParent(GameObject.Find("Main").transform, false);
			UnityEngine.Object.Destroy(gameObject, 3f);
		}
	}

	public void earnCheck()
	{
		this.earncheck = 0;
		for (int i = 0; i < this.unlocked.Length; i++)
		{
			if (this.unlocked[i])
			{
				this.earncheck++;
			}
		}
		this.actx_1.text = this.earncheck.ToString();
		this.actx_2.text = this.unlocked.Length.ToString();
	}

	public void ach1()
	{
		if (this.DC.lv >= 30)
		{
			this.earn(1);
		}
		if (this.DC.lv >= 100)
		{
			this.earn(2);
		}
		if (this.DC.lv >= 300)
		{
			this.earn(3);
		}
		if (this.DC.lv >= 700)
		{
			this.earn(4);
		}
		if (this.DC.lv >= 1500)
		{
			this.earn(5);
		}
		if (this.DC.lv >= 3000)
		{
			this.earn(6);
		}
	}

	public void ach2()
	{
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < this.Col.col[0].data.Length; j++)
			{
				this.n &= this.Col.col[i].data[j];
			}
			if (this.n)
			{
				this.earn(i + 7);
			}
		}
	}

	public void ach3()
	{
		if (this.playtime > 3600f)
		{
			this.earn(15);
		}
		if (this.playtime > 21600f)
		{
			this.earn(16);
		}
		if (this.playtime > 43200f)
		{
			this.earn(17);
		}
		if (this.playtime > 86400f)
		{
			this.earn(18);
		}
	}

	public void ach4()
	{
		if (this.mixcount >= 10)
		{
			this.earn(19);
		}
		if (this.mixcount >= 50)
		{
			this.earn(20);
		}
		if (this.mixcount >= 500)
		{
			this.earn(21);
		}
	}

	public void ach5()
	{
		if (this.upgradecount >= 50)
		{
			this.earn(22);
		}
		if (this.upgradecount >= 100)
		{
			this.earn(23);
		}
		if (this.upgradecount >= 500)
		{
			this.earn(24);
		}
	}

	public void ach6()
	{
		if (this.buildcount >= 10)
		{
			this.earn(25);
		}
		if (this.buildcount >= 100)
		{
			this.earn(26);
		}
		if (this.buildcount >= 1000)
		{
			this.earn(27);
		}
	}

	public void ach7()
	{
		this.earncheck = 0;
		for (int i = 0; i < this.unlocked.Length; i++)
		{
			if (this.unlocked[i])
			{
				this.earncheck++;
			}
		}
		if (this.earncheck >= 9)
		{
			this.earn(28);
		}
		if (this.earncheck >= 19)
		{
			this.earn(29);
		}
		if (this.earncheck >= 29)
		{
			this.earn(30);
		}
	}

	public void Allach()
	{
		this.ach1();
		this.ach2();
		this.ach3();
		this.ach4();
		this.ach5();
		this.ach6();
		this.ach7();
	}

	public void AchievLoad()
	{
		for (int i = 0; i < this.unlocked.Length; i++)
		{
			string[] array = PlayerPrefs.GetString("unlocked").Split(',');
			this.unlocked[i] = Convert.ToBoolean(Convert.ToInt32(array[i]));
		}
		this.buildcount = PlayerPrefs.GetInt("buildcount");
		this.mixcount = PlayerPrefs.GetInt("mixcount");
		this.upgradecount = PlayerPrefs.GetInt("upgradecount");
		this.playtime = PlayerPrefs.GetFloat("playtime");
	}

	public void AchievSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.unlocked.Length; i++)
		{
			text = ((i >= this.unlocked.Length - 1) ? (text + Convert.ToInt32(this.unlocked[i]).ToString()) : (text + Convert.ToInt32(this.unlocked[i]).ToString() + ","));
		}
		PlayerPrefs.SetString("unlocked", text);
		PlayerPrefs.SetInt("buildcount", this.buildcount);
		PlayerPrefs.SetInt("mixcount", this.mixcount);
		PlayerPrefs.SetInt("upgradecount", this.upgradecount);
		PlayerPrefs.SetFloat("playtime", this.playtime);
	}
}
