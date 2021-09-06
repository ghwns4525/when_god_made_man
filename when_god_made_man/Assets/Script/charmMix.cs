// charmMix
using UnityEngine;
using UnityEngine.UI;

public class charmMix : MonoBehaviour
{
	public Text[] charmnum = new Text[3];

	private DataController DC;

	private void Start()
	{
		this.DC = DataController.instance;
	}

	public void charmtenAdd()
	{
		if (this.DC.archarm[2] > 8)
		{
			this.DC.archarm[2] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[2]++;
			OptionManager.Basic(0);
		}
	}

	public void charmhundredAdd()
	{
		if (this.DC.archarm[1] > 8)
		{
			this.DC.archarm[1] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[1]++;
			OptionManager.Basic(0);
		}
	}

	public void charmthousandAdd()
	{
		if (this.DC.archarm[0] > 8)
		{
			this.DC.archarm[0] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[0]++;
			OptionManager.Basic(0);
		}
	}

	public void charmtenMinus()
	{
		if (this.DC.archarm[2] < 1)
		{
			this.DC.archarm[2] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[2]--;
			OptionManager.Basic(0);
		}
	}

	public void charmhundredMinus()
	{
		if (this.DC.archarm[1] < 1)
		{
			this.DC.archarm[1] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[1]--;
			OptionManager.Basic(0);
		}
	}

	public void charmthousandMinus()
	{
		if (this.DC.archarm[0] < 1)
		{
			this.DC.archarm[0] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.archarm[0]--;
			OptionManager.Basic(0);
		}
	}

	private void Update()
	{
		for (int i = 0; i < this.charmnum.Length; i++)
		{
			this.charmnum[i].text = this.DC.archarm[i].ToString();
		}
	}
}
