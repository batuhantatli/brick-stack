using GamesMrkt.Core;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    private List<Brick> list = new List<Brick>();
    public void Add(Brick arg)
    {
        if (list.Contains(arg))
            return;

        list.Add(arg);
    }
    public void Remove(Brick arg)
    {
        if (!list.Contains(arg))
            return;

        list.Remove(arg);
    }

    private List<Brick> building = new List<Brick>();
    public void Build(Brick args)
    {
        if (building.Contains(args))
            return;

        building.Add(args);

        if (building.Count == list.Count)
        {
            LevelManager.OnLevelComplete?.Invoke(LevelManager.Level);
            Debug.Log("Level Complete");
        }
    }
}