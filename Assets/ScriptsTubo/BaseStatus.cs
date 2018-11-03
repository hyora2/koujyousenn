using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStatus : MonoBehaviour {

	public int BaseHP;
	public int BaseTag; //1はプレイヤー、2は敵、3と4は中立の拠点

	public int neut //0は中立、1はプレイヤー、2は敵の拠点
	{
		get;
		private set;
	}

	public int getpoint; //中立の拠点を獲得した際に得られるポイントの量(獲得量は２つの拠点で同じにすること)

	private bool occu; //どちらかが占拠したら生成出来ないようにする
	private BaseManager baseManager;
	private UnitCreateStart unitCreateStart;
	private PointCont point;

	private CircleCollider2D circle;
	private SpriteRenderer[] renderers;
	private SpriteRenderer damageSprite;

	private GameObject playerbase;

    public Slider slider;

    // Use this for initialization
    void Start () {
		neut = 0;
		occu = true;
		baseManager = GameObject.Find("BaseManager").GetComponent<BaseManager>();
		unitCreateStart = GameObject.Find("GameSystem").GetComponent<UnitCreateStart>();
		point = GameObject.Find("GameSystem").GetComponent<PointCont>();
		circle = GetComponent<CircleCollider2D>();

		renderers = new SpriteRenderer[10];
		int i = 0;
		foreach (Transform child in transform)
		{
			renderers[i] = child.gameObject.GetComponent<SpriteRenderer>();
			if (renderers != null)
			    i++;
		}
		damageSprite = renderers[3];
		//damageSprite.enabled = false;

		playerbase = GameObject.Find("PlayerBase");

        slider.maxValue = BaseHP;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = BaseHP;

    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//ダメージ判定
		UnitStatus status = collision.gameObject.GetComponent<UnitStatus>();
		if (status != null)
		{
			string tagstr = collision.gameObject.tag;
			bool isUnit = tagstr.Contains("Unit");

			if (isUnit == true && status.unitCheck == false && BaseTag == 1)
			{
				damage(status.unitPower);
			}
			else if (isUnit == true && status.unitCheck == true && BaseTag == 2)
			{
				damage(status.unitPower);
			}
			else if (isUnit == true && BaseTag == 3)
			{
				damage(status.unitPower);
				//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
				if (BaseHP <= 0 && occu == true)
				{
					occu = false;
					if (status.unitCheck == true)
					{
						neut = 1;
						baseManager.playerbaseCount++;
						circle.radius = 0f;
						point.PGet(getpoint);
						BaseP(gameObject);
					}
					else if (status.unitCheck == false)
					{
						neut = 2;
						circle.radius = 0f;
						BaseE(gameObject);
					}
				}
			}
			else if (isUnit == true && BaseTag == 4)
			{
				damage(status.unitPower);
				//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
				if (BaseHP <= 0 && occu == true)
				{
					occu = false;
					if (status.unitCheck == true)
					{
						neut = 1;
						baseManager.playerbaseCount++;
						circle.radius = 0f;
						point.PGet(getpoint);
						BaseP(gameObject);
					}
					else if (status.unitCheck == false)
					{
						neut = 2;
						circle.radius = 0f;
						BaseE(gameObject);
					}
				}
			}
		}
		else if (collision.gameObject.tag == "Bullet")
		{
			UnitStatus Bstatus = collision.transform.root.gameObject.GetComponent<UnitStatus>();
			if (Bstatus == null)
			{
				GameObject unit = collision.gameObject.transform.root.gameObject;
				GameObject bul = unit.transform.Find("Ui&Unit/unit").gameObject;
				Bstatus = bul.GetComponent<UnitStatus>();
			}
			if (Bstatus != null)
			{
				if (Bstatus.unitCheck == false && BaseTag == 1)
				{
					damage(Bstatus.unitPower);
				}
				else if (Bstatus.unitCheck == true && BaseTag == 2)
				{
					damage(Bstatus.unitPower);
				}
				else if (BaseTag == 3)
				{
					damage(Bstatus.unitPower);
					//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
					if (BaseHP <= 0 && occu == true)
					{
						occu = false;
						if (Bstatus.unitCheck == true)
						{
							neut = 1;
							baseManager.playerbaseCount++;
							circle.radius = 0f;
							point.PGet(getpoint);
							BaseP(gameObject);
						}
						else if (Bstatus.unitCheck == false)
						{
							neut = 2;
							circle.radius = 0f;
							BaseE(gameObject);
						}
					}
				}
				else if (BaseTag == 4)
				{
					damage(Bstatus.unitPower);
					//中立拠点がプレイヤーもしくは敵の拠点になるかどうか判定
					if (BaseHP <= 0 && occu == true)
					{
						if (Bstatus.unitCheck == true)
						{
							occu = false;
							neut = 1;
							baseManager.playerbaseCount++;
							circle.radius = 0f;
							point.PGet(getpoint);
							BaseP(gameObject);
						}
						else if (Bstatus.unitCheck == false)
						{
							neut = 2;
							circle.radius = 0f;
							BaseE(gameObject);
						}
					}
				}
			}
		}
		Debug.Log(BaseHP);
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
			Instantiate(unitCreateStart.PlayerKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;

		float creY = 1f; //中立拠点の上下の位置に配置
		crePos = new Vector3(0f, creY, 0f);
		rand = Random.Range(0, 5);
		unitCre =
			Instantiate(unitCreateStart.PlayerKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;

		crePos = new Vector3(0f, -creY, 0f);
		rand = Random.Range(0, 5);
		unitCre =
			Instantiate(unitCreateStart.PlayerKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
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
		enemyUnitMove unitMove = unitCre.GetComponent<enemyUnitMove>();
		switch (BaseTag)
        {
            case 3:
				unitMove.unitTag = 11;
                break;
            case 4:
				unitMove.unitTag = 14;
                break;
            default:
                break;
        }

        float creY = 1f; //中立拠点の上下の位置に配置
        crePos = new Vector3(0f, creY, 0f);
        rand = Random.Range(0, 5);
        unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
		unitMove = unitCre.GetComponent<enemyUnitMove>();
		switch (BaseTag)
        {
            case 3:
                unitMove.unitTag = 12;
                break;
            case 4:
                unitMove.unitTag = 15;
                break;
            default:
                break;
        }

        crePos = new Vector3(0f, -creY, 0f);
        rand = Random.Range(0, 5);
        unitCre =
            Instantiate(unitCreateStart.EnemyKind[rand], baseObj.transform.position + crePos, Quaternion.identity) as GameObject;
		unitMove = unitCre.GetComponent<enemyUnitMove>();
		switch (BaseTag)
        {
            case 3:
                unitMove.unitTag = 13;
                break;
            case 4:
                unitMove.unitTag = 16;
                break;
            default:
                break;
        }
	}

	public void damage(int dam)
	{
		if (BaseHP >= 0 && damageSprite != null)
		    damageSprite.enabled = true;
		BaseHP -= dam;
		StartCoroutine("Span");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Unit")
		{
			UnitStatus status = collision.gameObject.GetComponent<UnitStatus>();
			if (status != null && status.unitCheck == false)
			{
				enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
				unitMove.canMove = false;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Unit")
        {
            UnitStatus status = collision.gameObject.GetComponent<UnitStatus>();
            if (status != null && status.unitCheck == false)
            {
                enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
                unitMove.canMove = true;
            }
        }
	}

	private IEnumerator Span()
	{

		yield return new WaitForSeconds(0.5f);

		damageSprite.enabled = false;
	}

}
