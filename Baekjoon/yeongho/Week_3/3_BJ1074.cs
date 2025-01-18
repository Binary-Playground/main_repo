public class BJ1074 : IBaekjoon
{
    private int N, r, c;
    private int setOrder;
    private int ans = 0;
    private readonly int[] dr = new[] { 0, 0, 1, 1 };
    private readonly int[] dc = new[] { 0, 1, 0, 1 };
    
    public void Initialize()
    {
        var dimension = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        (N, r, c) = (dimension[0], dimension[1], dimension[2]);
        setOrder = 0;
    }

    public void Play()
    {
        ans = GetOrder(r, c);
    }

    public void Print()
    {
        Console.WriteLine(ans);
    }

    private int GetOrder(int getRow, int getCol)
    {
        return FineOrder(0, 0, getRow, getCol, (int)Math.Pow(2, N));
    }
    
    private int FineOrder(int row, int column, int findRow, int findCol, int size)
    {
        if (size == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                var (nr, nc) = (row + dr[i], column + dc[i]);
                if (nr == findRow && nc == findCol)
                {
                    return i;
                }
            }

            return 0;
        }
        
        var newSize = size / 2;
        if (row <= r && r < row + newSize)
        {
            if (column <= c && c < column + newSize)
                return FineOrder(row, column, findRow, findCol, newSize);
            else
                return newSize * newSize + FineOrder(row, column + newSize, findRow, findCol, newSize);
        }
        else
        {
            if (column <= c && c < column + newSize)
                return 2 * newSize * newSize + FineOrder(row+ newSize, column, findRow, findCol, newSize);
            else
                return 3 * newSize * newSize + FineOrder(row+ newSize, column + newSize, findRow, findCol, newSize);
        }
    }
    
}