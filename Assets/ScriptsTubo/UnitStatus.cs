using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour {

	public int unitHp; //ユニットのHP
	public int unitPower; //ユニットの攻撃力
	public int unitHealingpower; //魔法兵の回復力　魔法兵以外は値を0にする
	public float unitspeed; //ユニットの移動速度
	public bool unitCheck; //プレイヤーのユニットならtrue、敵のユニットならfalse

	public int getscore; //倒した場合得られるスコア(敵の場合のみ)

	private Rigidbody2D rb;
	private PointCont point;

    int HPMax;

    // Use this for initialization
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		point = GameObject.Find("GameSystem").GetComponent<PointCont>();
        HPMax = unitHp;
    }

	// Update is called once per frame
	void Update()
	{
		if (unitHp <= 0)
		{
			Destroy(gameObject);
			if (unitCheck == false)
			{
				point.PGet(getscore);
			}
		}
        if (unitHp>HPMax) {
            unitHp = HPMax;
        }
	}
}
