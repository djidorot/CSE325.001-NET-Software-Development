using System;

public class GameState
{
    public const int Rows = 6;
    public const int Cols = 7;

    // 0 = empty, 1 = Player 1, 2 = Player 2
    private int[,] board = new int[Rows, Cols];

    // 0-based index: 0..41 (also used for CSS piece array)
    public int CurrentTurn { get; private set; }

    // 1 or 2
    public int PlayerTurn => (CurrentTurn % 2) + 1;

    public bool GameOver { get; private set; }

    public enum WinState
    {
        None,
        Player1_Wins,
        Player2_Wins,
        Tie
    }

    public void ResetBoard()
    {
        board = new int[Rows, Cols];
        CurrentTurn = 0;
        GameOver = false;
    }

    /// <summary>
    /// Plays a piece in the given column (0-6) and returns the landing row (0-5, 0=top).
    /// Throws ArgumentException if column is full or game is over.
    /// </summary>
    public int PlayPiece(byte col)
    {
        if (GameOver)
        {
            throw new ArgumentException("The game is over. Please reset the game.");
        }

        if (col < 0 || col >= Cols)
        {
            throw new ArgumentException("Invalid column selected.");
        }

        // Find lowest empty row in this column
        for (int row = Rows - 1; row >= 0; row--)
        {
            if (board[row, col] == 0)
            {
                board[row, col] = PlayerTurn;
                CurrentTurn++;
                return row;
            }
        }

        throw new ArgumentException("This column is full. Try another column.");
    }

    public WinState CheckForWin()
    {
        // Horizontal, vertical, diagonal checks
        int winner = DetectWinner();
        if (winner == 1)
        {
            GameOver = true;
            return WinState.Player1_Wins;
        }
        if (winner == 2)
        {
            GameOver = true;
            return WinState.Player2_Wins;
        }

        // Tie: board full and no winner
        if (CurrentTurn >= Rows * Cols)
        {
            GameOver = true;
            return WinState.Tie;
        }

        return WinState.None;
    }

    private int DetectWinner()
    {
        // Horizontal
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c <= Cols - 4; c++)
            {
                int p = board[r, c];
                if (p != 0 &&
                    p == board[r, c + 1] &&
                    p == board[r, c + 2] &&
                    p == board[r, c + 3])
                {
                    return p;
                }
            }
        }

        // Vertical
        for (int c = 0; c < Cols; c++)
        {
            for (int r = 0; r <= Rows - 4; r++)
            {
                int p = board[r, c];
                if (p != 0 &&
                    p == board[r + 1, c] &&
                    p == board[r + 2, c] &&
                    p == board[r + 3, c])
                {
                    return p;
                }
            }
        }

        // Diagonal (\)
        for (int r = 0; r <= Rows - 4; r++)
        {
            for (int c = 0; c <= Cols - 4; c++)
            {
                int p = board[r, c];
                if (p != 0 &&
                    p == board[r + 1, c + 1] &&
                    p == board[r + 2, c + 2] &&
                    p == board[r + 3, c + 3])
                {
                    return p;
                }
            }
        }

        // Diagonal (/)
        for (int r = 3; r < Rows; r++)
        {
            for (int c = 0; c <= Cols - 4; c++)
            {
                int p = board[r, c];
                if (p != 0 &&
                    p == board[r - 1, c + 1] &&
                    p == board[r - 2, c + 2] &&
                    p == board[r - 3, c + 3])
                {
                    return p;
                }
            }
        }

        return 0; // no winner
    }
}
