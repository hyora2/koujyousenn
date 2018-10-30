using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * このスクリプトをGameSystemオブジェクトにつけてください。
 * ポイント取得は、ユニットが破壊される時と拠点をとった時の処理の前にここのPGet関数に飛ばしてください。
 * 使用時は、使用する処理の場所にPUse関数を使ってください。
 * ポイントの取得、使用時の変動値はテストプレイしつつ決めてください。
 * 
 * 
*/
public class PointCont : MonoBehaviour {

    public int Point;   //強化に使うポイント。privateに変更予定

    public Text Ptext;  //ポイントを表示するテキスト

	// Use this for initialization
	void Start () {

        Point = 0;      //ポイント初期化
        
		
	}

    void Update()
    {
        //デバッグ用アップデート関数。消してください
        Ptext.text = Point.ToString();
    }



    public void PGet(int p){
        Point += p;
        Ptext.text = Point.ToString();

    }

    public void PUse(int p){
        if(Point <= 0){
            Debug.Log("Don't have point.");
            return;
        }

        Point -= p;
        Ptext.text = Point.ToString();
    }



}
