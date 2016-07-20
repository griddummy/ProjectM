using UnityEngine;
using System.Collections;

public class BossAiMannager : MonoBehaviour {

	public int FatternNumber;
	public GameObject boss;
	public GameObject Player;

	public int test;

	float PlaBosDis;


	public enum BossDistance {dis1, dis2, dis3}
	public BossDistance DisDis;
	/*
	public bool BossDistance1 = false;
	public bool BossDistance2 = false;
	public bool BossDistance3 = false;
*/

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		boss = this.gameObject;
		Player = GameObject.FindGameObjectWithTag ("Player");

	}
	void Acttion01(){
		;
	}

	/*
	IEnumerator BossDistanceCHeack()
	{
		if (DisDis == BossDistance.dis1) {
			while (true) {
				
			}
		}
	}*/

	void DistanceCheack(){

		if (PlaBosDis < 7) {
			DisDis = BossDistance.dis1;
			test = Random.Range (0, 3);
		} else if ((PlaBosDis >= 7) && (PlaBosDis < 15)) {
			DisDis = BossDistance.dis2;
			test = Random.Range (3, 7);
		} else if (PlaBosDis >= 15){
			DisDis = BossDistance.dis3;
			test = Random.Range (7, 10);
		}
	}
	/*
	void DistanceCheack(){
		if (PlaBosDis < 10) {
			BossDistance1 = true;
			BossDistance2 = false;
			BossDistance3 = false;
		} else if ((PlaBosDis >= 10) && (PlaBosDis < 25)) {
			BossDistance1 = false;
			BossDistance2 = true;
			BossDistance3 = false;
		} else if (PlaBosDis >= 25){
			BossDistance1 = false;
			BossDistance2 = false;
			BossDistance3 = true;
		}
	}*/

	
	// Update is called once per frame
	void Update () {
		PlaBosDis = Vector3.Distance (transform.position, Player.transform.position);
		DistanceCheack ();


	}
}
