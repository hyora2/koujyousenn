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

	public int getpoint; //中立の拠点を獲得した際に得られるポイントの量(獲得量は２つの拠点で同じにすること)

	private BaseManager baseManager;
	private UnitCreateStart unitCreateStart;
	private PointCont point;

	// Use this for initialization
	void Start () {
		neut = 0;
		baseManager = GameObject.Find("BaseManager").GetComponent<BaseManager>();
		unitCreateStart = GameObject.Find("GameSystem").GetComponent<UnitCreateStart>();
		point = GameObject.Find("GameSystem").GetComponent<PointCont>();
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
					point.PGet(getpoint);
					BaseP(gameObject);
				}
				else if (collision.gameObject.tag == "EnemyUnit")
				{
					neut = 2;
					BaseE(gameObject);
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
					point.PGet(getpoint);
					BaseP(gameObject);
                }
                else if (collision.gameObject.tag == "EnemyUnit")
                {
                    neut = 2;
					BaseE(gameObject);
                }
            }
		}
	}

	void BaseP(GameObject baseObj)
	{
		//生成場所決め
		float creX = 0f; //中立拠点の右(左)の位置に配置
		switch(BaseTag)
		{
			case 3:
				creX = 1f;
				break;
			case 4:
				creX = -1f;
				break;
			default:
				break;
		}
		Vector3 crePos = new Vector3(creX, 0f, 0f);
		int rand = Random.Range(0, 5); //どの種類のユニット生成するかを決める
		GameObject unitCre =
			Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
		UnitStatus unitStatus = unitCre.GetComponent<UnitStatus>();
		unitStatus.unitCheck = true;

		float creY = 1f; //中立拠点の上下の位置に配置
		crePos = new Vector3(0f, creY, 0f);
		rand = Random.Range(0, 5);
		unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
        unitStatus = unitCre.GetComponent<UnitStatus>();
        unitStatus.unitCheck = true;

		crePos = new Vector3(0f, -creY, 0f);
		rand = Random.Range(0, 5);
		unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
        unitStatus = unitCre.GetComponent<UnitStatus>();
        unitStatus.unitCheck = true;
	}

	void BaseE(GameObject baseObj)
	{
		//生成場所決め
        float creX = 0f; //中立拠点の右(左)の位置に配置
        switch (BaseTag)
        {
            case 3:
                creX = 1f;
                break;
            case 4:
                creX = -1f;
                break;
            default:
                break;
        }
        Vector3 crePos = new Vector3(creX, 0f, 0f);
        int rand = Random.Range(0, 5); //どの種類のユニット生成するかを決める
        GameObject unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
        UnitStatus unitStatus = unitCre.GetComponent<UnitStatus>();
        unitStatus.unitCheck = true;

        float creY = 1f; //中立拠点の上下の位置に配置
        crePos = new Vector3(0f, creY, 0f);
        rand = Random.Range(0, 5);
        unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
        unitStatus = unitCre.GetComponent<UnitStatus>();
        unitStatus.unitCheck = true;

        crePos = new Vector3(0f, -creY, 0f);
        rand = Random.Range(0, 5);
        unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
        unitStatus = unitCre.GetComponent<UnitStatus>();
        unitStatus.unitCheck = true;
	}

	public void damage(int dam)
	{
		BaseHP -= dam;
	}

}
