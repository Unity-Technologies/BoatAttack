using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class DOTSTransformManager : MonoBehaviour
{
	static DOTSTransformManager main;

	Dictionary<Entity, Transform> objects = new Dictionary<Entity, Transform>();
	

	private void Awake()
	{
		if (main != null && main != this)
		{
			Destroy(this);
			return;
		}

		main = this;
	}

	public static void Register(Entity entity, Transform objTransform)
	{
		if (main == null || main.objects.ContainsKey(entity))
			return;

		main.objects.Add(entity, objTransform);
	}

	public static Transform GetTransform(Entity entity)
	{
		Transform t = null;
		main.objects.TryGetValue(entity, out t);

		return t;
	}

	//private void Update()
	//{
	//	var manager = World.Active.EntityManager;
	//	foreach (var item in objects)
	//	{
	//		var pos = manager.GetComponentData<Translation>(item.Key);
	//		var rot = manager.GetComponentData<Rotation>(item.Key);

	//		item.Value.SetPositionAndRotation(pos.Value, rot.Value);
	//	}
	//}
}
