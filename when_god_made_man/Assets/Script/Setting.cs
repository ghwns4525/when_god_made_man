// Setting
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
	public Sprite d;

	public int a;

	public void Start()
	{
		if  (AutoSystem.slotOpen[this.a])
		{
			Basic();
			if(AutoSystem.slotOnChar[this.a])
				GetComponent<Image>().sprite = Collection.instance.col[AutoSystem.page[this.a]].img[AutoSystem.num[this.a]];
		}
	}

	public void OnClick()
	{
		OptionManager.Basic(0);
		AutoSystem.page [a] = AutoSystem.page1;
		AutoSystem.num [a] = AutoSystem.num1;
		if (AutoSystem.slotOpen[this.a])
		{
			base.GetComponent<Image>().sprite = Collection.instance.col[AutoSystem.page[this.a]].img[AutoSystem.num[this.a]];
			AutoSystem.slotOnChar[this.a] = true;
			for (int i = 0; i < AutoSystem.page.Length; i++)
			{
				if (i != this.a)
				{
					Image component = GameObject.Find("slot" + (i + 1)).GetComponent<Image>();
					if ((Object)base.GetComponent<Image>().sprite == (Object)component.sprite)
					{
						AutoSystem.slotOnChar[i] = false;
						component.SendMessage("Basic");
					}
				}
			}
		}
	}

	private void Basic()
	{
		base.GetComponent<Image>().sprite = this.d;
	}
}
