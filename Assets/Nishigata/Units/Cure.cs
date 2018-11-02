using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour {

	public GameObject unitmenu;
    public GameObject point;
    public GameObject unit;

    // Use this for initialization
    void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPush()
    {
        point = GameObject.FindWithTag("PointCount");
        point.GetComponent<PointCont>().Point -= 10;
        unit.GetComponent<UnitStatus>().unitHp += 50;
        unitmenu.SetActive(false);
        Debug.Log("cure");

       

    }
}
