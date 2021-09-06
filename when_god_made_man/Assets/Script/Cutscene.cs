// Cutscene
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
	private int hitcount = 1;

	public Sprite[] cut;

	public Image img;

	public GameObject scenechange;

	private IEnumerator Fade()
	{
		float f = 5E-07f;
		while (true) {
			if (f <= 1f) {
				this.img.CrossFadeAlpha (0f, 0.5f, true);
				yield return (object)new WaitForSeconds (0.5f);
				this.img.CrossFadeAlpha (1f, 0.5f, true);
				yield return (object)new WaitForSeconds (0.5f);
			}
			f += 5E-07f;
		}
	}

	public void On()
	{
		DataController.instance.CS = false;
	}

	public void Onclick()
	{
		if (this.hitcount == 0)
		{
			this.img.sprite = this.cut[0];
			this.hitcount++;
		}
		else if (this.hitcount == 1)
		{
			this.img.sprite = this.cut[1];
			OptionManager.Basic(6);
			this.hitcount++;
		}
		else if (this.hitcount == 2)
		{
			this.img.sprite = this.cut[2];
			OptionManager.Basic(6);
			this.hitcount++;
		}
		else if (this.hitcount == 3)
		{
			this.img.sprite = this.cut[3];
			OptionManager.Basic(6);
			this.scenechange.SetActive(true);
			base.StartCoroutine("Fade");
		}
	}
}
