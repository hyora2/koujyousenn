using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnitMove : MonoBehaviour {

	private GameObject neutBase, playerBase; //中立の拠点とプレイヤーの拠点

	// Use this for initialization
	void Start () {
		neutBase = GameObject.FindWithTag("NeutralBase");
		playerBase = GameObject.Find("PlayerBase");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
