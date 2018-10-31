using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicModeChange : MonoBehaviour {

	public bool attacking { get; set; } //攻撃モードならtrue、回復モードならfalse

	private MagicAttackMode attackMode;
	private MagicHealMode healMode;
	private ModeSwich swich;

	private GameObject Root;
    private GameObject Wmenu;

	// Use this for initialization
	void Start () {
		attacking = true;
		attackMode = gameObject.GetComponent<MagicAttackMode>();
		healMode = gameObject.GetComponent<MagicHealMode>();

		Root = transform.root.gameObject;
        Wmenu = Root.transform.Find("unitmenu/W_Menu").gameObject;
        swich = Wmenu.GetComponent<ModeSwich>();

		Changed();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void FixedUpdate()
	{
		if (attacking == false)
		{
			swich.Attack = true;
            swich.Cure = false;
			Changed();
		}
		else if (attacking == true)
		{
			healMode.healing = false;
			swich.Attack = false;
            swich.Cure = true;
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
