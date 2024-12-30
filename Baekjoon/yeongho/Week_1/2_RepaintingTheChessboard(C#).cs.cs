using System;

class Program
{
    public static void Main()
    {
        Repainting_Chessborad simulation = new Repainting_Chessborad();
        
        // 입력 및 초기화
        simulation.InitializeBoard();
        
        // 바꿔야 할 Block 체크
        simulation.CalculateRepaintingCosts();
        
        // 결과 출력
        Console.WriteLine(simulation.GetMinimumRepaintingCost());
    }
}

public class Repainting_Chessborad
{
    private int _rowSize;
    private int _colSize;
    private ChessBlock[,] _board;
    private BlockColor GetOppositeColor(BlockColor color) => color == BlockColor.White ? BlockColor.Black : BlockColor.White;
    
    public void InitializeBoard()
    {
        var dimensions = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        _rowSize = dimensions[0];
        _colSize = dimensions[1];
        
        _board = new ChessBlock[_rowSize,_colSize];

        for (int r = 0; r < _rowSize; r++)
        {
            string line = Console.ReadLine();
            for (int c = 0; c < _colSize; c++)
            {
                _board[r, c] = new ChessBlock()
                {
                    Color = line[c] == 'W' ? BlockColor.White : BlockColor.Black
                };
            }
        }
    }

    public void CalculateRepaintingCosts()
    {
        for (int r = 0; r < _rowSize; r++)
        {
            for (int c = 0; c < _colSize; c++)
            {
                BlockColor expectedColorWhite = (r + c) % 2 == 0 ? BlockColor.White : BlockColor.Black;
                BlockColor expectedColorBlack = GetOppositeColor(expectedColorWhite);

                _board[r, c].WhiteStartCost = (r > 0 ? _board[r - 1, c].WhiteStartCost : 0) +
                                              (c > 0 ? _board[r, c - 1].WhiteStartCost : 0) -
                                              (r > 0 && c > 0 ? _board[r - 1, c - 1].WhiteStartCost : 0) +
                                              (_board[r, c].Color == expectedColorWhite ? 0 : 1);
                
                _board[r, c].BlackStartCost = (r > 0 ? _board[r - 1, c].BlackStartCost : 0) +
                                              (c > 0 ? _board[r, c - 1].BlackStartCost : 0) -
                                              (r > 0 && c > 0 ? _board[r - 1, c - 1].BlackStartCost : 0) +
                                              (_board[r, c].Color == expectedColorBlack ? 0 : 1);
            }
        }
    }

    public int GetMinimumRepaintingCost()
    {
        int minCost = int.MaxValue;

        for (int r = 7; r < _rowSize; r++)
        {
            for (int c = 7; c < _colSize; c++)
            {
                int whiteCost = CalculateCost(r, c, true);
                int blackCost = CalculateCost(r, c, false);

                minCost = Math.Min(minCost, Math.Min(whiteCost, blackCost));
            }
        }

        return minCost;
    }

    private int CalculateCost(int r, int c, bool startWithWhite)
    {
        int totalCost = startWithWhite ? _board[r, c].WhiteStartCost : _board[r, c].BlackStartCost;

        if (r >= 8) totalCost -= startWithWhite ? _board[r - 8, c].WhiteStartCost : _board[r - 8, c].BlackStartCost;
        if (c >= 8) totalCost -= startWithWhite ? _board[r, c - 8].WhiteStartCost : _board[r, c - 8].BlackStartCost;
        if (r >= 8 && c >= 8) totalCost += startWithWhite ? _board[r - 8, c - 8].WhiteStartCost : _board[r - 8, c - 8].BlackStartCost;

        return totalCost;
    }
}

public enum BlockColor
{
    White,
    Black
}

public class ChessBlock
{
    public BlockColor Color { get; set; }
    public int WhiteStartCost { get; set; }
    public int BlackStartCost { get; set; }
}