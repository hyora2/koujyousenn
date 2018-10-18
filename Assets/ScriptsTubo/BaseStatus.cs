using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour {

	public int BaseHP;
	public int BaseTag; //1はプレイヤー、2は敵、3と4は中立の拠点

	public int neut //0は中立、1はプレイヤー、2は敵の拠点
	{
		get;
		private set;
	}

	private BaseManager baseManager;

	// Use this for initialization
	void Start () {
		neut = 0;
		baseManager = GameObject.Find("BaseManager").GetComponent<BaseManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//ダメージ判定
		if (collision.gameObject.tag == "EnemyUnit" && BaseTag == 1)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			BaseHP -= unitStatus.unitPower;
		}
		else if (collision.gameObject.tag == "PlayerUnit" && BaseTag == 2)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			BaseHP -= unitStatus.unitPower;
		}
		else if ((collision.gameObject.tag == "EnemyUnit" || collision.gameObject.tag == "PlayerUnit") && BaseTag == 3)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			BaseHP -= unitStatus.unitPower;
			//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
			if (BaseHP <= 0)
			{
				if (collision.gameObject.tag == "PlayerUnit")
				{
					neut = 1;
					baseManager.playerbaseCount++;
				}
				else if (collision.gameObject.tag == "EnemyUnit")
				{
					neut = 2;
				}
			}
		}
		else if ((collision.gameObject.tag == "EnemyUnit" || collision.gameObject.tag == "PlayerUnit") && BaseTag == 4)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			BaseHP -= unitStatus.unitPower;
			//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
			if (BaseHP <= 0)
            {
                if (collision.gameObject.tag == "PlayerUnit")
                {
                    neut = 1;
					baseManager.playerbaseCount++;
                }
                else if (collision.gameObject.tag == "EnemyUnit")
                {
                    neut = 2;
                }
            }
		}
	}
}
