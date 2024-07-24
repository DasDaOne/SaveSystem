# Unity SaveSystem

A small system of mine, designed for saving player data.

Requires NewtonsoftJson to work

# Usage
  - Import NewtonsoftJson into your project
  - Download and add to your project [SaveSystem.cs](Code/SaveSystem.cs) and [Singleton.cs](Code/Singleton.cs)
  - Create empty gameobject on preloading or main scene and add [SaveSystem](Code/SaveSystem.cs) on it
  - Fill SaveSystem's [PlayerSaveData](Code/SaveSystem.cs/#L76) struct with whatever information you need, fill default values in [LoadPlayerData](Code/SaveSystem.cs/#L36) method
  - If using PlayerPrefs as saving provider:
    - Add some points where you invoke [SaveToStorage](Code/SaveSystem.cs/#L57) method, since Unity can sometimes not save PlayerPrefs on some platforms when player is exiting the game
  - If using any other saving provider (Some WebGL Sdks for example):
    - Replace saving method in [SavePlayerData](Code/SaveSystem.cs/#L71)

# Notes
  - As described [here](Code/SaveSystem.cs/#L50) it is very important to check for any nulls when adding collections in [PlayerSaveData](Code/SaveSystem.cs/#L76) during game-updates
    - If not done properly, when player will load save in game it will create a null collection in those places, which can lead further to NullReferences in unexpected places
