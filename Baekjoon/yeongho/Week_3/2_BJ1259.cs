public class BJ1259 : IBaejoon
{
    public void Initialize()
    {
        
    }

    public void Play()
    {
        while (true)
        {
            var str = Console.ReadLine();
            if (str.Equals("0"))
                break;

            Console.WriteLine(CheckPlanDrop(str) ? "yes" : "no");
            
        }
    }

    public void Print()
    {
        
    }

    private bool CheckPlanDrop(string str)
    {
        bool tf = true;

        // 1개의 string 이면 플랜드롬수 이다.
        if (str.Length == 1) return tf;
        
        for (int i = 0; i < str.Length/2; i++)
        {
            if (!str[i].Equals(str[str.Length - i - 1]))
                return false;
        }

        return tf;
    }
}