using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class GameplayTag
{
    public string TagName { get; private set; }
    public GameplayTag ParentTag { get; private set; }
    private List<GameplayTag> _childTags;

    public GameplayTag(string tagName, GameplayTag parentTag = null)
    {
        TagName = tagName;
        ParentTag = parentTag;
        _childTags = new List<GameplayTag>();
    }

    public void AddChildTag(GameplayTag childTag)
    {
        if (_childTags.Contains(childTag)) return;
        
        _childTags.Add(childTag);
        childTag.ParentTag = this;
    }

    public bool HasChildTag(GameplayTag tag)
    {
        return _childTags.Contains(tag) || _childTags.Any(child => child.HasChildTag(tag));
    }

    public GameplayTag GetParentTag()
    {
        return ParentTag;
    }
}
