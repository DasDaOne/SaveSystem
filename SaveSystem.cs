using System;
using Newtonsoft.Json;
using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
	private static bool IsDataLoaded {get; set;}

	private static PlayerSaveData cachedSaveData;
	public static ref PlayerSaveData SaveData
	{
		get
		{
			if(!IsDataLoaded)
				cachedSaveData = LoadPlayerData();
			
			return ref cachedSaveData;
		}
	}

	private static string lastSavedJson;

	private const int SavingPeriod = 2;
	
	private void Awake()
	{
		if(Instance != this)
		{
			Destroy(gameObject);
			return;
		}
								
		InvokeRepeating(nameof(SavePlayerData), SavingPeriod, SavingPeriod);
	}
	
	private static PlayerSaveData LoadPlayerData()
	{
		string json = PlayerPrefs.GetString("SaveData", "");
		
		PlayerSaveData saveData;
		
		if(!string.IsNullOrEmpty(json) && !string.IsNullOrWhiteSpace(json))
			saveData = JsonConvert.DeserializeObject<PlayerSaveData>(json);
		else
			saveData = new PlayerSaveData
			{
				// Fill defaults of your SaveData here
			};
		
		IsDataLoaded = true;
		return saveData;
	}
	
	public void SaveToStorage()
	{
		SavePlayerData();
		
		PlayerPrefs.Save();
	}
	
	private void SavePlayerData()
	{
		string json = JsonConvert.SerializeObject(cachedSaveData);
		
		if(json == lastSavedJson)
			return;
			
		PlayerPrefs.SetString("SaveData", json);
	}
}

[Serializable]
public struct PlayerSaveData
{
	// Fill content of your SaveData, it can be anything that Newtonsoft can serialize
}