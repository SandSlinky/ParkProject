using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashTextUpdater : MonoBehaviour
{
	[SerializeField] private Text text;

    private void Awake()
    {
        TrashCollection.instance.UpdateTrashCount.AddListener(UpdateText);
    }

	private void OnDestroy()
	{
		TrashCollection.instance.UpdateTrashCount.RemoveListener(UpdateText);
	}

	private void UpdateText()
	{
		text.text = "Trash collected: " + TrashCollection.instance.GetTrashCollected() + "/" + TrashCollection.instance.GetTrashTotal();
	}
}
