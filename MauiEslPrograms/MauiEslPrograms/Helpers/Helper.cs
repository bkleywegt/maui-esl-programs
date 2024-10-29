namespace MauiEslPrograms.Helpers;

public class Helper
{
    public static string FisherYatesShuffle(string input)
    {
        Random random = new Random();
        char[] characters = input.ToCharArray();

        for (int i = characters.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap characters[i] with characters[j]
            (characters[i], characters[j]) = (characters[j], characters[i]);
        }

        return new string(characters);
    }
    
    public static string FisherYatesShuffleSentence(string input)
    {
        var random = new Random();
        var words = input.Split(" ");

        for (int i = words.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap characters[i] with characters[j]
            (words[i], words[j]) = (words[j], words[i]);
        }

        return string.Join(" ", words);
    }
    
    public static string FisherYatesShuffleStory(string input)
    {
        var random = new Random();
        var sentences = input.Split("\n");

        for (int i = sentences.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap characters[i] with characters[j]
            (sentences[i], sentences[j]) = (sentences[j], sentences[i]);
        }

        return string.Join("\n", sentences);
    }
}