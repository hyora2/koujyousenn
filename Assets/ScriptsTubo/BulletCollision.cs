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
        //中立拠点に当たったら
		if (collision.gameObject.tag == "NeutralBase")
		{
			BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
			baseStatus.BaseHP -= magicunitstatus.unitPower;
			Destroy(gameObject);
		}

        //プレイヤーユニットの場合
		if (magicunitstatus.unitCheck == true)
		{
			//敵拠点に当たったら
			if (collision.gameObject.tag == "EnemyBase")
			{
				BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.BaseHP -= magicunitstatus.unitPower;
				Destroy(gameObject);
			}
            //敵ユニットに当たったら
			else if (collision.gameObject.tag == "Unit")
			{
				UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
				if (unitStatus.unitCheck == false)
				{
					unitStatus.unitHp -= magicunitstatus.unitPower;
				}
				Destroy(gameObject);
			}
		}
        //敵ユニットの場合
		else
		{
			//プレイヤーの拠点に当たった場合
			if (collision.gameObject.tag == "PlayerBase")
            {
                BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.BaseHP -= magicunitstatus.unitPower;
				Destroy(gameObject);
            }
            //プレイヤーのユニットに当たったら
			else if (collision.gameObject.tag == "Unit")
			{
				UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
				if (unitStatus.unitCheck == true)
				{
					unitStatus.unitHp -= magicunitstatus.unitPower;
				}
				Destroy(gameObject);
			}
		}

	}

}
