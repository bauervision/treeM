using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

#if UNITY_EDITOR
using UnityEditor;



[ExecuteInEditMode]
public class TM_ChangeMesh : EditorWindow
{

    int speciesVersion = 1;
    int meshVersion = 1;
    bool includeChildren = true;
    bool removeFoliageBranch = false;
    bool addFoliageBranch = false;
    bool boostFoliageBranch = false;

    const int foliageSpeciesCount = 8;
    const int leavesSpeciesCount = 8;
    const int cardSpeciesCount = 8;
    const int trunkSpeciesCount = 8;
    const int hiPlantSpeciesCount = 0;
    const int grassSpeciesCount = 0;
    const int flowerSpeciesCount = 0;
    const int rockrSpeciesCount = 4;
    const int scatterSpeciesCount = 8;
    const int spruceSpeciesCount = 4;


    const int foliageOptionsCount = 8;
    const int leavesOptionsCount = 4;
    const int cardOptionsCount = 4;
    const int trunkOptionsCount = 32;
    const int hiPlantOptionsCount = 15;
    const int grassOptionsCount = 20;
    const int flowerOptionsCount = 21;
    const int rockrOptionsCount = 11;
    const int scatterOptionsCount = 7;
    const int spruceOptionsCount = 8;

    string[] resourceString = new string[] { "_FoliageBranches", "_BaseFoliage", "_Trunks", "_HighPlants", "_Grasses", "_Flowers", "_Rocks", "_Scatter", "_Spruce" };

    private int variety = 1, seasonal = 1, age = 1, trunk = 1, roots = 0, ivy = 0, ivyVariety = 1, vines = 0, vineVariety = 1, bark = 1, lichen = 0, leafMesh = 1;
    private int varietyOld = 1, seasonalOld = 1, ageOld = 1, trunkOld = 1, rootsOld = 0, ivyOld = 0, ivyVarietyOld = 1, vinesOld = 0, vineVarietyOld = 1, barkOld = 1, lichenOld = 0, leafMeshOld = 1;

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
    private float trunkScale = 1, oldTrunkScale = 1;
    private float ivyScale = 1, oldIvyScale = 1;
    private float vineScale = 1, oldVineScale = 1;


    int trunkMeshOptions = 3;
    int trunkBarkOptions = 3;
    int trunkLichenOptions = 3;
    int trunkRootOptions = 3;
    float trunkMaxScale = 10f;

    int foliageMeshOptions = 3;
    int foliageVarietyOptions = 16;
    int foliageSeasonalOptions = 4;
    int foliageAgeOptions = 4;
    float foliageMaxScale = 20f;

    int extraIvyOptions = 4;
    int extraIvyVarietyOptions = 4;
    int extraVineOptions = 4;
    int extraVineyVarietyOptions = 4;
    float extraMaxScale = 5f;


    Vector2 scrollPos;

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
                GUILayout.Label("Trunk:", EditorStyles.boldLabel);
                GUILayout.Label(newTrunkMeshName + " " + oldTrunkScale + "%", EditorStyles.label);
                EditorGUILayout.Space();
                trunk = EditorGUILayout.IntSlider("Trunk", trunk, 1, trunkMeshOptions);//changes mesh version
                SwitchTrunk(trunk);
                bark = EditorGUILayout.IntSlider("Bark", bark, 1, trunkBarkOptions);//changes material
                SwitchBark(bark);
                lichen = EditorGUILayout.IntSlider("Lichen", lichen, 0, trunkLichenOptions);//material
                SwitchLichen(lichen);
                roots = EditorGUILayout.IntSlider("Roots", roots, 0, trunkRootOptions);//changes mesh & material to match above
                SwitchRoots(roots);
                trunkScale = EditorGUILayout.Slider("Trunk Scale", trunkScale, 0.2f, trunkMaxScale);//scaling
                ScaleTrunk(trunkScale);
                EditorGUILayout.Space();

                GUILayout.Label("Foliage:", EditorStyles.boldLabel);
                GUILayout.Label(newFoliageMeshName + " " + oldLeafScale + "%", EditorStyles.label);
                EditorGUILayout.Space();
                leafMesh = EditorGUILayout.IntSlider("Mesh Option", leafMesh, 1, foliageMeshOptions);//changes mesh option
                SwitchLeafMesh(leafMesh);
                variety = EditorGUILayout.IntSlider("Variety", variety, 1, foliageVarietyOptions);//changes mesh UV
                SwitchVariety(variety);
                seasonal = EditorGUILayout.IntSlider("Season", seasonal, 1, foliageSeasonalOptions);//changes material
                SwitchSeason(seasonal);
                age = EditorGUILayout.IntSlider("Age", age, 1, foliageAgeOptions);//changes material
                SwitchAge(age);
                leafScale = EditorGUILayout.Slider("Foliage Scale", leafScale, 0.2f, foliageMaxScale);//scaling
                ScaleLeaves(leafScale);
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
            GUILayout.Label("Select something to see your options", EditorStyles.boldLabel);
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


