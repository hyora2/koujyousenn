using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnitMove : MonoBehaviour {

    //基地の設定
	private GameObject playerBase; //プレイヤーの拠点
	private GameObject enemyBase; //敵の拠点
	[SerializeField]
	private GameObject Neutral1, Neutral2; //中立の拠点
	private BaseStatus base1, base2; //中立の拠点が現在中立なのかどうか確認
	private BaseManager baseManager;

	// Use this for initialization
	void Start () {
		playerBase = GameObject.Find("PlayerBase");
		enemyBase = GameObject.Find("EnemyBase");
		base1 = Neutral1.GetComponent<BaseStatus>();
		base2 = Neutral2.GetComponent<BaseStatus>();
		baseManager = GameObject.Find("BaseManager").GetComponent<BaseManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		//中立の拠点を取りに行くユニットを決める
		if (base1.neut == 0)
		{
			
		}
		else if (base2.neut == 0)
		{
			
		}
        //中立の拠点がどちらもプレイヤーの拠点だった場合守りに徹する
		else if (baseManager.playerbaseCount == 2)
		{
			
		}
		//中立の拠点が片方プレイヤーの拠点だった場合中立の拠点を攻めていたユニットを敵の本拠地に向かわせる
		else if (baseManager.playerbaseCount == 1 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
		{
			
		}
        //中立の拠点が両方とも敵の拠点だった場合攻めに徹する
		else if (baseManager.playerbaseCount == 0 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
        {

        }
	}
}
