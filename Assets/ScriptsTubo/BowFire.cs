using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowFire : MonoBehaviour {

	private bool canattack; //攻撃できるかどうか
	[SerializeField]
	private GameObject bullet;
	[SerializeField]
	private Transform bulletPos;
	[Header("弾を撃つ間隔") , SerializeField]
	private float span;
	[Header("弾速"), SerializeField]
	private float bulletspeed;

	// Use this for initialization
	void Start () {
		canattack = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (canattack == true)
		{
			canattack = false;
			StartCoroutine("Fire");
		}
	}

	private IEnumerator Fire()
	{
		GameObject bullets = Instantiate(bullet, bulletPos) as GameObject;
		bullets.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletspeed;

		yield return new WaitForSeconds(span);

		canattack = true;
	}
}
