// NoGold
using UnityEngine;

public class NoGold : MonoBehaviour
{
	private void Start()
	{
		Object.Destroy(base.gameObject, 1.5f);
	}
}
