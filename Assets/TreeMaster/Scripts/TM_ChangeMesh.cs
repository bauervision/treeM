using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

#if UNITY_EDITOR
using UnityEditor;



[ExecuteInEditMode]
public class TM_ChangeMesh : EditorWindow
{

    private int variety = 1, flowerVariety = 1, seasonal = 1, age = 1, trunk = 1, roots = 0, ivy = 0, ivyVariety = 1, vines = 0, vineVariety = 1, bark = 1, lichen = 0;
    private int varietyOld = 1, seasonalOld = 1, ageOld = 1, trunkOld = 1, rootsOld = 0, ivyOld = 0, ivyVarietyOld = 1, vinesOld = 0, vineVarietyOld = 1, barkOld = 1, lichenOld = 0;

    static string foliageStarter = "T!L_m01_v01_s01_a01";
    static string trunkStarter = "T!K_t01_b01_l00_r00";
    static string extrasStarter = "T!X_i00_l01_v00_k01";

    ///<summary>T!L_m01_v01_s01_a01 </summary>
    string foliageString = foliageStarter;//foliage mesh, variety, season, age

    ///<summary>T!K_t01_b01_l01_r01 </summary>
    string trunkString = trunkStarter;//trunk, bark, lichen, roots

    ///<summary>T!X_i01_l01_v01_k01 </summary>
    string extrasString = extrasStarter;//ivy mesh, ivy look, vine mesh, vine look


    string newFoliageMeshName = foliageStarter;
    string newTrunkMeshName = trunkStarter;
    string newExtraMeshName = extrasStarter;
    private float leafScale = 1, oldLeafScale = 1;
    private float flowerScale = 1, oldFlowerScale = 1;
    private float trunkScale = 1, oldTrunkScale = 1;
    private float ivyScale = 1, oldIvyScale = 1;
    private float vineScale = 1, oldVineScale = 1;


    int trunkLichenOptions = 3;
    int trunkRootOptions = 3;
    float trunkMaxScale = 100f;

    int foliageVarietyOptions = 16;
    int foliageSeasonalOptions = 4;
    int foliageAgeOptions = 4;
    float foliageMaxScale = 2f;
    float flowersMaxScale = 2f;

    int extraIvyOptions = 4;
    int extraIvyVarietyOptions = 4;
    int extraVineOptions = 4;
    int extraVineyVarietyOptions = 4;
    float extraMaxScale = 5f;
    GameObject prefabtoSwap;

    Vector2 scrollPos;
    private string nameToSearch;

    public static void ShowWindow()
    {
        EditorWindow editorWindow = EditorWindow.GetWindow(typeof(TM_ChangeMesh));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.Show();
        editorWindow.titleContent = new GUIContent("Change Mesh");

    }


