# Unity SaveSystem

A small system of mine, designed for saving player data.

Requires NewtonsoftJson to work

# Usage
  - Import NewtonsoftJson into your project
  - Download [SaveSystem.cs](SaveSystem.cs) and [Singleton.cs](Singleton.cs)
  - Create empty gameobject on preloading or main scene and add SaveSystem on it
  - Fill SaveSystem's [PlayerData](SaveSystem.cs/#L73) struct with whatever information you need, fill default values in [LoadPlayerData](SaveSystem.cs/#L36) method
  - If using PlayerPrefs as saving provider:
    - Add some points where you invoke [SaveToStorage](SaveSystem/#L54) method, since Unity can sometimes not save PlayerPrefs on some platforms when player is exiting the game
  - If using any other saving provider (Some WebGL Sdks for example):
    - Replace saving method in [SavePlayerData](SaveSystem/#L68)
