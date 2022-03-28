using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

#if UNITY_EDITOR
using UnityEditor;



[ExecuteInEditMode]
public class TM_ChangeMesh : EditorWindow
{
    private bool addFlowers;
    private int variety = 1, flowerVariety = 1, leafMaterial = 1, age = 1, trunk = 1, roots = 0, ivy = 0, ivyVariety = 1, vines = 0, vineVariety = 1, bark = 1, lichen = 0;
    private int varietyOld = 0, leavesOld = 1, ageOld = 1, trunkOld = 1, rootsOld = 0, ivyOld = 0, ivyVarietyOld = 1, vinesOld = 0, vineVarietyOld = 1, barkOld = 1, lichenOld = 0;

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
    private float trunkRotation = 1, oldTrunkRotation = 1;
    private float ivyScale = 1, oldIvyScale = 1;
    private float vineScale = 1, oldVineScale = 1;


    int trunkLichenOptions = 3;
    int trunkRootOptions = 3;
    float trunkMaxScale = 100f;

    int foliageVarietyOptions = 16;
    int foliageSeasonalOptions = 16;
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
    private bool addRoots;
    private float rootScale;
    private float rootsRotation, oldRootsRotation;
    private int rootsVariety, oldRootsVariety;

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
                // lichen = EditorGUILayout.IntSlider("Lichen", lichen, 0, trunkLichenOptions);//material
                // SwitchLichen(lichen);
                // roots = EditorGUILayout.IntSlider("Roots", roots, 0, trunkRootOptions);//changes mesh & material to match above
                // SwitchRoots(roots);
                trunkScale = EditorGUILayout.Slider("Trunk Scale", trunkScale, 0.01f, trunkMaxScale);//scaling
                ScaleTrunk(trunkScale);
                trunkRotation = EditorGUILayout.Slider("Trunk Rotate", trunkRotation, -180f, 180f);//scaling
                RotateTrunk(trunkRotation);
                EditorGUILayout.Space();

                GUILayout.Label("Foliage:", EditorStyles.boldLabel);
                EditorGUILayout.Space();
                // leafMesh = EditorGUILayout.IntSlider("Mesh Option", leafMesh, 1, foliageMeshOptions);//changes mesh option
                // SwitchLeafMesh(leafMesh);
                variety = EditorGUILayout.IntSlider("Variety", variety, 1, foliageVarietyOptions);//changes mesh UV
                SwitchVariety(variety);
                leafMaterial = EditorGUILayout.IntSlider("Leaf Material", leafMaterial, 1, GetTotalCount("Assets/TreeMaster/Resources/Materials/Leaves"));//changes material
                SwitchLeafMaterial(leafMaterial);
                // age = EditorGUILayout.IntSlider("Age", age, 1, foliageAgeOptions);//changes material
                // SwitchAge(age);
                leafScale = EditorGUILayout.Slider("Foliage Scale", leafScale, 0.001f, foliageMaxScale);//scaling
                ScaleLeaves(leafScale);
                EditorGUILayout.Space();

                addFlowers = EditorGUILayout.Toggle("Add Flowers?", addFlowers);
                EnableFlowers(addFlowers); // make sure we enable all the flowers if we want them
                if (addFlowers)
                {
                    GUILayout.Label("Flowers:", EditorStyles.boldLabel);
                    EditorGUILayout.Space();

                    flowerVariety = EditorGUILayout.IntSlider("Variety", flowerVariety, 1, 9);//changes mesh UV
                    SwitchFlowerVariety(flowerVariety);
                    flowerScale = EditorGUILayout.Slider("Scale", flowerScale, 0.001f, flowersMaxScale);//scaling
                    ScaleFlowers(flowerScale);
                    EditorGUILayout.Space();
                }

