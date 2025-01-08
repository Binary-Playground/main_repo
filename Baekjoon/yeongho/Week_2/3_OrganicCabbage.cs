public class Program
{
    public static void Main()
    {
        OrganicCabbage tool = new OrganicCabbage();

        //초기화 및 입력
        tool.Initialize();
        
        // 시뮬레이션 시작
        tool.Play();
    }
}

public class OrganicCabbage
{
    private Queue<FieldSimulation> _simulations;
    
    //입력 및 초기화
    public void Initialize()
    {
        _simulations = new Queue<FieldSimulation>();
        
        int testCase = int.Parse(Console.ReadLine());
        for (int i = 0; i < testCase; i++)
        {
            var dimension = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int width = dimension[0];
            int height = dimension[1];
            int cabbageCnt = dimension[2];
            int[,] field = new int[height, width];

            for (int j = 0; j < cabbageCnt; j++)
            {
                int[] pos = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var (x, y) = (pos[0], pos[1]);
                field[y, x] = 1;
            }
            
            _simulations.Enqueue(new FieldSimulation(field, height, width));
        }
    }

    public void Play()
    {
        while (_simulations.Count != 0)
        {
            var simulation = _simulations.Dequeue();
            simulation.Start();
            simulation.PrintResult();
        }
    }
    
    public class FieldSimulation
    {
        private int[,] _field;
        private bool[,] _visited;
        private int RowSize;
        private int ColumSize;
        private int ans;
        // 상하좌우
        public readonly int[] dx = new[] { 0, 0, -1, 1 };
        public readonly int[] dy = new[] { 1, -1, 0, 0 };
        
        public FieldSimulation(int[,] field, int rowSize, int colSize)
        {
            _field = field;
            RowSize = rowSize;
            ColumSize = colSize;
            _visited = new bool[rowSize,colSize];
        }

        public void Start()
        {
            for (int r = 0; r < RowSize; r++)
            {
                for (int c = 0; c < ColumSize; c++)
                {
                    if(IsMovable(c,r))
                        DFS(c,r);
                }
            }
        }

        private void DFS(int c, int r)
        {
            Queue<(int, int)> qCabbages = new Queue<(int, int)>();
            qCabbages.Enqueue((c,r));
            _visited[r, c] = true;
            
            while (qCabbages.Count != 0)
            {
                var (x, y) = qCabbages.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    var nx = x + dx[i];
                    var ny = y + dy[i];

                    if (!InRange(nx, ny)) continue;
                    if (!IsMovable(nx, ny)) continue;

                    _visited[ny, nx] = true;
                    qCabbages.Enqueue((nx, ny));
                }
            }
            
            ans += 1;
        }

        private bool InRange(int x, int y)
        {
            return x >= 0 && x < ColumSize && y >= 0 && y < RowSize;
        }

        private bool IsMovable(int x, int y)
        {
            return !_visited[y, x] && _field[y,x] == 1;
        }

        public void PrintResult()
        {
            Console.WriteLine(ans);
        }
    }
    
}