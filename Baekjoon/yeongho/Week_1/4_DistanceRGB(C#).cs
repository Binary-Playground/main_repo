public class Program
{
    public static void Main()
    {
        DistanceRGB simulation = new DistanceRGB();

        // 입력 및 초기화
        simulation.Initialize();

        // 입력 및 초기화
        simulation.Play();
    }
}

public class DistanceRGB
{
    private int[,] rgbArray;
    private int[,] db;
    private int length;
    public void Initialize()
    {
        length = int.Parse(Console.ReadLine());
        rgbArray = new int[length, 3];
        for (var i = 0; i < length; i++)
        {
            var rgb = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            (rgbArray[i, 0], rgbArray[i, 1], rgbArray[i, 2]) = (rgb[0], rgb[1], rgb[2]);
        }

        db = new int[length, 3];
        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                db[i, j] = int.MaxValue;
            }
        }
    }

    public void Play()
    {
        // 첫째줄 세팅
        for (var i = 0; i < 3; i++)
        {
            db[0, i] = rgbArray[0, i];
        }

        // i번째 선택 시퀀스에서, j번째 집을 선택 했을때 최소 cost 없데이트
        for (var l = 1; l < length; l++)
        {
            for (var j = 0; j < 3; j++)
            {
                for (var k = 0; k < 3; k++)
                {
                    if (j == k) continue;

                    db[l, j] = Math.Min(db[l, j], rgbArray[l, j] + db[l - 1, k]);
                }
            }
        }

        var ans = int.MaxValue;
        // 첫째줄 세팅
        for (var i = 0; i < 3; i++)
            ans = Math.Min(ans, db[length - 1, i]);
        Console.WriteLine(ans);
    }
}