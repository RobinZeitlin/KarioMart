using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneChooser", order = 1)]
public class S_scriptableScenes : ScriptableObject
{
        public List<string> sceneList = new List<string>();
}
