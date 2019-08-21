# Change log


## [0.0.12-preview.33] - 2019-05-24

### New Features

* `[DisableAutoCreation]` can now apply to entire assemblies, which will cause all systems contained within to be excluded from automatic system creation. Useful for test assemblies.
* Added `ComponentSystemGroup.RemoveSystemFromUpdateList()`
* `EntityCommandBuffer` has commands for adding/removing components, deleting entities and adding shared components based on an EntityQuery and its filter. Not available in the `Concurrent` version

### Changes

* Generic component data types must now be registered in advance. Use [RegisterGenericComponentType] attribute to register each concrete use. e.g. `[assembly: RegisterGenericComponentType(typeof(TypeManagerTests.GenericComponent<int>))]` 
* Attempting to call `Playback()` more than once on the same EntityCommandBuffer will now throw an error.
* Improved error checking for `[UpdateInGroup]`, `[UpdateBefore]`, and `[UpdateAfter]` attributes
* TypeManager no longer imposes alignment requirements on components containing pointers. Instead, it now throws an exception if you try to serialize a blittable component containing an unmanaged pointer, which suggests different alternatives.

### Fixes

* Fixed regression where accessing and destroying a blob asset in a burst job caused an exception
* Fixed bug where entities with manually specified `CompositeScale` were not updated by `TRSLocalToWorldSystem`.
* Error message when passing in invalid parameters to CreateSystem() is improved.
* Fixed bug where an exception due to aggressive pointer restrictions could leave the `TypeManager` in an invalid state
* SceneBoundingVolume is now generated seperately for each subsection
* SceneBoundingVolume no longer throws exceptions in conversion flow
* Fixed regression where calling AddComponent(NativeArray<Entity> entities, ComponentType componentType) could cause a crash.

## [0.0.12-preview.32] - 2019-05-16

### New Features

* Added BlobBuilder which is a new API to build Blob Assets that does not require preallocating one contiguous block of memory. The BlobAllocator is now marked obsolete.
* Added versions of `IJobForEach` that support `DynamicBuffer`s
  * Due to C# language constraints, these overloads needed different names. The format for these overloads follows the following structure:
    * All job names begin with either `IJobForEach` or `IJobForEachEntity`
    * All jobs names are then followed by an underscore `_` and a combination of letter corresponding to the parameter types of the job
      * `B` - `IBufferElementData`
      * `C` - `IComponentData`
      * `E` - `Entity` (`IJobForEachWithEntity` only)
    * All suffixes for `WithEntity` jobs begin with `E`
    * All data types in a suffix are in alphabetical order
  * Here is the complete list of overloads:
    * `IJobForEach_C`, `IJobForEach_CC`, `IJobForEach_CCC`, `IJobForEach_CCCC`, `IJobForEach_CCCCC`, `IJobForEach_CCCCCC`
    * `IJobForEach_B`, `IJobForEach_BB`, `IJobForEach_BBB`, `IJobForEach_BBBB`, `IJobForEach_BBBBB`, `IJobForEach_BBBBBB`
    * `IJobForEach_BC`, `IJobForEach_BCC`, `IJobForEach_BCCC`, `IJobForEach_BCCCC`, `IJobForEach_BCCCCC`, `IJobForEach_BBC`, `IJobForEach_BBCC`, `IJobForEach_BBCCC`, `IJobForEach_BBCCCC`, `IJobForEach_BBBC`, `IJobForEach_BBBCC`, `IJobForEach_BBBCCC`, `IJobForEach_BBBCCC`, `IJobForEach_BBBBC`, `IJobForEach_BBBBCC`, `IJobForEach_BBBBBC`
    * `IJobForEachWithEntity_EB`, `IJobForEachWithEntity_EBB`, `IJobForEachWithEntity_EBBB`, `IJobForEachWithEntity_EBBBB`, `IJobForEachWithEntity_EBBBBB`, `IJobForEachWithEntity_EBBBBBB`
    * `IJobForEachWithEntity_EC`, `IJobForEachWithEntity_ECC`, `IJobForEachWithEntity_ECCC`, `IJobForEachWithEntity_ECCCC`, `IJobForEachWithEntity_ECCCCC`, `IJobForEachWithEntity_ECCCCCC`
    * `IJobForEachWithEntity_BC`, `IJobForEachWithEntity_BCC`, `IJobForEachWithEntity_BCCC`, `IJobForEachWithEntity_BCCCC`, `IJobForEachWithEntity_BCCCCC`, `IJobForEachWithEntity_BBC`, `IJobForEachWithEntity_BBCC`, `IJobForEachWithEntity_BBCCC`, `IJobForEachWithEntity_BBCCCC`, `IJobForEachWithEntity_BBBC`, `IJobForEachWithEntity_BBBCC`, `IJobForEachWithEntity_BBBCCC`, `IJobForEachWithEntity_BBBCCC`, `IJobForEachWithEntity_BBBBC`, `IJobForEachWithEntity_BBBBCC`, `IJobForEachWithEntity_BBBBBC`
    * Note that you can still use `IJobForEach` and `IJobForEachWithEntity` as before if you're using only `IComponentData`.
