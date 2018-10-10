using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	private UnitStatus magicunitstatus;

	// Use this for initialization
	void Start () {
		magicunitstatus = GameObject.Find("MagicUnit").GetComponent<UnitStatus>();
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Unit")
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			unitStatus.unitHp -= magicunitstatus.unitPower;
		}
        //基地の処理も書く
	}

}