        leafMesh = 1; variety = 1; seasonal = 1; age = 1; varietyOld = 1; seasonalOld = 1; ageOld = 1; leafMeshOld = 1;
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
            // first get all the branches
            List<Transform> allBranches = new List<Transform>();//  Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).GetComponentsInChildren<Transform>().ToList();
            for (int i = 0; i < Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).childCount; i++)
                allBranches.Add(Selection.activeGameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i));

            // then scale only the leaves
            foreach (Transform branch in allBranches)
                for (int i = 0; i < branch.childCount; i++)
                    branch.transform.GetChild(i).transform.localScale = new Vector3(leafScaleValue, leafScaleValue, leafScaleValue);

            oldLeafScale = leafScaleValue;
        }
    }

    #endregion

    #region Foliage
    private void SwitchLeafMesh(int newLeafMesh)
    {
        if (newLeafMesh != leafMeshOld)
        {
            foliageString = newFoliageMeshName = GetNewVersionName(foliageString, 'm', newLeafMesh);
            leafMeshOld = newLeafMesh;
        }
    }

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
            foliageString = newFoliageMeshName = GetNewVersionName(foliageString, 'v', newVariety);
            varietyOld = newVariety;
        }

        // // run through all of the children of the current selection
        // foreach (GameObject g in Selection.gameObjects)
        // {
        //     SwitchSpecies(g, variety);

        //     // and now figure out if we need to switch out children of our selection
        //     if (g.transform.childCount > 0 && includeChildren)
        //         LoopThroughChildren(g, variety);
        // }
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
            trunkOld = newTrunk;
        }
    }

    private void SwitchBark(int newBark)
    {
        if (newBark != barkOld)
        {
            trunkString = newTrunkMeshName = GetNewVersionName(trunkString, 'b', newBark);
            barkOld = newBark;
        }
    }
    #endregion

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





    private void SwitchSpecies(GameObject thisGameObject, int newSpecies)
    {
        // Mesh[] fbxMeshes = GetFBXSource(thisGameObject);
        // int resourceIndex = GetFBXResourceID(thisGameObject);
        // handle the current selection
        MeshFilter mf = thisGameObject.transform.GetComponent<MeshFilter>();
        string oldMeshName;
        string newMeshName;

        // if this gameobject has a mesh filter assigned, handle the swap
        if (mf != null)
        {
            // store the name of this current mesh
            oldMeshName = mf.sharedMesh.name;

            // remove the last character from the name, ie, the version number...add on the version number we want to switch to
            newMeshName = mf.sharedMesh.name.Remove(mf.sharedMesh.name.Length - 1) + newSpecies.ToString();
            Debug.Log(newMeshName);

            // if (oldMeshName != newMeshName)
            // {
            //     // as long as the swap mesh is different , swap it
            //     if (fbxMeshes != null)
            //     {
            //         foreach (Mesh mesh in fbxMeshes)
            //             // run through and find the source mesh we want to switch with
            //             if (mesh.name == newMeshName)// if we find the name of what we want to swap with in the fbx file
            //                 mf.sharedMesh = mesh;// swap meshes
            //     }
            //     else
            //     {

            //     }
            // }



        }

        // if (resourceIndex == 0 && thisGameObject.transform.childCount > 0)
        // {
        //     MeshFilter leavesMF = thisGameObject.transform.GetChild(0).transform.GetComponent<MeshFilter>();

        //     // if this gameobject has a mesh filter assigned, handle the swap
        //     if (leavesMF != null)
        //     {
        //         // store the name of this current mesh
        //         string oldLeavesMeshName = leavesMF.sharedMesh.name;
        //         string newLeavesMeshName = leavesMF.sharedMesh.name.Remove(leavesMF.sharedMesh.name.Length - 1) + newSpecies.ToString();

        //         // if (oldLeavesMeshName != newLeavesMeshName) // as long as the swap mesh is different, swap it
        //         //     foreach (Mesh mesh in fbxMeshes)// run through and find the source mesh we want to switch with
        //         //         if (mesh.name == newLeavesMeshName)// if we find the name of what we want to swap with in the fbx file
        //         //             leavesMF.sharedMesh = mesh;// swap meshes
        //     }



        // }
    }



    private void SwitchMesh(GameObject thisGameObject, int newVersion)
    {
        // Mesh[] fbxMeshes = GetFBXSource(thisGameObject);
        // int resourceIndex = GetFBXResourceID(thisGameObject);

        // handle the current selection
        MeshFilter mf = thisGameObject.transform.GetComponent<MeshFilter>();

        string oldMeshName;
        string newMeshName;
        // if this gameobject has a mesh filter assigned, handle the swap
        if (mf != null)
        {
            // store the name of this current mesh
            oldMeshName = mf.sharedMesh.name;
            // newMeshName = ProcessNewName(resourceIndex, mf);
            // if (oldMeshName != newMeshName) // as long as the swap mesh is different, swap it
            //     if (fbxMeshes != null)
            //         foreach (Mesh mesh in fbxMeshes)// run through and find the source mesh we want to switch with
            //             if (mesh.name == newMeshName)// if we find the name of what we want to swap with in the fbx file
            //                 mf.sharedMesh = mesh;// swap meshes
        }
        else
        {
            //this object doesnt have a mesh filter so lets see if it has any children
            // if (thisGameObject.transform.childCount > 0)
            // {
            //     // collect all of its children
            //     Transform[] allKids = thisGameObject.transform.GetComponentsInChildren<Transform>();
            //     foreach (Transform kid in allKids)
            //         SwitchMesh(kid.gameObject, newVersion);
            // }
        }


    }



    private Mesh[] GetFBXSource(GameObject selObject)
    {
        if (GetFBXResourceID(selObject) != -1)
            return Resources.LoadAll<Mesh>(resourceString[GetFBXResourceID(selObject)]);
        else
            return null;
    }

    private int GetFBXResourceID(GameObject selObject)
    {
        if (selObject.transform.GetComponent<MeshFilter>() != null)
        {
            bool leavesMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_L");
            bool cardMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_Card");
            if (leavesMesh || cardMesh)
                return 1;

            bool trunkMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_trunk");
            if (trunkMesh)
                return 2;

            bool hiPlantMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("HP");
            if (hiPlantMesh)
                return 3;

            bool grassMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Grass");
            if (grassMesh)
                return 4;

            bool flowerMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Flowers");
            if (flowerMesh)
                return 5;

            bool rockMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Rocks");
            if (rockMesh)
                return 6;

            bool scatterMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Scatter");
            if (scatterMesh)
                return 7;

            bool spruceMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Spruce");
            if (spruceMesh)
                return 8;

            return 0;// foliage
        }
        return -1;
    }

    private int GetSpeciesCount(GameObject selObject)
    {
        bool leavesMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_L");
        if (leavesMesh)
            return leavesSpeciesCount;

        bool cardMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_Card");
        if (cardMesh)
            return cardSpeciesCount;

        bool trunkMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_trunk");
        if (trunkMesh)
            return trunkSpeciesCount;

        bool hiPlantMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("HP");
        if (hiPlantMesh)
            return hiPlantSpeciesCount;

        bool grassMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Grasses");
        if (grassMesh)
            return grassSpeciesCount;

        bool flowerMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Flowers");
        if (flowerMesh)
            return flowerSpeciesCount;

        bool rockMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Rocks");
        if (rockMesh)
            return rockrSpeciesCount;

        bool scatterMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Scatter");
        if (scatterMesh)
            return scatterSpeciesCount;

        bool spruceMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Spruce");
        if (spruceMesh)
            return spruceSpeciesCount;

        return foliageSpeciesCount;
    }
    private int GetFBXResourceMeshCount(GameObject selObject)
    {
        bool spruceMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Spruce");
        if (spruceMesh)
            return spruceOptionsCount;

        bool leavesMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_L");
        if (leavesMesh)
            return leavesOptionsCount;

        bool cardMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_Card");
        if (cardMesh)
            return cardOptionsCount;

        bool trunkMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("_trunk");
        if (trunkMesh)
            return trunkOptionsCount;

        bool hiPlantMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("HP");
        if (hiPlantMesh)
            return hiPlantOptionsCount;

        bool grassMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Grasses");
        if (grassMesh)
            return grassOptionsCount;

        bool flowerMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Flowers");
        if (flowerMesh)
            return flowerOptionsCount;

        bool rockMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Rocks");
        if (rockMesh)
            return rockrOptionsCount;

        bool scatterMesh = selObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Scatter");
        if (scatterMesh)
            return scatterOptionsCount;

        return foliageOptionsCount;

    }



    public void SwitchMeshVersion(int newVersion)
    {
        // run through all of the children of the current selection
        foreach (GameObject g in Selection.gameObjects)
            SwitchMesh(g, newVersion);

    }

    public void LoopThroughChildren(GameObject currentGameObj)
    {

        // we know for certain we have children at this point, so loop through them
        // and decide if we need to switch out meshes
        for (int i = 0; i < currentGameObj.transform.childCount; i++)
        {
            //SwitchSpecies(currentGameObj.transform.GetChild(i).gameObject);

            if (currentGameObj.transform.GetChild(i).transform.childCount > 0)
            {
                LoopThroughChildren(currentGameObj.transform.GetChild(i).gameObject);
            }
        }
    }

    public void LoopThroughChildren(GameObject currentGameObj, int newValue)
    {

        // we know for certain we have children at this point, so loop through them
        // and decide if we need to switch out meshes
        for (int i = 0; i < currentGameObj.transform.childCount; i++)
        {
            SwitchSpecies(currentGameObj.transform.GetChild(i).gameObject, newValue);

            if (currentGameObj.transform.GetChild(i).transform.childCount > 0)
            {
                LoopThroughChildren(currentGameObj.transform.GetChild(i).gameObject);
            }
        }
    }




}
#endif