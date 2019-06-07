**_Note:This repositry uses GitLFS, to use this repo you need to pull via Git and make sure GitLFS is installed locally_**

# Boat Attack
###### Demo Project using the Lightweight Render Pipeline from Unity3D

[![Click for Youtube Video](http://gdurl.com/6ISqD)](http://www.youtube.com/watch?v=8ancNOmt4pA)

This Unity project has been created to aid the testing and development of LWRP. The project is a small vertical slice of a boat racing game, complete with raceable boats and island environment.

**Project Features**:
  * Uses LWRP(Lightweight Render Pipeline) from Unity
  * Mobile optimized, low poly, LODs, no compute
  * C# Jobs buoyancy system
  * Cinemachine camera setups
  * Shadergraph usage
  * Postprocesing v2 with Volume blending
  * Custom LWRP rendering for planar reflections via [SRP callbacks](https://docs.unity3d.com/ScriptReference/Rendering.RenderPipeline.html)
  * Custom SciptableRenderPass usage for WaterFX and Caustics
  * Gestner based water system in local package(WIP)
  * Much more..

[Youtube Video](http://www.youtube.com/watch?v=8ancNOmt4pA)

# Usage
Via your Git GUI(or terminal/commandline) clone* down and open in Unity. Make sure you clone down the relative branch depending on unity version you are using, you will find them via `release/20xx.x` for the version you are using. `master` branch is a development branch and used with the latest version of [SRP](https://github.com/Unity-Technologies/ScriptableRenderPipeline), due to this the project has local links to the directory of the SRP cloned down on a specific machine, meaning to use this you will need to clone down SRP and point to the directories via package manager, more info can be found [here](https://docs.unity3d.com/Manual/upm-ui-local.html).

Feel free to post any issues, but know this is a 'as is' repo, it's meant more for discovery of how some of the LWRP features work and a learning resource for some tricks.

# Todo

As this project is on goinig there is a lot more left that needs to be worked on, so I repeat this is not a resource for production ready workflow ideas or systems and lots of it was put together very quickly.

Some of the things left to do:
 * Make water system more modular and improve UX
 * Improve boat AI
 * Add imposter rendering for vegetation
 * Make menu system to switch between Demoing/Playing/Benchmarking
 * Impliment Unity Physics
 * Optimize cross platform performance and stability
 * Code cleanup
 * Wiki explaning features/systems in more depth
 * Add more sizzle....

# Credits
[Andre McGrail](http://www.andremcgrail.com) - Design, Programming, Modeling, Texturing, Sound
[Alex Best](https://big_ally.artstation.com) - Modeling, Texturing
[Stintah](https://soundcloud.com/stintah) - Soundtrack

Special thanks to:
[Felipe Lira](https://github.com/phi-lira) - For Making LWRP
[Tim Cooper](https://github.com/stramit) - Assorted SRP code help

And thanks to many more who have helped with suggestions and feedback!

# Notes

*Make sure you clone the repo as downloading the zip will not contain the GitLFS files(all textures/meshes etc)
