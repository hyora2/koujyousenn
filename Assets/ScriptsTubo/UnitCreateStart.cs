using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateStart : MonoBehaviour {

	public GameObject[] Enemy { get; private set; }//敵の数

	public GameObject[] EnemyKind; //0から順に歩兵、重装兵、騎馬兵、弓兵、魔法兵のプレハブをセットする
	public int Enecount { get; set; } //敵の魔法兵のカウント

	// Use this for initialization
	void Start () {
		Enemy = new GameObject[10];
        /*
		EnemyKind = new GameObject[5];
		EnemyKind[0] = (GameObject)Resources.Load("Prefabs/Work Unit");
		EnemyKind[1] = (GameObject)Resources.Load("Prefabs/Heavy Unit");
		EnemyKind[2] = (GameObject)Resources.Load("Prefabs/Horse Unit");
		EnemyKind[3] = (GameObject)Resources.Load("Prefabs/Bow Unit");
		EnemyKind[4] = (GameObject)Resources.Load("Prefabs/MagicUnit");
		*/
		Enecount = 1;
		int i = 0; //Enemyの配列のカウント
		int j = 0; //EnemyKindの配列のカウント
		int size = 2; //配列のサイズ
		float vx = -3f; //ユニットを生成するx軸の位置
		float vy = 1f; //ユニットを生成するy軸の位置
		Vector3 unitPos = new Vector3(vx, vy, 0f); //生成するユニットの位置
		while (Enemy[9] == null)
		{
			vy = 1f;
			while (i < size)
			{
				unitPos = new Vector3(vx, vy, 0f); //生成するユニットの位置
				Enemy[i] = Instantiate(EnemyKind[j], unitPos, Quaternion.Euler(0f, 0f, 180f)) as GameObject;
				//Enemy[i].transform.Rotate(new Vector3(0f, 180f, 0f)); //プレイヤー側を向く
				UnitStatus unitStatus = Enemy[i].GetComponent<UnitStatus>();
				unitStatus.unitCheck = false;
				//Enemy[i].SetActive(false);
				//Enemy[i].SetActive(true);

                if (size == 10)
				{
					StartCoroutine(comp(Enemy[i]));
				}
				    
				vy += 1.5f;
				Debug.Log(Enemy[i]);
				i++;
			}
			vx += 1.5f;
			i = size;
			size += 2;
			j++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator comp (GameObject enemy)
	{

		yield return new WaitForSeconds(1f);

		MagicModeChange magicModeChange = enemy.GetComponent<MagicModeChange>();
		Debug.Log(magicModeChange.attacking);
		MagicHealMode magicHealMode = enemy.GetComponent<MagicHealMode>();
        magicHealMode.circle.enabled = true;
        HealRenderer healRenderer = enemy.GetComponent<HealRenderer>();
        healRenderer.lineRenderer.enabled = true;
	}

	public int Objname(GameObject Obj)
	{
		Obj.name = "MagicUnit" + Enecount;
		return Enecount;
	}
}
