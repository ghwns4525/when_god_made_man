// OptionManager
using System;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
	private static AudioSource audioS;

	public static AudioClip[] clip;

	public static bool n;

	private static bool v;

	private void Start()
	{
		OptionManager.audioS = base.gameObject.AddComponent<AudioSource>();
		OptionManager.Load();
		OptionManager.clip = Resources.LoadAll<AudioClip>("Sound");
	}

	private void Update()
	{
		OptionManager.Save();
	}

	public static void Load()
	{
		OptionManager.n = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
		OptionManager.v = Convert.ToBoolean(PlayerPrefs.GetInt("vibrate"));
	}

	public static void Save()
	{
		PlayerPrefs.SetInt("sound", Convert.ToInt32(OptionManager.n));
		PlayerPrefs.SetInt("vibrate", Convert.ToInt32(OptionManager.v));
	}

	public static void Basic(int c)
	{
		if (!OptionManager.n)
		{
			OptionManager.audioS.PlayOneShot(OptionManager.clip[c]);
		}
	}

	public static void playVib()
	{
		if (OptionManager.v)
		{
			Handheld.Vibrate ();
		}
	}

	public void SoundOn()
	{
		OptionManager.n = false;
		bgm.mainBgm.enabled = true;
	}

	public void SoundOff()
	{
		OptionManager.n = true;
		bgm.mainBgm.enabled = false;
	}

	public void VibrateOn()
	{
		OptionManager.v = false;
	}

	public void VibrateOff()
	{
		OptionManager.v = true;
	}
}
