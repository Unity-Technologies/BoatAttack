using Unity.Entities;
using UnityEngine;
using WaterSystem;

namespace Unity.Physics.Authoring
{
	// IConvertGameObjectToEntity pipeline is called before the Physics Body & Shape Conversion Systems
	// This means that there would be no Physics components created when Convert was called.
	// Instead Convert is called from this specific ConversionSystem for any component that may need
	// to read or write the various Physics components at conversion time.
	[UpdateAfter(typeof(PhysicsBodyConversionSystem))]
	[UpdateAfter(typeof(LegacyRigidbodyConversionSystem))]
	public class PhysicsConversionSystem : GameObjectConversionSystem
	{
		// Update is called once per frame
		protected override void OnUpdate()
		{
			Entities.ForEach((BuoyantObject_DOTS behaviour) => { behaviour.Convert(GetPrimaryEntity(behaviour), DstEntityManager, this); });
		}
	}
}