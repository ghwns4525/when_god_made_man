// MixSystem
using UnityEngine;

public class MixSystem : MonoBehaviour
{
	public GameObject obj;

	private Collection col;

	private AchievmentManager ach;

	private DataController DC;

	public static int a;

	public static int b;

	public GameObject overlap;
	public GameObject upgrade;
	public static MixSystem instance;
	void Awake(){
		if ((UnityEngine.Object)MixSystem.instance == (UnityEngine.Object)null)
		{
			MixSystem.instance = this;
		}
	}
	private void Start()
	{
		this.DC = DataController.instance;
		this.col = Collection.instance;
		this.ach = AchievmentManager.instance;
	}

	public void OnClick()
	{
		OptionManager.Basic(0);
		this.DC.create();
		this.DC.createreset();
	}

	private void create(int a, int b)
	{
		MixSystem.a = a;
		MixSystem.b = b;
		DC.calc ();
		this.ach.mixcount++;
		if (!this.col.col[a].data[b])
		{
			this.col.col[a].data[b] = true;
			OptionManager.Basic(7);
			OptionManager.playVib();
			Object.Instantiate(this.obj).transform.SetParent(GameObject.Find("Craft").transform, false);
		}
		else
		{
			Object.Instantiate(this.upgrade).transform.SetParent(GameObject.Find("Craft").transform, false);
			UpgradeCharWithCreate();
		}
	}

	void UpgradeCharWithCreate()
	{
		Collection.instance.col[MixSystem.a].att[MixSystem.b] += Collection.instance.col[MixSystem.a].attAdd[MixSystem.b];
		Collection.instance.col[MixSystem.a].level[MixSystem.b]++;
		Collection.instance.col[AutoSystem.page1].cost[AutoSystem.num1] += 100;
	}

