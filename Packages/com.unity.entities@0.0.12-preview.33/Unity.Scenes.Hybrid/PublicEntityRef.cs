using Unity.Entities;
using UnityEditor;

namespace Unity.Scenes
{
	[InternalBufferCapacity(16)]
	struct PublicEntityRef : IBufferElementData
	{
		public int entityIndex; //TODO: Should be GUID
		public Entity targetEntity;

		public static bool operator<(PublicEntityRef a, PublicEntityRef b)
		{
			return a.entityIndex < b.entityIndex;
		}

		public static bool operator>(PublicEntityRef a, PublicEntityRef b)
		{
			return a.entityIndex > b.entityIndex;
		}

		private static unsafe int FindInsertionPoint(ref DynamicBuffer<PublicEntityRef> buffer, PublicEntityRef entityref)
		{
			int low = 0;
			int high = buffer.Length;
			while (low != high)
			{
				int mid = (low + high) / 2;
				if (entityref < buffer[mid])
					high = mid;
				else
					low = mid+1;
			}

			return low;
		}

		public static void Add(ref DynamicBuffer<PublicEntityRef> buffer, PublicEntityRef entityref)
		{
			int i = FindInsertionPoint(ref buffer, entityref);
			buffer.Insert(i, entityref);
		}
	}


	[InternalBufferCapacity(16)]
	struct ExternalEntityRef : IBufferElementData
	{
		public int entityIndex; //TODO: Should be GUID

		public static bool operator<(ExternalEntityRef a, ExternalEntityRef b)
		{
			return a.entityIndex < b.entityIndex;
		}

		public static bool operator>(ExternalEntityRef a, ExternalEntityRef b)
		{
			return a.entityIndex > b.entityIndex;
		}

		private static unsafe int FindInsertionPoint(ref DynamicBuffer<ExternalEntityRef> buffer, ExternalEntityRef entityref)
		{
			int low = 0;
			int high = buffer.Length;
			while (low != high)
			{
				int mid = (low + high) / 2;
				if (entityref < buffer[mid])
					high = mid;
				else
					low = mid+1;
			}

			return low;
		}

		public static void Add(ref DynamicBuffer<ExternalEntityRef> buffer, ExternalEntityRef entityref)
		{
			int i = FindInsertionPoint(ref buffer, entityref);
			buffer.Insert(i, entityref);
		}
	}

    struct ExternalEntityRefInfo : IComponentData
    {
        public Hash128 SceneGUID;
        public int SubSectionIndex;
        public int EntityIndexStart;
    }
}
