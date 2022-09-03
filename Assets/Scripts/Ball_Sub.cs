using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Sub : Ball_Base
{
    public override void Start()
    {
        base.Start();
        GetNewPostion();
        StartCoroutine(GetPositions());
    }

    public override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, gotoPos, 5f * Time.deltaTime);
        CheckHeight();
    }

    public override void GetNewPostion()
    {
        Vector3 setPos = Vector3.zero;
        float testDistance = float.MaxValue;
        Debug.Log(GameObject.FindGameObjectsWithTag("Main").Length);
        foreach (GameObject main in GameObject.FindGameObjectsWithTag("Main"))
        {
            float checkDist = Vector3.Distance(main.transform.position, transform.position);
            if (testDistance > checkDist && checkDist > 3f) {
                testDistance = checkDist;
                setPos = main.transform.position;
            }
        }

        gotoPos = setPos;
    }

    IEnumerator GetPositions()
    {
        yield return new WaitForSeconds(.5f);
        GetNewPostion();
        StartCoroutine(GetPositions());
    }
}
