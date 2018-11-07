using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;


    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }

    //他オブジェクトと接触した瞬間に呼ばれるメソッド
    void OnTriggerEnter(Collider other)
    {

    }

    //他オブジェクトと触れている間に呼ばれるメソッド
    private void OnTriggerStay(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

        Vector3 Apos = objA.transform.position;
        Vector3 Bpos = objB.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);

        Color c = objB.GetComponent<Renderer>().material.color;
        Color color = new Color(c.r, c.b, c.g, dis / 100);
        objB.GetComponent<Renderer>().material.color = color;
        Debug.Log("dis/100 : " + dis / 100);
    }

    //接触した他オブジェクトから離れた瞬間に呼ばれるメソッド
    private void OnTriggerExit(Collider other)
    {

    }

}