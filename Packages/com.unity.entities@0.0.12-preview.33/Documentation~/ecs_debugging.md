---
uid: ecs-debugging
---
# Debugging ECS

> Synopsis: All about debugging ECS
> Outline:
> Entity Debugger
> Inspecting an Entity
> Live-link

<a name="entity_debugger"></a>
## Entity Debugger

The Entity Debugger allows you to visualize your entities, systems, and components 

Open the entity Debugger window using the menu: Window > Analysis > Entity Debugger.

<a name="systems_list"></a>
### Systems list

The Systems list shows the systems in your project and how much time a system takes to run each frame. You can turn systems on and off from the list using the checkbox provided for each system.

Use the System Display control drop down at the top of the list to control what to display in the System list. The System Display control contains:

* Worlds — Choose the World containing the entities and ComponentSystems to display. By default, an **Editor World** exists when not in play mode and a **Default World** exists in play mode. 
* **Show Full Player Loop** option — Choose to display the systems of all Worlds and show all of the Unity execution phases (not just those containing systems).
* **Show Inactive Systems** option — Choose to show systems that are not currently running in addition to the running systems.

Select a system to view its details.

**Note:** If you select the EntityManager entry in the System list, then you have different options on the System details section.

<a name="system_details"></a>
### System details

The System details section shows the groups of components that a System operates on and the list of entities associated with those component groups.
 
 Each component group shows the components in the group along with the number of entities associated with it. Select a component group  to view information about the Chunks containing the data for the components in the group.
 
 When you select the EntityManager entry in the system list, the details section shows all of the entities in the displayed World. When you display a World (rather than the full player loop), you can also filter the list of entities by component
 
 To filter the Entity list:
 1. Select a World in the System Display control.
 2. Select the EntityManager for that World.
 3. At the top of the System details section, click **Edit**.
 4. In the **Choose Component** window, check the components whose entities you want to view.
 
<a name="chunk_information"></a>
### Chunk information

The Chunk information section shows the Chunks containing data for the components and entities selected in the details section.

## Inspecting an Entity

Select an entity in the Entity Debugger to view its data in the Unity Inspector window.