	public void blueprint()
	{
		if (this.DC.arstr[3] == 10 && this.DC.arknowledge[3] == 10 && this.DC.arskill[3] == 10 && this.DC.archarm[3] == 10)
		{
			this.create(7, 4);
		}
		else if (this.DC.arstr[3] == 20 && this.DC.arknowledge[3] == 20 && this.DC.arskill[3] == 20 && this.DC.archarm[3] == 20)
		{
			this.create(7, 9);
		}
		else if (this.DC.arstr[3] == 9990 && this.DC.arknowledge[3] == 9990 && this.DC.arskill[3] == 9990 && this.DC.archarm[3] == 9990)
		{
			this.create(7, 0);
		}
		else if (this.DC.arstr[3] == 560 && this.DC.arknowledge[3] == 560 && this.DC.arskill[3] == 560 && this.DC.archarm[3] == 560 )
		{
			this.create(7, 1);
		}
		else if (this.DC.arstr[3] == 9250 && this.DC.arknowledge[3] == 9250  && this.DC.arskill[3] == 9250  && this.DC.archarm[3] == 9250)
		{
			this.create(7, 2);
		}		else if (this.DC.arstr[3] == 3000 && this.DC.arknowledge[3] == 3000 && this.DC.arskill[3] == 3000 && this.DC.archarm[3] == 3000)
		{
			this.create(7, 3);
		}
		else if (this.DC.arstr[3] == 2520 && this.DC.arknowledge[3] == 2520 && this.DC.arskill[3] == 2520 && this.DC.archarm[3] == 2520)
		{
			this.create(7, 5);
		}
		else if (this.DC.arstr[3] == 250 && this.DC.arknowledge[3] == 250 && this.DC.arskill[3] == 250 && this.DC.archarm[3] == 250)
		{
			this.create(7, 6);
		}
		else if (this.DC.arstr[3] == 760 && this.DC.arknowledge[3] == 760 && this.DC.arskill[3] == 760 && this.DC.archarm[3] == 760)
		{
			this.create(7, 7);
		}
		else if (this.DC.arstr[3] == 1000 && this.DC.arknowledge[3] == 2500 && this.DC.arskill[3] == 500 && this.DC.archarm[3] == 2000)
		{
			this.create(7, 8);
		}
		else if (this.DC.arstr[3] == 500 && this.DC.arknowledge[3] == 200 && this.DC.arskill[3] == 500 && this.DC.archarm[3] == 200)
		{
			this.create(7, 10);
		}
		else if (this.DC.arstr[3] == 1010 && this.DC.arknowledge[3] == 1010 && this.DC.arskill[3] == 1010 && this.DC.archarm[3] == 1010)
		{
			this.create(7, 11);
		}
			
		else if (400 > this.DC.totalSource && this.DC.totalSource >= 200)
		{
			if (this.DC.arstr[3] >= 100 && this.DC.arskill[3] >= 100)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(0, 3);
					break;
				case 2:
					this.create(0, 4);
					break;
				case 3:
					this.create(0, 5);
					break;
				case 4:
					this.create(0, 11);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 100 && this.DC.arknowledge[3] >= 100)
			{
				switch (Random.Range(1, 6))
				{
				case 1:
					this.create(0, 6);
					break;
				case 2:
					this.create(0, 7);
					break;
				case 3:
					this.create(0, 8);
					break;
				case 4:
					this.create(0, 9);
					break;
				case 5:
					this.create(0, 10);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(0, 0);
					break;
				case 2:
					this.create(0, 1);
					break;
				case 3:
					this.create(0, 2);
					break;
				}
			}
		}
		else if (700 > this.DC.totalSource && this.DC.totalSource >= 400)
		{
			if (this.DC.arstr[3] >= 200 && this.DC.arknowledge[3] >= 100)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(1, 4);
					break;
				case 2:
					this.create(1, 5);
					break;
				case 3:
					this.create(1, 6);
					break;
				case 4:
					this.create(1, 7);
					break;
				}
			}
			else if (this.DC.arskill[3] >= 200 && this.DC.archarm[3] >= 100)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(1, 8);
					break;
				case 2:
					this.create(1, 9);
					break;
				case 3:
					this.create(1, 10);
					break;
				case 4:
					this.create(1, 11);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(1, 0);
					break;
				case 2:
					this.create(1, 1);
					break;
				case 3:
					this.create(1, 2);
					break;
				case 4:
					this.create(1, 3);
					break;
				}
			}
		}
		else if (1300 > this.DC.totalSource && this.DC.totalSource >= 700)
		{
			if (this.DC.arstr[3] >= 400 && this.DC.arknowledge[3] >= 200)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(2, 4);
					break;
				case 2:
					this.create(2, 5);
					break;
				case 3:
					this.create(2, 6);
					break;
				case 4:
					this.create(2, 11);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 400 && this.DC.arskill[3] >= 200)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(2, 7);
					break;
				case 2:
					this.create(2, 8);
					break;
				case 3:
					this.create(2, 9);
					break;
				case 4:
					this.create(2, 10);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(2, 0);
					break;
				case 2:
					this.create(2, 1);
					break;
				case 3:
					this.create(2, 2);
					break;
				case 4:
					this.create(2, 3);
					break;
				}
			}
		}
		else if (2000 > this.DC.totalSource && this.DC.totalSource >= 1300)
		{
			if (this.DC.arknowledge[3] >= 400 && this.DC.arskill[3] >= 500 && this.DC.archarm[3] >= 300)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(3, 3);
					break;
				case 2:
					this.create(3, 4);
					break;
				case 3:
					this.create(3, 5);
					break;
				}
			}
			else if (this.DC.arknowledge[3] >= 100 && this.DC.arskill[3] >= 600 && this.DC.archarm[3] >= 500)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(3, 6);
					break;
				case 2:
					this.create(3, 7);
					break;
				case 3:
					this.create(3, 8);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 300 && this.DC.arknowledge[3] >= 300 && this.DC.arskill[3] >= 300 && this.DC.archarm[3] >= 300)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(3, 9);
					break;
				case 2:
					this.create(3, 10);
					break;
				case 3:
					this.create(3, 11);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(3, 0);
					break;
				case 2:
					this.create(3, 1);
					break;
				case 3:
					this.create(3, 2);
					break;
				}
			}
		}
		else if (4200 > this.DC.totalSource && this.DC.totalSource >= 2000)
		{
			if (this.DC.arknowledge[3] >= 600 && this.DC.arskill[3] >= 900 && this.DC.archarm[3] >= 400)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(4, 2);
					break;
				case 2:
					this.create(4, 3);
					break;
				case 3:
					this.create(4, 4);
					break;
				}
			}
			else if (this.DC.arknowledge[3] >= 400 && this.DC.arskill[3] >= 800 && this.DC.archarm[3] >= 700)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(4, 5);
					break;
				case 2:
					this.create(4, 6);
					break;
				case 3:
					this.create(4, 7);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 500 && this.DC.arknowledge[3] >= 400 && this.DC.arskill[3] >= 500 && this.DC.archarm[3] >= 500)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(4, 8);
					break;
				case 2:
					this.create(4, 9);
					break;
				case 3:
					this.create(4, 10);
					break;
				case 4:
					this.create(4, 11);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 3))
				{
				case 1:
					this.create(4, 0);
					break;
				case 2:
					this.create(4, 1);
					break;
				}
			}
		}
		else if (8400 > this.DC.totalSource && this.DC.totalSource >= 4200)
		{
			if (this.DC.arstr[3] >= 1000 && this.DC.arknowledge[3] >= 2000 && this.DC.arskill[3] >= 500 && this.DC.archarm[3] >= 500)
			{
				switch (Random.Range(1, 5))
				{
				case 1:
					this.create(5, 2);
					break;
				case 2:
					this.create(5, 3);
					break;
				case 3:
					this.create(5, 4);
					break;
				case 4:
					this.create(5, 11);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 700 && this.DC.arknowledge[3] >= 1500 && this.DC.arskill[3] >= 900 && this.DC.archarm[3] >= 900)
			{
				switch (Random.Range(1, 3))
				{
				case 1:
					this.create(5, 5);
					break;
				case 2:
					this.create(5, 6);
					break;
				}
			}
			else
			{
				switch (Random.Range(1, 7))
				{
				case 1:
					this.create(5, 0);
					break;
				case 2:
					this.create(5, 1);
					break;
				case 3:
					this.create(5, 7);
					break;
				case 4:
					this.create(5, 8);
					break;
				case 5:
					this.create(5, 9);
					break;
				case 6:
					this.create(5, 10);
					break;
				}
			}
		}
		else if (this.DC.totalSource >= 8400)
		{
			if (this.DC.arstr[3] >= 1500 && this.DC.arknowledge[3] >= 3000 && this.DC.arskill[3] >= 1000 && this.DC.archarm[3] >= 2500)
			{
				switch (Random.Range(1, 3))
				{
				case 1:
					this.create(6, 3);
					break;
				case 2:
					this.create(6, 4);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 2000 && this.DC.arknowledge[3] >= 3000 && this.DC.arskill[3] >= 1000 && this.DC.archarm[3] >= 2000)
			{
				switch (Random.Range(1, 3))
				{
				case 1:
					this.create(6, 5);
					break;
				case 2:
					this.create(6, 6);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 2500 && this.DC.arknowledge[3] >= 2500 && this.DC.arskill[3] >= 1500 && this.DC.archarm[3] >= 1000)
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(6, 7);
					break;
				case 2:
					this.create(6, 8);
					break;
				case 3:
					this.create(6, 9);
					break;
				}
			}
			else if (this.DC.arstr[3] >= 2000 && this.DC.arknowledge[3] >= 2000 && this.DC.arskill[3] >= 2000 && this.DC.archarm[3] >= 2000)
			{
				this.create(6, 10);
			}
			else if (this.DC.arstr[3] >= 1000 && this.DC.arknowledge[3] >= 1000 && this.DC.arskill[3] >= 1000 && this.DC.archarm[3] >= 4000)
			{
				this.create(6, 11);
			}
			else
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					this.create(6, 0);
					break;
				case 2:
					this.create(6, 1);
					break;
				case 3:
					this.create(6, 2);
					break;
				}
			}
		}
		else{
			Object.Instantiate(this.overlap).transform.SetParent(GameObject.Find("Craft").transform, false);
		}
	}

}