                addRoots = EditorGUILayout.Toggle("Add Roots?", addRoots);
                EnableRoots(addRoots); // make sure we enable all the flowers if we want them
                if (addRoots)
                {
                    GUILayout.Label("Roots:", EditorStyles.boldLabel);
                    EditorGUILayout.Space();
                    rootsVariety = EditorGUILayout.IntSlider("Variety", rootsVariety, 1, 4);//changes mesh UV
                    SwitchRootsVariety(rootsVariety);
                    rootScale = EditorGUILayout.Slider("Roots Scale", rootScale, 0.01f, 3f);//scaling
                    ScaleRoots(rootScale);
                    rootsRotation = EditorGUILayout.Slider("Roots Rotate", rootsRotation, -180f, 180f);//scaling
                    RotateRoots(rootsRotation);
                }
                // GUILayout.Label("Extras:", EditorStyles.boldLabel);
                // GUILayout.Label(newExtraMeshName, EditorStyles.label);
                // EditorGUILayout.Space();
                // ivy = EditorGUILayout.IntSlider("Ivy Mesh", ivy, 0, extraIvyOptions);//changes mesh option
                // SwitchIvy(ivy);
                // ivyVariety = EditorGUILayout.IntSlider("Ivy Look", ivyVariety, 1, extraIvyVarietyOptions);// changes UV
                // SwitchIvyVariety(ivyVariety);
                // ivyScale = EditorGUILayout.Slider("Ivy Scale", ivyScale, 0.2f, extraMaxScale);//scaling
                // ScaleIvy(ivyScale);

                // vines = EditorGUILayout.IntSlider("Vine Mesh", vines, 0, extraVineOptions);//changes mesh option
                // SwitchVines(vines);
                // vineVariety = EditorGUILayout.IntSlider("Vine Look", vineVariety, 1, extraVineyVarietyOptions);// changes UV
                // SwitchVineVariety(vineVariety);

                // vineScale = EditorGUILayout.Slider("Vine Scale", vineScale, 0.2f, extraMaxScale);//scaling
                // ScaleVine(vineScale);
                // EditorGUILayout.Space();

                // GUILayout.Label("Extras:", EditorStyles.boldLabel);
                // GUILayout.Label(newExtraMeshName, EditorStyles.label);
                // EditorGUILayout.Space();
                // ivy = EditorGUILayout.IntSlider("Ivy Mesh", ivy, 0, extraIvyOptions);//changes mesh option
                // SwitchIvy(ivy);
                // ivyVariety = EditorGUILayout.IntSlider("Ivy Look", ivyVariety, 1, extraIvyVarietyOptions);// changes UV
                // SwitchIvyVariety(ivyVariety);
                // ivyScale = EditorGUILayout.Slider("Ivy Scale", ivyScale, 0.2f, extraMaxScale);//scaling
                // ScaleIvy(ivyScale);

                // vines = EditorGUILayout.IntSlider("Vine Mesh", vines, 0, extraVineOptions);//changes mesh option
                // SwitchVines(vines);
                // vineVariety = EditorGUILayout.IntSlider("Vine Look", vineVariety, 1, extraVineyVarietyOptions);// changes UV
                // SwitchVineVariety(vineVariety);

                // vineScale = EditorGUILayout.Slider("Vine Scale", vineScale, 0.2f, extraMaxScale);//scaling
                // ScaleVine(vineScale);
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

    private void SwitchRootsVariety(int rootsVarietyValue)
    {
        string varietyString = rootsVarietyValue < 10 ? "0" + rootsVarietyValue : rootsVarietyValue.ToString();
        // now jump down to the roots object
        GameObject rootsObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(1).transform.gameObject;

        Mesh[] fbxMeshes = Resources.LoadAll<Mesh>("Source Mesh/TM_Roots");
        //only make changes if this is a leaf object
        MeshFilter mf = rootsObj.GetComponent<MeshFilter>();
        // if this gameobject has a mesh filter assigned, handle the swap
        if (mf != null)
        {
            // store the name of this current mesh
            string oldMeshName = mf.sharedMesh.name;
            string newMeshName = mf.sharedMesh.name.Remove(mf.sharedMesh.name.Length - 2) + varietyString;

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




    private void RotateRoots(float rootsRotationValue)
    {
        if (oldRootsRotation != rootsRotationValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.GetChild(1).transform.localEulerAngles = new Vector3(0, rootsRotationValue, 0);
            oldRootsRotation = rootsRotationValue;
        }
    }

    private void ScaleRoots(float rootScaleValue)
    {
        if (oldTrunkScale != rootScaleValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.GetChild(1).transform.localScale = new Vector3(rootScaleValue, rootScaleValue, rootScaleValue);
            oldTrunkScale = rootScaleValue;
        }
    }

    private void EnableRoots(bool addRoots)
    {
        List<MeshFilter> allRootRenderers = new List<MeshFilter>();
        Selection.activeGameObject.transform.GetChild(0).transform.GetChild(1).transform.GetComponentsInChildren<MeshFilter>(true, allRootRenderers);

        if (allRootRenderers != null)
            foreach (MeshFilter mesh in allRootRenderers)
                if (mesh.sharedMesh.name.StartsWith("Roots"))
                    mesh.transform.gameObject.SetActive(addRoots);
    }

    private void RotateTrunk(float trunkRotationValue)
    {
        if (oldTrunkRotation != trunkRotationValue)
        {
            Selection.activeGameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, trunkRotationValue, 0);
            oldTrunkRotation = trunkRotationValue;
        }
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


        variety = 1; leafMaterial = 1; age = 1; varietyOld = 1; leavesOld = 1; ageOld = 1;
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

            oldLeafScale = leafScaleValue;
        }
    }


