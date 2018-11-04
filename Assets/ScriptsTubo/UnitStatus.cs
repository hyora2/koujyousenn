using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatus : MonoBehaviour {

	public int unitHp; //ユニットのHP
	public int unitPower; //ユニットの攻撃力
	public int unitHealingpower; //魔法兵の回復力　魔法兵以外は値を0にする
	public float unitspeed; //ユニットの移動速度
	public bool unitCheck; //プレイヤーのユニットならtrue、敵のユニットならfalse

	public int getscore; //倒した場合得られるスコア(敵の場合のみ)

	private Rigidbody2D rb;
	private PointCont point;

    public Text Powertext;
  

    int HPMax;

    public Slider slider;

    bool damageflag = false;

    public float slideractive=1f;

	private AudioSource[] audios;

    // Use this for initialization
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		point = GameObject.Find("GameSystem").GetComponent<PointCont>();
        HPMax = unitHp;

        slider.maxValue = HPMax;

		audios = GetComponents<AudioSource>();
    }

	// Update is called once per frame
	void Update()
	{
		if (unitHp <= 0)
		{
			Destroy(gameObject);
			audios[0].Play();
			Powertext.enabled = false;
			if (unitCheck == false)
			{
				point.PGet(getscore);
			}
		}
        if (unitHp>HPMax) {
            unitHp = HPMax;
        }


        slider.value = unitHp;
        if (damageflag == true) {
            slideractive -= Time.deltaTime;
        }
        if (slideractive <= 0) {
            damageflag = false;
            slideractive = 1f;
            slider.gameObject.SetActive(false);
        }

        Powertext.text = unitPower.ToString();

       
    }
    public void AddDamage(int damage)
    {
        //Debug.Log("damege");
      
            slider.gameObject.SetActive(true);
            damageflag = true;
        
        unitHp -= damage;
    }
    public void AddPower(int power) {
        unitPower += power;
        Powertext.color =Color.blue;
        
    }
}
