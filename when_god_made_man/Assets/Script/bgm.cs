using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour {
	public static AudioSource mainBgm;
	// Use this for initialization
	void Start () {
		mainBgm = gameObject.GetComponent<AudioSource>();
		DontDestroyOnLoad (this);
		mainBgm.Play ();
	}
}
