using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SavingSystem
{
    public class EntityDataAssetPostprocessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
        {
            // Get rid of all movedFromAssetPaths from importedAssets to prevent moved entity data from regenerating id.
            string[] createdAssets = importedAssets.Except(movedAssets).ToArray();

            foreach (var assetPath in createdAssets) 
            {
                // Check if the asset is entity data.
                ScriptableObject scriptableObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
                if (!scriptableObject || scriptableObject is not IEntityDataSo entityDataScriptableObject)
                    continue;

                // Generate ID for the created entity data.
                entityDataScriptableObject.GetEntityData().GenerateGuid();
                EditorUtility.SetDirty(scriptableObject);
            }
        }
    }
}
