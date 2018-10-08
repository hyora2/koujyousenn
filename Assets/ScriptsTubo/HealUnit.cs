using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUnit : MonoBehaviour {

	[SerializeField] private bool isPlayer; //このスクリプトがアタッチされているユニットがプレイヤーのユニットかどうか判定

	private UnitStatus unitStatus, magicunitStatus; //magicunitStatusは魔法兵の回復力を参照している
	//private MagicHealMode healMode;
	private GameObject magicunit;

	// Use this for initialization
	void Start () {
		unitStatus = gameObject.GetComponent<UnitStatus>();
		isPlayer = false;
		magicunit = GameObject.Find("MagicUnit");
		magicunitStatus = magicunit.GetComponent<UnitStatus>(); //プレイヤーのユニットか敵のユニットか区別できるようにする
		//healMode = magicunit.GetComponent<MagicHealMode>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D trigger)
	{
		if (isPlayer == true)
		{
			if (trigger.gameObject == magicunit && magicunitStatus.unitCheck == true)
			{
				//healMode.healcount++;
				unitStatus.unitHp += magicunitStatus.unitHealingpower;
			}
		}
		else
		{
			if (trigger.gameObject == magicunit && magicunitStatus.unitCheck == false)
			{
				//healMode.healcount++;
				unitStatus.unitHp += magicunitStatus.unitHealingpower;
			}
		}
	}
}
