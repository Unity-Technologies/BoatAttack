---
uid: gameplay-transform-system
---
# TransformSystem

----------------------------------------------
Section 1: Non-hierarchical Transforms (Basic)
----------------------------------------------

LocalToWorld (float4x4) represents the transform from local space to world space. It is the canonical representation and is the only component and can be relied upon to communicate local space among systems. 

- Some DOTS features may rely on the existence of LocalToWorld in order to function. 
- For example, the RenderMesh component relies on the LocalToWorld component to exist for rendering an instance.
- If only the LocalToWorld transform component exists, no transform system will write or affect the LocalToWorld data.
- User code may write directly to LocalToWorld to define the transform for an instance, if no other transform components are associated with the same entity.

The purpose of all transform systems and all other transform components is to provide interfaces to write to LocalToWorld.

LocalToWorld = Translation * Rotation * Scale

If any combination of Translation (float3), Rotation (quaternion), or Scale (float) components are present along with a LocalToWorld component, a transform system will combine those components and write to LocalToWorld. 

Concretely, each of these component combinations will write to LocalToWorld as:

- [TRSToLocalToWorldSystem] LocalToWorld <= Translation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * Rotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * Rotation * Scale
- [TRSToLocalToWorldSystem] LocalToWorld <= Rotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Rotation * Scale
- [TRSToLocalToWorldSystem] LocalToWorld <= Scale

e.g. If the following components are present...

| (Entity)      |
| --------------|
| LocalToWorld  |
| Translation   |
| Rotation      |

...then the transform system will:

- [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * Rotation 

![](images/sec1-1.png)

Or, if the following components are present...

| (Entity)      |
| --------------|
| LocalToWorld  |
| Translation   |
| Rotation      |
| Scale         |

...then the transform system will:

- [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * Rotation * Scale

![](images/sec1-2.png)

------------------------------------------
Section 2: Hierarchical Transforms (Basic)
------------------------------------------

LocalToParent and Parent components are required for the transform system to write a LocalToWorld based on a hierarchical transform.

- LocalToParent (float4x4) represents the transform from local space to parent local space. 
- Parent (Entity) references the parent's LocalToWorld.
- User code may write directly to LocalToParent, if no other transform system is defined as writing to it.

e.g. If the following components are present...

| Parent (Entity) | Child (Entity) |
| --------------- | -------------- |
| LocalToWorld    | LocalToWorld   |
| Translation     | LocalToParent  |
| Rotation        | Parent         |
| Scale           |                |

...then the transform system will:

1. [TRSToLocalToWorldSystem] Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [LocalToParentSystem]     Child: Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec2-1.png)

LocalToWorld components associated with Parent Entity IDs are guaranteed to be computed before multiplies with LocalToParent associated with Child Entity ID.

Note: Cyclical graph relationships are invalid. Results are undefined.

When the hierarchy (topology) is changed (i.e. Any Parent component is added, removed or changed) internal state is added as SystemStateComponentData as:

- Child component (ISystemStateBufferElementData of Entity) associated with the Parent Entity ID 
- PreviousParent component (ISystemStateComponentData of Entity) associated with the Child Entity ID

| Parent (Entity) | Child (Entity)  |
| --------------- | --------------- |
| LocalToWorld    | LocalToWorld    |
| Translation     | LocalToParent   |
| Rotation        | Parent          |
| Scale           | PreviousParent* |
| Child*          |                 |

Adding, removing, and updating of these components is handled by the [ParentSystem]. It is not expected that systems external to transform systems will read or write to these components.

LocalToParent = Translation * Rotation * Scale

If any combination of Translation (float3), Rotation (quaternion), or Scale (float) components are present along with a LocalToParent component, a transform system will combine those components and write to LocalToParent. 

Concretely, each of these component combinations will write to LocalToParent as:

- [TRSToLocalToParentSystem] LocalToParent <= Translation
- [TRSToLocalToParentSystem] LocalToParent <= Translation * Rotation
- [TRSToLocalToParentSystem] LocalToParent <= Translation * Rotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Rotation
- [TRSToLocalToParentSystem] LocalToParent <= Rotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Scale

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)  |
| --------------- | --------------- |
| LocalToWorld    | LocalToWorld    |
| Translation     | LocalToParent   |
| Rotation        | Parent          |
| Scale           | PreviousParent* |
| Child*          | Translation     |
|                 | Rotation        |
|                 | Scale           |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * Rotation * Scale
3. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec2-2.png)

