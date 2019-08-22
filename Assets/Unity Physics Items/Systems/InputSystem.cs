using BoatAttack;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(DriveSystem))]
public class InputSystem : ComponentSystem
{
	InputControls controls;

	float throttle;
	float steering;

	float startTime;

	protected override void OnCreate()
	{
		startTime = Time.time + WaypointGroup.raceDelay;

		controls = new InputControls();

		controls.BoatControls.Trottle.performed += context => throttle = context.ReadValue<float>();
		controls.BoatControls.Trottle.canceled += context => throttle = 0f;

		controls.BoatControls.Steering.performed += context => steering = context.ReadValue<float>();
		controls.BoatControls.Steering.canceled += context => steering = 0f;

		controls.BoatControls.Enable();

		base.OnCreate();
	}

	protected override void OnUpdate()
	{
		//not time to start
		//if (Time.time < startTime)
			//return;

		Entities.ForEach((Entity entity, ref Translation pos, ref Rotation rot, ref DrivingData data ) =>
		{
			if (data.isHuman)
			{
				data.throttle = throttle;
				data.steering = steering;
			}
			else
			{
				AIController_DOTS.GetInputs(entity, pos.Value, rot.Value, out data.throttle, out data.steering);
			}
		});
	}
}
