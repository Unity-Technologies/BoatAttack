**_Note:This repository uses GitLFS, to use this repo you need to pull via Git and make sure GitLFS is installed locally_**

# Boat Attack
###### Demo Project using the Universal RP from Unity3D

[![Click for Youtube Video](https://media.githubusercontent.com/media/Verasl/BoatAttack/release/2019.3/Assets/Textures/UI/welcome-title.png)](https://drive.google.com/file/d/1PTNdhnqbhzSWUCfAinIefP5cfr6Dezuw/view)

This Unity project has been created to aid the testing and development of Universal RP. The project is a small vertical slice of a boat racing game, complete with race-able boats and island environment.

Feel free to post any issues, but know this is a 'as is' repo, it's meant more for discovery of how some of the Universal RP features work and a learning resource for some tricks.

**Project Features**:
  * Uses Universal RP from Unity
  * Mobile optimized, low poly, LODs, no compute
  * C# Jobs buoyancy system
  * Cinemachine camera setups
  * Shader Graph usage
  * Post-processing v3 with Volume blending
  * Addressables asset management package
  * Custom Universal RP rendering for planar reflections via [SRP callbacks](https://docs.unity3d.com/ScriptReference/Rendering.RenderPipelineManager.html)
  * Custom SciptableRenderPass usage for WaterFX and Caustics
  * Gerstner based water system in local package(WIP)
  * Much more..

[Demo Footage](https://drive.google.com/file/d/1PTNdhnqbhzSWUCfAinIefP5cfr6Dezuw/view)

# Usage

#### Getting the project
via Git:
  1. Make sure you have GitLFS installed, check [here](https://git-lfs.github.com) for details.
  2. Clone the repo as usual via cmd/terminal or in your favourite Git GUI software.
  3. Checkout the branch that matches the Unity verison you are using, eg `release/2019.3`

Downloadable zips:
  1. [2019.3 Project (Unity 2019.3f5)](https://drive.google.com/file/d/1vXpbVC36GHnyC-Eitl1WpLay9l_YqJGQ/view?usp=sharing)

#### Load the project:
Once you have the project files locally you can load the project, ideally in the Unity version that is noted in the `ProjectSettings/ProjectVersion.txt` for the best experience.
Upon loading the project will display a small welcome screen with some buttons to load starting scenes.

Scenes worth noting:
 - `scenes/main_menu.unity` - Starting menu scene if you want to have a full play-through of the demo.
 - `scenes/demo_island.unity` - Setup to play in the editor and go straight into an AI based race.
 - `scenes/_levels/level_Island.unity` - The scene loaded when entering from the main menu.
 - `scenes/Testing/***.unity` - Assorted test scenes, these are in need of updating and come as is.

#### Build the project:
One thing to make sure you do before building is make sure to build the addressable assets, this can be done via the addressables window, for more information please checkout the addressables [package documentation](https://docs.unity3d.com/Packages/com.unity.addressables@latest).
Once the addressable assets are built you can continue to build a player as usual.

One thing to mention is not all controls and platforms have been tested, especially for the menu work. if you want to just see the project running on a device you can add the `scenes/demo_island.unity` scene to the build list and disable/remove the others.

# Todo

As this project is on going there is a lot more left that needs to be worked on, so I repeat this is not a resource for production ready workflow ideas or systems and lots of it was put together very quickly.

Some of the things left to do:
 * Make water system more modular and improve UX
 * Improve boat AI
 * Add imposter rendering for vegetation
 * Cleanup menu system to switch between Demoing/Playing/Benchmarking
 * Implement Unity Physics
 * Optimize cross platform performance and stability
 * Continue code cleanup
 * Wiki explaining features/systems in more depth
 * Add more sizzle....

![Sunny Island](https://gdurl.com/STO1)

# Credits
[Andre McGrail](http://www.andremcgrail.com) - Design, Programming, Modeling, Textures, SFX

[Alex Best](https://big_ally.artstation.com) - Modeling, Textures

[Stintah](https://soundcloud.com/stintah) - Soundtrack

Special thanks to:

[Felipe Lira](https://github.com/phi-lira) - For Making Universal RP & LWRP

[Tim Cooper](https://github.com/stramit) - Assorted SRP code help

And thanks to many more who have helped with suggestions and feedback!

# Notes

*Make sure you clone the repo as downloading the zip will not contain the GitLFS files(all textures/meshes etc)
