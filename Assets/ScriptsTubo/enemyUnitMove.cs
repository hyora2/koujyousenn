using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnitMove : MonoBehaviour {
    //敵のユニットにアタッチする

	public bool canMove { get; set; } //移動できるか出来ないか 拠点の一定範囲内に入ったら動きを止める
	public bool rotP { get; set; } //敵拠点に到着した時、プレイヤーの拠点側を向く

    //基地の設定
	private GameObject playerBase; //プレイヤーの拠点
	private GameObject enemyBase; //敵の拠点
	private GameObject Neutral1, Neutral2; //中立の拠点
	private BaseStatus base1, base2; //中立の拠点が現在中立なのかどうか確認
	private BaseManager baseManager;
	private UnitCreateStart unitCreateStart;
	private bool rot, rotN1, rotN2; //拠点への向き変更

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		canMove = true;

		playerBase = GameObject.Find("PlayerBase");
		enemyBase = GameObject.Find("EnemyBase");
		Neutral1 = GameObject.Find("NeutralBase1");
		Neutral2 = GameObject.Find("NeutralBase2");

		base1 = Neutral1.GetComponent<BaseStatus>();
		base2 = Neutral2.GetComponent<BaseStatus>();
		baseManager = GameObject.Find("BaseManager").GetComponent<BaseManager>();
		unitCreateStart = GameObject.Find("GameSystem").GetComponent<UnitCreateStart>();

		rot = true;
		rotP = false;
		rotN1 = true;
		rotN2 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove == true)
        {
            move(unitCreateStart.Enemy);
        }
	}

	private void FixedUpdate()
	{

        //向き指定→ターゲットと一定の距離になるまで移動→敵ユニットもしくは拠点攻撃

		//中立の拠点を取りに行くユニットを決める
		if (base1.neut == 0)
		{
			if (rotN1 == true)
			{
				rotN1 = false;
				for (int i = 0; i < 10; i += 2)
                {
					//unitCreateStart.Enemy[i].transform.LookAt(Neutral1.transform);
					var vec = (Neutral1.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
					var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
					unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
			}
		}
		else if (base2.neut == 0)
		{
			if (rotN2 == true)
			{
				rotN2 = false;
				for (int i = 0; i < 10; i += 2)
                {
					//unitCreateStart.Enemy[i].transform.LookAt(Neutral2.transform);
					var vec = (Neutral2.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
				canMove = true;
			}
		}
        //中立の拠点がどちらもプレイヤーの拠点だった場合守りに徹する
		else if (baseManager.playerbaseCount == 2)
		{
			//敵の拠点に戻らせる
			if (rot == true)
			{
				rot = false;
				for (int i = 0; i < 10; i++)
                {
                    //unitCreateStart.Enemy[i].transform.LookAt(enemyBase.transform);
					var vec = (enemyBase.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
				canMove = true;
			}
            //敵の拠点周辺にたどり着いたらプレイヤーの拠点側を向く
			if (rotP == true)
			{
				rotP = false;
				for (int i = 0; i < 10; i++)
				{
					//unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
					var vec = (playerBase.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
				}
			}
            
		}
		//中立の拠点が片方プレイヤーの拠点だった場合中立の拠点を攻めていたユニットをプレイヤーの本拠地に向かわせる
		else if (baseManager.playerbaseCount == 1 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
		{
			if (rot == true)
			{
				rot = false;
				for (int i = 0; i < 10; i += 2)
                {
                    //unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
					var vec = (playerBase.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
				canMove = true;
			}
		}
        //中立の拠点が両方とも敵の拠点だった場合攻めに徹する
		else if (baseManager.playerbaseCount == 0 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
        {
            if (rot == true)
			{
				rot = false;
				for (int i = 0; i < 10; i++)
				{
					//unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
					var vec = (playerBase.transform.position - unitCreateStart.Enemy[i].transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    unitCreateStart.Enemy[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
				}
				canMove = true;
			}
        }
	}

	private void move(GameObject[] objects)
	{
		for (int i = 0; i < 10; i++)
		{
			//rb = objects[i].GetComponent<Rigidbody2D>();
			UnitStatus status = objects[i].GetComponent<UnitStatus>();
			//rb.velocity = objects[i].transform. * status.unitspeed;
			objects[i].transform.Translate(0f, status.unitspeed, 0f);

		}
	}
}
