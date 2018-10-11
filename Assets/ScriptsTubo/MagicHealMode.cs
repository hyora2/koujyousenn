using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHealMode : MonoBehaviour {

	public bool healing { get; set; } //現在回復モードならtrue

	private bool canheal;//回復可能かどうか
	private CircleCollider2D circle; //モード切り替え時に回復処理を正しく行わせるため
	private int healcount; //回復したユニットの数
	private bool healingcheck; //ユニットが範囲内に入ったかどうかチェック
	private GameObject[] healunit; //回復するユニットのチェック
	private float waittime;
	private UnitStatus magicUnitStatus;

	// Use this for initialization
	void Start () {
		healing = false;
		healcount = 0;
		healingcheck = false;
		canheal = false;
		waittime = 2.0f;
		magicUnitStatus = gameObject.GetComponent<UnitStatus>();

		int unitnum = 20; //ユニットの数(各々所持できるユニットは20以内)
		healunit = new GameObject[unitnum];

		circle = gameObject.GetComponent<CircleCollider2D>();
		circle.enabled = false;
		circle.radius = 0f; //半径の大きさを変更している理由は下記参照
	}

	//circle.radiusについて
    //circleコライダーをenabledで消したり付けたりを切り替えると、正しく回復判定・処理がされなかったため半径の大きさで再度判定できるようにした
	
	// Update is called once per frame
	void Update () {

	}

	private void FixedUpdate()
	{
		if (healing == false)
		{
			healCancel();
		}

		if (healingcheck == true && canheal == true)
        {
            canheal = false;
            StartCoroutine("HealCheck");
        }

		if (healcount > 0)
		{
			healingcheck = true;
		}
		else
		{
			healingcheck = false;
		}
	}

	//回復モード移行時
	public void Heal ()
	{
		healing = true;
		canheal = true;
		circle.enabled = true;
        circle.radius = 3.0f;
	}

    //攻撃モード移行時
	private void healCancel ()
	{
		canheal = false;

		healingcheck = false;
		healcount = 0;
		for (int i = 0; i < 20; i++)
        {
            healunit[i] = null;
        }
		circle.enabled = false;
		circle.radius = 0f;
	}

    //回復継続時
	private void reHeal()
	{
		canheal = true;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (magicUnitStatus.unitCheck == true)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			if (collision.gameObject.tag == "Unit" && unitStatus.unitCheck == true)
			{
				healcount++;
				for (int i = 0; i < 20; i++)
				{
					if (healunit[i] == null)
					{
						healunit[i] = collision.gameObject;
						break;
					}
				}
			}
		}
		else
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			if (collision.gameObject.tag == "Unit" && unitStatus.unitCheck == false)
            {
                healcount++;
                for (int i = 0; i < 20; i++)
                {
                    if (healunit[i] == null)
                    {
                        healunit[i] = collision.gameObject;
                        break;
                    }
                }
            }
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (magicUnitStatus.unitCheck == true)
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			if (collision.gameObject.tag == "Unit" && unitStatus.unitCheck == true)
			{
				healcount--;
				for (int i = 0; i < 20; i++)
				{
					if (healunit[i] == collision.gameObject)
					{
						healunit[i] = null;
						break;
					}
				}
			}
		}
		else
		{
			UnitStatus unitStatus = collision.gameObject.GetComponent<UnitStatus>();
			if (collision.gameObject.tag == "Unit" && unitStatus.unitCheck == false)
            {
                healcount--;
                for (int i = 0; i < 20; i++)
                {
                    if (healunit[i] == collision.gameObject)
                    {
                        healunit[i] = null;
                        break;
                    }
                }
            }
		}
	}

	IEnumerator HealCheck()
	{
		for (int i = 0; i < 20; i++)
		{
			if (healunit[i] != null)
			{
				//回復処理
				UnitStatus unitStatus = healunit[i].GetComponent<UnitStatus>();
				UnitStatus magicunitStatus = gameObject.GetComponent<UnitStatus>();
				unitStatus.unitHp += magicunitStatus.unitHealingpower;
			}
		}

		yield return new WaitForSeconds(waittime);

		reHeal();
	}
}
