﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : Orc {

	public float myspeed = 1;

	public GameObject prefabCarrot;
	public float carrot_radius = 5.0f;
	float last_carrot = 0;
	public float carrotIntervalSeconds = 5.0f;

	// Use this for initialization
	void Start () {
		base.Start ();
		speed = myspeed;
	}

	void launchCarrot(float direction) {
		if (Time.time - last_carrot > carrotIntervalSeconds) {
			last_carrot = Time.time;
			animator.SetTrigger ("attack");

			GameObject obj = GameObject.Instantiate(this.prefabCarrot);
			Vector3 carrot_pos = this.transform.position;
			carrot_pos.y += 1;
			obj.transform.position = carrot_pos;

			Carrot carrot = obj.GetComponent<Carrot>();
			carrot.launch(direction);

		}
	}

	protected override void checkSetAttackMode () {
		if (isRabitAttack ())
			mode = Mode.Attack;
		else if (sr.flipX)
			mode = Mode.GoToB;
		else
			mode = Mode.GoToA;
	}

	protected override bool isRabitAttack() {
		Vector3 rabbit_pos = HeroRabit.lastRabit.transform.position;
		Vector3 my_pos = this.transform.position;

		return Mathf.Abs(rabbit_pos.x - my_pos.x) < carrot_radius;
	}

	public override void move () {
		if (mode == Mode.Attack) {
			speed = 0;
		} else {
			speed = myspeed;
		}
		base.move ();
	}

	protected override void OnRabitHit(HeroRabit rabit) {
		Debug.Log ("hit");
		Vector3 rabit_pos = rabit.transform.position;
		Vector3 my_pos = this.transform.position;
		if (mode == Mode.Attack ) {
			launchCarrot (rabit_pos.x - my_pos.x);

			if (isRabitClose ()&&Mathf.Abs(rabit_pos.y-my_pos.y)  >1f) {
					mode = Mode.Die;
					StartCoroutine (die ());
				} else {
				speed = myspeed;
				}
			}

	}


}
