using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHealMode : MonoBehaviour {

	public bool healing { get; set; } //現在回復モードならtrue
	public int healcount{ get ; set; } //回復したユニットの数

	private bool healingcheck; //ユニットが範囲内に入ったかどうかチェック
	private bool canheal; //回復可能かどうか
	private GameObject[] healunit = new GameObject[20]; //回復するユニットのチェック
	private float waittime;

	// Use this for initialization
	void Start () {
		healing = false;
		healcount = 0;
		healingcheck = false;
		canheal = true;
		waittime = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (healing == true && healcount > 0)
		{
			healing = false;
			Invoke("Heal", 2f);
		}
		*/
		//Debug.Log(canheal);
	}

	private void FixedUpdate()
	{
		if (healingcheck == true && canheal == true)
        {
            canheal = false;
            StartCoroutine("HealCheck");
        }
	}

	//回復モード移行時
	public void Heal ()
	{
		healing = true;
		canheal = true;
		healingcheck = false;
		healcount = 0;
		for (int i = 0; i < 20; i++)
        {
			healunit[i] = null;
        }
	}

    //回復継続時
	private void reHeal()
	{
		canheal = true;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Unit")
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
			healingcheck = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Unit")
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

		if (healcount <= 0)
		{
			healingcheck = false;
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
