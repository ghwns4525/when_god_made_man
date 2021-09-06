// Page
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
	public Text itext;

	public Text ptext;

	public Text ptext2;

	public Text stext;

	public GameObject[] page;

	public GameObject charinfo;

	public GameObject pagestat;

	private Collection ct;

	public void Onclick(int a)
	{
		OptionManager.Basic(6);
		AutoSystem.page1 = a - 1;
		for (int i = 0; i < this.page.Length; i++)
		{
			this.page[i].SetActive(false);
		}
		this.page[a - 1].SetActive(true);
		this.charinfo.SetActive(false);
		this.pagestat.SetActive(true);
		if (a == 8)
		{
			this.ptext.text = string.Empty;
			this.ptext2.text = "★";
			this.stext.text = "?";
		}
		else
		{
			this.ptext2.text = string.Empty;
			this.ptext.text = a.ToString();
			switch (a)
			{
			case 1:
				this.stext.text = "200";
				break;
			case 2:
				this.stext.text = "400";
				break;
			case 3:
				this.stext.text = "700";
				break;
			case 4:
				this.stext.text = "1300";
				break;
			case 5:
				this.stext.text = "2000";
				break;
			case 6:
				this.stext.text = "4200";
				break;
			case 7:
				this.stext.text = "8400";
				break;
			}
		}
	}

	private void Start()
	{
		this.ct = Collection.instance;
	}
}
