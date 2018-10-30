using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	private UnitStatus magicunitstatus;
	//private UnitCreateStart unitCreateStart;

	// Use this for initialization
	void Start () {
		//unitCreateStart = GameObject.Find("GameSystem").GetComponent<UnitCreateStart>();
		//int magicFind = unitCreateStart.Objname(gameObject);
		//magicunitstatus = GameObject.Find("MagicUnit" + magicFind).GetComponent<UnitStatus>(); //複数体いるので、名前を変えるなどして区別する
		magicunitstatus = transform.root.gameObject.GetComponent<UnitStatus>();
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
        //中立拠点に当たったら
		if (collision.gameObject.tag == "NeutralBase")
		{
			BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
			baseStatus.BaseHP -= magicunitstatus.unitPower;
			//Destroy(gameObject);
		}

		//一番上の階層にある親を取得してどの魔法兵かを判別させる
        //プレイヤーユニットの場合
		if (magicunitstatus.unitCheck == true)
		{
			//敵拠点に当たったら
			if (collision.gameObject.tag == "EnemyBase")
			{
				BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.BaseHP -= magicunitstatus.unitPower;
				//Destroy(gameObject);
			}
            //敵ユニットに当たったら
			else if (collision.gameObject.tag == "Unit")
			{
				UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
				if (unitStatus.unitCheck == false)
				{
					unitStatus.unitHp -= magicunitstatus.unitPower;
				}
				//Destroy(gameObject);
			}
            //プレイヤーユニットやお互いの弾に当たったら
			else if(collision.gameObject.tag == "Bullet")
			{
				//Destroy(gameObject);
			}
		}
        //敵ユニットの場合
		else if (magicunitstatus.unitCheck == false)
		{
			//プレイヤーの拠点に当たった場合
			if (collision.gameObject.tag == "PlayerBase")
            {
                BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.BaseHP -= magicunitstatus.unitPower;
				//Destroy(gameObject);
            }
            //ユニットに当たったら
			else if (collision.gameObject.tag == "Unit")
			{
				UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
                //プレイヤーのユニットかどうか
				if (unitStatus.unitCheck == true)
				{
					unitStatus.unitHp -= magicunitstatus.unitPower;
				}
				//Destroy(gameObject);
			}
			//お互いの弾に当たったら
			else if (collision.gameObject.tag == "Bullet")
			{
				//Destroy(gameObject);
			}
			//Destroy(gameObject);
		}

	}

}
