using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayTagComponent : MonoBehaviour
{
    private readonly List<GameplayTag> _tags = new List<GameplayTag>();

    public void AddTag(string tagName)
    {
        var gameplayTag = GameplayTagManager.Instance.CreateTag(tagName);
        if (!_tags.Contains(gameplayTag))
        {
            _tags.Add(gameplayTag);
        }
    }

    public void RemoveTag(string tagName)
    {
        var gameplayTag = GameplayTagManager.Instance.GetTag(tagName);
        if (gameplayTag != null)
        {
            _tags.Remove(gameplayTag);
        }
    }

    public bool HasTag(string tagName)
    {
        var gameplayTag = GameplayTagManager.Instance.GetTag(tagName);
        return gameplayTag != null && _tags.Contains(gameplayTag);
    }

    public bool HasTagRecursive(string tagName)
    {
        var gameplayTag = GameplayTagManager.Instance.GetTag(tagName);
        return gameplayTag != null && _tags.Any(t => t == gameplayTag || t.HasChildTag(gameplayTag));
    }
}
