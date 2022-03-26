using UnityEngine;

namespace I2.Loc
{
    public class RegisterBundlesManager : MonoBehaviour, IResourceManager_Bundles
	{
		public void OnEnable()
		{
            if (!ResourceManager.pInstance.mBundleManagers.Contains(this))
            {
                ResourceManager.pInstance.mBundleManagers.Add(this);
            }
		}

        public void OnDisable()
        {
            ResourceManager.pInstance.mBundleManagers.Remove(this);
        }

        public virtual Object LoadFromBundle(string path, System.Type assetType)
        {
            // load from a bundle using path and return the object
            return null;
        }
}


    // To use bundles, create a class similar to this one
    // and add it to one of your scenes
    //
    
    /*public class CustomBundlesManager : RegisterBundlesManager
    {
        public override Object LoadFromBundle(string path, System.Type assetType )
        {
            // load from a bundle using path and return the object
            return null;
        }
    }
    */
}