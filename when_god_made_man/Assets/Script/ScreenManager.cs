// ScreenManager
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	private void Start()
	{
		Screen.sleepTimeout = -1;
		Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
	}
}
