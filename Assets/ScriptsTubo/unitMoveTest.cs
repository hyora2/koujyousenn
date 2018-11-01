using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitMoveTest : MonoBehaviour {

	//private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		transform.Translate(0f, 0.01f, 0f);
	}
}
