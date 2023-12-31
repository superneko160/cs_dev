namespace Statistics
{
    public partial class Form1 : Form
    {
        private double[] data;
        private Label[] results;

        public Form1()
        {
            data = [
                100, 60, 70, 900, 100, 200,
                500, 500, 503, 600, 1000, 1200
            ];
            Label[] results = new Label[5];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = new Label();
            }
            results[0].Text = $"Mean: {mean(data):F5}";
            results[1].Text = $"Median: {median(data):F5}";
            results[2].Text = $"Mode: {string.Join(" ", modes(data))}";
            results[3].Text = $"Variance: {variance(data):F5}";
            results[4].Text = $"Standard deviation: {standardDeviation(variance(data)):F5}";
            int resultHeight = 0;
            foreach (Label result in results)
            {
                result.Width = Width;
                result.Location = new Point(0, resultHeight);
                result.Parent = this;
                resultHeight += 25;
            }
            InitializeComponent();
        }

        /**
         * 平均値
         * @param double[] data データセット
         * @return double 平均値
         */
        private double mean(double[] data)
        {
            // 平均値
            return data.Average();
        }

        /**
         * 中央値
         * @param double[] data データセット
         * @return double 中央値
         */
        private double median(double[] data)
        {
            // 昇順ソート
            Array.Sort(data);
            // データの個数が偶数
            if (data.Length % 2 == 0)
            {
                return (data[(data.Length / 2) - 1] + data[data.Length / 2]) / 2.0;
            }
            // データの個数が奇数
            return data[data.Length / 2];
        }

        /**
         * 最頻値
         * @param double[] data データセット
         * @return IEnumerable<double> 最頻値
         */
        private IEnumerable<double> modes(double[] data)
        {
            var groups = data.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() });  // 値とその出現回数の辞書作成
            int maxCount = groups.Max(g => g.Count);  // 出現回数の最大値を取得
            return groups.Where(g => g.Count == maxCount).Select(g => g.Value);  // 出現回数が最大値の値を取得
        }

        /**
         * 分散（Σ(xi - x平均) ** 2 / 総和）
         * @param double[] data データセット
         * @return double 分散
         */
        private double variance(double[] data)
        {
            // 分散の計算式の分子を算出
            double numerator = varianceNumerator(data);
            return numerator / data.Length;
        }

        /**
         * 分散の計算式の分子を算出（Σ(xi - x平均) ** 2）
         * @param double[] data データセット
         * @return double 分子の値
         */
        private double varianceNumerator(double[] data)
        {
            double mean = this.mean(data);
            double[] result = new double[data.Length];
            foreach (var d in data.Select((value, index) => new {value, index}))
            {
                result[d.index] = Math.Pow((d.value - mean), 2);
            }
            return result.Sum();
        }

        /**
         * 標準偏差（分散の平方根）
         * @param variance 分散
         * @return double 標準偏差
         */
        private double standardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }
    }
}
