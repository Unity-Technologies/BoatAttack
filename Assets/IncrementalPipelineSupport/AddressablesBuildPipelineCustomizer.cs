using System;
using System.IO;
using System.Linq;
using Unity.Build.Classic;
using UnityEngine.AddressableAssets;



public class AddressablesBuildPipelineCustomizer : ClassicBuildPipelineCustomizer
{
    public override void RegisterAdditionalFilesToDeploy(Action<string, string> registerAdditionalFileToDeploy)
    {
        if (!Directory.Exists(Addressables.BuildPath))
            return;

        var buildPath = Addressables.BuildPath;
        var relativeRoot = Path.GetDirectoryName(Path.GetDirectoryName(buildPath));
        var fileToCopies = Directory.GetFiles(buildPath, "*.*", SearchOption.AllDirectories).ToArray();
        foreach (var fileToCopy in fileToCopies)
        {
            var relative = fileToCopy.Substring(relativeRoot.Length+1);
            var targetFile = $"{StreamingAssetsDirectory}/{relative}";
            registerAdditionalFileToDeploy(fileToCopy, targetFile);
        }
    }
}