Parents may of course themselves be children of other LocalToWorld components. 

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)  |
| --------------- | --------------- |
| LocalToWorld    | LocalToWorld    |
| LocalToParent   | LocalToParent   |
| Parent          | Parent          |
| PreviousParent* | PreviousParent* |
| Child*          | Translation     |
| Translation     | Rotation        |
| Rotation        | Scale           |
| Scale           |                 |

...then the transform system will:

1. [TRSToLocalToParentSystem] Parent: Write LocalToParent <= Translation * Rotation * Scale
2. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * Rotation * Scale
3. [LocalToParentSystem]      Parent: Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent
4. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec2-3.png)

-------------------------------------
Section 3: Default Conversion (Basic)
-------------------------------------

Hybrid Conversion:

UnityEngine.Transform MonoBehaviours which are part of GameObjects and are included in Sub Scenes or are on GameObjects with "Convert To Entity" Monobehaviours attached, have a default conversion to Transform system components. That conversion can be found in TransformConversion system in the Unity.Transforms.Hybrid assembly.

1. Entities associated with the GameObject being transformed which have a Static component, only have LocalToWorld added to the resulting entity. So in the case of static instances, no transform system update will happen at runtime.
2. For non-Static entities,
   a. Translation component will be added with the Transform.position value.
   b. Rotation component will be added with the Transform.rotation value.
   c. Transform.parent == null
      - For non-unit Transform.localScale, NonUniformScale component will be added with the Transform.localScale value.
   d. If Transform.parent != null, but at the start of the (partial) hierarchy being converted:
      - For non-unit Transform.lossyScale, NonUniformScale component will be added with the Transform.lossyScale value.
   e. For other cases where Transform.parent != null,
      - Parent component will be added with the Entity referring to the converted Transform.parent GameObject.
      - LocalToParent component will be added.

-------------------------------------------------
Section 4: Non-hierarchical Transforms (Advanced)
-------------------------------------------------

NonUniformScale (float3) as an alternative to Scale to specify scale per-axis. Note that not all DOTS features fully support non-uniform scale. Be sure to check those features’ documentation to understand their limitations.

- [TRSToLocalToWorldSystem] LocalToWorld <= Translation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * Rotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * Rotation * NonUniformScale
- [TRSToLocalToWorldSystem] LocalToWorld <= Rotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Rotation * NonUniformScale
- [TRSToLocalToWorldSystem] LocalToWorld <= NonUniformScale

The presence of both Scale and NonUniform scale is not a valid case, but the result is defined. Scale will be used, NonUniformScale will be ignored.

e.g. If the following components are present...

| (Entity)         |
| ---------------- |
| LocalToWorld     |
| Translation      |
| Rotation         |
| NonUniformScale  |

...then the transform system will:

