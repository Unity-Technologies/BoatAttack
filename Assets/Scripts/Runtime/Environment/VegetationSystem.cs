using UnityEngine;

namespace BoatAttack
{
    public class VegetationSystem : MonoBehaviour
    {
        private MaterialPropertyBlock _props; // material propery block for instance value setting
        private static readonly int Position = Shader.PropertyToID("_Position");

        void Start()
        {
            _props = new MaterialPropertyBlock();
            SetProperties(transform);
        }

        /// <summary>
        /// Sets the properties for the vegetations shader
        /// </summary>
        /// <param name="t">Transform to use</param>
        private void SetProperties(Transform t)
        {
            foreach (Transform child in t)
            {
                var rend = child.gameObject.GetComponent<MeshRenderer>();
                if (rend)
                {
                    _props.SetVector(Position, child.position);
                    rend.SetPropertyBlock(_props);
                }
                if (child.childCount > 0)
                    SetProperties(child);
            }
        }
    }
}
