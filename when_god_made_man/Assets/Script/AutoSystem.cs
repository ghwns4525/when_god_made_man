// AutoSystem
using System;
using UnityEngine;
using UnityEngine.UI;

public class AutoSystem : MonoBehaviour
{
	public GameObject[] slot;

	public static bool[] slotOpen;

	public static bool[] slotOnChar;

	public static int[] page;

	public static int[] num;

	public static int page1;

	public static int num1;

	public static int b;

	private AutoSystem()
	{
		AutoSystem.slotOnChar = new bool[6];
		AutoSystem.slotOpen = new bool[6];
		AutoSystem.page = new int[6];
		AutoSystem.num = new int[6];
		for (int i = 0; i < AutoSystem.slotOnChar.Length; i++)
		{
			AutoSystem.slotOnChar[i] = false;
			AutoSystem.slotOpen[i] = false;
		}
		this.slot = new GameObject[6];
	}

	private void Start()
	{
		this.slotOnCharLoad();
		this.slotOpenLoad();
		this.slotPageLoad();
		this.slotNumLoad();
		AutoSystem.b = PlayerPrefs.GetInt("b");
		this.SlotUpdate();
	}

	private void Update()
	{
		this.slotOnCharSave();
		this.slotOpenSave();
		this.slotPageSave();
		this.slotNumSave();
		PlayerPrefs.SetInt("b", AutoSystem.b);
		//PlayerPrefs.DeleteAll ();
	}

	public void SlotUpdate()
	{
		if (Application.loadedLevel == 2)
		{
			for (int i = 0; i < this.slot.Length; i++)
			{
				if (AutoSystem.slotOpen[i])
				{
					this.slot[i].SetActive(true);
					this.slot[i].GetComponent<Image>().sprite = Collection.instance.col[0].img[0];
				}
			}
		}
	}

	private void slotOnCharLoad()
	{
		string[] array = PlayerPrefs.GetString("slotOnChar").Split(',');
		for (int i = 0; i < this.slot.Length; i++)
		{
			AutoSystem.slotOnChar[i] = Convert.ToBoolean(Convert.ToInt32(array[i]));
		}
	}

	private void slotOnCharSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.slot.Length; i++)
		{
			text = ((i >= this.slot.Length - 1) ? (text + Convert.ToInt32(AutoSystem.slotOnChar[i]).ToString()) : (text + Convert.ToInt32(AutoSystem.slotOnChar[i]).ToString() + ","));
		}
		PlayerPrefs.SetString("slotOnChar", text);
	}

	private void slotOpenLoad()
	{
		string[] array = PlayerPrefs.GetString("slotOpen").Split(',');
		for (int i = 0; i < this.slot.Length; i++)
		{
			AutoSystem.slotOpen[i] = Convert.ToBoolean(Convert.ToInt32(array[i]));
		}
	}

	private void slotOpenSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.slot.Length; i++)
		{
			text = ((i >= this.slot.Length - 1) ? (text + Convert.ToInt32(AutoSystem.slotOpen[i]).ToString()) : (text + Convert.ToInt32(AutoSystem.slotOpen[i]).ToString() + ","));
		}
		PlayerPrefs.SetString("slotOpen", text);
	}

	private void slotPageLoad()
	{
		string[] array = PlayerPrefs.GetString("page").Split(',');
		for (int i = 0; i < this.slot.Length; i++)
		{
			AutoSystem.page[i] = int.Parse(array[i]);
		}
	}

	private void slotPageSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.slot.Length; i++)
		{
			text = ((i >= this.slot.Length - 1) ? (text + AutoSystem.page[i].ToString()) : (text + AutoSystem.page[i].ToString() + ","));
		}
		PlayerPrefs.SetString("page", text);
	}

	private void slotNumLoad()
	{
		string[] array = PlayerPrefs.GetString("num").Split(',');
		for (int i = 0; i < this.slot.Length; i++)
		{
			AutoSystem.num[i] = Convert.ToInt32(array[i]);
		}
	}

	private void slotNumSave()
	{
		string text = string.Empty;
		for (int i = 0; i < this.slot.Length; i++)
		{
			text = ((i >= this.slot.Length - 1) ? (text + AutoSystem.num[i].ToString()) : (text + AutoSystem.num[i].ToString() + ","));
		}
		PlayerPrefs.SetString("num", text);
	}
}
