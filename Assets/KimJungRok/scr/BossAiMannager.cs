using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossAiMannager : MonoBehaviour
{

	public List<MonsterPatternInfo> listPattern;
	public GameObject boss;
	public GameObject Player;

	NavMeshAgent agent;

	public float waitingtime;


	public int Dosomething = 3;

	float PlaBosDis;

	Vector3 Dir;

	public bool PlayerLook = false;
	public bool PlayerChasing = false;

	bool Running = false;
	bool onGroggy;
	float groggyTime;


	public enum BossDistance
	{
dis1,
		dis2,
		dis3

	}

	public BossDistance DisDis;
	/*
	public bool BossDistance1 = false;
	public bool BossDistance2 = false;
	public bool BossDistance3 = false;
*/

	Animator animator;
	//Animation animation;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

		boss = this.gameObject;
		Player = GameObject.FindGameObjectWithTag ("Player");

		StartCoroutine (BossPatternState (1f));
		onGroggy = false;
		groggyTime = 0.0f;

	}

	IEnumerator BossPatternState (float RegTime)
	{
		if (Dosomething == 0)
		{ // 플레이어를향해다가오며근접공격2회
			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (3f);
			PlayerChasing = false;
			PlayerLook = false;

			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsAttack01"); // 빠르게두번휘두름
			yield return new WaitForSeconds (0.2f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			yield return new WaitForSeconds (0.35f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			//animator.SetTrigger ("Idle");


			/*if (PlaBosDis < 5) {					
					break;
				}

			yield return new WaitForSeconds(waitingtime);
			*/
		}
		else if (Dosomething == 1)
		{
			
			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (3f);
			PlayerChasing = false;
			PlayerLook = false;

			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsAttack01"); // 빠르게두번휘두름
			yield return new WaitForSeconds (0.2f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			yield return new WaitForSeconds (0.35f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;


		}
		else if (Dosomething == 2)
		{
			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (3f);
			PlayerChasing = false;
			PlayerLook = false;

			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsJump"); // 빠르게두번휘두름
			yield return new WaitForSeconds (0.2f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			yield return new WaitForSeconds (0.35f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;
		}
		else if (Dosomething == 3)
		{  // 물러났다가 플레이어를 향해 돌격, 벽에 충돌시 그로기

			animator.SetBool ("Run", true);
			Running = true;

			agent.SetDestination (Player.transform.position - transform.position);
			yield return new WaitForSeconds (10f);
			Debug.Log ("RUN");


		}
		else if (Dosomething == 4)
		{
		}
		else if (Dosomething == 5)
		{
		}
		else if (Dosomething == 6)
		{
		}
		else if (Dosomething == 7)
		{
		}
		else if (Dosomething == 8)
		{
		}
		else if (Dosomething == 9)
		{
		}
		yield return new WaitForSeconds (1f);
		StartCoroutine (BossPatternState (1f));
	}


	/*
	IEnumerator BossDistanceCHeack()
	{
		if (DisDis == BossDistance.dis1) {
			while (true) {
				
			}
		}
	}*/

	void DistanceCheack ()
	{

		if (PlaBosDis < 15)
		{
			DisDis = BossDistance.dis1;
			Dosomething = Random.Range (0, 4);



		}
		else if ((PlaBosDis >= 15) && (PlaBosDis < 25))
		{
			DisDis = BossDistance.dis2;
			Dosomething = Random.Range (3, 7);


		}
		else if (PlaBosDis >= 25)
		{
			DisDis = BossDistance.dis3;
			Dosomething = Random.Range (7, 10);
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
	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == ("Wall"))
		{
			if (Running == true)
			{

				animator.Stop ();
				animator.SetFloat ("Grogy", 10f - Time.deltaTime); // 초당 1씩 감소시켜 10초후 그로기가 종료되게
				Running = false;
				onGroggy = true;
			}


		}
	}

	
	// Update is called once per frame
	void Update ()
	{
		PlaBosDis = Vector3.Distance (transform.position, Player.transform.position);
		DistanceCheack ();

		if (onGroggy)
		{
			//use groggy animation
			animator.SetFloat ("Grogy", 10f);
			groggyTime += Time.deltaTime;
			if (groggyTime >= 7f)
			{
				onGroggy = false;
			}

		}
		else if (PlayerChasing == true)
		{
			if (PlaBosDis > 5)
			{
				animator.SetBool ("IsWalk", true);
				//transform.position = Vector3.Lerp (transform.position, Player.transform.position, Time.deltaTime);
				agent.SetDestination (Player.transform.position);
				agent.Resume ();

			}
			else if (PlaBosDis <= 10)
			{
				agent.Stop ();
				animator.SetBool ("IsWalk", false);
			}
		}

		if (PlayerLook == true)
		{
			Vector3 vecLookPos = Player.transform.position;
			vecLookPos.y = transform.position.y;
			transform.LookAt (vecLookPos);

		}
		else if (PlayerLook == false)
		{

		}


			



	}
}