- [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * Rotation * NonUniformScale

![](images/sec4-1.png)

The Rotation component may be written to directly as a quaternion by user code. However, if an Euler interface is preferred, components are available for each rotation order which will cause a write to the Rotation component if present. 

- [RotationEulerSystem] Rotation <= RotationEulerXYZ
- [RotationEulerSystem] Rotation <= RotationEulerXZY
- [RotationEulerSystem] Rotation <= RotationEulerYXZ
- [RotationEulerSystem] Rotation <= RotationEulerYZX
- [RotationEulerSystem] Rotation <= RotationEulerZXY
- [RotationEulerSystem] Rotation <= RotationEulerZYX

e.g. If the following components are present...

| (Entity)         |
| ---------------- |
| LocalToWorld     |
| Translation      |
| Rotation         |
| RotationEulerXYZ |

...then the transform system will:

1. [RotationEulerSystem]     Write Rotation <= RotationEulerXYZ
2. [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * Rotation * Scale

![](images/sec4-2.png)

It is a setup error to have more than one RotationEuler*** component is associated with the same Entity, however the result is defined. The first to be found in the order of precedence will be applied. That order is:

1. RotationEulerXYZ
2. RotationEulerXZY
3. RotationEulerYXZ
4. RotationEulerYZX
5. RotationEulerZXY
6. RotationEulerZYX

For more complex Rotation requirements, a CompositeRotation (float4x4) component may be used as an alternative to Rotation.

All of the combinations which are valid for Rotation are also valid for CompositeRotation. i.e.

- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * CompositeRotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * CompositeRotation * Scale
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeRotation
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeRotation * Scale
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * CompositeRotation
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * CompositeRotation * NonUniformScale
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeRotation
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeRotation * NonUniformScale

The CompositeRotation component may be written to directly as a float4x4 by user code. However, if a Maya/FBX-style interface is preferred, components are available which will write to the CompositeRotation component if present.

CompositeRotation = RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1

If any combination of RotationPivotTranslation (float3), RotationPivot (float3), Rotation (quaternion), or PostRotation (quaternion) components are present along with a CompositeRotation component, a transform system will combine those components and write to CompositeRotation. 

Concretely, each of these component combinations will write to CompositeRotation as:

- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * Rotation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * Rotation * PostRotation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * PostRotation 
- [CompositeRotationSystem] CompositeRotation <= RotationPivot * Rotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivot * Rotation * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= PostRotation
- [CompositeRotationSystem] CompositeRotation <= Rotation 
- [CompositeRotationSystem] CompositeRotation <= Rotation * PostRotation

Cases where RotationPivot is specified without either of Rotation, PostRotation have no additional affect on CompositeRotation.

Note that since Rotation is re-used as a source for CompositeRotation, the alternative data interfaces to Rotation are still available.

e.g. If the following components are present...

| (Entity)                 |
| ------------------------ |
| LocalToWorld             |
| Translation              |
| CompositeRotation        |
| Rotation                 |
| RotationPivotTranslation |
| RotationPivot            |
| PostRotation             |
| RotationEulerXYZ         |
| Scale                    |

...then the transform system will:

1. [CompositeRotationSystem] Write CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
2. [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * CompositeRotation * Scale

![](images/sec4-3.png)

The PostRotation component may be written to directly as a quaternion by user code. However, if an Euler interface is preferred, components are available for each rotation order which will cause a write to the PostRotation component if present. 

- [PostRotationEulerSystem] PostRotation <= PostRotationEulerXYZ
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerXZY
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerYXZ
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerYZX
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerZXY
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerZYX

e.g. If the following components are present...

| (Entity)                 |
| ------------------------ |
| LocalToWorld             |
| Translation              |
| CompositeRotation        |
| Rotation                 |
| RotationPivotTranslation |
| RotationPivot            |
| RotationEulerXYZ         |
| PostRotation             |
| PostRotationEulerXYZ     |
| Scale                    |

...then the transform system will:

1. [RotationEulerSystem]     Write Rotation <= RotationEulerXYZ
2. [PostRotationEulerSystem] Write PostRotation <= PostRotationEulerXYZ
3. [CompositeRotationSystem] Write CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
4. [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * CompositeRotation * Scale

![](images/sec4-4.png)

For more complex Scale requirements, a CompositeScale (float4x4) component may be used as an alternative to Scale (or NonUniformScale).

All of the combinations which are valid for Scale or NonUniformScale are also valid for CompositeScale. i.e.

- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * Rotation * CompositeScale
- [TRSToLocalToWorldSystem] LocalToWorld <= Rotation * CompositeScale
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeScale
- [TRSToLocalToWorldSystem] LocalToWorld <= Translation * CompositeRotation * CompositeScale
- [TRSToLocalToWorldSystem] LocalToWorld <= CompositeRotation * CompositeScale

The CompositeScale component may be written to directly as a float4x4 by user code. However, if a Maya/FBX-style interface is preferred, components are available which will write to the CompositeScale component if present.

CompositeScale = ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
CompositeScale = ScalePivotTranslation * ScalePivot * NonUniformScale * ScalePivot^-1

If any combination of ScalePivotTranslation (float3), ScalePivot (float3), Scale (float) components are present along with a CompositeScale component, a transform system will combine those components and write to CompositeScale. 

Alternatively, if any combination of ScalePivotTranslation (float3), ScalePivot (float3), NonUniformScale (float3) components are present along with a CompositeScale component, a transform system will combine those components and write to CompositeScale. 

Concretely, each of these component combinations will write to CompositeRotation as:

- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * Scale
- [CompositeScaleSystem] CompositeScale <= ScalePivot * Scale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= Scale 
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * ScalePivot * NonUniformScale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * Scale
- [CompositeScaleSystem] CompositeScale <= ScalePivot * NonUniformScale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= NonUniformScale 

Cases where ScalePivot is specified without either of Scale, NonUniformScale have no additional effect have no additional affect on CompositeScale.

e.g. If the following components are present...

| (Entity)                 |
| ------------------------ |
| LocalToWorld             |
| Translation              |
| CompositeRotation        |
| Rotation                 |
| RotationPivotTranslation |
| RotationPivot            |
| RotationEulerXYZ         |
| PostRotation             |
| PostRotationEulerXYZ     |
| CompositeScale           |
| Scale                    |
| ScalePivotTranslation    |
| ScalePivot               |

...then the transform system will:

1. [RotationEulerSystem]     Write Rotation <= RotationEulerXYZ
2. [PostRotationEulerSystem] Write PostRotation <= PostRotationEulerXYZ
3. [CompositeScaleSystem]    Write CompositeScale <= ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
4. [CompositeRotationSystem] Write CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
5. [TRSToLocalToWorldSystem] Write LocalToWorld <= Translation * CompositeRotation * CompositeScale

![](images/sec4-5.png)

---------------------------------------------
Section 5: Hierarchical Transforms (Advanced)
---------------------------------------------

Note: Advanced Hierarchical transform component rules largely mirror the use of the non-hierarchical components, except that they are writing to LocalToParent (instead of LocalToWorld.) The main additional component unique to hierarchical transforms is ParentScaleInverse.

-----

NonUniformScale (float3) as an alternative to Scale to specify scale per-axis. Note that not all DOTS features fully support non-uniform scale. Be sure to check those features’ documentation to understand their limitations.

- [TRSToLocalToParentSystem] LocalToParent <= Translation
- [TRSToLocalToParentSystem] LocalToParent <= Translation * Rotation
- [TRSToLocalToParentSystem] LocalToParent <= Translation * Rotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= Rotation
- [TRSToLocalToParentSystem] LocalToParent <= Rotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= NonUniformScale

The presence of both Scale and NonUniform scale is not a valid case, but the result is defined. Scale will be used, NonUniformScale will be ignored.

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)   |
| --------------- | ---------------- |
| LocalToWorld    | LocalToWorld     |
| Translation     | LocalToParent    |
| Rotation        | Parent           |
| Scale           | PreviousParent*  |
| Child*          | Translation      |
|                 | Rotation         |
|                 | NonUniformScale  |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * Rotation * NonUniformScale
3. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-1.png)

Parent LocalToWorld is multiplied with the Child LocalToWorld, which includes any scaling. However, if removing Parent scale is preferred (AKA Scale Compensate), ParentScaleInverse is available for that purpose.

- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse 
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse 
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * Rotation 
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * Rotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation 
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * Rotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * Rotation 
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * Rotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * Rotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation 
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * CompositeScale

Inverse of any explicitly assigned parent scale values if present are written to ParentScaleInverse, as:

- [ParentScaleInverseSystem] ParentScaleInverse <= CompositeScale[Parent]^-1
- [ParentScaleInverseSystem] ParentScaleInverse <= Scale[Parent]^-1
- [ParentScaleInverseSystem] ParentScaleInverse <= NonUniformScale[Parent]^-1

If LocalToWorld[Parent] is written directly by the user, or scaling is otherwise applied in a way that is not explicitly using the scale components, then nothing is written to the ParentScaleInverse. It is the responsibility of the system applying that scaling to write inverse to ParentScaleInverse. The results of a system not updating ParentScaleInverse in this case are undefined. 

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)     |
| --------------- | ------------------ |
| LocalToWorld    | LocalToWorld       |
| Translation     | LocalToParent      |
| Rotation        | Parent             |
| Scale           | PreviousParent*    |
| Child*          | Translation        |
|                 | Rotation           |
|                 | ParentScaleInverse |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [ParentScaleInverseSystem] Child:  ParentScaleInverse <= Scale[Parent]^-1
3. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * ParentScaleInverse * Rotation 
4. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-2.png)

