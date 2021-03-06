using System;
using System.Collections.Generic;

public static class DictionaryExtensions
{
    public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : defaultValue;
    }

    public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> defaultValueProvider)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : defaultValueProvider();
    }
}