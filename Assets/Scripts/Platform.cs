using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<GameObject> blocks;

    public void InsertBlock(GameObject block)
    {
        if(!blocks.Contains(block))
        {
            blocks.Add(block);
        }
    }

    public void RemoveBlock(GameObject block)
    {
        if (blocks.Contains(block))
        {
            blocks.Remove(block);
        }
    }
}
