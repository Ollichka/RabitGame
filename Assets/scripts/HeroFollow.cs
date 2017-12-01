﻿using UnityEngine;
using System.Collections;

public class HeroFollow : MonoBehaviour
{
	public HeroRabit rabit;

	
	// Update is called once per frame
	void Update ()
	{
		if (rabit != null) {
			Transform rabit_transform = rabit.transform;
			Transform camera_transform = this.transform;
			Vector3 rabit_position = rabit_transform.position;
			Vector3 camera_position = camera_transform.position;
			camera_position.x = rabit_position.x;
			camera_position.y = rabit_position.y;
			camera_transform.position = camera_position;
		}
	}
}