    private void EnableFlowers(bool addFlowers)
    {
        List<MeshRenderer> allFlowerRenderers = new List<MeshRenderer>();
        Selection.activeGameObject.transform.GetComponentsInChildren<MeshRenderer>(true, allFlowerRenderers);

        if (allFlowerRenderers != null)
            foreach (MeshRenderer renderer in allFlowerRenderers)
                if (renderer.sharedMaterial.name.StartsWith("Flowers"))
                    renderer.transform.gameObject.SetActive(addFlowers);
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


    public void SwitchVariety(int newVariety)
    {

        string varietyString = newVariety < 10 ? "0" + newVariety : newVariety.ToString();
        // now jump down to the foliage object
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;

        //make sure we have branches to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMesh(foliageObj, varietyString);

        // varietyOld = newVariety;

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
            MeshRenderer currentMR = foliageObj.transform.GetChild(i).GetComponent<MeshRenderer>();
            if (currentMR != null)
            {
                if (currentMR.sharedMaterial.name.StartsWith("Leaves "))
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
                mr.material = GetNewMaterial($"Materials/Barks/{newVersion}");


        // now change out the bark material on all bark based children
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //make sure we have kids to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMaterials(foliageObj, newVersion, "Bark ", $"Materials/Barks/{newVersion}");
    }

    private void SwitchLeafMaterial(int leafMaterial)
    {
        if (leafMaterial != leavesOld)
        {
            SwitchLeavesMaterial("Leaves " + leafMaterial);

            leavesOld = leafMaterial;
        }
    }

    void SwitchLeavesMaterial(string newVersion)
    {
        // switch the trunk material
        MeshRenderer mr = Selection.activeGameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        // if this gameobject has a mesh renderer assigned, handle the swap
        if (mr != null)
            if (mr.sharedMaterial.name.StartsWith("Leaves "))
                mr.material = GetNewMaterial($"Materials/Leaves/{newVersion}");

        // now change out the bark material on all bark based children
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //make sure we have kids to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMaterials(foliageObj, newVersion, "Leaves ", $"Materials/Leaves/{newVersion}");
    }

    void SwitchBranchMaterial(string newVersion)
    {
        // switch the trunk material
        MeshRenderer mr = Selection.activeGameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        // if this gameobject has a mesh renderer assigned, handle the swap
        if (mr != null)
            if (mr.sharedMaterial.name.StartsWith("Branch "))
                mr.material = GetNewMaterial($"Materials/Branches/{newVersion}");

        // now change out the bark material on all bark based children
        GameObject foliageObj = Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //make sure we have kids to loop through
        if (foliageObj.transform.childCount > 0)
            LoopThroughChildrenMaterials(foliageObj, newVersion, "Branch ", $"Materials/Branches/{newVersion}");
    }

    Material GetNewMaterial(string path) { return Resources.Load<Material>(path); }

    public void LoopThroughChildrenMaterials(GameObject currentGameObj, string newVersion, string sourceName, string pathtoMaterial)
    {
        // loop and find all the meshes with the sourceName material assigned and swap them
        for (int i = 0; i < currentGameObj.transform.childCount; i++)
        {
            MeshRenderer mrC = currentGameObj.transform.GetChild(i).GetComponent<MeshRenderer>();
            // if this gameobject has a mesh renderer assigned and 
            if (mrC != null)
                if (mrC.sharedMaterial.name.StartsWith(sourceName))
                    mrC.material = GetNewMaterial(pathtoMaterial);

            if (currentGameObj.transform.GetChild(i).transform.childCount > 0)
                LoopThroughChildrenMaterials(currentGameObj.transform.GetChild(i).gameObject, newVersion, sourceName, pathtoMaterial);
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

    private void SwitchVines(int newVines)
    {
        if (newVines != vinesOld)
        {
            extrasString = newExtraMeshName = GetNewVersionName(extrasString, 'v', newVines);
            vinesOld = newVines;
        }
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