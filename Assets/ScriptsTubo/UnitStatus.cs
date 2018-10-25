using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour {

	public int unitHp { get { return hp; } set { hp = value; }}
	public int unitPower { get { return power; } set { power = value; } }
	public int unitHealingpower { get { return magichealingpower; } set { magichealingpower = value; } }
	public float unitspeed { get { return speed; } set { speed = value; } }
	public bool unitCheck { get { return playerunit; } set { playerunit = value; } }

	[SerializeField] private int hp; //ユニットのHP
    [SerializeField] private int power; //ユニットの攻撃力
	[SerializeField] private int magichealingpower; //魔法兵の回復力　魔法兵以外は値を0にする
	[SerializeField] private float speed; //ユニットの移動速度
	[SerializeField] private bool playerunit; //プレイヤーのユニットならtrue、敵のユニットならfalse

	private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update()
	{
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
		Debug.Log(unitHp);
	}
}
