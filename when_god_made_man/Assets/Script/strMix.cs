// strMix
using UnityEngine;
using UnityEngine.UI;

public class strMix : MonoBehaviour
{
	private DataController DC;

	public Text[] strnum = new Text[3];

	private void Start()
	{
		this.DC = DataController.instance;
	}

	public void strtenAdd()
	{
		if (this.DC.arstr[2] > 8)
		{
			OptionManager.Basic(0);
			this.DC.arstr[2] = 0;
		}
		else
		{
			OptionManager.Basic(0);
			this.DC.arstr[2]++;
		}
	}

	public void strhundredAdd()
	{
		if (this.DC.arstr[1] > 8)
		{
			this.DC.arstr[1] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arstr[1]++;
			OptionManager.Basic(0);
		}
	}

	public void strthousandAdd()
	{
		if (this.DC.arstr[0] > 8)
		{
			this.DC.arstr[0] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arstr[0]++;
			OptionManager.Basic(0);
		}
	}

	public void strtenMinus()
	{
		if (this.DC.arstr[2] < 1)
		{
			this.DC.arstr[2] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arstr[2]--;
			OptionManager.Basic(0);
		}
	}

	public void strhundredMinus()
	{
		if (this.DC.arstr[1] < 1)
		{
			this.DC.arstr[1] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arstr[1]--;
			OptionManager.Basic(0);
		}
	}

	public void strthousandMinus()
	{
		if (this.DC.arstr[0] < 1)
		{
			this.DC.arstr[0] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arstr[0]--;
			OptionManager.Basic(0);
		}
	}

	private void Update()
	{
		for (int i = 0; i < this.strnum.Length; i++)
		{
			this.strnum[i].text = this.DC.arstr[i].ToString();
		}
	}
}
