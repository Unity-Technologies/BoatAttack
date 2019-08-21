using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.Entities
{
    public class CircularSystemDependencyException : Exception
    {
        public CircularSystemDependencyException(IEnumerable<ComponentSystemBase> chain)
        {
            Chain = chain;
#if NET_DOTS
            var lines = new List<string>();
            Console.WriteLine($"The following systems form a circular dependency cycle (check their [UpdateBefore]/[UpdateAfter] attributes):");
            foreach (var s in Chain)
            {
                int index = TypeManager.GetSystemTypeIndex(s.GetType());
                string name = TypeManager.SystemNames[index];
                Console.WriteLine(name);
            }
#endif
        }

        public IEnumerable<ComponentSystemBase> Chain { get; }

#if !NET_DOTS
        public override string Message
        {
            get
            {
                var lines = new List<string>();
                lines.Add($"The following systems form a circular dependency cycle (check their [UpdateBefore]/[UpdateAfter] attributes):");
                foreach (var s in Chain)
                {
                    lines.Add($"- {s.GetType().ToString()}");
                }
                return lines.Aggregate((str1, str2) => str1 + "\n" + str2);
            }
        }
#endif
    }

    public abstract class ComponentSystemGroup : ComponentSystem
    {
        private bool m_systemSortDirty = false;
        protected List<ComponentSystemBase> m_systemsToUpdate = new List<ComponentSystemBase>();

        public virtual IEnumerable<ComponentSystemBase> Systems => m_systemsToUpdate;

        public void AddSystemToUpdateList(ComponentSystemBase sys)
        {
            if (sys != null)
            {
                if (this == sys)
                {
#if !NET_DOTS
                    throw new ArgumentException($"Can't add {GetType()} to its own update list");
#else
                    throw new ArgumentException($"Can't add a ComponentSystemGroup to its own update list");
#endif
                }

                // Check for duplicate Systems. Also see issue #1792
                if (m_systemsToUpdate.IndexOf(sys) >= 0)
                    return;

                m_systemsToUpdate.Add(sys);
                m_systemSortDirty = true;
            }
        }

        public void RemoveSystemFromUpdateList(ComponentSystemBase sys)
        {
            m_systemsToUpdate.Remove(sys);
            m_systemSortDirty = true;
            m_systemSortDirty = true;
        }

        class Heap<T>
            where T : IComparable<T>
        {
            private T[] _elements;
            private int _size;
            private int _capacity;
            private static readonly int BaseIndex = 1;
            public Heap(int capacity) {
                _capacity = capacity;
                _size = 0;
                _elements = new T[capacity + BaseIndex];
            }
            public bool Empty { get { return _size <= 0; } }
            public void Insert(T e) {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (_size >= _capacity)
                {
                    throw new InvalidOperationException($"Attempted to Insert() to a full heap.");
                }
#endif
                int i = BaseIndex + _size++;
                while (i > BaseIndex) {
                    int parent = i / 2;

                    if (e.CompareTo(_elements[parent]) > 0) {
                        break;
                    }
                    _elements[i] = _elements[parent];
                    i = parent;
                }
                _elements[i] = e;
            }
            public T Peek() {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (Empty)
                {
                    throw new InvalidOperationException($"Attempted to Peek() an empty heap.");
                }
#endif
                return _elements[BaseIndex];
            }
            public T Extract() {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (Empty)
                {
                    throw new InvalidOperationException($"Attempted to Extract() from an empty heap.");
                }
#endif
                T top = _elements[BaseIndex];
                _elements[BaseIndex] = _elements[_size--];
                if (!Empty) {
                    Heapify(BaseIndex);
                }
                return top;
            }
            private void Heapify(int i) {
                // The index taken by this function is expected to be already biased by BaseIndex.
                // Thus, m_Heap[size] is a valid element (specifically, the final element in the heap)
                //Debug.Assert(i >= BaseIndex && i < (_size+BaseIndex), $"heap index {i} is out of range with size={_size}");
                T val = _elements[i];
                while (i <= _size / 2) {
                    int child = 2 * i;
                    if (child < _size && _elements[child + 1].CompareTo(_elements[child]) < 0) {
                        child++;
                    }
                    if (val.CompareTo(_elements[child]) < 0) {
                        break;
                    }
                    _elements[i] = _elements[child];
                    i = child;
                }
                _elements[i] = val;
            }
        }

        struct SysAndDep
        {
            public ComponentSystemBase system;
            public List<Type> updateBefore;
            public int nAfter;
        }
        public struct TypeHeapElement : IComparable<TypeHeapElement>
        {
            private string typeName;
            public int unsortedIndex;

            public TypeHeapElement(int index, Type t)
            {
                unsortedIndex = index;
                typeName = TypeManager.SystemName(t);
            }
            public int CompareTo(TypeHeapElement other)
            {
#if NET_DOTS
                // Workaround for missing string.CompareTo() in HPC#. This is not a fully compatible substitute,
                // but should be suitable for comparing system names.
                if (typeName.Length < other.typeName.Length)
                    return -1;
                if (typeName.Length > other.typeName.Length)
                    return 1;
                for (int i = 0; i < typeName.Length; ++i)
                {
                    if (typeName[i] < other.typeName[i])
                        return -1;
                    if (typeName[i] > other.typeName[i])
                        return 1;
                }
                return 0;
#else
                return typeName.CompareTo(other.typeName);
#endif
            }
        }

        // Tiny doesn't have a data structure that can take Type as a key.
        // For now, this gives Tiny a linear search. Would like to do better.
#if !NET_DOTS
        private Dictionary<Type, int> lookupDictionary = null;

        private int LookupSysAndDep(Type t, SysAndDep[] array) {
            if (lookupDictionary == null) {
                lookupDictionary = new Dictionary<Type, int>();
                for(int i=0; i<array.Length; ++i) {
                    lookupDictionary[array[i].system.GetType()] = i;
                }
            }
            if (lookupDictionary.ContainsKey(t))
               return lookupDictionary[t];
            return -1;
        }
#else
        private int LookupSysAndDep(Type t, SysAndDep[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].system != null && array[i].system.GetType() == t)
                {
                    return i;
                }
            }
            return -1;
        }
