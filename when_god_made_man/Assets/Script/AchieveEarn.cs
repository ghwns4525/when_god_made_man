// AchieveEarn
using UnityEngine;

public class AchieveEarn : MonoBehaviour
{
	public float speed;

	public float wait;

	private void Start()
	{
		this.wait = 0f;
	}

	private void Update()
	{
		this.wait += Time.deltaTime;
		if (this.wait > 2f)
		{
			base.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
		}
	}
}
