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

    private int variety, seasonal, age, trunk, roots, ivy, vines, bark, lichen;
    private int varietyOld, seasonalOld, ageOld, trunkOld, rootsOld, ivyOld, vinesOld, barkOld, lichenOld;

    string foliageString = "lf_v01_s01_a01";
    string trunkString = "k_b01_t01_l01_r01";
    string extrasString = "ex_i01_v01";

    public static void ShowWindow()
    {
        EditorWindow editorWindow = EditorWindow.GetWindow(typeof(TM_ChangeMesh));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.Show();
        editorWindow.titleContent = new GUIContent("Change Mesh");

    }


    void OnGUI()
    {
        GUILayout.BeginVertical("box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        EditorGUILayout.Space();
        if (Selection.activeGameObject)
        {
            MeshFilter selMf = Selection.activeGameObject.transform.GetComponent<MeshFilter>();
            if (selMf)
            {
                // verify that we are selected on A TreeMaster Mesh before running any of the following methods
                if (!isTreeMasterMesh())
                {
                    GUILayout.Label("Not a TreeMaster Mesh", EditorStyles.boldLabel);
                    EditorGUILayout.Space();
                }

                //int initialVersion = int.Parse(selMf.sharedMesh.name.Last().ToString());
                // GUILayout.Label("Switch Species on Selected", EditorStyles.boldLabel);
                // includeChildren = EditorGUILayout.Toggle("Include Children?", includeChildren);
                //speciesVersion = initialVersion;
                GUILayout.Label("Foliage:", EditorStyles.boldLabel);
                variety = EditorGUILayout.IntSlider("Variety", variety, 1, 16);
                SwitchVariety(variety);
                seasonal = EditorGUILayout.IntSlider("Season", seasonal, 1, 8);
                SwitchSeason(seasonal);
                age = EditorGUILayout.IntSlider("Age", age, 1, 8);
                SwitchAge(age);
                EditorGUILayout.Space();

                GUILayout.Label("Trunk:", EditorStyles.boldLabel);
                bark = EditorGUILayout.IntSlider("Bark", bark, 1, 8);
                SwitchBark(bark);
                trunk = EditorGUILayout.IntSlider("Trunk", trunk, 1, 8);
                SwitchTrunk(trunk);
                lichen = EditorGUILayout.IntSlider("Lichen", lichen, 1, 8);
                SwitchLichen(lichen);
                roots = EditorGUILayout.IntSlider("Roots", roots, 1, 8);
                SwitchRoots(roots);

                EditorGUILayout.Space();
                GUILayout.Label("Extras:", EditorStyles.boldLabel);
                ivy = EditorGUILayout.IntSlider("Ivy", ivy, 1, 8);
                SwitchIvy(ivy);
                vines = EditorGUILayout.IntSlider("Vines", vines, 1, 8);
                SwitchVines(vines);


                // }
                EditorGUILayout.Space();

                GUILayout.Label("Export", EditorStyles.boldLabel);

                if (GUILayout.Button("Save this tree preset", GUILayout.ExpandWidth(false)))
                    Debug.Log("Exporting new tree...");


            }
            else
            {
                GUILayout.Label("No Mesh Filter on Selected", EditorStyles.boldLabel);
            }
        }
        else
        {
            GUILayout.Label("Select something to see your options", EditorStyles.boldLabel);
        }

        GUILayout.EndVertical();
    }

    private void SwitchVines(int newVines)
    {
        string newName;
        if (newVines != vinesOld)
        {
            extrasString = newName = GetNewVersionName(extrasString, 'v', newVines);
            Debug.Log("Vines: " + newName);
            vinesOld = newVines;
        }
    }

    private void SwitchIvy(int newIvy)
    {
        string newName;
        if (newIvy != ivyOld)
        {
            extrasString = newName = GetNewVersionName(extrasString, 'i', newIvy);
            //Debug.Log("Ivy: " + newName);
            ivyOld = newIvy;
        }
    }

    private void SwitchRoots(int newRoots)
    {
        string newName;
        if (newRoots != rootsOld)
        {
            trunkString = newName = GetNewVersionName(trunkString, 'r', newRoots);
            Debug.Log("Roots: " + newName);
            rootsOld = newRoots;
        }
    }

    private void SwitchLichen(int newLichen)
    {
        string newName;
        if (newLichen != lichenOld)
        {
            trunkString = newName = GetNewVersionName(trunkString, 'l', newLichen);
            //Debug.Log("Lichen: " + newName);
            lichenOld = newLichen;
        }
    }

    private void SwitchTrunk(int newTrunk)
    {
        string newName;
        if (newTrunk != trunkOld)
        {
            trunkString = newName = GetNewVersionName(trunkString, 't', newTrunk);
            //Debug.Log("Trunk: " + newName);
            trunkOld = newTrunk;
        }
    }

    private void SwitchBark(int newBark)
    {
        string newName;
        if (newBark != barkOld)
        {
            trunkString = newName = GetNewVersionName(trunkString, 'b', newBark);
            //Debug.Log("Bark: " + newName);
            barkOld = newBark;
        }
    }

    private void SwitchAge(int newAge)
    {
        string newName;
        if (newAge != ageOld)
        {
            foliageString = newName = GetNewVersionName(foliageString, 'a', newAge);
            Debug.Log("Age: " + newName);
            ageOld = newAge;
        }
    }

    private void SwitchSeason(int newSeason)
    {
        string newName;
        if (newSeason != seasonalOld)
        {
            foliageString = newName = GetNewVersionName(foliageString, 's', newSeason);
            //Debug.Log("Season: " + newName);
            seasonalOld = newSeason;
        }
    }
    public void SwitchVariety(int newVariety)
    {
        string newName;
        if (newVariety != varietyOld)
        {
            foliageString = newName = GetNewVersionName(foliageString, 'v', newVariety);
            //Debug.Log("Variety: " + newName);
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

    string GetNewVersionName(string inputString, char splitChar, int newVersion)
    {
        string[] split = inputString.Split(splitChar);
        string removed;
        removed = split[1].Remove(0, 2);
        //add in the new variety
        string newVarietyString = newVersion + removed;
        //determine if we need to add a zero
        string finalName;
        if (variety < 10)
            finalName = split[0] + splitChar + "0" + newVarietyString;
        else
            finalName = split[0] + splitChar + newVarietyString;

        return finalName;
    }


    private bool isTreeMasterMesh()
    {
        return (GetFoliageType("TM_leaf") || GetFoliageType("TM_trunk") || GetFoliageType("TM_extra"));
    }


    ///<summary>Check to see if the passed string matches what the meshfilter mesh name starts with. </summary>
    private bool GetFoliageType(string nameCompare)
    {
        if (Selection.activeGameObject.transform.GetComponent<MeshFilter>() != null)
            return Selection.activeGameObject.transform.GetComponent<MeshFilter>().sharedMesh.name.StartsWith(nameCompare);
        else return false;
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

        // now check to see if this is a foliage mesh, which means we also will need to update the leaves mesh child IF there is one
        // if (resourceIndex == 0 && thisGameObject.transform.childCount > 0)
        // {
        //     MeshFilter leavesMF = thisGameObject.transform.GetChild(0).transform.GetComponent<MeshFilter>();
        //     string oldLeavesMeshName;
        //     string newLeavesMeshName;
        //     // if this gameobject has a mesh filter assigned, handle the swap
        //     if (leavesMF != null)
        //     {
        //         // store the name of this current mesh
        //         oldLeavesMeshName = leavesMF.sharedMesh.name;
        //         char currentSpeciesVersion = oldLeavesMeshName[oldLeavesMeshName.Length - 1];
        //         newLeavesMeshName = leavesMF.sharedMesh.name.Remove(leavesMF.sharedMesh.name.Length - 4) + newVersion.ToString() + "_v" + currentSpeciesVersion;

        //         // handle whether we add the boost foliage or remove it
        //         if (addFoliageBranch)
        //         {
        //             thisGameObject.transform.GetChild(0).transform.GetComponent<MeshRenderer>().enabled = true;
        //             removeFoliageBranch = false;
        //             addFoliageBranch = false;
        //         }

        //         if (removeFoliageBranch)
        //         {
        //             thisGameObject.transform.GetChild(0).transform.GetComponent<MeshRenderer>().enabled = false;
        //             removeFoliageBranch = false;
        //             addFoliageBranch = false;
        //         }


        //         if (boostFoliageBranch)
        //         {
        //             // if we have already boosted it, just change the mesh
        //             if (newLeavesMeshName.Contains("c2_") || newLeavesMeshName.Contains("y2_") || newLeavesMeshName.Contains("n2_") || newLeavesMeshName.Contains("e2_"))
        //                 newLeavesMeshName = newLeavesMeshName.Remove(newLeavesMeshName.Length - 6) + "2_" + newVersion.ToString() + "_v" + currentSpeciesVersion;
        //             else // boost it and change the mesh
        //                 newLeavesMeshName = newLeavesMeshName.Remove(newLeavesMeshName.Length - 5) + "2_" + newVersion.ToString() + "_v" + currentSpeciesVersion;



        //         }
        //         else
        //         {
        //             // we dont want to boost foliage so we need to set it back to its original state
        //             // but first check to see if it HAS been boosted
        //             if (newLeavesMeshName.Contains("c2_") || newLeavesMeshName.Contains("y2_") || newLeavesMeshName.Contains("n2_") || newLeavesMeshName.Contains("e2_"))
        //                 newLeavesMeshName = newLeavesMeshName.Remove(newLeavesMeshName.Length - 6) + "_" + newVersion.ToString() + "_v" + currentSpeciesVersion;
        //         }


        //         if (oldLeavesMeshName != newLeavesMeshName) // as long as the swap mesh is different, swap it
        //             foreach (Mesh mesh in fbxMeshes)// run through and find the source mesh we want to switch with
        //                 if (mesh.name == newLeavesMeshName)// if we find the name of what we want to swap with in the fbx file
        //                     leavesMF.sharedMesh = mesh;// swap meshes
        //     }



        //}
    }


    private string ProcessNewName(int resourceIndex, MeshFilter meshFilter)
    {
        // get the current mesh name
        string MeshName = meshFilter.sharedMesh.name;
        // grab the species version currently being used
        char currentSpeciesVersion = MeshName[MeshName.Length - 1];

        string newName;

        // foliage cases
        if (resourceIndex < 2 || resourceIndex == 8)
        {
            newName = meshFilter.sharedMesh.name.Remove(meshFilter.sharedMesh.name.Length - 4) + meshVersion.ToString() + "_v" + currentSpeciesVersion;
        }
        else if (resourceIndex == 2 || resourceIndex == 6 || resourceIndex == 7)// trunk or rocks
        {
            string zeroedMeshVersion = meshVersion < 10 ? "0" + meshVersion.ToString() : meshVersion.ToString();
            newName = meshFilter.sharedMesh.name.Remove(meshFilter.sharedMesh.name.Length - 5) + zeroedMeshVersion + "_v" + currentSpeciesVersion;

        }


        else// everything else
        {
            string zeroedMeshVersion = meshVersion < 10 ? "0" + meshVersion.ToString() : meshVersion.ToString();
            newName = meshFilter.sharedMesh.name.Remove(meshFilter.sharedMesh.name.Length - 2) + zeroedMeshVersion;

        }
        return newName;
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