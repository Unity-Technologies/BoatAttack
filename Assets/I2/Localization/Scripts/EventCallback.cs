using UnityEngine;
using System;

namespace I2.Loc
{
	[Serializable]
	public class EventCallback
	{
		public MonoBehaviour Target;
		public string MethodName = string.Empty;

		public void Execute( UnityEngine.Object Sender = null )
		{
			if (HasCallback() && Application.isPlaying)
				Target.gameObject.SendMessage(MethodName, Sender, SendMessageOptions.DontRequireReceiver);
		}

		public bool HasCallback()
		{
			return Target != null && !string.IsNullOrEmpty (MethodName);
		}
	}
}