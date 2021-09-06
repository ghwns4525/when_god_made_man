// DestroyScript
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
	public float time;

	private void Start()
	{
		transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
	}

	private void Update()
	{
		Object.Destroy(base.gameObject, this.time);
	}
}
