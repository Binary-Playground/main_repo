public class BJ1546 : IBaekjoon
{
    private float[] scores;
    
    public void Initialize()
    {
        int N = int.Parse(Console.ReadLine());
        scores = new float[N];
        scores = Array.ConvertAll(Console.ReadLine().Split(), float.Parse);
    }

    public void Play()
    {
        float maxNum = scores.Max();
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = scores[i] / maxNum * 100;
        }
    }

    public void Print()
    {
        Console.WriteLine(scores.Average());
    }
}