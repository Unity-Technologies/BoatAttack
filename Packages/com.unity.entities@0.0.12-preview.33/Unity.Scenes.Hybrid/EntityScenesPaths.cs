using System;
using System.IO;
using UnityEngine;
using Hash128 = Unity.Entities.Hash128;

namespace Unity.Scenes
{
    class EntityScenesPaths
    {
        public static string GetPath(Hash128 sceneGUID, PathType type, string subsectionName)
        {
            if (sceneGUID == new Hash128())
                return "";

            string sceneName = sceneGUID.ToString();
            if (!String.IsNullOrEmpty(subsectionName))
                sceneName += "_" + subsectionName;
    
            if (type == PathType.EntitiesSharedComponents)
                return "Assets/EntityCache/Resources/" + sceneName + "_shared.prefab";
            if (type == PathType.EntitiesHeader)
                return "Assets/EntityCache/Resources/" + sceneName + "_header.asset";
            if (type == PathType.EntitiesBinary)
                return "Assets/StreamingAssets/EntityCache/" + sceneName + ".entities";
            throw new ArgumentException();
        }

        public static string GetPathAndCreateDirectory(Hash128 sceneGUID, PathType type, string subsectionName)
        {
            var path = GetPath(sceneGUID, type, subsectionName);
            if (String.IsNullOrEmpty(path))
                return "";
    
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
    
            return path;
        }

        public enum PathType
        {
            EntitiesSharedComponents,
            EntitiesBinary,
            EntitiesHeader
        }

        public static string GetLoadPath(Hash128 sceneGUID, PathType type, int sectionIndex)
        {
            if (type == PathType.EntitiesSharedComponents)
                return $"{sceneGUID}_{sectionIndex}_shared";
            else if (type == PathType.EntitiesHeader)
                return GetPath(sceneGUID, type, "");

            var path = GetPath(sceneGUID, type, sectionIndex.ToString());

            if (type == PathType.EntitiesBinary)
                return Application.streamingAssetsPath + "/EntityCache/" + Path.GetFileName(path);
            else if (type == PathType.EntitiesSharedComponents)
                return Path.GetFileNameWithoutExtension(path);
            else
                return path;
        }
    }
}
