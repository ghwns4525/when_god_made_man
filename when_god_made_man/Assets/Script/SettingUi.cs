using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUi : MonoBehaviour {
	public GameObject[] slot;
	public Sprite a;
	// Use this for initialization
	SettingUi(){
		slot = new GameObject[6];
	}
	void Start () {
		for (int i = 0; i < this.slot.Length; i++)
		{
			if (AutoSystem.slotOpen[i])
			{
				this.slot [i].GetComponent<Image> ().sprite = a;
			}
		}
	}
}
