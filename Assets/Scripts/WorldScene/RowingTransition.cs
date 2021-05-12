using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RowingTransition : MonoBehaviour
{
    public GameObject rowingParent;
    public float x, y;
    [SerializeField] PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        x = transform.position.x;
        y = transform.position.y;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
    }
}