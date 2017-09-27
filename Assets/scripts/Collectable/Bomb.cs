using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

	protected override void OnRabitHit(HeroRabit rabit) {
		if (!rabit.beBig (false)) rabit.die(this.transform);
		this.CollectedHide();
	}

}
