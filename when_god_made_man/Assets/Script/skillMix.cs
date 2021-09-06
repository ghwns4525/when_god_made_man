// skillMix
using UnityEngine;
using UnityEngine.UI;

public class skillMix : MonoBehaviour
{
	public Text[] skillnum = new Text[3];

	private DataController DC;

	private void Start()
	{
		this.DC = DataController.instance;
	}

	public void skilltenAdd()
	{
		if (this.DC.arskill[2] > 8)
		{
			this.DC.arskill[2] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[2]++;
			OptionManager.Basic(0);
		}
	}

	public void skillhundredAdd()
	{
		if (this.DC.arskill[1] > 8)
		{
			this.DC.arskill[1] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[1]++;
			OptionManager.Basic(0);
		}
	}

	public void skillthousandAdd()
	{
		if (this.DC.arskill[0] > 8)
		{
			this.DC.arskill[0] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[0]++;
			OptionManager.Basic(0);
		}
	}

	public void skilltenMinus()
	{
		if (this.DC.arskill[2] < 1)
		{
			this.DC.arskill[2] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[2]--;
			OptionManager.Basic(0);
		}
	}

	public void skillhundredMinus()
	{
		if (this.DC.arskill[1] < 1)
		{
			this.DC.arskill[1] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[1]--;
			OptionManager.Basic(0);
		}
	}

	public void skillthousandMinus()
	{
		if (this.DC.arskill[0] < 1)
		{
			this.DC.arskill[0] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arskill[0]--;
			OptionManager.Basic(0);
		}
	}

	private void Update()
	{
		for (int i = 0; i < this.skillnum.Length; i++)
		{
			this.skillnum[i].text = this.DC.arskill[i].ToString();
		}
	}
}
