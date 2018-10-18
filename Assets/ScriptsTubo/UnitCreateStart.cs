using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateStart : MonoBehaviour {

	public GameObject[] Enemy; //敵の数

	[SerializeField]
	private GameObject[] EnemyKind; //0から順に歩兵、重装兵、騎馬兵、弓兵、魔法兵のプレハブをセットする

	// Use this for initialization
	void Start () {
		Enemy = new GameObject[10];
		EnemyKind = new GameObject[5];
		int i = 0; //Enemyの配列のカウント
		int j = 0; //EnemyKindの配列のカウント
		int size = 2; //配列のサイズ
		Vector3 unitPos = new Vector3(-2, 0, 0); //ユニット
		while (Enemy[9] != null)
		{
			while (i < size)
			{
				GameObject EnemyUnit = Instantiate(EnemyKind[j], transform.position, Quaternion.identity) as GameObject;
				Enemy[i] = EnemyUnit;
				i++;
			}
			i = size;
			size += 2;
			j++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
