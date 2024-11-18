using System;
using System.Collections;
using System.Collections.Generic;

public class Set<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> elements;

    public Set()
    {
        elements = new List<T>();
    }

    public Set(T[] array)
    {
        elements = new List<T>();
        foreach (var item in array)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        if (!Contains(item))
        {
            elements.Add(item);
        }
    }

    public void Remove(T item)
    {
        elements.Remove(item);
    }

    public bool Contains(T item)
    {
        return elements.Contains(item);
    }

    public Set<T> Union(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (var item in elements)
        {
            result.Add(item);
        }
        foreach (var item in other)
        {
            result.Add(item);
        }
        return result;
    }

    public Set<T> Intersection(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (var item in elements)
        {
            if (other.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public Set<T> Difference(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (var item in elements)
        {
            if (!other.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public Set<T> SymmetricDifference(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (var item in elements)
        {
            if (!other.Contains(item))
            {
                result.Add(item);
            }
        }
        foreach (var item in other)
        {
            if (!Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public bool IsSubsetOf(Set<T> other)
    {
        foreach (var item in elements)
        {
            if (!other.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsSupersetOf(Set<T> other)
    {
        foreach (var item in other)
        {
            if (!Contains(item))
            {
                return false;
            }
        }
        return true;
    }

    public void Clear()
    {
        elements.Clear();
    }

    public int Count()
    {
        return elements.Count;
    }

    public T[] ToArray()
    {
        return elements.ToArray();
    }

    public static Set<T> UnionAll(Set<T>[] sets)
    {
        Set<T> result = new Set<T>();
        foreach (var set in sets)
        {
            foreach (var item in set)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public Set<T> Sorted()
    {
        List<T> sortedList = new List<T>(elements);
        sortedList.Sort();
        return new Set<T>(sortedList.ToArray());
    }

    public Set<T> Reverse()
    {
        List<T> reversedList = new List<T>(elements);
        reversedList.Reverse();
        return new Set<T>(reversedList.ToArray());
    }

    public Set<T> Clone()
    {
        return new Set<T>(elements.ToArray());
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", elements) + "}"; // Форматирование строки с элементами
    }

    public bool Equals(Set<T> other)
    {
        if (Count() != other.Count())
        {
            return false;
        }
        foreach (var item in elements)
        {
            if (!other.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in elements)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Set<int> setA = new Set<int>();

        Set<int> setB = new Set<int>();

        Set<int> setC = new Set<int>();

        setA.Add(1);
        setA.Add(2);
        setA.Add(3);

        setB.Add(3);
        setB.Add(4);
        setB.Add(5);

        setC.Add(1);
        setC.Add(2);

        Console.WriteLine("Задание №1");
        Console.WriteLine(setA.SymmetricDifference(setB));

        Console.WriteLine("\nЗадание №2");
        if (setC.IsSubsetOf(setA)) Console.WriteLine("метод являяется подмножеством");
        else Console.WriteLine("метод НЕ являяется подмножеством");

        Console.WriteLine("\nЗадание №3");
        if (setA.IsSupersetOf(setC)) Console.WriteLine("метод являяется надммножеством");
        else Console.WriteLine("метод НЕ являяется надммножеством");

        Console.WriteLine("\nЗадание №4");
        setC.Clear();
        Console.WriteLine("Множество очищено ");

        Console.WriteLine("\nЗадание №5");
        Console.WriteLine("Количество элементов в A: " + setA.Count());

        Console.WriteLine("\nЗадание №6");
        var setD = new Set<int>();
        setD.Add(1);
        setD.Add(1);
        setD.Add(2);
        Console.WriteLine(setD);

        Console.WriteLine("\nЗадание №7");
        var array = setA.ToArray();
        Console.WriteLine("Массив из A: " + string.Join(", ", array));

        Console.WriteLine("\nЗадание №8");
        Set<int> newSet = Set<int>.UnionAll(new Set<int>[] { setA, setB });
        Console.WriteLine(newSet);

        Console.WriteLine("\nЗадание №9");
        // тута

        Console.WriteLine("\nЗадание №10");
        // тута

        Console.WriteLine("\nЗадание №11");
        // тута

        Console.WriteLine("\nЗадание №12");
        Console.WriteLine(setA.Equals(setB));

        Console.WriteLine("\nЗадание №13");
        Console.WriteLine(setA.Sorted());

        Console.WriteLine("\nЗадание №14");
        Console.WriteLine(setB.Clone());

        Console.WriteLine("\nЗадание №15");
        Console.WriteLine(setB.Reverse());

        Console.WriteLine("\nЗадание №16");
        if (setC.IsEmpty()) Console.WriteLine("Множество C пустое");

        Console.WriteLine("\nЗадание №17");
        Console.WriteLine(setC);

        Console.WriteLine("\nЗадание №18");
        setA.Add(3);
        Console.WriteLine(setA);

        Console.WriteLine("\nЗадание №19");
        // это
    }
}
