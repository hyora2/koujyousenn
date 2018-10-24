using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour {
    //public GameObject Line;
   
    int arrayi=0;
     int linepoint;
    float rx, ry;//進むべき方向
     float px , py ;// 引っ張り始めた点
    float fx, fy;//引っ張って離した点
    float sx, sy;//速度ベクトル
    float rate;
    public float speed=1;
    float rl;//進行方向ベクトルの大きさ
    float sa;//x軸のポジションの差を図る
    public float rotctl = 1;//回転具合
    Vector2 fmouseposition;//前のマウスのポジション
    Vector2 pastpoint;
    bool leftup=false;//左ボタンを離したか
    public float linespan=3f;
    Vector2 plusvec;
    
     
    LineRenderer lineRenderer;
    


    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        pastpoint = transform.position;
        plusvec = new Vector2(linespan, linespan);
        px = transform.position.x;
        py = transform.position.y;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        Vector2 fmouseposition = transform.position;


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            if (leftup == true)
            {

                Move();
                leftup = false;
            }
        }
        
      
    }
    private void OnMouseDrag()
    {

        Debug.Log("Drag");
        Vector2 currentScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 currentPisition = Camera.main.ScreenToWorldPoint(currentScreenPoint);

        if (Input.GetMouseButton(1))
        {//向きの変更
            sa = Input.mousePosition.x - fmouseposition.x;
            transform.rotation = Quaternion.Euler(0, 0, sa * rotctl);
            fmouseposition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1)){
            return;
        }
        else
        {
            leftup = true;
            double xdistance = Mathf.Abs((Input.mousePosition.x - pastpoint.x) * (Input.mousePosition.x - pastpoint.x) );
            double ydistance = Mathf.Abs( (Input.mousePosition.y - pastpoint.y) * (Input.mousePosition.y - pastpoint.y));



            Vector2 pvec = pastpoint;
            //引っ張る

            if (xdistance >= linespan&& Input.mousePosition.x < pastpoint.x) { plusvec.x = -linespan; }
            else if (xdistance >= linespan){ plusvec.x = linespan; }
            else { plusvec.x = 0; }
            if (ydistance >= linespan&& Input.mousePosition.y< pastpoint.y) { plusvec.y = -linespan; }
            else if (ydistance >= linespan) { plusvec.y = linespan; }
            else { plusvec.y = 0; }



            if (xdistance >= linespan || ydistance >= linespan)
            {
                arrayi++;
                pvec += plusvec;
                // lineRenderer.SetVertexCount(arrayi);
                lineRenderer.positionCount = arrayi;
                lineRenderer.SetPosition(arrayi-1, pvec);
                pastpoint = pvec;
            }

        }
    }

    private void Move() {
        int i;
        bool moveflag=false;
        /* float distanse; //始点から離した点まで等間隔でラインを引く//
         
         float vec;//ベクトルｘ座標
         float topdistanse;//１頂点の距離
         Vector2 vecplus =new Vector2(0,0);
         Vector2 MouseupPoint= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
         lineRenderer.SetPosition(linepoint,MouseupPoint );
         distanse = Vector2.Distance(MouseupPoint,pastpoint );
         topdistanse = distanse / linepoint;
         vec = Mathf.Sqrt((topdistanse * topdistanse) / 2);
         vecplus = new Vector2(vec, vec);//追加する距離
         for (i=1;i<=linepoint;i++) {
             lineRenderer.SetPosition(i, vecplus);
             vecplus += new Vector2(vec, vec);
         }

         pastpoint = MouseupPoint;*/

        for (i=0; i <=arrayi; i++) {
            if (moveflag== false)
            {
                px = transform.position.x; py = transform.position.y;//始点をリセット
                fx = lineRenderer.GetPosition(i).x; fy = lineRenderer.GetPosition(i).y;
                // Debug.Log("UP");
                rx = px - fx; ry = py - fy;
                rl = Mathf.Sqrt(rx * rx + ry * ry);
                //固定スピードを求める
                rate = speed / rl;
                sx = -(rx * rate); sy = -(ry * rate);
            }
            /*while(this.transform.position != lineRenderer.GetPosition(i))
            {
                moveflag = true;
                transform.position += new Vector3(sx, sy);//移動
            }*/
            moveflag = false;
                
        }
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
       
        arrayi = 0;
    }

}
    


