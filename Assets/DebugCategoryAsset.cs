using UnityEngine;
using System.Collections;
namespace CustomDebugger
{
	[CreateAssetMenu(fileName = "Debug Categories", menuName = "Debugging/Custom Category Asset")]
	public class DebugCategoryAsset : ScriptableObject
	{
		public DebugCategory[] debugCategories;
	}
}