The Rotation component may be written to directly as a quaternion by user code. However, if an Euler interface is preferred, components are available for each rotation order which will cause a write to the Rotation component if present. 

- [RotationEulerSystem] Rotation <= RotationEulerXYZ
- [RotationEulerSystem] Rotation <= RotationEulerXZY
- [RotationEulerSystem] Rotation <= RotationEulerYXZ
- [RotationEulerSystem] Rotation <= RotationEulerYZX
- [RotationEulerSystem] Rotation <= RotationEulerZXY
- [RotationEulerSystem] Rotation <= RotationEulerZYX

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)   |
| --------------- | ---------------- |
| LocalToWorld    | LocalToWorld     |
| Translation     | LocalToParent    |
| Rotation        | Parent           |
| Scale           | PreviousParent*  |
| Child*          | Translation      |
|                 | Rotation         |
|                 | RotationEulerXYZ |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [RotationEulerSystem]      Child:  Write Rotation <= RotationEulerXYZ
3. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * Rotation 
4. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-3.png)

For more complex Rotation requirements, a CompositeRotation (float4x4) component may be used as an alternative to Rotation.

All of the combinations which are valid for Rotation are also valid for CompositeRotation. i.e.

- [TRSToLocalToParentSystem] LocalToParent <= Translation * CompositeRotation
- [TRSToLocalToParentSystem] LocalToParent <= Translation * CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation 
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation 
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= CompositeRotation
- [TRSToLocalToParentSystem] LocalToParent <= CompositeRotation * Scale
- [TRSToLocalToParentSystem] LocalToParent <= CompositeRotation * NonUniformScale
- [TRSToLocalToParentSystem] LocalToParent <= CompositeRotation * CompositeScale

