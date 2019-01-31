using UnityEngine;

namespace CustomDebugger
{
	[System.Serializable]
	public class DebugCategory
	{
		public string categoryName;

		[HideInInspector]
		public bool categoryActive;
	}
}