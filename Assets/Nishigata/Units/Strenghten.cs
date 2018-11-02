using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strenghten : MonoBehaviour {
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
        point.GetComponent<PointCont>().Point -= 20;
        unit.GetComponent<UnitStatus>().unitPower += 20;
        unitmenu.SetActive(false);


    }
}
