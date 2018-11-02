using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutSpriteChange : MonoBehaviour {

	private BaseStatus baseStatus;
	private SpriteRenderer[] sprites;

	// Use this for initialization
	void Start () {
		baseStatus = GetComponent<BaseStatus>();
		sprites = new SpriteRenderer[3];
		int i = 0;
		foreach (Transform child in transform)
		{
			sprites[i] = child.gameObject.GetComponent<SpriteRenderer>();
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (baseStatus.neut == 0)
		{
			sprites[0].enabled = true;
			sprites[1].enabled = false;
			sprites[2].enabled = false;
		}
		else if (baseStatus.neut == 1)
		{
			sprites[0].enabled = false;
            sprites[1].enabled = true;
            sprites[2].enabled = false;
		}
		else if (baseStatus.neut == 2)
		{
			sprites[0].enabled = false;
            sprites[1].enabled = false;
            sprites[2].enabled = true;
		}
	}
}
