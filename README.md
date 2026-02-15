# Unity Global Bootstrapper

This project is built with [Unity version 6000.3.0f1](https://unity.com/releases/editor/whats-new/6000.3.0f1) (Universal 2D Core)

Check out a short [walkthrough on YouTube](https://www.youtube.com/watch?v=nxF8CvFj9aE).

A simple example showing how to **bootstrap scene-independent global game systems in Unity** using Unity’s `RuntimeInitializeOnLoadMethod` to run code **before any scene loads** (see [official Unity documentation](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/RuntimeInitializeLoadType.BeforeSceneLoad.html)).

This pattern makes sure global systems like managers (game, audio, input, settings, etc.) are **available everywhere**, regardless of which scene is active.

Purpose:
- No "manager scene"
- No scene dependencies
- Predictable initialization order

Feel free to use this however you like!

UI audio clips used here are courtesy of [Neon Strike](https://store.steampowered.com/app/3685030/Neon_Strike/).

[![Neon Strike](https://github.com/Dreamware-Games/.github/blob/master/images/Neon%20Strike%20Steam%20Promo.png)](https://store.steampowered.com/app/3685030/Neon_Strike/)


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
