using System;
using System.Collections.Generic;

public static class ListShuffleExtension
{
    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int k = rng.Next(i + 1);
            T value = list[k];
            list[k] = list[i];
            list[i] = value;
        }
    }
}