using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : Orc {

	public float myspeed = 1;


	// Use this for initialization
	void Start () {
		base.Start ();
		speed = myspeed;
	}

	protected override void checkSetAttackMode () {
		 base.checkSetAttackMode ();
	}

	protected override bool isRabitAttack() {
		float rabit_x = HeroRabit.lastRabit.transform.position.x;
		return rabit_x >= pointA.x && rabit_x <= pointB.x;
	}

	protected override void attack() {
		if (mode == Mode.Attack ) {
			animator.SetBool ("walk", true);

			if (isRabitClose ()) {
				StartCoroutine (hitRabbit ());
				if (isRabitWin ()) {
					mode = Mode.Die;
					StartCoroutine (die ());
				} else {
					StartCoroutine (killRabbit ());
				}
			}

		} else {
			animator.SetBool ("walk", true);
			animator.SetBool ("attack", false);
		}
	}

	IEnumerator killRabbit() {
		yield return new WaitForSeconds(0.5f);
			HeroRabit rabit = HeroRabit.lastRabit;
		if (rabit.isBigRabit()) {
				rabit.beBig (false);
			} else {
				HeroRabit.lastRabit.die (this.transform);
			}
			if (sr.flipX) mode = Mode.GoToA;
			else mode = Mode.GoToB;
	}

	IEnumerator hitRabbit() { 
		animator.SetBool ("attack", true);
		animator.SetBool ("walk", true);
		yield return new WaitForSeconds(1f);
	}

}
