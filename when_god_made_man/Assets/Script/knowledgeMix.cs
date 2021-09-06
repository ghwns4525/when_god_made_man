// knowledgeMix
using UnityEngine;
using UnityEngine.UI;

public class knowledgeMix : MonoBehaviour
{
	public Text[] knowledgenum = new Text[3];

	private DataController DC;

	private void Start()
	{
		this.DC = DataController.instance;
	}

	public void knowledgetenAdd()
	{
		if (this.DC.arknowledge[2] > 8)
		{
			this.DC.arknowledge[2] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[2]++;
			OptionManager.Basic(0);
		}
	}

	public void knowledgehundredAdd()
	{
		if (this.DC.arknowledge[1] > 8)
		{
			this.DC.arknowledge[1] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[1]++;
			OptionManager.Basic(0);
		}
	}

	public void knowledgethousandAdd()
	{
		if (this.DC.arknowledge[0] > 8)
		{
			this.DC.arknowledge[0] = 0;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[0]++;
			OptionManager.Basic(0);
		}
	}

	public void knowledgetenMinus()
	{
		if (this.DC.arknowledge[2] < 1)
		{
			this.DC.arknowledge[2] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[2]--;
			OptionManager.Basic(0);
		}
	}

	public void knowledgehundredMinus()
	{
		if (this.DC.arknowledge[1] < 1)
		{
			this.DC.arknowledge[1] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[1]--;
			OptionManager.Basic(0);
		}
	}

	public void knowledgethousandMinus()
	{
		if (this.DC.arknowledge[0] < 1)
		{
			this.DC.arknowledge[0] = 9;
			OptionManager.Basic(0);
		}
		else
		{
			this.DC.arknowledge[0]--;
			OptionManager.Basic(0);
		}
	}

	private void Update()
	{
		for (int i = 0; i < this.knowledgenum.Length; i++)
		{
			this.knowledgenum[i].text = this.DC.arknowledge[i].ToString();
		}
	}
}
