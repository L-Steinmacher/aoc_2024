using System;
using System.Collections.Generic;

public class SimilarityDict
{
    public enum ListType
    {
        left_ids,
        right_ids
    }
    private Dictionary<int, Dictionary<ListType, int>> _data;
    public int similarityScore { get; private set; }

    public SimilarityDict()
    {
        _data = new Dictionary<int, Dictionary<ListType, int>>();
    }

    public void Increment(int key, ListType listType)
    {
        if (!_data.ContainsKey(key))
        {
            _data[key] = new Dictionary<ListType, int>
            {
                { ListType.left_ids, 0 },
                { ListType.right_ids, 0 }
            };
        }

        _data[key][listType]++;
    }

    public void PrintData()
    {
        int localSimilarityScore = 0;  // Local variable instead of modifying class field
        foreach (var outerKey in _data.Keys)
        {
            var innerDict = _data[outerKey];
            if (innerDict[ListType.left_ids] != 0)
            {
                localSimilarityScore += outerKey * innerDict[ListType.left_ids] * innerDict[ListType.right_ids];
            }
        }
        similarityScore = localSimilarityScore;  // Set the class field only once
        // Console.WriteLine($"Similarity Score: {similarityScore}");
    }

    public Dictionary<int, Dictionary<ListType, int>> GetData()
    {
        return _data;
    }
}