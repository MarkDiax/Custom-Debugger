using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomDebugger
{
	public class DebugWindow : EditorWindow
	{
		public DebugCategoryAsset debugCategoryAsset;

		public bool showLogs, showWarnings, showErrors;

		[SerializeField]
		private bool _categoryFoldout;

		[MenuItem("Window/Debugger")]
		static void OpenWindow()
		{
			DebugWindow window = (DebugWindow)GetWindow(typeof(DebugWindow));
			window.minSize = new Vector2(75, 100);
			window.Show();
		}

		private void OnEnable()
		{

		}

		private void OnGUI()
		{
			debugCategoryAsset = (DebugCategoryAsset)EditorGUILayout.ObjectField(debugCategoryAsset, typeof(DebugCategoryAsset), false);

			showLogs = EditorGUILayout.Toggle("Debug Logs", showLogs);
			showWarnings = EditorGUILayout.Toggle("Debug Warnings", showWarnings);
			showErrors = EditorGUILayout.Toggle("Debug Errors", showErrors);

			if (debugCategoryAsset != null)
			{
				GUILayout.Space(10f);

				_categoryFoldout = EditorGUILayout.Foldout(_categoryFoldout, "Categories");
				if (_categoryFoldout)
				{
					if (debugCategoryAsset.debugCategories.Length > 0)
					{
						int emptyCount = 0;
						for (int i = 0; i < debugCategoryAsset.debugCategories.Length; i++)
						{
							DebugCategory category = debugCategoryAsset.debugCategories[i];

							if (!string.IsNullOrEmpty(category.categoryName) && !string.IsNullOrWhiteSpace(category.categoryName))
								category.categoryActive = EditorGUILayout.Toggle(category.categoryName, category.categoryActive);
							else
								emptyCount++;
						}

						if (debugCategoryAsset.debugCategories.Length == emptyCount)
							EmptyDebugCategoryLabel();
					}
					else
					{
						EmptyDebugCategoryLabel();
					}
				}
			}

			void EmptyDebugCategoryLabel()
			{
				GUILayout.Label("Debug Categories or its names are not specified.");

			}
		}
	}
}