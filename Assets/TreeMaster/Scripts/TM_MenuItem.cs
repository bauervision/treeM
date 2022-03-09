using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using TreeMasterScreenshot;

namespace TreeMaster
{
    public static class MenuItems
    {

        #region Main Menu Tools

        [MenuItem("Tools/TreeMaster/Switch Mesh", false, 30)]
        private static void ShowToolSwitchMesh() { TM_ChangeMesh.ShowWindow(); }

        [MenuItem("Tools/TreeMaster/Swap Material", false, 30)]
        private static void ShowToolSwapMaterial() { TM_SwapMaterial.ShowWindow(); }

        [MenuItem("Tools/TreeMaster/Collapse Mesh", false, 30)]
        private static void ShowToolNewOptimized() { TM_CollapseMesh.ShowWindow(); }

        [MenuItem("Tools/TreeMaster/New Prefab", false, 30)]
        private static void ShowToolNewPrefab() { TM_SavePrefab.ShowWindow(); }

        [MenuItem("Tools/TreeMaster/Renamer", false, 50)]
        private static void ShowToolRenamer() { TM_Renamer.ShowWindow(); }

        [MenuItem("Tools/TreeMaster/Screenshot", false, 50)]
        private static void ShowToolScreenshot() { TM_Screenshots.ShowWindow(); }

        #endregion

        #region Assets

        [MenuItem("GameObject/3D Object/TreeMaster/Trunk", false, 30)]
        private static void CreateStraightTrunkv1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("_trunk_01_v1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        #endregion

    }

}
#endif