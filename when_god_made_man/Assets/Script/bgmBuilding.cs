using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmBuilding : MonoBehaviour {
	public static AudioSource buildingBgm;
	// Use this for initialization
	void Start () {
		buildingBgm = gameObject.GetComponent<AudioSource>();
		if (!OptionManager.n)
			buildingBgm.Play ();
		else
			buildingBgm.Stop ();
	}
}
