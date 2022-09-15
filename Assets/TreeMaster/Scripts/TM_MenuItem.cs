using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using TreeMasterScreenshot;

namespace TreeMaster
{
    public static class MenuItems
    {

        #region Main Menu Tools

        [MenuItem("Tools/TreeMaster/Edit Tree", false, 10)]
        private static void ShowToolSwitchMesh() { TM_ChangeMesh.ShowWindow(); }


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


        #region Trees
        [MenuItem("GameObject/TreeMaster/Trees/Redwood", false, 10)]
        private static void CreateTMTreeRW()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Seqouia", false, 10)]
        private static void CreateTMTreeS()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_02", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Kapok", false, 10)]
        private static void CreateTMTreeK()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_03", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Maple", false, 10)]
        private static void CreateTMTreeM()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_04", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Bald Cypress", false, 10)]
        private static void CreateTMTreeB()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_05", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Hickory", false, 10)]
        private static void CreateTMTreeH()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_06", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Cypress Oak", false, 10)]
        private static void CreateTMTreeCO()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_07", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Pine", false, 10)]
        private static void CreateTMTreeP()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_08", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Spruce", false, 10)]
        private static void CreateTMTreeSpr()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_09", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Acacia", false, 10)]
        private static void CreateTMTreeAc()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_10", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Birch", false, 10)]
        private static void CreateTMTreeBir()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_11", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Sapling 1", false, 10)]
        private static void CreateTMTreeSap1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_12", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Sapling 2", false, 10)]
        private static void CreateTMTreeSap2()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_13", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Trees/Forest Tree", false, 10)]
        private static void CreateTMTreeFor()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Trees/Tree_14", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        #endregion

        [MenuItem("GameObject/TreeMaster/Add Controller", false, 10)]
        private static void CreateController()
        {
            GameObject newObj = new GameObject("TreeMaster");
            newObj.transform.parent = (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null;
            newObj.transform.localPosition = Vector3.zero;
            newObj.transform.parent = (Selection.activeGameObject.transform.parent != null) ? Selection.activeGameObject.transform.parent : null;
            Selection.activeGameObject.transform.parent = newObj.transform;
            Selection.activeGameObject = newObj;
        }

        #region Groups
        [MenuItem("GameObject/TreeMaster/Groups/Foliage Bundle", false, 30)]
        private static void CreateFoliageGroup()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/FoliageGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Groups/Leaf Plane Curved", false, 30)]
        private static void CreateLeafPlaneCurvedGroup()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlaneCurvedGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        [MenuItem("GameObject/TreeMaster/Groups/Leaf Planes", false, 30)]
        private static void CreateLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlane_Group", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Groups/Pine Branches", false, 30)]
        private static void CreatePineLeafPlaneBundle()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafCardBent", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Groups/Leaves", false, 50)]
        private static void CreateLeafCard()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafCard", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        #endregion

        #region Parts

        [MenuItem("GameObject/TreeMaster/Parts/Leaf Plane", false, 50)]
        private static void CreateLeafPlane()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlane_01", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Leaf Plane Curved", false, 50)]
        private static void CreateLeafPlaneCurved()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/LeafPlaneCurved", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Tree Flower", false, 50)]
        private static void CreateTreeFlower()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Flower", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Branch Mask", false, 50)]
        private static void CreateBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Dead Branch Mask", false, 50)]
        private static void CreateDeadBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask-DeadGroup", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Flowers Branch Mask", false, 50)]
        private static void CreateFlowersBranchMask()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/BranchMask_Flowers", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Trunk Mesh", false, 50)]
        private static void CreateTrunkMesh()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/TM_TrunkBase", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Parts/Roots", false, 50)]
        private static void CreateRoots()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Parts/Roots", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        #endregion

        #region Branches

        [MenuItem("GameObject/TreeMaster/Branches/Acacia", false, 50)]
        private static void CreateBranchAcacia1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/ABranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        [MenuItem("GameObject/TreeMaster/Branches/Cypress", false, 50)]
        private static void CreateBranchCypress1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/CBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Drooping", false, 50)]
        private static void CreateBranchDrooping1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/DBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Gnarly", false, 50)]
        private static void CreateBranchGnarly1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/GBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Kapok", false, 50)]
        private static void CreateBranchKapok1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/KBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Maple", false, 50)]
        private static void CreateBranchMaple1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/MBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Pine", false, 50)]
        private static void CreateBranchPine1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/PBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }


        [MenuItem("GameObject/TreeMaster/Branches/Redwood", false, 50)]
        private static void CreateBranchRedwood1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/RWBranch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        [MenuItem("GameObject/TreeMaster/Branches/Thin", false, 50)]
        private static void CreateBranchThin1()
        {
            GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load("Branches/Thin_Branch1", typeof(GameObject)), (Selection.activeGameObject != null) ? Selection.activeGameObject.transform : null) as GameObject;
            PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Selection.activeGameObject = newObj;
        }

        #endregion

        #endregion



    }

}
#endif