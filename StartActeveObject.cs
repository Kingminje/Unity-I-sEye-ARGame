using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActeveObject : MonoBehaviour
{
    //public Vector3 currentScale;

    //public Vector3 saveScale;

    //public float _time = 0f;

    private void Awake()
    {
        //saveScale = transform.localScale;
        //currentScale = transform.localScale;
    }

    private void Start()
    {
        //StartCoroutine(StartScaleUp());
        //transform.lossyScale

        //transform.localScale = new Vector3(2f, 2f, 2f);

        //for (int i = 0; i < 10; i++)
        //{
        //    if (transform.GetChild(i) != null)
        //    {
        //        transform.GetChild(i).transform.localScale = new Vector3(1f, 1f, 1f);
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
    }

    //public IEnumerator StartScaleUp()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        //if (_time >= 1f)
    //        //{
    //        //    StopAllCoroutines();
    //        //    Debug.Log("다뒤져라");
    //        //}
    //        yield return new WaitForSeconds(0.01f);

    //        _time += 0.1f;

    //        transform.localScale += new Vector3(0.001f, 0.001f, 0.05f);

    //        StartCoroutine("StartScaleDown", 0.5f);
    //    }
    //}

    //public IEnumerator StartScaleDown()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        if (_time >= 2f)
    //        {
    //            transform.localScale = saveScale;
    //            StopAllCoroutines();
    //            Debug.Log("다뒤져라");
    //        }
    //        yield return new WaitForSeconds(0.01f);

    //        _time += 0.1f;

    //        transform.localScale -= new Vector3(0.001f, 0.001f, 0.05f);
    //    }
    //}
}