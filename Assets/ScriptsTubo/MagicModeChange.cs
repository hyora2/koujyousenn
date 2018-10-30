using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicModeChange : MonoBehaviour {

	public bool attacking { get; set; } //攻撃モードならtrue、回復モードならfalse

	private MagicAttackMode attackMode;
	private MagicHealMode healMode;

	// Use this for initialization
	void Start () {
		attacking = true;
		attackMode = gameObject.GetComponent<MagicAttackMode>();
		healMode = gameObject.GetComponent<MagicHealMode>();
		Changed();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			attacking = false;
			Changed();

		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			attacking = true;
			healMode.healing = false;
			Changed();
		}
		Debug.Log(attacking);
	}

	private void Changed()
	{
		if (attacking == true)
        {
            attackMode.Attack();
        }
        else
        {
            healMode.Heal();
        }
	}

}
