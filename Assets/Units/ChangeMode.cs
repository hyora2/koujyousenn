using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {
    bool mode;
   
    public GameObject Cbutton;

	private GameObject Root;
    private GameObject magicunit;

	private MagicModeChange modeChange;

    // Use this for initialization
    void Start () {
       /* if (Cbutton.tag == "C_Mode")
        {
            ButtonPushC();

        }
        else {
            ButtonPushA();
        }*/
        
		Root = transform.root.gameObject;
        magicunit = Root.transform.Find("MagicUnit").gameObject;

        modeChange = magicunit.GetComponent<MagicModeChange>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPushC()
    {

		modeChange.attacking = false;

    }
    public void ButtonPushA() {
		modeChange.attacking = true;
    }
}
