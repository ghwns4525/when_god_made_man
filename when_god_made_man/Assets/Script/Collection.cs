// Collection
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
	[Serializable]
	public class collection
	{
		public Button[] obj;

		public Sprite[] img;

		public string[] sp;

		public string[] str;

		public string[] kol;

		public string[] charm;

		public string[] skill;

		public string[] name;

		public string[] total;

		public bool[] data;

		public float[] att;

		public float[] attSpeed;

		public float[] attAdd;

		public int[] level;

		public int[] cost;

		private collection()
		{
			this.img = new Sprite[12];
			this.sp = new string[12];
			this.str = new string[12];
			this.kol = new string[12];
			this.charm = new string[12];
			this.skill = new string[12];
			this.name = new string[12];
			this.total = new string[12];
			this.data = new bool[12];
			this.att = new float[12];
			this.attSpeed = new float[12];
			this.level = new int[12];
			this.cost = new int[12];
			attAdd = new float[12];
			for (int i = 0; i < this.att.Length; i++)
			{
				this.att[i] = (float)(i + 1);
				this.attSpeed[i] = 3f;
				this.level[i] = 1;
				this.cost[i] = 100;
			}
		}
	}

	public collection[] col;

	public static Collection instance;

	public int count;

	public Text collectionRate;

	public Color c;

	public Color nc;

	private Collection()
	{
		this.col = new collection[8];
	}

	private void Awake()
	{
		if ((UnityEngine.Object)Collection.instance == (UnityEngine.Object)null)
		{
			Collection.instance = this;
		}
	}

	public void Start()
	{
		this.collectionLoad();
		List<Dictionary<string, object>> list = CSVReader.Read("cha");
		for (int i = 1; i < this.col.Length + 1; i++)
		{
			this.col[i - 1].img = Resources.LoadAll<Sprite>(i.ToString());
		}
		for (int j = 0; j < this.col.Length; j++)
		{
			switch (j)
			{
			case 0:
				for (int l = 0; l < 12; l++)
				{
					this.col[j].sp[l] = list[l]["sp"].ToString();
					this.col[j].str[l] = list[l]["str"].ToString();
					this.col[j].kol[l] = list[l]["kol"].ToString();
					this.col[j].charm[l] = list[l]["charm"].ToString();
					this.col[j].skill[l] = list[l]["skill"].ToString();
					this.col[j].name[l] = list[l]["name"].ToString();
					this.col[j].total[l] = list[l]["total"].ToString();
					this.col[j].att[l] = float.Parse(list[l]["att"].ToString());
					this.col[j].attAdd[l] = float.Parse(list[l]["att"].ToString())/5;
					this.col[j].attSpeed[l] = float.Parse(list[l]["attspeed"].ToString());
					col[j].cost[l] = int.Parse(list[l]["total"].ToString())/2;
				}
				break;
			case 1:
				for (int num2 = 0; num2 < 12; num2++)
				{
					this.col[j].sp[num2] = list[num2 + 12]["sp"].ToString();
					this.col[j].str[num2] = list[num2 + 12]["str"].ToString();
					this.col[j].kol[num2] = list[num2 + 12]["kol"].ToString();
					this.col[j].charm[num2] = list[num2 + 12]["charm"].ToString();
					this.col[j].skill[num2] = list[num2 + 12]["skill"].ToString();
					this.col[j].name[num2] = list[num2 + 12]["name"].ToString();
					this.col[j].total[num2] = list[num2 + 12]["total"].ToString();
					this.col[j].att[num2] = float.Parse(list[num2+12]["att"].ToString());
					this.col[j].attAdd[num2] = float.Parse(list[num2+12]["att"].ToString())/5;
					this.col[j].attSpeed[num2] = float.Parse(list[num2+12]["attspeed"].ToString());
					col[j].cost[num2] = int.Parse(list[num2 + 12]["total"].ToString())/2;
				}
				break;
			case 2:
				for (int num4 = 0; num4 < 12; num4++)
				{
					this.col[j].sp[num4] = list[num4 + 24]["sp"].ToString();
					this.col[j].str[num4] = list[num4 + 24]["str"].ToString();
					this.col[j].kol[num4] = list[num4 + 24]["kol"].ToString();
					this.col[j].charm[num4] = list[num4 + 24]["charm"].ToString();
					this.col[j].skill[num4] = list[num4 + 24]["skill"].ToString();
					this.col[j].name[num4] = list[num4 + 24]["name"].ToString();
					this.col[j].total[num4] = list[num4 + 24]["total"].ToString();
					this.col[j].att[num4] = float.Parse(list[num4+24]["att"].ToString());
					this.col[j].attAdd[num4] = float.Parse(list[num4+24]["att"].ToString())/5;
					this.col[j].attSpeed[num4] = float.Parse(list[num4+24]["attspeed"].ToString());
					col[j].cost[num4] = int.Parse(list[num4 + 24]["total"].ToString())/2;
				}
				break;
			case 3:
				for (int n = 0; n < 12; n++)
				{
					this.col[j].sp[n] = list[n + 36]["sp"].ToString();
					this.col[j].str[n] = list[n + 36]["str"].ToString();
					this.col[j].kol[n] = list[n + 36]["kol"].ToString();
					this.col[j].charm[n] = list[n + 36]["charm"].ToString();
					this.col[j].skill[n] = list[n + 36]["skill"].ToString();
					this.col[j].name[n] = list[n + 36]["name"].ToString();
					this.col[j].total[n] = list[n + 36]["total"].ToString();
					this.col[j].att[n] = float.Parse(list[n+36]["att"].ToString());
					this.col[j].attAdd[n] = float.Parse(list[n+36]["att"].ToString())/5;
					this.col[j].attSpeed[n] = float.Parse(list[n+36]["attspeed"].ToString());
					col[j].cost[n] = int.Parse(list[n + 36]["total"].ToString())/2;
				}
				break;
			case 4:
				for (int num5 = 0; num5 < 12; num5++)
				{
					this.col[j].sp[num5] = list[num5 + 48]["sp"].ToString();
					this.col[j].str[num5] = list[num5 + 48]["str"].ToString();
					this.col[j].kol[num5] = list[num5 + 48]["kol"].ToString();
					this.col[j].charm[num5] = list[num5 + 48]["charm"].ToString();
					this.col[j].skill[num5] = list[num5 + 48]["skill"].ToString();
					this.col[j].name[num5] = list[num5 + 48]["name"].ToString();
					this.col[j].total[num5] = list[num5 + 48]["total"].ToString();
					this.col[j].att[num5] = float.Parse(list[num5+48]["att"].ToString());
					this.col[j].attAdd[num5] = float.Parse(list[num5+48]["att"].ToString())/5;
					this.col[j].attSpeed[num5] = float.Parse(list[num5+48]["attspeed"].ToString());
					col[j].cost[num5] = int.Parse(list[num5 + 48]["total"].ToString())/2;
				}
				break;
			case 5:
				for (int num3 = 0; num3 < 12; num3++)
				{
					this.col[j].sp[num3] = list[num3 + 60]["sp"].ToString();
					this.col[j].str[num3] = list[num3 + 60]["str"].ToString();
					this.col[j].kol[num3] = list[num3 + 60]["kol"].ToString();
					this.col[j].charm[num3] = list[num3 + 60]["charm"].ToString();
					this.col[j].skill[num3] = list[num3 + 60]["skill"].ToString();
					this.col[j].name[num3] = list[num3 + 60]["name"].ToString();
					this.col[j].total[num3] = list[num3 + 60]["total"].ToString();
					this.col[j].att[num3] = float.Parse(list[num3+60]["att"].ToString());
					this.col[j].attAdd[num3] = float.Parse(list[num3+60]["att"].ToString())/5;
					this.col[j].attSpeed[num3] = float.Parse(list[num3+60]["attspeed"].ToString());
					col[j].cost[num3] = int.Parse(list[num3 + 60]["total"].ToString())/2;
				}
				break;
			case 6:
				for (int num = 0; num < 12; num++)
				{
					this.col[j].sp[num] = list[num + 72]["sp"].ToString();
					this.col[j].str[num] = list[num + 72]["str"].ToString();
					this.col[j].kol[num] = list[num + 72]["kol"].ToString();
					this.col[j].charm[num] = list[num + 72]["charm"].ToString();
					this.col[j].skill[num] = list[num + 72]["skill"].ToString();
					this.col[j].name[num] = list[num + 72]["name"].ToString();
					this.col[j].total[num] = list[num + 72]["total"].ToString();
					this.col[j].att[num] = float.Parse(list[num+72]["att"].ToString());
					this.col[j].attAdd[num] = float.Parse(list[num+72]["att"].ToString())/5;
					this.col[j].attSpeed[num] = float.Parse(list[num+72]["attspeed"].ToString());
					col[j].cost[num] = int.Parse(list[num + 72]["total"].ToString())/2;
				}
				break;
			case 7:
				for (int m = 0; m < 12; m++)
				{
					this.col[j].sp[m] = list[m + 84]["sp"].ToString();
					this.col[j].str[m] = list[m + 84]["str"].ToString();
					this.col[j].kol[m] = list[m + 84]["kol"].ToString();
					this.col[j].charm[m] = list[m + 84]["charm"].ToString();
					this.col[j].skill[m] = list[m + 84]["skill"].ToString();
					this.col[j].name[m] = list[m + 84]["name"].ToString();
					this.col[j].total[m] = list[m + 84]["total"].ToString();
					this.col[j].att[m] = float.Parse(list[m+84]["att"].ToString());
					this.col[j].attAdd[m] = float.Parse(list[m+84]["att"].ToString())/5;
					this.col[j].attSpeed[m] = float.Parse(list[m+84]["attspeed"].ToString());
					col[j].cost[m] = int.Parse(list[m + 84]["total"].ToString())/2;
				}
				break;
			}
		}
		AttLevelSave ();
		//AttLevelLoad();
	}

	private void Update()
	{
		this.collectionSave();
		this.ColSave();
		this.AttLevelSave();
	}

	public void ColSave()
	{
			int num = 0;
			for (int i = 0; i < this.col.Length; i++)
			{
				for (int j = 0; j < this.col[i].data.Length; j++)
				{
					if (this.col[i].data[j])
					{
						((Component)this.col[i].obj[j]).GetComponent<Image>().sprite = this.col[i].img[j];
						((Component)this.col[i].obj[j]).GetComponent<Image>().color = this.c;
						num++;
					}
					else
					{
						((Component)this.col[i].obj[j]).GetComponent<Image>().sprite = this.col[i].img[j];
						((Component)this.col[i].obj[j]).GetComponent<Image>().color = this.nc;
					}
				}
			}
			this.count = num;
			this.collectionRate.text = Collection.instance.count + "/" + Collection.instance.col.Length * Collection.instance.col[0].data.Length;
	}

	private void collectionLoad()
	{
		for (int i = 0; i < this.col.Length; i++)
		{
			string[] array = PlayerPrefs.GetString("collection" + i).Split(',');
			for (int j = 0; j < this.col[i].data.Length; j++)
			{
				this.col[i].data[j] = Convert.ToBoolean(Convert.ToInt32(array[j]));
			}
		}
	}

	private void collectionSave()
	{
		for (int i = 0; i < this.col.Length; i++)
		{
			string text = string.Empty;
			for (int j = 0; j < this.col[i].data.Length; j++)
			{
				text = ((j >= this.col[i].data.Length - 1) ? (text + Convert.ToInt32(this.col[i].data[j]).ToString()) : (text + Convert.ToInt32(this.col[i].data[j]).ToString() + ","));
			}
			PlayerPrefs.SetString("collection" + i, text);
		}
	}

	private void AttLevelLoad()
	{
		for (int i = 0; i < this.col.Length; i++)
		{
			string[] array = PlayerPrefs.GetString("att" + i).Split(',');
			string[] array2 = PlayerPrefs.GetString("level" + i).Split(',');
			string[] array3 = PlayerPrefs.GetString("cost" + i).Split(',');
			for (int j = 0; j < this.col[i].att.Length; j++)
			{
				this.col[i].att[j] = float.Parse(array[j]);
				this.col[i].level[j] = int.Parse(array2[j]);
				this.col[i].cost[j] = int.Parse(array3[j]);
			}
		}
	}

	public void AttLevelSave()
	{
		for (int i = 0; i < this.col.Length; i++)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			for (int j = 0; j < this.col[i].att.Length; j++)
			{
				if (j < this.col[i].att.Length - 1)
				{
					text = text + this.col[i].att[j].ToString() + ",";
					text2 = text2 + this.col[i].level[j].ToString() + ",";
					text3 = text3 + this.col[i].cost[j].ToString() + ",";
				}
				else
				{
					text += this.col[i].att[j].ToString();
					text2 += this.col[i].level[j].ToString();
					text3 += this.col[i].cost[j].ToString();
				}
			}
			PlayerPrefs.SetString("att" + i, text);
			PlayerPrefs.SetString("level" + i, text2);
			PlayerPrefs.SetString("cost" + i, text3);
		}
	}
}