The CompositeRotation component may be written to directly as a float4x4 by user code. However, if a Maya/FBX-style interface is preferred, components are available which will write to the CompositeRotation component if present.

CompositeRotation = RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1

If any combination of RotationPivotTranslation (float3), RotationPivot (float3), Rotation (quaternion), or PostRotation (quaternion) components are present along with a CompositeRotation component, a transform system will combine those components and write to CompositeRotation. 

Concretely, each of these component combinations will write to CompositeRotation as:

- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * RotationPivot * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * Rotation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * Rotation * PostRotation
- [CompositeRotationSystem] CompositeRotation <= RotationPivotTranslation * PostRotation 
- [CompositeRotationSystem] CompositeRotation <= RotationPivot * Rotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= RotationPivot * Rotation * PostRotation * RotationPivot^-1
- [CompositeRotationSystem] CompositeRotation <= PostRotation
- [CompositeRotationSystem] CompositeRotation <= Rotation 
- [CompositeRotationSystem] CompositeRotation <= Rotation * PostRotation

Cases where RotationPivot is specified without either of Rotation, PostRotation have no additional affect on CompositeRotation.

Note that since Rotation is re-used as a source for CompositeRotation, the alternative data interfaces to Rotation are still available.

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)           |
| --------------- | ------------------------ |
| LocalToWorld    | LocalToWorld             |
| Translation     | LocalToParent            |
| Rotation        | Parent                   |
| Scale           | PreviousParent*          |
| Child*          | Translation              |
|                 | CompositeRotation        |
|                 | Rotation                 |
|                 | RotationPivotTranslation |
|                 | RotationPivot            |
|                 | PostRotation             |
|                 | RotationEulerXYZ         |
|                 | Scale                    |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [RotationEulerSystem]      Child:  Write Rotation <= RotationEulerXYZ
3. [CompositeRotationSystem]  Child:  Wirte CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
4. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * CompositeRotation * Scale
5. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-4.png)

The PostRotation component may be written to directly as a quaternion by user code. However, if an Euler interface is preferred, components are available for each rotation order which will cause a write to the PostRotation component if present. 

