using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttackMode : MonoBehaviour {

	[SerializeField] private GameObject Bullet; //発射するオブジェクト
	[SerializeField] private Transform bulletPos; //発射する場所
	[SerializeField] private float bulletSpeed; //弾の速さ

	private bool canattack; //現在攻撃モードかどうか
	private float wait; //弾を撃つ間隔
	private MagicModeChange change;
	private UnitStatus status;
	private Transform verRot; //アタッチしているオブジェクトの位置
	//private float sensitivity; //マウス感度
	private float Xrot; //マウスの横軸の移動量の取得

	// Use this for initialization
	void Start () {
		canattack = false;
		bulletSpeed = 10f;
		wait = 1.0f;
		change = gameObject.GetComponent<MagicModeChange>();
		status = GetComponent<UnitStatus>();
		verRot = GetComponent<Transform>();
		//sensitivity = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//右ドラッグでオブジェクトの向き変更
		Xrot = Input.GetAxis("Mouse X");
		if (Input.GetMouseButton(1))
        {
            verRot.Rotate(0, 0, 5f * Xrot);
        }      
	}

	private void FixedUpdate()
	{
		if (change.attacking == false)
		{
			canattack = false;
		}

		if (canattack == true)
		{
			canattack = false;
			StartCoroutine("Fire");
		}
	}

	public void Attack ()
	{
		canattack = true;
	}

	IEnumerator Fire ()
	{
		//弾発射
		GameObject Bullets = Instantiate(Bullet, bulletPos) as GameObject;
		if (status.unitCheck == false)
        {
            Bullets.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed;
        }
        else
        {
            Bullets.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletSpeed;
        }

		yield return new WaitForSeconds(wait);

		canattack = true;
	}
}