* EntityManager.SetEnabled API automatically enables & disables an entity or set of entities. If LinkedEntityGroup is present the whole group is enabled / disabled. Inactive game objects automatically get a LinkedEntityGroup added so that EntityManager.SetEnabled works as expected out of the box.
* Add `WithAnyReadOnly` and `WithAllReadyOnly` methods to EntityQueryBuilder to specify queries that filter on components with access type ReadOnly.
* No longer throw when the same type is in a WithAll and ForEach delegate param for ForEach queries.
* `DynamicBuffer` CopyFrom method now supports another DynamicBuffer as a parameter.
* Fixed cases that would not be handled correctly by the api updater.

### Upgrade guide

* Usages of BlobAllocator will need to be changed to use BlobBuilder instead. The API is similar but Allocate now returns the data that can be populated:

  ```csharp
    ref var root = ref builder.ConstructRoot<MyData>();
    var floatArray = builder.Allocate(3, ref root.floatArray);
    floatArray[0] = 0; // root.floatArray[0] can not be used and will throw on access
  ```

* ISharedComponentData with managed fields must implement IEquatable and GetHashCode
* IComponentData and ISharedComponentData implementing IEquatable must also override GetHashCode

### Fixes

* Comparisons of managed objects (e.g. in shared components) now work as expected
* Prefabs referencing other prefabs are now supported in game object entity conversion process
* Fixed a regression where ComponentDataProxy was not working correctly on Prefabs due to a ordering issue.
* Exposed GameObjectConversionDeclarePrefabsGroup for declaring prefab references. (Must happen before any conversion systems run)
* Inactive game objects are automatically converted to be Disabled entities
* Disabled components are ignored during conversion process. Behaviour.Enabled has no direct mapping in ECS. It is recommended to Disable whole entities instead
* Warnings are now issues when asking for a GetPrimaryEntity that is not a game object that is part of the converted group. HasPrimaryEntity can be used to check if the game object is part of the converted group in case that is necessary.
* Fixed a race condition in `EntityCommandBuffer.AddBuffer()` and `EntityCommandBuffer.SetBuffer()`

## [0.0.12-preview.31] - 2019-05-01

### New Features

### Upgrade guide

* Serialized entities file format version has changed, Sub Scenes entity caches will require rebuilding.

### Changes

* Adding components to entities that already have them is now properly ignored in the cases where no data would be overwritten. That means the inspectable state does not change and thus determinism can still be guaranteed.
* Restored backwards compatibility for `ForEach` API directly on `ComponentSystem` to ease people upgrading to the latest Unity.Entities package on top of Megacity.
* Rebuilding the entity cache files for sub scenes will now properly request checkout from source control if required.

### Fixes

