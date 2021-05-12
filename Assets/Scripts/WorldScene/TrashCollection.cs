using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrashCollection : MonoBehaviour
{
	public static TrashCollection instance;
	[Header("DO NOT CHANGE HERE")]
    [SerializeField] private int trashCollected;
	[SerializeField] private int trashTotal = 0;
	[SerializeField] private List<Vector3> CollectedTrashPositions = new List<Vector3>();
	[SerializeField] private bool generationCompleted = false;
	[SerializeField] private int trashCount = 0;

	public UnityEvent UpdateTrashCount;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
	        DontDestroyOnLoad(this.gameObject);
        }
        else
        {
	        instance.generationCompleted = true;
	        instance.trashCount = 0;
	        UpdateTrashCollectedText();
			Destroy(gameObject);
		}
    }

	private void Start()
	{
	}

	public int GetTrashId()
	{
		if (generationCompleted)
		{
			trashCount++;
			UpdateTrashCollectedText();
			return trashCount;
		}
		else
		{
			trashTotal++;
			UpdateTrashCollectedText();
			trashCount++;
			return trashCount;
		}
	}

    public void ChangeTrash(Vector3 trashPosition, int trashValue)
    {
        trashCollected += trashValue;
	    UpdateTrashCollectedText();
		Debug.Log($"Trash collected = {trashCollected}");
	    CollectedTrashPositions.Add(trashPosition);
    }

	public bool HasPickedUpTrash(Vector3 trashPosition)
	{
		return CollectedTrashPositions.Contains(trashPosition);
	}

	public int GetTrashCollected()
	{
		return trashCollected;
	}

	public int GetTrashTotal()
	{
		return trashTotal;
	}

	private void UpdateTrashCollectedText()
	{
		UpdateTrashCount.Invoke();
	}
}
