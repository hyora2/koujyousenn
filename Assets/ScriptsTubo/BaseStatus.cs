using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour {

	public int BaseHP;
	public int BaseTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "EnemyUnit" && BaseTag == 1)
		{
			BaseHP -= 10; //本来は敵ユニットの攻撃力で判定する
		}
		else if (collision.gameObject.tag == "PlayerUnit" && BaseTag == 2)
		{
			BaseHP -= 10; //上に同じ
		}
		else if ((collision.gameObject.tag == "EnemyUnit" || collision.gameObject.tag == "PlayerUnit") && BaseTag == 3)
		{
			BaseHP -= 10;
		}
		else if ((collision.gameObject.tag == "EnemyUnit" || collision.gameObject.tag == "PlayerUnit") && BaseTag == 4)
        {
            BaseHP -= 10;
        }
	}
}