#endif

        public virtual void SortSystemUpdateList()
        {
            if (!m_systemSortDirty)
                return;
            m_systemSortDirty = false;
#if !NET_DOTS
            lookupDictionary = null;
#endif
            // Populate dictionary mapping systemType to system-and-before/after-types.
            // This is clunky - it is easier to understand, and cleaner code, to
            // just use a Dictionary<Type, SysAndDep>. However, Tiny doesn't currently have
            // the ability to use Type as a key to a NativeHash, so we're stuck until that gets addressed.
            //
            // Likewise, this is important shared code. It can be done cleaner with 2 versions, but then...
            // 2 sets of bugs and slightly different behavior will creep in.
            //
            var sysAndDep = new SysAndDep[m_systemsToUpdate.Count];

            for(int i=0; i<m_systemsToUpdate.Count; ++i)
            {
                var sys = m_systemsToUpdate[i];
                if (TypeManager.IsSystemAGroup(sys.GetType()))
                {
                    (sys as ComponentSystemGroup).SortSystemUpdateList();
                }
                sysAndDep[i] = new SysAndDep
                {
                    system = sys,
                    updateBefore = new List<Type>(),
                    nAfter = 0,
                };
            }
            for(int i=0; i<m_systemsToUpdate.Count; ++i)
            {
                var sys = m_systemsToUpdate[i];
                var before = TypeManager.GetSystemAttributes(sys.GetType(), typeof(UpdateBeforeAttribute));
                var after = TypeManager.GetSystemAttributes(sys.GetType(), typeof(UpdateAfterAttribute));
                foreach (var attr in before)
                {
                    var dep = attr as UpdateBeforeAttribute;
                    if (!typeof(ComponentSystemBase).IsAssignableFrom(dep.SystemType))
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateBefore] attribute on {sys.GetType()} because {dep.SystemType} is not a subclass of {nameof(ComponentSystemBase)}.\n"
                            + $"Set the target parameter of [UpdateBefore] to a system class in the same {nameof(ComponentSystemGroup)} as {sys.GetType()}.");
#else
                        Debug.LogWarning($"WARNING: invalid [UpdateBefore] attribute:");
                        Debug.LogWarning(TypeManager.SystemName(dep.SystemType));
                        Debug.LogWarning(" is not derived from ComponentSystemBase. Set the target parameter of [UpdateBefore] to a system class in the same ComponentSystemGroup.");
#endif
                        continue;
                    }
                    if (dep.SystemType == sys.GetType())
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateBefore] attribute on {sys.GetType()} because a system cannot be updated before itself.\n"
                            + $"Set the target parameter of [UpdateBefore] to a different system class in the same {nameof(ComponentSystemGroup)} as {sys.GetType()}.");
