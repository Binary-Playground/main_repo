public class BJ1202 : IBaejoon
{
    private List<Jewelry> Jewelries;
    private List<Bag> bags;
    private long ans;
    public void Initialize()
    {
        var dimension = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        var (N, K) = (dimension[0], dimension[1]);

        Jewelries = new List<Jewelry>();
        for (int i = 0; i < N; i++)
        {
            var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var (weight, value) = (inputs[0], inputs[1]);
            Jewelries.Add(new Jewelry(weight, value));
        }
        Jewelries.Sort();

        bags = new List<Bag>();
        for (int i = 0; i < K; i++)
        {
            var weight = int.Parse(Console.ReadLine());
            bags.Add(new Bag(weight));
        }
        bags.Sort();
        
        ans = 0;
    }

    public void Play()
    {
        var jewelryQueue = new PriorityQueue<Jewelry, int>();

        int idx = 0;
        foreach (var bag in bags)
        {
            while (idx < Jewelries.Count && Jewelries[idx].Weight <= bag.Weight)
            {
                jewelryQueue.Enqueue(Jewelries[idx], -Jewelries[idx].Value);
                idx++;
            }

            if (jewelryQueue.Count == 0) continue;

            var curJewelry = jewelryQueue.Dequeue();
            ans += curJewelry.Value;
        }
    }

    public void Print()
    {
        Console.WriteLine(ans);
    }

    private class Jewelry : IComparable<Jewelry>
    {
        public int Weight { get; private set; }
        public int Value { get; private set; }

        public Jewelry(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }

        public int CompareTo(Jewelry other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    private class Bag : IComparable<Bag>
    {
        public int Weight { get; private set; }

        public Bag(int weight)
        {
            Weight = weight;
        }

        public int CompareTo(Bag orther)
        {
            return Weight.CompareTo(orther.Weight);
        }
    }
}