- [PostRotationEulerSystem] PostRotation <= PostRotationEulerXYZ
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerXZY
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerYXZ
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerYZX
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerZXY
- [PostRotationEulerSystem] PostRotation <= PostRotationEulerZYX

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)           |
| --------------- | ------------------------ |
| LocalToWorld    | LocalToWorld             |
| Translation     | LocalToParent            |
| Rotation        | Parent                   |
| Scale           | PreviousParent*          |
| Child*          | Translation              |
|                 | CompositeRotation        |
|                 | Rotation                 |
|                 | RotationPivotTranslation |
|                 | RotationPivot            |
|                 | PostRotation             |
|                 | RotationEulerXYZ         |
|                 | Scale                    |
|                 | PostRotationEulerXYZ     |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [PostRotationEulerSystem]  Child:  Write PostRotation <= PostRotationEulerXYZ
3. [RotationEulerSystem]      Child:  Write Rotation <= RotationEulerXYZ
4. [CompositeRotationSystem]  Child:  Wirte CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
5. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * CompositeRotation * Scale
6. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-5.png)

It is a setup error to have more than one PostRotationEuler*** component is associated with the same Entity, however the result is defined. The first to be found in the order of precedence will be applied. That order is:

1. PostRotationEulerXYZ
2. PostRotationEulerXZY
3. PostRotationEulerYXZ
4. PostRotationEulerYZX
5. PostRotationEulerZXY
6. PostRotationEulerZYX

For more complex Scale requirements, a CompositeScale (float4x4) component may be used as an alternative to Scale (or NonUniformScale).

All of the combinations which are valid for Scale or NonUniformScale are also valid for CompositeScale. i.e.

- [TRSToLocalToParentSystem] LocalToParent <= Translation * Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= Translation * ParentScaleInverse * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * Rotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeRotation * CompositeScale
- [TRSToLocalToParentSystem] LocalToParent <= ParentScaleInverse * CompositeScale

The CompositeScale component may be written to directly as a float4x4 by user code. However, if a Maya/FBX-style interface is preferred, components are available which will write to the CompositeScale component if present.

CompositeScale = ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
CompositeScale = ScalePivotTranslation * ScalePivot * NonUniformScale * ScalePivot^-1

If any combination of ScalePivotTranslation (float3), ScalePivot (float3), Scale (float) components are present along with a CompositeScale component, a transform system will combine those components and write to CompositeScale. 

Alternatively, if any combination of ScalePivotTranslation (float3), ScalePivot (float3), NonUniformScale (float3) components are present along with a CompositeScale component, a transform system will combine those components and write to CompositeScale. 

Concretely, each of these component combinations will write to CompositeRotation as:

- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * Scale
- [CompositeScaleSystem] CompositeScale <= ScalePivot * Scale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= Scale 
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * ScalePivot * NonUniformScale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= ScalePivotTranslation * Scale
- [CompositeScaleSystem] CompositeScale <= ScalePivot * NonUniformScale * ScalePivot^-1
- [CompositeScaleSystem] CompositeScale <= NonUniformScale 

Cases where ScalePivot is specified without either of Scale, NonUniformScale have no additional effect have no additional affect on CompositeScale.

e.g. If the following components are present...

| Parent (Entity) | Child (Entity)           |
| --------------- | ------------------------ |
| LocalToWorld    | LocalToWorld             |
| Translation     | LocalToParent            |
| Rotation        | Parent                   |
| Scale           | PreviousParent*          |
| Child*          | Translation              |
|                 | CompositeRotation        |
|                 | Rotation                 |
|                 | RotationPivotTranslation |
|                 | RotationPivot            |
|                 | PostRotation             |
|                 | RotationEulerXYZ         |
|                 | Scale                    |
|                 | PostRotationEulerXYZ     |
|                 | CompositeScale           |
|                 | ScalePivotTranslation    |
|                 | ScalePivot               |

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [PostRotationEulerSystem]  Child:  Write PostRotation <= PostRotationEulerXYZ
2. [RotationEulerSystem]      Child:  Write Rotation <= RotationEulerXYZ
3. [CompositeRotationSystem]  Child:  Wirte CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
4. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * CompositeRotation * Scale
5. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-6.png)

...then the transform system will:

