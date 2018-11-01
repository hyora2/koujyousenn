using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicModeChange : MonoBehaviour {

	public bool attacking { get; set; } //攻撃モードならtrue、回復モードならfalse
	public bool save { get; set; } //弾の発射を制御

	private MagicAttackMode attackMode;
	private MagicHealMode healMode;
	private ModeSwich swich;

	private GameObject Root;
    private GameObject Wmenu;

	//private int modenum; //1はattack、2はheal

	// Use this for initialization
	void Start () {
		attacking = true;
		save = true;
		//modenum = 1;
		attackMode = gameObject.GetComponent<MagicAttackMode>();
		healMode = gameObject.GetComponent<MagicHealMode>();

		Root = transform.root.gameObject;
        //Wmenu = Root.transform.Find("unitmenu/W_Menu").gameObject;
        //swich = Wmenu.GetComponent<ModeSwich>();

		Changed(1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void FixedUpdate()
	{
		/*
		if (attacking == false)
		{
			if (save == true)
			{
				//swich.Attack = true;
                //swich.Cure = false;
                modenum = 2;
                Changed(modenum);
			}
		}
		else if (attacking == true)
		{
			if (save == true)
			{
				healMode.healing = false;
                //swich.Attack = false;
                //swich.Cure = true;
                modenum = 1;
                Changed(modenum);
			}
		}
		*/
	}

	public void Changed(int changenum)
	{
		if (changenum == 1)
        {
			//save = false;
            attackMode.Attack();
        }
		else if (changenum == 2)
        {
			//save = false;
            healMode.Heal();
        }
		Debug.Log("name = " + gameObject.name + ", num = " + changenum);
	}

}
