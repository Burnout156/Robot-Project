using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<GameObject> blocks;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void InsertBlock(GameObject block)
    {
        if(!blocks.Contains(block))
        {
            blocks.Add(block);
        }

        StartCoroutine(DelayCheck());
    }

    public void RemoveBlock(GameObject block)
    {
        if (blocks.Contains(block))
        {
            blocks.Remove(block);
        }
    }

    public IEnumerator DelayCheck()
    {
        yield return new WaitForSeconds(0.1f);
        gameManager.CheckVictory();
    }
}
