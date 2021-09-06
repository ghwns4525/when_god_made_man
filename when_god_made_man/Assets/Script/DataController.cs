// DataController
using System;
using UnityEngine;

public class DataController : MonoBehaviour
{
	public float dmg = 2f;

	public float totalHp = 50;

	public float Hpbar = 50;

	public int gold;

	public int lv;

	public int str;

	public int knowledge;

	public int skill;

	public int charm;

	public int[] arstr = new int[4];

	public int[] arknowledge = new int[4];

	public int[] arskill = new int[4];

	public int[] archarm = new int[4];

	public int totalSource;

	public int soundclip;

	public GameObject obj;

	public bool CS;

	public static DataController instance;

	public GameObject boom;

	public GameObject img;
	public GameObject effectpos;

	private void Awake()
	{
		if ((UnityEngine.Object)DataController.instance == (UnityEngine.Object)null)
		{
			DataController.instance = this;
		}
	}

	private void Start()
	{
		if ((int)PlayerPrefs.GetFloat("dmg") == 0)
		{
			this.dmg = 2f;
			totalHp = 50;
			Hpbar = 50;
		}
		else
		{
			this.dmg = PlayerPrefs.GetFloat("dmg");
			this.totalHp = PlayerPrefs.GetFloat("totalHp");
			this.Hpbar = PlayerPrefs.GetFloat("Hpbar");
		}
		this.gold = PlayerPrefs.GetInt("gold");
		this.lv = PlayerPrefs.GetInt("lv");
		this.str = PlayerPrefs.GetInt("str");
		this.knowledge = PlayerPrefs.GetInt("knowledge");
		this.skill = PlayerPrefs.GetInt("skill");
		this.charm = PlayerPrefs.GetInt("charm");
		this.CS = Convert.ToBoolean(PlayerPrefs.GetInt("collection"));
	}

	private void Update()
	{
		this.saveSource();
		//reset ();
	}
	public void reset(){
		PlayerPrefs.DeleteAll ();
		resetSource ();
	}
	public void Event(int a)
	{
		this.Hpbar -= a;
		if (this.Hpbar < 1)
		{
			this.gold += (this.lv+1) * UnityEngine.Random.Range(1, 10) + 10;
			this.str += (this.lv+1) + UnityEngine.Random.Range(1, 3);
			this.knowledge += (this.lv+1) + UnityEngine.Random.Range(1, 3);
			this.skill += (this.lv+1) + UnityEngine.Random.Range(1, 3);
			this.charm += (this.lv+1) + UnityEngine.Random.Range(1, 3);
			this.lv++;
			this.totalHp += 50 + (totalHp * 0.01f);
			/*if (this.lv % 3 == 0)
			{
				this.totalHp *= 1.03f;
			}*/
			this.Hpbar = this.totalHp;
			ImageScript.Swip();
			this.Boom();
			OptionManager.Basic(5);
		}
	}

	private void saveSource()
	{
		PlayerPrefs.SetFloat("dmg", this.dmg);
		PlayerPrefs.SetFloat("totalHp", this.totalHp);
		PlayerPrefs.SetFloat("Hpbar", this.Hpbar);
		PlayerPrefs.SetInt("gold", this.gold);
		PlayerPrefs.SetInt("lv", this.lv);
		PlayerPrefs.SetInt("str", this.str);
		PlayerPrefs.SetInt("knowledge", this.knowledge);
		PlayerPrefs.SetInt("skill", this.skill);
		PlayerPrefs.SetInt("charm", this.charm);
	}

	private void resetSource()
	{
		PlayerPrefs.SetFloat("dmg", 2f);
		PlayerPrefs.SetFloat("totalHp", 50);
		PlayerPrefs.SetFloat("Hpbar", 50);
		PlayerPrefs.SetInt("gold", 0);
		PlayerPrefs.SetInt("lv", 0);
		PlayerPrefs.SetInt("str", 0);
		PlayerPrefs.SetInt("knowledge", 0);
		PlayerPrefs.SetInt("skill", 0);
		PlayerPrefs.SetInt("charm", 0);
	}

	public void create()
	{
		this.arstr[3] = this.arstr[0] * 1000 + this.arstr[1] * 100 + this.arstr[2] * 10;
		this.arknowledge[3] = this.arknowledge[0] * 1000 + this.arknowledge[1] * 100 + this.arknowledge[2] * 10;
		this.arskill[3] = this.arskill[0] * 1000 + this.arskill[1] * 100 + this.arskill[2] * 10;
		this.archarm[3] = this.archarm[0] * 1000 + this.archarm[1] * 100 + this.archarm[2] * 10;
		if (this.str - this.arstr[3] > 1 && this.knowledge - this.arknowledge[3] > 1 && this.skill - this.arskill[3] > 1 && this.charm - this.archarm[3] > 1)
		{
			this.totalSource = this.arstr[3] + this.arknowledge[3] + this.arskill[3] + this.archarm[3];
			MixSystem.instance.blueprint ();
		}
		else
		{
			UnityEngine.Object.Instantiate(this.obj).transform.SetParent(GameObject.Find("Craft").transform, false);
		}
	}
	public void calc(){
		this.str -= this.arstr[3];
		this.knowledge -= this.arknowledge[3];
		this.skill -= this.arskill[3];
		this.charm -= this.archarm[3];
	}
	public void createreset()
	{
		for (int i = 0; i < this.arstr.Length; i++)
		{
			this.arstr[i] = 0;
			this.arknowledge[i] = 0;
			this.arskill[i] = 0;
			this.archarm[i] = 0;
		}
	}

	public void Boom()
	{
		Vector3 position = this.img.transform.position;
		float y = position.y;
		Vector3 position2 = this.img.transform.position;
		float x = position2.x;
		float y2 = y;
		Vector3 position3 = this.img.transform.position;
		Vector3 position4 = new Vector3(x, y2, position3.z);
		GameObject gameObject = UnityEngine.Object.Instantiate(this.boom, position4, Quaternion.identity);
		gameObject.transform.parent = this.effectpos.transform;
	}
}
