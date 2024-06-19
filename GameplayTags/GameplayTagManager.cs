using System.Collections.Generic;
using UnityEngine;

public class GameplayTagManager : MonoBehaviour
{
    private readonly Dictionary<string, GameplayTag> _allTags = new Dictionary<string, GameplayTag>();

    public static GameplayTagManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameplayTag CreateTag(string tagName, string parentTagName = null)
    {
        if (_allTags.ContainsKey(tagName)) return _allTags[tagName];
        GameplayTag parentTag = null;
        if (parentTagName != null)
        {
            parentTag = CreateTag(parentTagName);
        }
        var newTag = new GameplayTag(tagName, parentTag);
        _allTags.Add(tagName, newTag);
        parentTag?.AddChildTag(newTag);
        return _allTags[tagName];
    }

    public GameplayTag GetTag(string tagName)
    {
        _allTags.TryGetValue(tagName, out var tag);
        return tag;
    }
}
