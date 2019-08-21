using Unity.Properties;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    [CustomEditor(typeof(EntitySelectionProxy))]
    internal class EntitySelectionProxyEditor : UnityEditor.Editor
    {
        private EntityIMGUIVisitor visitor;
        private readonly RepaintLimiter repaintLimiter = new RepaintLimiter();

        [SerializeField] private SystemInclusionList inclusionList;

        void OnEnable()
        {
            visitor = new EntityIMGUIVisitor((entity) =>
                {
                    var targetProxy = (EntitySelectionProxy) target;
                    if (!targetProxy.Exists)
                        return;
                    targetProxy.OnEntityControlDoubleClick(entity);
                });

            inclusionList = new SystemInclusionList();
        }

        private uint lastVersion;

        private uint GetVersion()
        {
            var container = target as EntitySelectionProxy;
            return container.World.EntityManager.GetChunkVersionHash(container.Entity);
        }

        public override void OnInspectorGUI()
        {
            var targetProxy = (EntitySelectionProxy) target;
            if (!targetProxy.Exists)
                return;

            var container = targetProxy.Container;

            PropertyContainer.Visit(ref container, visitor);

            GUI.enabled = true;

            inclusionList.OnGUI(targetProxy.World, targetProxy.Entity);

            repaintLimiter.RecordRepaint();
            lastVersion = GetVersion();
        }

        public override bool RequiresConstantRepaint()
        {
            return (GetVersion() != lastVersion) && (repaintLimiter.SimulationAdvanced() || !Application.isPlaying);
        }
    }
}
