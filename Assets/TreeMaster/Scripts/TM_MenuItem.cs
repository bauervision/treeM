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

        [MenuItem("GameObject/3D Object/TreeMaster/Add Controller", false, 10)]
        private static void CreateController()
        {
            GameObject newObj = new GameObject("TreeMaster");
            newObj.transform.parent = (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null;
            newObj.transform.localPosition = Vector3.zero;
            newObj.transform.parent = (Selection.activeGameObject.transform.parent != null) ? Selection.activeGameObject.transform.parent : null;
            Selection.activeGameObject.transform.parent = newObj.transform;
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Foliage Group", false, 30)]
        private static void CreateFoliageGroup()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("FoliageGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Leaf Plane Group", false, 30)]
        private static void CreateLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("LeafPlane_Group", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Pine Branch Group", false, 30)]
        private static void CreatePineLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("LeafCardBent", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Leaf Bundle", false, 50)]
        private static void CreateLeafCard()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("LeafCard_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }



        [MenuItem("GameObject/3D Object/TreeMaster/Leaf Plane", false, 50)]
        private static void CreateLeafPlane()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("LeafPlane_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        #endregion

    }

}
#endif