1. [TRSToLocalToWorldSystem]  Parent: Write LocalToWorld as defined above in "Non-hierarchical Transforms (Basic)"
2. [PostRotationEulerSystem]  Child:  Write PostRotation <= PostRotationEulerXYZ
3. [RotationEulerSystem]      Child:  Write Rotation <= RotationEulerXYZ
4. [CompositeScaleSystem]     Child:  Write CompositeScale <= ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
5. [CompositeRotationSystem]  Child:  Wirte CompositeRotation <= RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
6. [TRSToLocalToParentSystem] Child:  Write LocalToParent <= Translation * CompositeRotation * Scale
7. [LocalToParentSystem]      Child:  Write LocalToWorld <= LocalToWorld[Parent] * LocalToParent

![](images/sec5-7.png)

---------------------------------------
Section 6: Custom Transforms (Advanced)
---------------------------------------

There are two methods for writing user-defined transforms that are fully compatible with the transform system.

1. Overriding transform components
2. Extending transform components

Overriding transform components
-------------------------------

A user component (UserComponent) is defined and added to the LocalToWorld WriteGroup, as in:

[Serializable]
[WriteGroup(typeof(LocalToWorld))]
struct UserComponent : IComponentData
{
}

Overriding transform components means that no additional extensions are possible. The user defined transform is the only transform that can occur with the specified user component.

In the UserTransformSystem, use the default query method to request write access to LocalToWorld.

e.g.

    public class UserTransformSystem : JobComponentSystem
    {
        [BurstCompile]
        struct UserTransform : IJobForEach<LocalToWorld, UserComponent>
        {
            public void Execute(ref LocalToWorld localToWorld, [ReadOnly] ref UserComponent userComponent)
            {
                localToWorld.Value = ... // Assign localToWorld as needed for UserTransform
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new UserTransform()
            {
            };
            return job.Schedule(this, inputDependencies);
        }
    }

All other transform components which write to LocalToWorld will be ignored by the transform system where UserComponent is included.

e.g.
If the following components are present...

| (Entity)      |
| --------------|
| LocalToWorld  |
| Translation   |
| Rotation      |
| Scale         |
| UserComponent |

...then:

- [TRSToLocalToWorldSystem] Will not run on this Entity
- [UserTransformSystem] Will run on this Entity

However, unexpected behavior may result if two different systems both override LocalToWorld and both components are present. e.g. 

e.g. If there is an additional:

    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    struct UserComponent2 : IComponentData
    {
    }

And the equivalent system:

    public class UserTransformSystem2 : JobComponentSystem
    {
        [BurstCompile]
        struct UserTransform2 : IJobForEach<LocalToWorld, UserComponent2>
        {
            public void Execute(ref LocalToWorld localToWorld, [ReadOnly] ref UserComponent2 userComponent2)
            {
                localToWorld.Value = ... // Assign localToWorld as needed for UserTransform
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new UserTransform()
            {
            };
            return job.Schedule(this, inputDependencies);
        }
    }

Then if the following components are present...

| (Entity)       |
| -------------- |
| LocalToWorld   |
| Translation    |
| Rotation       |
| Scale          |
| UserComponent  |
| UserComponent2 |

Both systems will attempt to write to LocalToWorld, likely resulting in unexpected behavior. This may not be an issue in context.


Extending transform components
------------------------------

In order to ensure that multiple overridden transform components can interact in a way which is well-defined, a WriteGroup query can be used to only explicitly match the requested components.

e.g. If there is a:

    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    struct UserComponent : IComponentData
    {
    }

And a system which filters based on the WriteGroup of LocalToWorld:

    public class UserTransformSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadWrite<LocalToWorld>(),
                    ComponentType.ReadOnly<UserComponent>(),
                },
                Options = EntityQueryDescOptions.FilterWriteGroup
            });
        }

        [BurstCompile]
        struct UserTransform : IJobForEach<LocalToWorld, UserComponent>
        {
            public void Execute(ref LocalToWorld localToWorld, [ReadOnly] ref UserComponent userComponent)
            {
                localToWorld.Value = ... // Assign localToWorld as needed for UserTransform
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new UserTransform()
            {
            };
            return job.ScheduleGroup(m_Group, inputDependencies);
        }
    }

