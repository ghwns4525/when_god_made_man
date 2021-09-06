// deleteObject
using UnityEngine;

public class deleteObject : MonoBehaviour
{
	public int a;

	public void Close()
	{
		Object.Destroy(base.gameObject, 0.3f);
	}
}
