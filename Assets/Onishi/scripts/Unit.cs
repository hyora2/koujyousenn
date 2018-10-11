using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int unitHp = 100;
    [SerializeField] private int unitAttack = 100;
    [SerializeField] private int unitRecovery = 100;

    public int UnitAttack{
        get { return unitAttack;}
    }
    public int UnitHp{
        get { return unitHp;}
    }
    public int UnitRecovery{
        get { return unitRecovery;}
    }
          
          
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

        
