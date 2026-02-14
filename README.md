# Unity Global Bootstrapper

This project is built with [Unity version 6000.3.0f1](https://unity.com/releases/editor/whats-new/6000.3.0f1) (Universal 2D Core)

A simple example showing how to **bootstrap scene-independent global game systems in Unity** using Unity’s `RuntimeInitializeOnLoadMethod` to run code **before any scene loads**.

This pattern makes sure global systems like managers (game, audio, input, settings, etc.) are **available everywhere**, regardless of which scene is active.

Purpose:
- No "manager scene"
- No scene dependencies
- Predictable initialization order

Feel free to use this however you like!

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

## Pros/Cons

**Pros**
- Globals ready before any scene loads.
- No need for "manager scene" or scene coupling.

**Cons**
- Depends on `Resources` loading.
- Init order can get fragile as the game grows.
