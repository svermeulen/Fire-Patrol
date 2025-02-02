using System;
using System.Collections.Generic;
using UnityEngine;

namespace FirePatrol
{
    [Serializable]
    public class TilePrefabLink
    {
        public int PrefabIndex;
        public float Rotation;
    }

    [Serializable]
    public class TilePrefabVariations
    {
        public int PrefabIndex;
        public List<GameObject> Prefabs;
    }

    [Serializable]
    public class PropInfo
    {
        public PropType PropType;
        public List<GameObject> Prefabs;
        public float ScaleMin = 1.0f;
        public float ScaleMax = 1.0f;
        public float MinDistanceToOtherProps = 0.5f;
    }

    [Serializable]
    public class TileSettings
    {
        public List<TilePrefabLink> GrassPrefabLinks;
        public TilePrefabVariations[] GrassPrefabVariations;
        public PropInfo[] PropPrefabs;
    }

    // [CreateAssetMenu(fileName = "LevelEditorSettings", menuName = "level editor settings")]
    public class LevelEditorSettings : ScriptableObject
    {
        public TileSettings TileSettings;

        static LevelEditorSettings _instance;
        static bool _hasLoaded;

        public static LevelEditorSettings Instance
        {
            get
            {
                if (!_hasLoaded)
                {
                    _hasLoaded = true;
                    _instance = Load();
                }

                return _instance;
            }
        }

        private static LevelEditorSettings Load()
        {
            var instance = (LevelEditorSettings)Resources.Load("FirePatrol/LevelEditorSettings");

            if (instance == null)
            {
                instance = ScriptableObject.CreateInstance<LevelEditorSettings>();
            }

            return instance;
        }
    }
}
