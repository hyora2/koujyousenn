using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove_sin : MonoBehaviour {
    public GameObject lineObj;

    private List<GameObject> lineLength;
    private List<Line> activeLine;

    [Header("何秒間描けるか"), SerializeField, Range(1, 30)]
    private float lineLimit = 10f;
    private float drawingTime;

    [Header("描き終わったらすぐに消すか")]
    public bool deleteSoon = false;


    [Header("Line is straight?")]
    public bool linestraight;

    [HideInInspector]
    public float deleteTime = 30f;
    float linelifetime = 0f;

    private int indexCount;

    private bool drawing;

    

    bool leftup = false;//左ボタンを離したか

    Vector2 fmouseposition;//前のマウスのポジション

    public GameObject unit;

    bool delete;

    bool moving;
    bool goal = true;

    int listcount=0;

    bool touchcollider = false;

    private List<Vector3> mousePosList;

    float sa;//x軸のポジションの差を図る

    [Header("回転具合")]
    public float rotctl = 1;//回転具合

    /*float fps;//1秒当たりのフレーム数
    float speedtime;
    float flamecount=0;
    float setflame;*/

    float timemove;
    //public float standardspeed = 0.1f;

    [Header("点同士の距離分割割合")]
    public float linespan=0.1f;

    [Header("speed_range:大きすぎずに")]
    public float speed = 5;

    float deftimemove;



    void Start()
    {
        lineLength = new List<GameObject>();
        activeLine = new List<Line>();

        indexCount = -1;

        drawing = false;

        mousePosList = new List<Vector3>();

        fmouseposition = transform.position;
        moving = false;

        linelifetime = deleteTime;

        /* fps = 1f / Time.deltaTime;
         speedtime = speed * fps;

         flamecount = speedtime;*/

        //deftimemove= speed * standardspeed;

        timemove = deftimemove;


    }

    void Update()
    {
      Debug.Log("index=" + indexCount);

        if (moving == false)
        {
            pivot();
            if (goal==true) {
                DrawingLine();
                //SetLine();
            }
        }
        else { linelifetime -= Time.deltaTime;
           // timemove -= Time.deltaTime;
            //flamecount -= 1f / Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (leftup == true)
            {

               
                leftup = false;
                
            }
        }
        Move();
        
        if(listcount==mousePosList.Count||delete==true){
            goal = true;
            moving = false;
            if (indexCount >= 0)
            {
                
                DeleteLine(indexCount);
                
            }
            mousePosList = new List<Vector3>();
            listcount = 0;
            delete = false;
            
        }

    }
    private void pivot() {
      
        if (Input.GetMouseButtonDown(1)) {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d) {
                touchcollider = true;

            }
        }
        if (Input.GetMouseButton(1))
        {//向きの変更

            if (touchcollider == true)
            {
                sa = Input.mousePosition.x - transform.position.x;//fmouseposition.x;
                unit.transform.rotation = Quaternion.Euler(0, 0, sa * rotctl);
                // fmouseposition = Input.mousePosition;
            }
            
        }
         if (Input.GetMouseButtonUp(1))
        {
            touchcollider = false;
            return;
        }

    }

    private void DrawingLine()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d)
            {
                indexCount++;
                lineLength.Add(Instantiate(lineObj));
                activeLine.Add(lineLength[indexCount].GetComponent<Line>());

                GameObject obj = aCollider2d.transform.gameObject;
                //Debug.Log(obj.name);
            }
            
        }
       
        if (Input.GetMouseButton(0))
        {
            SetLine();//
            LineLimit();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (indexCount > -1 && activeLine[indexCount] != null&&linestraight == true) {
                //直線移動の場合
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float a = (mousePos.y - unit.transform.position.y) / (mousePos.x - unit.transform.position.x);//傾き


                Vector2 direction;
                direction.x = 0.01f * (mousePos.x - unit.transform.position.x);
                direction.y = 0.01f* (mousePos.y - unit.transform.position.y);
                Vector3 p = mousePos;
                for (int i=0; i< 100; i++)
                {   
                    mousePosList.Add(p);
                    activeLine[indexCount].LineUpdate(p);
                    p += new Vector3(direction.x, direction.y);
                }

            }
            drawingTime = 0;

            if (drawing)
            {
                drawing = false;

                return;
            }

            if (deleteSoon)
            {
                DeleteLine(indexCount);
            }
            else if (linelifetime <= 0)
            {
                linelifetime = deleteTime;
                // StartCoroutine(DeleteTiming());
                activeLine[indexCount] = null;
                DeleteLine(0);
                mousePosList = new List<Vector3>();

            }
            else {  }
            goal = false;
            moving = true;
        }
       
    }

    private void SetLine()
    {
        if (indexCount > -1 && activeLine[indexCount] != null && linestraight == false)
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosList.Add(mousePos);
            activeLine[indexCount].LineUpdate(mousePos);
            //Debug.Log(mousePosList.Count);
        }
        else if (indexCount > -1 && activeLine[indexCount] != null && linestraight == true) {
            //ラインが直線でないとき
           /* Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (activeLine[indexCount].lr.positionCount == 0){
                activeLine[indexCount].lr.SetPosition(0, unit.transform.position);
                activeLine[indexCount].lr.positionCount = 1;
            }*/
            
            //activeLine[indexCount].lr.SetPosition(1, Input.mousePosition);


            /*  activeLine[indexCount].LineUpdate(mousePos);
              mousePosList.Add(mousePos);

              float a=(mousePos.y-unit.transform.position.y)/(mousePos.x-unit.transform.position.x);//傾き

              for ( int i = 0; i < mousePosList.Count; i++) {
                  Vector3 pos= mousePosList[i];
                  pos.x = mousePosList[i].y / a;//中継が必要
                  mousePosList[i] = pos;
                  activeLine[indexCount].lr.SetPosition(i, mousePosList[i]);
              }*/
        }
    }

    private void LineLimit()
    {
        drawingTime += Time.deltaTime;

        if (drawingTime > lineLimit)
        {
            drawingTime = 0;

            drawing = true;

            DeleteLine(indexCount);
        }
    }

    private void DeleteLine(int index)
    {
        
        Destroy(activeLine[index]);
        activeLine.RemoveAt(index);

        Destroy(lineLength[index]);
        lineLength.RemoveAt(index);

        delete = true;

       

        indexCount--;

       
    }

    private IEnumerator DeleteTiming()
    {
        activeLine[indexCount] = null;

        yield return new WaitForSeconds(deleteTime);

        DeleteLine(0);

        yield return null;
    }
    private void Move() {
        if (listcount != mousePosList.Count && goal == false)
        {

            //Debug.Log(mousePosList[listcount]);

            /* unit.transform.position = mousePosList[listcount];
             listcount++;
             timemove = deftimemove; */
            if (Mathf.Abs(mousePosList[listcount].x - unit.transform.position.x) >= 0.01 && Mathf.Abs(mousePosList[listcount].y - unit.transform.position.y) >= 0.01)
            {

                //float localdirection;
                //localdirection = Vector2.Distance(unit.transform.position, mousePosList[listcount]);


                Vector2 direction;
                direction.x = linespan * (mousePosList[listcount].x - unit.transform.position.x);
                direction.y = linespan * (mousePosList[listcount].y - unit.transform.position.y);
                // Debug.Log("directionx=" + direction.x+"directiony=" + direction.y);
                // Debug.Log("mousepos=" + mousePosList[listcount]);

                /* Vector2 direction2;
                 direction2.x = (mousePosList[listcount].x - unit.transform.position.x);
                 direction2.y =  (mousePosList[listcount].y - unit.transform.position.y);
                 unit.GetComponent<Rigidbody2D>().velocity = direction2 * speed;*/


                unit.transform.position += new Vector3(direction.x * speed, direction.y * speed);

            }
            else
            {

                listcount++;
                // Debug.Log("listcount=" + listcount+"mouscount="+mousePosList.Count);
            }

        }

    }
    
}