#else
                        Debug.LogWarning($"WARNING: invalid [UpdateBefore] attribute:");
                        Debug.LogWarning(TypeManager.SystemName(sys.GetType()));
                        Debug.LogWarning("  depends on itself. Set the target parameter of [UpdateBefore] to a system class in the same ComponentSystemGroup.");
#endif
                        continue;
                    }
                    int depIndex = LookupSysAndDep(dep.SystemType, sysAndDep);
                    if (depIndex < 0)
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateBefore] attribute on {sys.GetType()} because {dep.SystemType} belongs to a different {nameof(ComponentSystemGroup)}.\n"
                            + $"This attribute can only order systems that are children of the same {nameof(ComponentSystemGroup)}.\n"
                            + $"Make sure that both systems are in the same parent group with [UpdateInGroup(typeof({GetType()})].\n"
                            + $"You can also change the relative order of groups when appropriate, by using [UpdateBefore] and [UpdateAfter] attributes at the group level.");
#else
                        Debug.LogWarning("WARNING: invalid [UpdateBefore] dependency:");
                        Debug.LogWarning(TypeManager.SystemName(sys.GetType()));
                        Debug.LogWarning("  depends on a non-sibling system: ");
                        Debug.LogWarning(TypeManager.SystemName(dep.SystemType));
#endif
                        continue;
                    }

                    sysAndDep[i].updateBefore.Add(dep.SystemType);
                    sysAndDep[depIndex].nAfter++;
                }
                foreach (var attr in after)
                {
                    var dep = attr as UpdateAfterAttribute;
                    if (!typeof(ComponentSystemBase).IsAssignableFrom(dep.SystemType))
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateAfter] attribute on {sys.GetType()} because {dep.SystemType} is not a subclass of {nameof(ComponentSystemBase)}.\n"
                            + $"Set the target parameter of [UpdateAfter] to a system class in the same {nameof(ComponentSystemGroup)} as {sys.GetType()}.");
#else
                        Debug.LogWarning($"WARNING: invalid [UpdateAfter] attribute:");
                        Debug.LogWarning(TypeManager.SystemName(dep.SystemType));
                        Debug.LogWarning(" is not derived from ComponentSystemBase. Set the target parameter of [UpdateAfter] to a system class in the same ComponentSystemGroup.");
#endif
                        continue;
                    }
                    if (dep.SystemType == sys.GetType())
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateAfter] attribute on {sys.GetType()} because a system cannot be updated after itself.\n"
                            + $"Set the target parameter of [UpdateAfter] to a different system class in the same {nameof(ComponentSystemGroup)} as {sys.GetType()}.");
#else
                        Debug.LogWarning($"WARNING: invalid [UpdateAfter] attribute:");
                        Debug.LogWarning(TypeManager.SystemName(sys.GetType()));
                        Debug.LogWarning("  depends on itself. Set the target parameter of [UpdateAfter] to a system class in the same ComponentSystemGroup.");