m_Group in UserTransformSystem will only match the explicitly mentioned components.

For instance, the following with match and be included in the EntityQuery:

| (Entity)       |
| -------------- |
| LocalToWorld   |
| UserComponent  |

But this will not:

| (Entity)       |
| -------------- |
| LocalToWorld   |
| Translation    |
| Rotation       |
| Scale          |
| UserComponent  |

The implicit expectation is that UserComponent is a completely orthogonal set of requirements to write to LocalToWorld, so no other (unstated) components which are in the same WriteGroup should be present.

However, they may be explicitly supported by UserComponent systems by adding to the queries, as:

    public class UserTransformExtensionSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadWrite<LocalToWorld>(),
                    ComponentType.ReadOnly<UserComponent>(),
                    ComponentType.ReadOnly<Translation>(),
                    ComponentType.ReadOnly<Rotation>(),
                    ComponentType.ReadOnly<Scale>(),
                },
                Options = EntityQueryDescOptions.FilterWriteGroup
            });
        }

        [BurstCompile]
        struct UserTransform : IJobForEach<LocalToWorld, UserComponent>
        {
            public void Execute(ref LocalToWorld localToWorld, [ReadOnly] ref UserComponent userComponent,
                [ReadOnly] ref Translation translation,
                [ReadOnly] ref Rotation rotation,
                [ReadOnly] ref Scale scale)
            {
                localToWorld.Value = ... // Assign localToWorld as needed for UserTransform
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new UserTransform()
            {
            };
            return job.ScheduleGroup(m_Group, inputDependencies);
        }
    }

In the same way, if there is an additional:

    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    struct UserComponent2 : IComponentData
    {
    }

And there is:

| (Entity)       |
| -------------- |
| LocalToWorld   |
| UserComponent  |
| UserComponent2 |

The UserTransformSystem defined above would not match, since UserComponent2 is not explicitly mentioned and it is in the LocalToWorld WriteGroup.

However, an explicit query can be created which can resolve the case and ensure the behavior is well defined. As in:

    public class UserTransformComboSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadWrite<LocalToWorld>(),
                    ComponentType.ReadOnly<UserComponent>(),
                    ComponentType.ReadOnly<UserComponent2>(),
                },
                Options = EntityQueryDescOptions.FilterWriteGroup
            });
        }

        [BurstCompile]
        struct UserTransform : IJobForEach<LocalToWorld, UserComponent>
        {
            public void Execute(ref LocalToWorld localToWorld, 
                [ReadOnly] ref UserComponent userComponent,
                [ReadOnly] ref UserComponent2 userComponent2
            {
                localToWorld.Value = ... // Assign localToWorld as needed for UserTransform
            }
        }
    
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new UserTransform()
            {
            };
            return job.ScheduleGroup(m_Group, inputDependencies);
        }
    }

Then the following systems (or equivalents):
  - UserTransformSystem (LocalToWorld FilterWriteGroup:UserComponent) 
  - UserTransformSystem2 (LocalToWorld FilterWriteGroup:UserComponent2) 
  - UserTransformComboSystem (LocalToWorld FilterWriteGroup:UserComponent, UserComponent2) 

Will all run side-by-side, query and run on their respective component archetypes, and have well-defined behavior.

-----------------------------------------------
Section 7: Relationship to Maya transform nodes
-----------------------------------------------

For reference on Maya transform nodes, see: https://download.autodesk.com/us/maya/2010help/Nodes/transform.html

Maya Transformation Matrix is defined as:
> matrix = SP^-1 * S * SH * SP * ST * RP^-1 * RA * R * RP * RT * T

These can be mapped to transform components as follows:

| Maya                       | Unity                     |
| -------------------------- | ------------------------- |
| T                          | Translation               |
| (RT * RP * R * RA * RP^-1) | CompositeRotation         |
| RT                         | RotationPivotTranslation  |
| RP                         | RotationPivot             |
| R                          | Rotation                  |
| RA                         | PostRotation              |
| (ST * SP * S * SP^-1)      | CompositeScale            |
| ST                         | ScalePivotTranslation     |
| SP                         | ScalePivot                |
| SH                         | --- Unused ---            |
| S                          | NonUniformScale           |

