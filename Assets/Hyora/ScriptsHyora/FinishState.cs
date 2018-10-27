using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinishState : MonoBehaviour {

    public GameObject Font;

    public GameObject Pbase;    //Pbase:プレイヤー側の拠点
    public GameObject Ebase;    //Ebase:敵側の拠点

    private int PbaseHP;
    private int EbaseHP;

    void Start(){

        Pbase = GameObject.FindWithTag("PlayerBase");
        Ebase = GameObject.FindWithTag("EnemyBase");
  
       PbaseHP = Pbase.GetComponent<BaseStatus>().BaseHP;
       EbaseHP = Ebase.GetComponent<BaseStatus>().BaseHP;

    }

    void Update(){
        PbaseHP = Pbase.GetComponent<BaseStatus>().BaseHP;
        EbaseHP = Ebase.GetComponent<BaseStatus>().BaseHP;

        if(PbaseHP <= 0 ){
            //プレイヤー側の敗北処理
            GameEnd(1);

        }else if(EbaseHP <= 0){
            //プレイヤー側勝利
            GameEnd(0);

        }else{
            Debug.Log(PbaseHP);
            Debug.Log(EbaseHP);
        }


    }

   /// <summary>
   /// ゲームオーバー時の処理
   /// </summary>
   /// <param name="winSide">勝利チームを表す変数。0 = プレイヤー側、1 = 敵側の勝利.</param>
    public void GameEnd(int winSide){
      
        Font.SetActive(true);   //GAME SETの文字を出す。使わなければ消してください。
        wait(3.0f);

        if(winSide == 0){
            //0 : プレイヤー側が勝利したときの処理。

            SceneManager.LoadScene("");     //シーン名の記入をお願いします
            
        }else if(winSide == 1){
            //1 : 敵側が勝ち。ゲームオーバー処理。

            SceneManager.LoadScene("");     //シーン名の記入
            
        }else {
            Debug.Log("Error.");
            return;
        }


    }
	

    IEnumerator wait(float time){
        yield return new WaitForSeconds(time);
    }


}
