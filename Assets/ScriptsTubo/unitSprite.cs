using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitSprite : MonoBehaviour {

	private SpriteRenderer damageRenderer;

	// Use this for initialization
	void Start () {
		damageRenderer = transform.Find("damage").gameObject.GetComponent<SpriteRenderer>();
		damageRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
