// UIManager
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text goldDisplay;

	public Text strDisplay;

	public Text knowledgeDisplay;

	public Text skillDisplay;

	public Text charmDisplay;

	private DataController DC;

	private void Start()
	{
		this.DC = DataController.instance;
	}

	public void show(int a, Text t)
	{
		float num = 0f;
		if (a <= 999)
		{
			num = (float)a;
			t.text = num.ToString();
		}
		else if (a >= 1000 && a <= 999999)
		{
			num = (float)a / 1000f - 0.05f;
			t.text = num.ToString("F1") + "K";
		}
		else if (a >= 1000000)
		{
			num = (float)a / 1000000f - 0.05f;
			t.text = num.ToString("F1") + "M";
		}
	}

	private void Update()
	{
		this.show(this.DC.gold, this.goldDisplay);
		this.show(this.DC.str, this.strDisplay);
		this.show(this.DC.knowledge, this.knowledgeDisplay);
		this.show(this.DC.skill, this.skillDisplay);
		this.show(this.DC.charm, this.charmDisplay);
	}
}
