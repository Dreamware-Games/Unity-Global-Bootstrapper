# unity-global-bootstrapper

A simple example showing how to **bootstrap global game systems in Unity** using Unity’s `RuntimeInitializeOnLoadMethod` to run code **before any scene loads**

This pattern ensures global systems like various managers (game, audio, input, settings etc) are **available everywhere**, regardless of scene.

Purpose:
- No “manager scene”
- No scene dependencies
- Predictable initialization order

## How it works

- **MasterBootstrapper**
  - Entry point
  - Runs before scene load
  - Bootstraps required global systems

- **Bootstrapper**
  - Generic helper
  - Ensures only one instance exists
  - Loads prefab from `Resources`
  - Handles lifetime (`DontDestroyOnLoad`)

- **AudioManager (example)**
  - Simple SFX-only global system
  - Scene-agnostic
  - Callable from anywhere via static API


## Pros / Cons

TODO
