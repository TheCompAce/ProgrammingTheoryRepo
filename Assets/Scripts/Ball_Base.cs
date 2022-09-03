using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Base : MonoBehaviour
{
    public Vector3 gotoPos;
    // Start is called before the first frame update
    public virtual void Start()
    {
        GetNewPostion();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, gotoPos, 5f * Time.deltaTime);

        if (Vector3.Distance(transform.position, gotoPos) < 1.5)
        {
            GetNewPostion();
        }

        CheckHeight();
    }

    public virtual void GetNewPostion()
    {
        gotoPos = new Vector3(Random.Range(-6f, 6f), .5f, Random.Range(-6f, 6f));
    }

    public void CheckHeight()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
