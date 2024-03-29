using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> Flatten<T>(
        this IEnumerable<T> items,
        Func<T, IEnumerable<T>> getChildren)
    {
        if (items == null)
        {
            yield break;
        }

        var stack = new Stack<T>(items);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;

            if (current == null) { continue; }

            var children = getChildren(current);
            if (children == null) { continue; }

            foreach (var child in children)
            {
                stack.Push(child);
            }
        }
    }
}