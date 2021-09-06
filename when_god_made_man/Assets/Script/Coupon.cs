// Coupon
using System;
using UnityEngine;
using UnityEngine.UI;

public class Coupon : MonoBehaviour
{
	public InputField InputText;

	private string itext;

	private DataController DC;

	public GameObject OptionBackground;

	public GameObject CouponBackground;

	public Text t;
	bool c;
	private void Start()
	{
		this.DC = DataController.instance;
		c=Convert.ToBoolean(PlayerPrefs.GetInt ("coupon"));
	}

	public void Onclick()
	{
		this.itext = this.InputText.text.ToUpper();
		if (this.itext == "NEUF")
		{
			if (!c) {
				this.DC.gold += 10000;
				t.text = "10000골드 획득";
				c = true;
				PlayerPrefs.SetInt ("coupon", Convert.ToInt32(c));
			} else
				t.text = "이미 사용하셨습니다.";
		}
		else
		{
			t.text = "틀렸습니다.";
		}
	}
}