#endif
                        continue;
                    }
                    int depIndex = LookupSysAndDep(dep.SystemType, sysAndDep);
                    if (depIndex < 0)
                    {
#if !NET_DOTS
                        Debug.LogWarning(
                            $"Ignoring invalid [UpdateAfter] attribute on {sys.GetType()} because {dep.SystemType} belongs to a different {nameof(ComponentSystemGroup)}.\n"
                            + $"This attribute can only order systems that are children of the same {nameof(ComponentSystemGroup)}.\n"
                            + $"Make sure that both systems are in the same parent group with [UpdateInGroup(typeof({GetType()})].\n"
                            + $"You can also change the relative order of groups when appropriate, by using [UpdateBefore] and [UpdateAfter] attributes at the group level.");
#else
                        Debug.LogWarning("WARNING: invalid [UpdateAfter] dependency:");
                        Debug.LogWarning(TypeManager.SystemName(sys.GetType()));
                        Debug.LogWarning("  depends on a non-sibling system: ");
                        Debug.LogWarning(TypeManager.SystemName(dep.SystemType));
#endif
                        continue;
                    }
                    sysAndDep[depIndex].updateBefore.Add(sys.GetType());
                    sysAndDep[i].nAfter++;
                }
            }

            // Clear the systems list and rebuild it in sorted order from the lookup table
            var readySystems = new Heap<TypeHeapElement>(m_systemsToUpdate.Count);
            m_systemsToUpdate.Clear();
            for (int i = 0; i < sysAndDep.Length; ++i)
            {
                if (sysAndDep[i].nAfter == 0)
                {
                    readySystems.Insert(new TypeHeapElement(i, sysAndDep[i].system.GetType()));
                }
            }
            while (!readySystems.Empty)
            {
                int sysIndex = readySystems.Extract().unsortedIndex;
                SysAndDep sd = sysAndDep[sysIndex];
                Type sysType = sd.system.GetType();

                sysAndDep[sysIndex] = new SysAndDep();  // "Remove()"
                m_systemsToUpdate.Add(sd.system);
                foreach (var beforeType in sd.updateBefore)
                {
                    int beforeIndex = LookupSysAndDep(beforeType, sysAndDep);
                    if (beforeIndex <  0) throw new Exception("Bug in SortSystemUpdateList(), beforeIndex < 0");
                    if (sysAndDep[beforeIndex].nAfter <= 0) throw new Exception("Bug in SortSystemUpdateList(), nAfter <= 0");

                    sysAndDep[beforeIndex].nAfter--;
                    if (sysAndDep[beforeIndex].nAfter == 0)
                    {
                        readySystems.Insert(new TypeHeapElement(beforeIndex, sysAndDep[beforeIndex].system.GetType()));
                    }
                }
            }

            for(int i=0; i<sysAndDep.Length; ++i)
            {
                if (sysAndDep[i].system != null)
                {
                    // Since no System in the circular dependency would have ever been added
                    // to the heap, we should have values for everything in sysAndDep. Check,
                    // just in case.
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    var visitedSystems = new List<ComponentSystemBase>();
                    var startIndex = i;
                    var currentIndex = i;
                    while (true)
                    {
                        if (sysAndDep[currentIndex].system != null)
                            visitedSystems.Add(sysAndDep[currentIndex].system);

                        currentIndex = LookupSysAndDep(sysAndDep[currentIndex].updateBefore[0], sysAndDep);
                        if (currentIndex < 0 || currentIndex == startIndex || sysAndDep[currentIndex].system == null)
                        {
                            throw new CircularSystemDependencyException(visitedSystems);
                        }
                    }
#else
                    sysAndDep[i] = new SysAndDep();
#endif
                }
            }
        }


#if NET_DOTS
        public void RecursiveLogToConsole()
        {
            foreach (var sys in m_systemsToUpdate)
            {
                if (sys is ComponentSystemGroup)
                {
                    (sys as ComponentSystemGroup).RecursiveLogToConsole();
                }

                var index = TypeManager.GetSystemTypeIndex(sys.GetType());
                var names = TypeManager.SystemNames;
                var name = names[index];
                Debug.Log(name);
            }
        }

#endif

        protected override void OnUpdate()
        {
            if (m_systemSortDirty)
                SortSystemUpdateList();

            foreach (var sys in m_systemsToUpdate)
            {
                try
                {
                    sys.Update();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
                if (World.QuitUpdate)
                    break;
            }
        }
    }
}
