﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

	protected override void OnRabitHit(HeroRabit rabit) {
		rabit.beBig(true);
		this.CollectedHide();
	}

}
