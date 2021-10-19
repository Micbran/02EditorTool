using UnityEngine;
using SaveLoadSystem;

public class SaveManager : MonoBehaviour
{
    public PlayerControls playerReference;

    public void SaveGame()
    {
        Transform playerTransform = playerReference.transform;
        PlayerStats player = new PlayerStats
        {
            position = playerTransform.position,
            rotation = playerTransform.rotation
        };

        SerializationManager.Save(player);
    }

    public void LoadGame()
    {
        PlayerStats oldPlayer = SerializationManager.Load() as PlayerStats;
        if (oldPlayer != null)
        {
            playerReference.transform.position = oldPlayer.position;
            playerReference.transform.rotation = oldPlayer.rotation;
        }
        else
        {
            Debug.LogError("Old player is null!");
        }
        
    }
}
