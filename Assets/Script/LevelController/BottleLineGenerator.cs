using UnityEngine;

public static class BottleLineGenerator
{
    public static ItemColor[] GenerateLine(int level, int length)
    {
        if (level < 10)
            return BalancedPattern(length);

        if (level < 20)
            return DominantPattern(length);

        if (level < 40)
            return MissingColorPattern(length);

        return ExtremePattern(length);
    }

    // --- Level 1–10 ---
    private static ItemColor[] BalancedPattern(int length)
    {
        ItemColor[] line = new ItemColor[length];
        int colors = 4;

        for (int i = 0; i < length; i++)
            line[i] = (ItemColor)(i % colors);

        Shuffle(line);
        return line;
    }

    // --- Level 10–20 ---
    private static ItemColor[] DominantPattern(int length)
    {
        ItemColor[] line = new ItemColor[length];

        ItemColor dominant = (ItemColor)Random.Range(0, 4);
        int dominantCount = length / 2;

        for (int i = 0; i < dominantCount; i++)
            line[i] = dominant;

        for (int i = dominantCount; i < length; i++)
            line[i] = (ItemColor)Random.Range(0, 4);

        Shuffle(line);
        return line;
    }

    // --- Level 20–40 ---
    private static ItemColor[] MissingColorPattern(int length)
    {
        ItemColor missing = (ItemColor)Random.Range(0, 4);
        ItemColor[] line = new ItemColor[length];

        for (int i = 0; i < length; i++)
        {
            ItemColor c;
            do
            {
                c = (ItemColor)Random.Range(0, 4);
            }
            while (c == missing);

            line[i] = c;
        }

        Shuffle(line);
        return line;
    }

    // --- Level 40+ ---
    private static ItemColor[] ExtremePattern(int length)
    {
        ItemColor[] line = new ItemColor[length];
        ItemColor dominant = (ItemColor)Random.Range(0, 4);

        for (int i = 0; i < length; i++)
            line[i] = dominant;

        // Add small diversity
        int swaps = Random.Range(1, 3);
        for (int i = 0; i < swaps; i++)
            line[Random.Range(0, length)] = (ItemColor)Random.Range(0, 4);

        Shuffle(line);
        return line;
    }

    private static void Shuffle(ItemColor[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
