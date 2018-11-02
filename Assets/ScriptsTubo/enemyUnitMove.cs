using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnitMove : MonoBehaviour {
    //敵のユニットにアタッチする

	public bool canMove { get; set; } //移動できるか出来ないか 拠点の一定範囲内に入ったら動きを止める
	public bool rotP { get; set; } //敵拠点に到着した時、プレイヤーの拠点側を向く
	public int unitTag { get; set; }
	//public int pinchUnit { get; set; } //体力がピンチのユニットが増えてきた場合、魔法兵が回復モードに切り替える

    //基地の設定
	private GameObject playerBase; //プレイヤーの拠点
	private GameObject enemyBase; //敵の拠点
	private GameObject Neutral1, Neutral2; //中立の拠点
	private BaseStatus base1, base2; //中立の拠点が現在中立なのかどうか確認
	private BaseManager baseManager;
	private UnitCreateStart unitCreateStart;
	private MagicModeChange magicModeChange;
	private bool rot, rotN1, rotN2; //拠点への向き変更
	private int modenum;

	//private Rigidbody2D rb;

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

		modenum = 1;
		if (gameObject.tag == "WizardUnit")
		{
			magicModeChange = GetComponent<MagicModeChange>();
			StartCoroutine("modechange");
		}
		else
		{
			magicModeChange = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove == true)
        {
            move();
        }
	}

	private void FixedUpdate()
	{

        //個々用に書き直す

		//中立の拠点を取りに行くユニットを決める
		if (base1.neut == 0)
		{
			if (rotN1 == true)
			{
				rotN1 = false;
				canMove = false;
				if (unitTag % 2 == 1)
                {
					//unitCreateStart.Enemy[i].transform.LookAt(Neutral1.transform);
					var vec = (Neutral1.transform.position - transform.position).normalized;
					var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
					transform.rotation = Quaternion.Euler(0f, 0f, angle);
					canMove = true;
                }
			}
		}
		else if (base2.neut == 0)
		{
			if (rotN2 == true)
			{
				rotN2 = false;
				canMove = false;
				if (unitTag % 2 == 1)
                {
					//unitCreateStart.Enemy[i].transform.LookAt(Neutral2.transform);
					var vec = (Neutral2.transform.position - transform.position).normalized;
                    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                    transform.rotation = Quaternion.Euler(0f, 0f, angle);
					canMove = true;
                }
				//canMove = true;
			}
		}
        //中立の拠点がどちらもプレイヤーの拠点だった場合守りに徹する
		else if (baseManager.playerbaseCount == 2)
		{
			//敵の拠点に戻らせる
			if (rot == true)
			{
				rot = false;
				canMove = true;
                //unitCreateStart.Enemy[i].transform.LookAt(enemyBase.transform);
				var vec = (enemyBase.transform.position - transform.position).normalized;
                var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

				//canMove = true;
			}
            //敵の拠点周辺にたどり着いたらプレイヤーの拠点側を向く
			if (rotP == true)
			{
				rotP = false;
				canMove = false;
				//unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
				var vec = (playerBase.transform.position - transform.position).normalized;
                var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
				transform.rotation = Quaternion.Euler(0f, 0f, angle);
			}
            
		}
		//中立の拠点が片方プレイヤーの拠点だった場合中立の拠点を攻めていたユニットをプレイヤーの本拠地に向かわせる
		else if (baseManager.playerbaseCount == 1 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
		{
			if (rot == true)
			{
				rot = false;
				canMove = false;
				if (unitTag % 2 == 1)
				{
					//unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
					var vec = (playerBase.transform.position - transform.position).normalized;
					var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
					transform.rotation = Quaternion.Euler(0f, 0f, angle);
					canMove = true;
				}
				//canMove = true;
			}
		}
        //中立の拠点が両方とも敵の拠点だった場合攻めに徹する
		else if (baseManager.playerbaseCount == 0 && base1.BaseHP <= 0 && base2.BaseHP <= 0)
        {
            if (rot == true)
			{
				rot = false;
				canMove = true;
				//unitCreateStart.Enemy[i].transform.LookAt(playerBase.transform);
				var vec = (playerBase.transform.position - transform.position).normalized;
                var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

				//canMove = true;
			}
        }
	}

	private void move()
	{
		//rb = objects[i].GetComponent<Rigidbody2D>();
		UnitStatus status = GetComponent<UnitStatus>();
		//rb.velocity = new Vector2(0, status.unitspeed);
		transform.Translate(0f, status.unitspeed, 0f);
	}

	private IEnumerator modechange()
	{
		magicModeChange.Changed(modenum);

		yield return new WaitForSeconds(10f);

		switch(modenum)
		{
			case 1:
				modenum = 2;
				break;
			case 2:
				modenum = 1;
				break;
		}
		StartCoroutine("modechange");
	}
}
