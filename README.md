# Unity Global Bootstrapper

A simple example showing how to **bootstrap scene-independent global game systems in Unity** using Unity’s `RuntimeInitializeOnLoadMethod` to run code **before any scene loads**.

This pattern makes sure global systems like managers (game, audio, input, settings, etc.) are **available everywhere**, regardless of which scene is active.

Purpose:
- No "manager scene"
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
