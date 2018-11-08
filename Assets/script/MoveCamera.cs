using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCamera : MonoBehaviour
{
    public GameObject objA;
    public Material opaqueMat;
    public Material transparentMat;
    private List<Renderer> rendarerList;


    void getRenderer( Transform t){
        Renderer r = t.gameObject.GetComponent<Renderer>();
        if (r != null)
        {
            rendarerList.Add(r);
        }

        for (int i = 0; i < t.childCount; i ++ ){
            Transform tt = t.GetChild(i);
            getRenderer(tt);
        }

    }

    private void Start()
    {
        // 子供のノードのレンダラーを取得
        rendarerList = new List<Renderer>();
        getRenderer(gameObject.transform);

    }


    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }

  
    //他オブジェクトと触れている間に呼ばれるメソッド
    /*
    private void OnTriggerStay(Collider other)
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        Vector3 Apos = objA.transform.position;
        Vector3 Bpos = gameObject.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);

        for (int i = 0; i < rendarerList.Count; i ++){
            //Renderer r = rendarerList[i];
            //Color c = r.material.color;
            //Color color = new Color(c.r, c.b, c.g, dis / 100);
            //r.material.color = color;
            //Debug.Log("dis/100 : " + dis / 100);

            Renderer r = rendarerList[i];
            Color c = r.material.color;
            Color color = new Color(c.r, c.b, c.g, 128);
            r.material.color = color;

        }
    }
    */

    //接触した他オブジェクトから離れた瞬間に呼ばれるメソッド
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < rendarerList.Count; i++)
        {
            Renderer r = rendarerList[i];
            r.material = opaqueMat;
        }
    }

    //接触した他オブジェクトから離れた瞬間に呼ばれるメソッド
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < rendarerList.Count; i++)
        {
            Renderer r = rendarerList[i];
            r.material = transparentMat;
        }
    }


}