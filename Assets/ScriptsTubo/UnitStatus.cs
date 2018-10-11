using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour {

	public int unitHp; //ユニットのHP
	public int unitPower; //ユニットの攻撃力
	public int unitHealingpower; //魔法兵の回復力　魔法兵以外は値を0にする
	public float unitspeed; //ユニットの移動速度
	public bool unitCheck; //プレイヤーのユニットならtrue、敵のユニットならfalse

	private int maxHp;

    // Use this for initialization
    void Start()
    {
		maxHp = unitHp;
    }

    // Update is called once per frame
    void Update()
	{
		if (unitHp > maxHp)
		{
			unitHp = maxHp;
		}

		if (unitHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
