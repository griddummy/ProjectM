using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossAiMannager : MonoBehaviour
{

	//public List<MonsterPatternInfo> listPattern;
	public GameObject boss;
	public GameObject Player;

	public GameObject Muzzle01_Weapon1;
	public GameObject Muzzle02_Weapon2;
	public GameObject Muzzle03_Mouth;

	public GameObject Bullet_Sword;
	//public GameObject Bullet_Fire;
	public GameObject Bullet_Laser;

	NavMeshAgent agent;
	Rigidbody Rig;

	public float waitingtime;


	public int Dosomething;

	float PlaBosDis;

	Vector3 Dir;

	public bool PlayerLook = false;
	public bool PlayerChasing = false;

	bool Running = false;
	//bool onGroggy;
	//float groggyTime;

	public float Speed;

	bool BackJump;
	/*
	Vector3 toTarget;
	Vector3 PrevPos;
	float ratio;
	float deltaRatio;*/
	/*
	enum State
	{
		Idle,
		Run
	}*/
	//State currentState = State.Idle;
	/*
	public void MoveTo(Vector3 _target)
	{
		//currentState = State.Run;
		ratio = 0;
		PrevPos = transform.position;
		toTarget = _target - PrevPos;

	}*/



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
		Rig = GetComponent<Rigidbody> ();

		boss = this.gameObject;
		Player = GameObject.FindGameObjectWithTag ("Player");

		StartCoroutine (BossPatternState (1f));
		BackJump = false;
		//onGroggy = false;
		//groggyTime = 0.0f;

	}

	IEnumerator BossPatternState (float RegTime)
	{

		if (Dosomething == 0)
		{ // 플레이어를향해다가오며근접공격2회
			//Debug.Log ("0");
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
			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 1)
		{
			//Debug.Log ("1");
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

			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 2)
		{

			//Debug.Log ("2");


			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (3f);
			PlayerChasing = false;
			//PlayerLook = false;

			Dir = Player.transform.position - transform.position;


			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsJump"); // 후퇴하며점프
			yield return new WaitForSeconds (0.2f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			BackJump = true;
			//transform.position = Vector3.Lerp(transform.position, transform.position - (Vector3.forward) * 3f, 3f);// * Time.deltaTime), 1f);

			yield return new WaitForSeconds (0.6f);
			BackJump = false;
			Instantiate (Bullet_Sword, Muzzle01_Weapon1.transform.position, Muzzle01_Weapon1.transform.rotation);
			yield return new WaitForSeconds (0.3f);
			Instantiate (Bullet_Sword, Muzzle02_Weapon2.transform.position, Muzzle02_Weapon2.transform.rotation);

			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;
			PlayerLook = false;

			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 3)
		{  /*
			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (2f);
			PlayerChasing = false;
			PlayerLook = false;
			Rig.constraints = RigidbodyConstraints.FreezeRotationY;
			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsLaser"); 
			yield return new WaitForSeconds (1f);

			yield return new WaitForSeconds (0.5f);
			Instantiate (Bullet_Laser, Muzzle03_Mouth.transform.position, Muzzle03_Mouth.transform.rotation);
			yield return new WaitForSeconds (10f);
			animator.speed = 1f;
			Rig.constraints = RigidbodyConstraints.None;
*/
			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 4)
		{
			//Debug.Log ("4");

			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (2f);
			PlayerChasing = false;
			PlayerLook = false;

			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsCombo01"); // 빠르게두번휘두름
			yield return new WaitForSeconds (0.2f);
			animator.speed = 0.1f;
			yield return new WaitForSeconds (0.5f);
			animator.speed = 1f;

			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 5) //레이저
		{
			//Debug.Log ("5");
			PlayerLook = true;
			PlayerChasing = true;
			yield return new WaitForSeconds (2f);
			PlayerChasing = false;
			PlayerLook = false;
			Rig.constraints = RigidbodyConstraints.FreezeRotationY;
			yield return new WaitForSeconds (0.5f);
			animator.SetTrigger ("IsLaser"); 
			yield return new WaitForSeconds (1f);

			animator.speed = 0.15f;
			yield return new WaitForSeconds (2f);
			Instantiate (Bullet_Laser, Muzzle03_Mouth.transform.position, Muzzle03_Mouth.transform.rotation);
			yield return new WaitForSeconds (10f);
			animator.speed = 1f;
			Rig.constraints = RigidbodyConstraints.None;

			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 6)
		{
			//Debug.Log ("6");
			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 7)
		{
			//Debug.Log ("7");
			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		else if (Dosomething == 8)
		{
			//Debug.Log ("8");
			// 물러났다가 플레이어를 향해 돌격, 벽에 충돌시 그로기

			PlayerLook = true;
			PlayerChasing = false;
			//animator.speed = 0.5f;
			animator.SetTrigger ("IsRunWait");
			yield return new WaitForSeconds (2f);

			Dir = Player.transform.position - transform.position;

			//transform.position = Vector3.Lerp (transform.position, Dir, 5f);
			// * Time.deltaTime), 3f);

			Rig.constraints = RigidbodyConstraints.FreezeRotationY;
			yield return new WaitForSeconds (3f);
			Running = true;
			PlayerLook = false;
			animator.speed = 1f;
			animator.SetBool ("IsRun", true);


			//currentState = State.Run;


		}
		else if (Dosomething == 9)
		{
			//Debug.Log ("9");
			yield return new WaitForSeconds (3f);
			StartCoroutine (BossPatternState (0.3f));
		}
		//yield return new WaitForSeconds (0.3f);
		//StartCoroutine (BossPatternState (0.3f));
	}

	void DistanceCheack ()
	{
		if (PlaBosDis < 15)
		{
			DisDis = BossDistance.dis1;
			Dosomething = (Random.Range (0, 6)); // 0,1,2,3,4,5

		}
		else if ((PlaBosDis >= 15) && (PlaBosDis < 25))
		{
			DisDis = BossDistance.dis2;
			Dosomething = Random.Range (4, 8); // 4,5,6,7

		}
		else if (PlaBosDis >= 25)
		{
			DisDis = BossDistance.dis3;
			Dosomething = Random.Range (8, 10); // 8,9
		}
	}

	IEnumerator BossRePatten(){
		yield return new WaitForSeconds (4.2f);
		//Debug.Log ("return");
		StartCoroutine (BossPatternState (0.3f));
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == ("Wall"))
		{
			if (Running == true)
			{
				//Debug.Log ("EnterWall");
				agent.Stop ();
				animator.SetBool ("IsRun", false);
				animator.SetTrigger ("IsGroggy"); // 초당 1씩 감소시켜 10초후 그로기가 종료되게
				Running = false;
				Rig.constraints = RigidbodyConstraints.None;

				//agent.speed = 3.5f;
				//agent.angularSpeed = 120;
				//agent.acceleration = 8;

				//onGroggy = true;
				StartCoroutine (BossRePatten ());

			}
			else
			{
				//Debug.Log ("EnterWall");
			}

		}
		else if (col.gameObject.tag == ("Player"))
		{
			//Debug.Log ("EnterPlayer");
			//player hp -=;
		}
	}

	void Run(){
		//Dir = Play		er.transform.position - transform.position;
	}

	
	// Update is called once per frame
	void Update ()
	{
		PlaBosDis = Vector3.Distance (transform.position, Player.transform.position);
		DistanceCheack ();

		if (Running == true)
		{
			//Debug.Log ("running");
			agent.Stop ();
			transform.Translate(Vector3.forward * Time.deltaTime * 1f);

			//transform.position = transform.position + Dir * Time.deltaTime * 0.5f;
			//transform.position = transform.position + Vector3.forward;
		}else if (BackJump == true)
		{
			//Run ();
			//Debug.Log ("backJump");
			agent.Stop ();

			transform.Translate (Vector3.forward * Time.deltaTime * -7f);
		}
		else if (PlayerChasing == true)
		{
			//Debug.Log ("chasing");
			if (PlaBosDis > 7)
			{
				animator.SetBool ("IsWalk", true);
				//transform.position = Vector3.Lerp (transform.position, Player.transform.position, Time.deltaTime);
				agent.SetDestination (Player.transform.position);
				agent.Resume ();

			}
			else if (PlaBosDis <= 7)
			{
				agent.Stop ();
				animator.SetBool ("IsWalk", false);
			}
		}
			else if (PlayerChasing == false)
		{
			animator.SetBool ("IsWalk", false);
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
