using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName="Data")]
public class MyData : ScriptableObject {

	public string myName;
	public int hp;
	public float attackPower;
}