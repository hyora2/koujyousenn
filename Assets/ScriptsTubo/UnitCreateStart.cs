using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateStart : MonoBehaviour {

	public GameObject[] Enemy { get; private set; }//敵
	public GameObject[] Player { get; private set; }//プレイヤー

	public GameObject[] EnemyKind; //0から順に歩兵、重装兵、騎馬兵、弓兵、魔法兵のプレハブをセットする
	public GameObject[] PlayerKind; //上に同じ
	public int Enecount { get; set; } //敵の魔法兵のカウント

	// Use this for initialization
	void Start () {
		Enemy = new GameObject[10];
		Player = new GameObject[10];
		Enecount = 1;
		int i = 0; //Enemyの配列のカウント
		int j = 0; //EnemyKindの配列のカウント
		int size = 2; //配列のサイズ
		float vx = -3f; //ユニットを生成するx軸の位置
		float vy = 1f; //ユニットを生成するy軸の位置
		Vector3 unitPos = new Vector3(vx, vy, 0f); //生成するユニットの位置
		while (Enemy[9] == null)
		{
			vy = 2f;
			while (i < size)
			{
				unitPos = new Vector3(vx, vy, 0f); //生成するユニットの位置
				Enemy[i] = Instantiate(EnemyKind[j], unitPos, Quaternion.Euler(0f, 0f, 180f)) as GameObject; //プレイヤーの方を向き生成
				//Enemy[i].AddComponent<enemyUnitMove>(); //敵が移動できるようにする
				enemyUnitMove move = Enemy[i].GetComponent<enemyUnitMove>();
				move.unitTag = i + 1;
				UnitStatus unitStatus = Enemy[i].GetComponent<UnitStatus>();
				unitStatus.unitCheck = false;

                if (size == 10)
				{
					MagicModeChange modeChange = Enemy[i].GetComponent<MagicModeChange>();
					if (modeChange != null)
					{
						modeChange.attacking = true;
					}
					StartCoroutine(comp(Enemy[i]));
				}
				    
				vy += 1.5f;
				i++;
			}
			vx += 1.5f;
			i = size;
			size += 2;
			j++;
		}

		i = 0;
		j = 0;
		size = 2;
		vx = -3f;
		while (Player[9] == null)
        {
            vy = -3f;
            while (i < size)
            {
                unitPos = new Vector3(vx, vy, 0f); //生成するユニットの位置
				Player[i] = Instantiate(PlayerKind[j], unitPos, Quaternion.identity) as GameObject;

                if (size == 10)
                {
					MagicModeChange modeChange = Player[i].transform.Find("Ui&Unit/unit").gameObject.GetComponent<MagicModeChange>();
                    if (modeChange != null)
                    {
                        modeChange.attacking = true;
                    }
                    //StartCoroutine(comp(Player[i]));
                }

                vy -= 1.5f;
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
