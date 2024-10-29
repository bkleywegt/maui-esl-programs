namespace MauiEslPrograms.Helpers;

public class WordSearchHelper
{
    private static readonly Random Random = new Random();
    
    public static string GenerateWordSearch(int gridSize, bool allowReverseWords, List<string> words)
    {
        char[,] grid = new char[gridSize, gridSize];

        // Initialize the grid with placeholders (e.g., '.')
        for (int i = 0; i < gridSize; i++)
        for (int j = 0; j < gridSize; j++)
            grid[i, j] = '.';

        // Place each word in the grid
        foreach (var word in words)
        {
            bool placed = false;
            
            foreach (var i in Enumerable.Range(0, gridSize).OrderBy(x => Random.Next()))
            {
                foreach (var j in Enumerable.Range(0, gridSize).OrderBy(x => Random.Next()))
                {
                    foreach (var k in Enumerable.Range(0, allowReverseWords ? 6 : 3).OrderBy(x => Random.Next()))
                    {
                        int row = i;
                        int col = j;
                        int direction = k; 
                        // 0: horizontal, 1: vertical, 2: diagonal

                        placed = PlaceWordInGrid(word, grid, row, col, direction);
                        
                        if (placed)
                        {
                            break;
                        }
                    }
                    
                    if (placed)
                    {
                        break;
                    }
                }
                
                if (placed)
                {
                    break;
                }
            }
            
            if (!placed)
            {
                throw new Exception("Failed to place all words in the grid. Please try again.");
            }
        }

        // Fill remaining empty spots with random letters
        FillRandomLetters(grid);

        return GridToString(grid);
    }

    private static bool PlaceWordInGrid(string word, char[,] grid, int row, int col, int direction)
    {
        int gridSize = grid.GetLength(0);
        int wordLength = word.Length;
        word = word.ToUpper();

        // Check if the word fits in the selected direction and position
        if (direction == 0) // Horizontal
        {
            if (col + wordLength > gridSize) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row, col + i] != '.' && grid[row, col + i] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row, col + i] = word[i];
        }
        else if (direction == 1) // Vertical
        {
            if (row + wordLength > gridSize) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row + i, col] != '.' && grid[row + i, col] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row + i, col] = word[i];
        }
        else if (direction == 2) // Diagonal
        {
            if (row + wordLength > gridSize || col + wordLength > gridSize) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row + i, col + i] != '.' && grid[row + i, col + i] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row + i, col + i] = word[i];
        }
        else if (direction == 3) // Reverse Horizontal
        {
            if (col - wordLength + 1 < 0) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row, col - i] != '.' && grid[row, col - i] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row, col - i] = word[i];
        }
        else if (direction == 4) // Reverse Vertical
        {
            if (row - wordLength + 1 < 0) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row - i, col] != '.' && grid[row - i, col] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row - i, col] = word[i];
        }
        else if (direction == 5) // Reverse Diagonal
        {
            if (row - wordLength + 1 < 0 || col - wordLength + 1 < 0) return false;
            for (int i = 0; i < wordLength; i++)
                if (grid[row - i, col - i] != '.' && grid[row - i, col - i] != word[i])
                    return false;
            for (int i = 0; i < wordLength; i++)
                grid[row - i, col - i] = word[i];
        }
        else
        {
            return false;
        }

        return true;
    }

    private static void FillRandomLetters(char[,] grid)
    {
        int gridSize = grid.GetLength(0);
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (grid[i, j] == '.')
                {
                    grid[i, j] = (char)('A' + Random.Next(0, 26));
                }
            }
        }
    }
    
    private static string GridToString(char[,] grid)
    {
        string result = "";
        int gridSize = grid.GetLength(0);
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                result += (grid[i, j] + " ");
            }
            result += "\n";
        }

        return result;
    }
}