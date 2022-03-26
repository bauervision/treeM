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

        [MenuItem("GameObject/3D Object/TreeMaster/Starter", false, 10)]
        private static void CreateTMStarter()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("TreeMaster", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Trees/Redwood", false, 10)]
        private static void CreateTMTreeRW()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Trees/Seqouia", false, 10)]
        private static void CreateTMTreeS()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_02", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

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

        [MenuItem("GameObject/3D Object/TreeMaster/Groups/Foliage Bundle", false, 30)]
        private static void CreateFoliageGroup()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/FoliageGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Groups/Leaf Plane Curved", false, 30)]
        private static void CreateLeafPlaneCurvedGroup()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlaneCurvedGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        [MenuItem("GameObject/3D Object/TreeMaster/Groups/Leaf Planes", false, 30)]
        private static void CreateLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlane_Group", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Groups/Pine Branches", false, 30)]
        private static void CreatePineLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafCardBent", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Groups/Leaves", false, 50)]
        private static void CreateLeafCard()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafCard", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }



        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Leaf Plane", false, 50)]
        private static void CreateLeafPlane()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlane_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Leaf Plane Curved", false, 50)]
        private static void CreateLeafPlaneCurved()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlaneCurved", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Tree Flower", false, 50)]
        private static void CreateTreeFlower()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Flower", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Branch Mask", false, 50)]
        private static void CreateBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Dead Branch Mask", false, 50)]
        private static void CreateDeadBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask-DeadGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Flowers Branch Mask", false, 50)]
        private static void CreateFlowersBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask_Flowers", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Parts/Trunk Mesh", false, 50)]
        private static void CreateTrunkMesh()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/TM_TrunkBase", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }



        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Acacia", false, 50)]
        private static void CreateBranchAcacia()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Acacia Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Cypress", false, 50)]
        private static void CreateBranchCypress()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Cypress Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Drooping", false, 50)]
        private static void CreateBranchDrooping()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Drooping Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Gnarly", false, 50)]
        private static void CreateBranchGnarly()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Gnarly Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Kapok", false, 50)]
        private static void CreateBranchKapok()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Kapok Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Maple", false, 50)]
        private static void CreateBranchMaple()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Maple Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Pine", false, 50)]
        private static void CreateBranchPine()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Pine Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Redwood", false, 50)]
        private static void CreateBranchRedwood()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Redwood Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/3D Object/TreeMaster/Branches/Thin", false, 50)]
        private static void CreateBranchThin()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Thin Branch", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }
        #endregion

    }

}
#endif