    void OnGUI()
    {
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginVertical("box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        EditorGUILayout.Space();
        if (Selection.activeGameObject)
        {
            // final verification that they are selected on the right thing

            // verify that we are selected on A TreeMaster Mesh before running any of the following methods
            if (Selection.activeGameObject.name != "TreeMaster")
            {
                GUILayout.Label("Not a TreeMaster Mesh", EditorStyles.boldLabel);
                EditorGUILayout.Space();
            }
            else
            {

                EditorGUILayout.Space();
                GUILayout.Label("Tree:", EditorStyles.boldLabel);
                trunk = EditorGUILayout.IntSlider("Type", trunk, 1, GetTotalCount("Assets/TreeMaster/Resources/Trees"));//changes tree version
                SwitchTrunk(trunk);
                EditorGUILayout.Space();
                GUILayout.Label("Trunk:", EditorStyles.boldLabel);
                bark = EditorGUILayout.IntSlider("Bark", bark, 1, GetTotalCount("Assets/TreeMaster/Resources/Materials/Barks"));//changes material
                SwitchBark(bark);
                lichen = EditorGUILayout.IntSlider("Lichen", lichen, 0, trunkLichenOptions);//material
                SwitchLichen(lichen);
                roots = EditorGUILayout.IntSlider("Roots", roots, 0, trunkRootOptions);//changes mesh & material to match above
                SwitchRoots(roots);
                trunkScale = EditorGUILayout.Slider("Trunk Scale", trunkScale, 0.01f, trunkMaxScale);//scaling
                ScaleTrunk(trunkScale);
                EditorGUILayout.Space();

                GUILayout.Label("Foliage:", EditorStyles.boldLabel);
                EditorGUILayout.Space();
                // leafMesh = EditorGUILayout.IntSlider("Mesh Option", leafMesh, 1, foliageMeshOptions);//changes mesh option
                // SwitchLeafMesh(leafMesh);
                variety = EditorGUILayout.IntSlider("Variety", variety, 1, foliageVarietyOptions);//changes mesh UV
                SwitchVariety(variety);
                seasonal = EditorGUILayout.IntSlider("Season", seasonal, 1, foliageSeasonalOptions);//changes material
                SwitchSeason(seasonal);
                age = EditorGUILayout.IntSlider("Age", age, 1, foliageAgeOptions);//changes material
                SwitchAge(age);
                leafScale = EditorGUILayout.Slider("Foliage Scale", leafScale, 0.001f, foliageMaxScale);//scaling
                ScaleLeaves(leafScale);
                EditorGUILayout.Space();

                GUILayout.Label("Flowers:", EditorStyles.boldLabel);
                EditorGUILayout.Space();
                flowerVariety = EditorGUILayout.IntSlider("Variety", flowerVariety, 1, 9);//changes mesh UV
                SwitchFlowerVariety(flowerVariety);
                flowerScale = EditorGUILayout.Slider("Scale", flowerScale, 0.001f, flowersMaxScale);//scaling
                ScaleFlowers(flowerScale);
                EditorGUILayout.Space();

                GUILayout.Label("Extras:", EditorStyles.boldLabel);
                GUILayout.Label(newExtraMeshName, EditorStyles.label);
                EditorGUILayout.Space();
                ivy = EditorGUILayout.IntSlider("Ivy Mesh", ivy, 0, extraIvyOptions);//changes mesh option
                SwitchIvy(ivy);
                ivyVariety = EditorGUILayout.IntSlider("Ivy Look", ivyVariety, 1, extraIvyVarietyOptions);// changes UV
                SwitchIvyVariety(ivyVariety);
                ivyScale = EditorGUILayout.Slider("Ivy Scale", ivyScale, 0.2f, extraMaxScale);//scaling
                ScaleIvy(ivyScale);

                vines = EditorGUILayout.IntSlider("Vine Mesh", vines, 0, extraVineOptions);//changes mesh option
                SwitchVines(vines);
                vineVariety = EditorGUILayout.IntSlider("Vine Look", vineVariety, 1, extraVineyVarietyOptions);// changes UV
                SwitchVineVariety(vineVariety);

                vineScale = EditorGUILayout.Slider("Vine Scale", vineScale, 0.2f, extraMaxScale);//scaling
                ScaleVine(vineScale);
                EditorGUILayout.Space();


                GUILayout.Label("Export", EditorStyles.boldLabel);
                EditorGUILayout.Space();

                EditorGUILayout.Space();
                GUILayout.Label("Exported tree will be located in /TreeMaster/Exports/", EditorStyles.wordWrappedLabel);

                if (GUILayout.Button("Save this tree preset", GUILayout.MaxHeight(50), GUILayout.MinHeight(50)))
                    ExportNewPreset();

                EditorGUILayout.Space();
                if (GUILayout.Button("Reset", GUILayout.MaxHeight(30), GUILayout.MinHeight(30)))
                    Reset();

                GUILayout.Label("Exported tree will be located in /TreeMaster/Exports/", EditorStyles.wordWrappedLabel);
            }

        }
        else
        {
            GUILayout.Label("Select Something if you want to change it...", EditorStyles.boldLabel);
        }

        GUILayout.EndVertical();
        GUILayout.EndScrollView();
    }



    void Reset()
    {
        foliageString = foliageStarter;
        trunkString = trunkStarter;
        extrasString = extrasStarter;

        leafScale = 1; oldLeafScale = 1;
        trunkScale = 1; oldTrunkScale = 1;
        ivyScale = 1; oldIvyScale = 1;
        vineScale = 1; oldVineScale = 1;


        variety = 1; seasonal = 1; age = 1; varietyOld = 1; seasonalOld = 1; ageOld = 1;
        trunk = 1; roots = 0; bark = 1; lichen = 0; trunkOld = 1; rootsOld = 0; barkOld = 1; lichenOld = 0;
        ivy = 0; ivyVariety = 1; vines = 0; vineVariety = 1; ivyOld = 0; ivyVarietyOld = 1; vinesOld = 0; vineVarietyOld = 1;
    }

    void ExportNewPreset()
    {
        Debug.Log("Export Trunk Mesh: " + newTrunkMeshName + " scaled: " + oldTrunkScale + "%");
        Debug.Log("Export Foliage Mesh: " + newFoliageMeshName + " scaled: " + oldLeafScale + "%");
        Debug.Log("Export Extra Mesh: " + newExtraMeshName);


    }

    #region Scaling


    private void ScaleIvy(float ivyScaleValue)
    {
        if (oldIvyScale != ivyScaleValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.GetChild(2).transform.localScale = new Vector3(ivyScaleValue, ivyScaleValue, ivyScaleValue);
            oldIvyScale = ivyScaleValue;
        }
    }

    private void ScaleVine(float vineScaleValue)
    {
        if (oldVineScale != vineScaleValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.GetChild(1).transform.localScale = new Vector3(vineScaleValue, vineScaleValue, vineScaleValue);
            oldVineScale = vineScaleValue;
        }
    }

    private void ScaleTrunk(float trunkScaleValue)
    {
        if (oldTrunkScale != trunkScaleValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.localScale = new Vector3(trunkScaleValue, trunkScaleValue, trunkScaleValue);
            oldTrunkScale = trunkScaleValue;
        }
    }

    private void ScaleLeaves(float leafScaleValue)
    {
        if (oldLeafScale != leafScaleValue)
        {
            List<MeshRenderer> allLeafRenderers = new List<MeshRenderer>();
            Selection.activeGameObject.transform.GetComponentsInChildren<MeshRenderer>(false, allLeafRenderers);

            if (allLeafRenderers != null)
                foreach (MeshRenderer renderer in allLeafRenderers)
                    if (renderer.sharedMaterial.name.StartsWith("Leaves "))
                        renderer.transform.localScale = new Vector3(leafScaleValue, leafScaleValue, leafScaleValue);

            // // first get all the branches
            // List<Transform> allBranches = new List<Transform>();//  Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).GetComponentsInChildren<Transform>().ToList();
            // for (int i = 0; i < Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).childCount; i++)
            //     allBranches.Add(Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i));

            // // then scale only the leaves
            // foreach (Transform branch in allBranches)
            //     for (int i = 0; i < branch.childCount; i++)
            //         branch.transform.GetChild(i).transform.localScale = new Vector3(leafScaleValue, leafScaleValue, leafScaleValue);

            oldLeafScale = leafScaleValue;
        }
    }

    private void ScaleFlowers(float flowerScaleValue)
    {
        if (oldFlowerScale != flowerScaleValue)
        {
            List<MeshRenderer> allFlowerRenderers = new List<MeshRenderer>();
            Selection.activeGameObject.transform.GetComponentsInChildren<MeshRenderer>(false, allFlowerRenderers);

            if (allFlowerRenderers != null)
                foreach (MeshRenderer renderer in allFlowerRenderers)
                    if (renderer.sharedMaterial.name.StartsWith("Flowers"))
                        renderer.transform.localScale = new Vector3(flowerScaleValue, flowerScaleValue, flowerScaleValue);

            oldFlowerScale = flowerScaleValue;
        }
    }





    #endregion

    #region Foliage


    private void SwitchAge(int newAge)
    {
        if (newAge != ageOld)
        {
            foliageString = newFoliageMeshName = GetNewVersionName(foliageString, 'a', newAge);
            ageOld = newAge;
        }
    }

    private void SwitchSeason(int newSeason)
    {
        if (newSeason != seasonalOld)
        {
            foliageString = newFoliageMeshName = GetNewVersionName(foliageString, 's', newSeason);
            seasonalOld = newSeason;
        }
    }
    public void SwitchVariety(int newVariety)
    {
        if (newVariety != varietyOld)
        {
            string varietyString = newVariety < 10 ? "0" + newVariety : newVariety.ToString();

            // now jump down to the foliage object
            GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;

            //make sure we have branches to loop through
            if (foliageObj.transform.childCount > 0)
                LoopThroughChildrenMesh(foliageObj, varietyString);

            varietyOld = newVariety;
        }
    }

    public void SwitchFlowerVariety(int newVariety)
    {
        if (newVariety != varietyOld)
        {
            string varietyString = newVariety < 10 ? "0" + newVariety : newVariety.ToString();

            // now jump down to the foliage object
            GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;

            //make sure we have branches to loop through
            if (foliageObj.transform.childCount > 0)
                LoopThroughChildrenFlowers(foliageObj, varietyString);

            varietyOld = newVariety;
        }
    }

    private void LoopThroughChildrenFlowers(GameObject foliageObj, string newVariety)
    {
        // Foliage object level

        Mesh[] fbxMeshes = Resources.LoadAll<Mesh>("Source Mesh/TM_Flowers");
        // loop and find all the meshes with the sourceName material assigned and swap them
        for (int i = 0; i < foliageObj.transform.childCount; i++)
        {
            // Branch level
            if (foliageObj.transform.GetChild(i).transform.childCount > 0)
                LoopThroughChildrenFlowers(foliageObj.transform.GetChild(i).gameObject, newVariety);

            //only make changes if this is a leaf object
            if (foliageObj.transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial.name.StartsWith("Flowers "))
            {
                MeshFilter mf = foliageObj.transform.GetChild(i).GetComponent<MeshFilter>();
                // if this gameobject has a mesh filter assigned, handle the swap
                if (mf != null)
                {
                    // store the name of this current mesh
                    string oldMeshName = mf.sharedMesh.name;
                    string newMeshName = mf.sharedMesh.name.Remove(mf.sharedMesh.name.Length - 2) + newVariety;

                    if (oldMeshName != newMeshName)
                    {
                        // as long as the swap mesh is different , swap it
                        if (fbxMeshes != null)
                        {
                            foreach (Mesh mesh in fbxMeshes)
                                if (mesh.name == newMeshName)// if we find the name of what we want to swap with in the fbx file
                                    mf.sharedMesh = mesh;// swap meshes
                        }
                    }
                }
            }
        }
    }

    private void LoopThroughChildrenMesh(GameObject foliageObj, string newVariety)
    {
        // Foliage object level

        Mesh[] fbxMeshes = Resources.LoadAll<Mesh>("Source Mesh/TM_Leaves");
        // loop and find all the meshes with the sourceName material assigned and swap them
        for (int i = 0; i < foliageObj.transform.childCount; i++)
        {
            // Branch level
            if (foliageObj.transform.GetChild(i).transform.childCount > 0)
                LoopThroughChildrenMesh(foliageObj.transform.GetChild(i).gameObject, newVariety);

            //only make changes if this is a leaf object
            if (foliageObj.transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial.name.StartsWith("Leaves "))
            {
                MeshFilter mf = foliageObj.transform.GetChild(i).GetComponent<MeshFilter>();
                // if this gameobject has a mesh filter assigned, handle the swap
                if (mf != null)
                {
                    // store the name of this current mesh
                    string oldMeshName = mf.sharedMesh.name;
                    string newMeshName = mf.sharedMesh.name.Remove(mf.sharedMesh.name.Length - 2) + newVariety;

                    if (oldMeshName != newMeshName)
                    {
                        // as long as the swap mesh is different , swap it
                        if (fbxMeshes != null)
                        {
                            foreach (Mesh mesh in fbxMeshes)
                                if (mesh.name == newMeshName)// if we find the name of what we want to swap with in the fbx file
                                    mf.sharedMesh = mesh;// swap meshes
                        }

                    }

                }



            }
            // else
            // {
            //     // if this branch has children
            //     if (foliageObj.transform.GetChild(i).transform.childCount > 0)
            //         LoopThroughChildrenMesh(foliageObj.transform.GetChild(i).gameObject, newVariety);

            //     Debug.Log(foliageObj.transform.GetChild(i).name);
            // }


        }
    }



    #endregion

    #region Trunks
    private void SwitchRoots(int newRoots)
    {
        if (newRoots != rootsOld)
        {
            trunkString = newTrunkMeshName = GetNewVersionName(trunkString, 'r', newRoots);
            rootsOld = newRoots;
        }
    }

    private void SwitchLichen(int newLichen)
    {
        if (newLichen != lichenOld)
        {
            trunkString = newTrunkMeshName = GetNewVersionName(trunkString, 'l', newLichen);
            lichenOld = newLichen;
        }
    }

    private void SwitchTrunk(int newTrunk)
    {
        if (newTrunk != trunkOld)
        {
            trunkString = newTrunkMeshName = GetNewVersionName(trunkString, 't', newTrunk);
            string tempString = trunkString.Substring(0, trunkString.Length - 12);
            string finalVersion = tempString.Substring(tempString.Length - 2);
            SwitchTrunkVersion(finalVersion);
            trunkOld = newTrunk;
        }
    }

    private void SwitchBark(int newBark)
    {
        if (newBark != barkOld)
        {
            SwitchBarkMaterial("Bark " + newBark);
            SwitchBranchMaterial("Branch " + newBark);
            barkOld = newBark;
        }
    }
    #endregion

    int GetTotalCount(string folder)
    {
        return System.IO.Directory.GetFiles(folder).Length / 2;
    }

    void SwitchBarkMaterial(string newVersion)
    {
        // switch the trunk material
        MeshRenderer mr = Selection.activeGameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        // if this gameobject has a mesh renderer assigned, handle the swap
        if (mr != null)
            if (mr.sharedMaterial.name.StartsWith("Bark "))
                mr.material = GetNewMaterial(newVersion);


        // now change out the bark material on all bark based children
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //make sure we have kids to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMaterials(foliageObj, newVersion, "Bark ");
    }

    void SwitchBranchMaterial(string newVersion)
    {
        // switch the trunk material
        MeshRenderer mr = Selection.activeGameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        // if this gameobject has a mesh renderer assigned, handle the swap
        if (mr != null)
            if (mr.sharedMaterial.name.StartsWith("Branch "))
                mr.material = GetNewBranchMaterial(newVersion);

        // now change out the bark material on all bark based children
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //make sure we have kids to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMaterials(foliageObj, newVersion, "Branch ");
    }

    Material GetNewMaterial(string newMaterialName) { return Resources.Load<Material>($"Materials/Barks/{newMaterialName}"); }

    Material GetNewBranchMaterial(string newMaterialName) { return Resources.Load<Material>($"Materials/Branches/{newMaterialName}"); }

    public void LoopThroughChildrenMaterials(GameObject currentGameObj, string newVersion, string sourceName)
    {
        // loop and find all the meshes with the sourceName material assigned and swap them
        for (int i = 0; i < currentGameObj.transform.childCount; i++)
        {
            MeshRenderer mrC = currentGameObj.transform.GetChild(i).GetComponent<MeshRenderer>();
            // if this gameobject has a mesh renderer assigned and 
            if (mrC != null)
                if (mrC.sharedMaterial.name.StartsWith(sourceName))
                    if (mrC.sharedMaterial.name.StartsWith("Bark"))
                        mrC.material = GetNewMaterial(newVersion);
                    else
                        mrC.material = GetNewBranchMaterial(newVersion);

            if (currentGameObj.transform.GetChild(i).transform.childCount > 0)
                LoopThroughChildrenMaterials(currentGameObj.transform.GetChild(i).gameObject, newVersion, sourceName);
        }
    }



    #region Extras
    private void SwitchIvyVariety(int newIvyVariety)
    {

        if (newIvyVariety != ivyVarietyOld)
        {
            extrasString = newExtraMeshName = GetNewVersionName(extrasString, 'l', newIvyVariety);
            ivyVarietyOld = newIvyVariety;
        }
    }

    private void SwitchVineVariety(int newVineVariety)
    {
        if (newVineVariety != vineVarietyOld)
        {
            extrasString = newExtraMeshName = GetNewVersionName(extrasString, 'k', newVineVariety);
            vineVarietyOld = newVineVariety;
        }
    }



    private void SwitchVines(int newVines)
    {
        if (newVines != vinesOld)
        {
            extrasString = newExtraMeshName = GetNewVersionName(extrasString, 'v', newVines);
            vinesOld = newVines;
        }
    }

    private void SwitchIvy(int newIvy)
    {
        if (newIvy != ivyOld)
        {
            extrasString = newExtraMeshName = GetNewVersionName(extrasString, 'i', newIvy);
            ivyOld = newIvy;
        }
    }
    #endregion



    string GetNewVersionName(string inputString, char splitChar, int newVersion)
    {
        string[] split = inputString.Split(splitChar);
        string removed = split[1].Remove(0, 2);

        //add in the new variety
        string newVarietyString = newVersion + removed;
        //determine if we need to add a zero
        string finalName;
        if (newVersion < 10)
            finalName = split[0] + splitChar + "0" + newVarietyString;
        else
            finalName = split[0] + splitChar + newVarietyString;

        return finalName;
    }


    public void SwitchTrunkVersion(string newVersion)
    {
        // only switch on the trunk mesh
        ChangeTreePrefab(newVersion);
    }

    private void ChangeTreePrefab(string newVersion)
    {
        // first remove the current tree
        DestroyImmediate(Selection.activeGameObject.transform.GetChild(0).gameObject);
        // get the new tree name
        string newTreePrefab = $"Trees/Tree_{newVersion}";
        //load the prefab
        GameObject newObj = PrefabUtility.InstantiatePrefab(Resources.Load(newTreePrefab, typeof(GameObject)), Selection.activeGameObject.transform) as GameObject;
        PrefabUtility.UnpackPrefabInstance(newObj, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        // set the parent
        newObj.transform.parent = Selection.activeGameObject.transform;
    }

}
#endif