* `IJobForEach` will only create new entity queries when scheduled, and won't rely on injection anymore. This avoids the creation of useless queries when explicit ones are used to schedule those jobs. Those useless queries could cause systems to keep updating even though the actual queries were empty.
* APIs changed in the previous version now have better obsolete stubs and upgrade paths.  All obsolete APIs requiring manual code changes will now soft warn and continue to work, instead of erroring at compile time.  These respective APIs will be removed in a future release after that date.
* LODGroup conversion now handles renderers being present in a LOD Group in multipe LOD levels correctly
* Fixed potential memory leak when disposing an EntityCommandBuffer after certain types of playback errors
* Fixed an issue where chunk utilization histograms weren't properly clipped in EntityDebugger
* Fixed an issue where tag components were incorrectly shown as subtractive in EntityDebugger
* ComponentSystem.ShouldRunSystem() exception message now more accurately reports the most likely reason for the error when the system does not exist.

### Known Issues

* It might happen that shared component data with managed references is not compared for equality correctly with certain profiles.


## [0.0.12-preview.30] - 2019-04-05

### New Features
Script templates have been added to help you create new component types and systems, similar to Unity's built-in template for new MonoBehaviours. Use them via the Assets/Create/ECS menu.

### Upgrade guide

Some APIs have been deprecated in this release:

[API Deprecation FAQ](https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/)

** Removed obsolete ComponentSystem.ForEach
** Removed obsolete [Inject]
** Removed obsolete ComponentDataArray
** Removed obsolete SharedComponentDataArray
** Removed obsolete BufferArray
** Removed obsolete EntityArray
** Removed obsolete ComponentGroupArray

####ScriptBehaviourManager removal
* The ScriptBehaviourManager class has been removed.
* ComponentSystem and JobComponentSystem remain as system base classes (with a common ComponentSystemBase class)
  * ComponentSystems have overridable methods OnCreateManager and OnDestroyManager. These have been renamed to OnCreate and OnDestroy.
    * This is NOT handled by the obsolete API updater and will need to be done manually.
    * The old OnCreateManager/OnDestroyManager will continue to work temporarily, but will print a warning if a system contains them.
* World APIs have been updated as follows:
  * CreateManager, GetOrCreateManager, GetExistingManager, DestroyManager, BehaviourManagers have been renamed to CreateSystem, GetOrCreateSystem, GetExistingSystem, DestroySystem, Systems.
    * These should be handled by the obsolete API updater.
  * EntityManager is no longer accessed via GetExistingManager. There is now a property directly on World: World.EntityManager.
    * This is NOT handled by the obsolete API updater and will need to be done manually.
    * Searching and replacing Manager<EntityManager> should locate the right spots. For example, world.GetExistingManager<EntityManager>() should become just world.EntityManager.

#### IJobProcessComponentData renamed to IJobForeach
This rename unfortunately cannot be handled by the obsolete API updater.
A global search and replace of IJobProcessComponentData to IJobForEach should be sufficient.

#### ComponentGroup renamed to EntityQuery
ComponentGroup has been renamed to EntityQuery to better represent what it does.
All APIs that refer to ComponentGroup have been changed to refer to EntityQuery in their name, e.g. CreateEntityQuery, GetEntityQuery, etc.

#### EntityArchetypeQuery renamed to EntityQueryDesc
EntityArchetypeQuery has been renamed to EntityQueryDesc

### Changes
* Minimum required Unity version is now 2019.1.0b9
* Adding components to entities that already have them is now properly ignored in the cases where no data would be overwritten.
* UNITY_CSHARP_TINY is now NET_DOTS to match our other NET_* defines

### Fixes
* Fixed exception in inspector when Script is missing
* The presence of chunk components could lead to corruption of the entity remapping during deserialization of SubScene sections.
* Fix for an issue causing filtering with IJobForEachWithEntity to try to access entities outside of the range of the group it was scheduled with.

<!-- Template for version sections
## [0.0.0-preview.0]

### New Features


### Upgrade guide


### Changes


### Fixes
-->
