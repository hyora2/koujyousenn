using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject lineObj;

    private List<GameObject> lineLength;
    private List<Line> activeLine;

    [Header("何秒間描けるか"), SerializeField, Range(1, 30)]
    private float lineLimit = 5f;
    private float drawingTime;

    [Header("描き終わったらすぐに消すか")]
    public bool deleteSoon = false;

    [HideInInspector]
    public float deleteTime = 3f;

    private int indexCount;

    private bool drawing;


    private List<Vector3> mousePosList;



    void Start()
    {
        lineLength = new List<GameObject>();
        activeLine = new List<Line>();

        indexCount = -1;

        drawing = false;

        mousePosList = new List<Vector3>();
    }

    void Update()
    {
        DrawingLine();

        SetLine();
    }

    private void DrawingLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            indexCount++;
            lineLength.Add(Instantiate(lineObj));
            activeLine.Add(lineLength[indexCount].GetComponent<Line>());
        }

        if (Input.GetMouseButton(0))
        {
            LineLimit();
        }

        if (Input.GetMouseButtonUp(0))
        {
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
            else
            {
                StartCoroutine(DeleteTiming());
            }
        }
    }

    private void SetLine()
    {
        if (indexCount > -1 && activeLine[indexCount] != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosList.Add(mousePos);
            activeLine[indexCount].LineUpdate(mousePos);
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

        indexCount--;
    }

    private IEnumerator DeleteTiming()
    {
        activeLine[indexCount] = null;

        yield return new WaitForSeconds(deleteTime);

        DeleteLine(0);

        yield return null;
    }
}