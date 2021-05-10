using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCollection : MonoBehaviour
{
	public static TrashCollection instance;
    public Text text;
    private static int trashCollected;
	private static int trashTotal = 0;
	private static List<int> CollectedTrashIds = new List<int>();
	private bool generationCompleted = false;
	private int trashCount = 0;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
	        instance.generationCompleted = true;
	        text.text = "Trash collected: " + trashCollected + "/" + trashTotal;
		}
    }

	private void Start()
	{

	}

	public int GetTrashId()
	{
		if (generationCompleted)
		{
			trashTotal++;
			return trashTotal;
		}
		else
		{
			trashCount++;
			return trashCount;
		}
	}

    public void ChangeTrash(int trashId, int trashValue)
    {
        trashCollected += trashValue;
        text.text = "Trash collected: " + trashCollected + "/" + trashTotal;
        Debug.Log($"Trash collected = {trashCollected}");
	    CollectedTrashIds.Add(trashId);
    }

	public bool HasPickedUpTrash(int trashId)
	{
		return CollectedTrashIds.Contains(trashId);
	}
}
