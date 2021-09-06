// Exit
using UnityEngine;

public class Exit : MonoBehaviour
{
	public GameObject Exitbackground;

	public GameObject S;

	public GameObject O;

	public GameObject A;

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (!this.Exitbackground.activeInHierarchy)
			{
				if (!this.S.activeInHierarchy && !this.O.activeInHierarchy && !this.A.activeInHierarchy)
				{
					Debug.Log("b");
					this.Exitbackground.SetActive(true);
				}
			}
			else
			{
				this.Exitbackground.SetActive(false);
			}
		}
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}

	public void Close()
	{
		this.Exitbackground.SetActive(false);
	}
}
