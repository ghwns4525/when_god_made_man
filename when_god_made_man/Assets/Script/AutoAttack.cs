// AutoAttack
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoAttack : MonoBehaviour
{
	public int a;

	int d=0;

	Animator b;

	Sprite[] spr;

	public static int C;

	public GameObject Img;

	public GameObject tex;

	public GameObject effectpos;

	IEnumerator Start()
	{
		b = base.GetComponent<Animator>();
		d = 0;
		b.SetInteger("num", 0);
		if (AutoSystem.slotOnChar[this.a])
		{
			d = AutoSystem.page[this.a] * 12 + AutoSystem.num[this.a] + 1;
			if (d < 10)
			{
				spr = Resources.LoadAll<Sprite>("Charater/0" + d);
			}
			else
			{
				spr = Resources.LoadAll<Sprite>("Charater/" + d);
			}
		}
		if (AutoSystem.slotOnChar [this.a]) {
			while (true) {
				C = (int)(Collection.instance.col [AutoSystem.page [a]].att [AutoSystem.num [a]]);
				base.GetComponent<Image> ().sprite = spr [0];
				b.SetInteger ("num", d);
				yield return (object)new WaitForSeconds (Collection.instance.col [AutoSystem.page [this.a]].attSpeed [AutoSystem.num [this.a]]);
				DataController.instance.Event (C);
				AutoBallon ();
			}
		}
	}

	private void AutoBallon()
	{
		Vector3 position = this.Img.transform.position;
		float x = position.x + (float)Random.Range(-100, 100);
		float y = position.y;
		position = new Vector3(x, y, position.z);
		GameObject gameObject = Object.Instantiate(this.tex, position, Quaternion.identity);
		gameObject.transform.parent = this.effectpos.transform;
	}
}
