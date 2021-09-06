// ImageScript
using UnityEngine;

public class ImageScript : MonoBehaviour
{
	private static int i;

	private static Animator b;

	private void Awake()
	{
		ImageScript.b = base.GetComponent<Animator>();
		ImageScript.i = 0;
	}

	private void Update()
	{
	}

	public static void Swip()
	{
		if (DataController.instance.lv % 3 == 0)
		{
			if (ImageScript.i >= 15)
			{
				ImageScript.i = 0;
			}
			else
			{
				ImageScript.i++;
			}
			ImageScript.b.SetInteger("num", ImageScript.i);
		}
	}
}
