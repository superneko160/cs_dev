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
         * ���ϒl
         * @param double[] data �f�[�^�Z�b�g
         * @return double ���ϒl
         */
        private double mean(double[] data)
        {
            // ���ϒl
            return data.Average();
        }

        /**
         * �����l
         * @param double[] data �f�[�^�Z�b�g
         * @return double �����l
         */
        private double median(double[] data)
        {
            // �����\�[�g
            Array.Sort(data);
            // �f�[�^�̌�������
            if (data.Length % 2 == 0)
            {
                return (data[(data.Length / 2) - 1] + data[data.Length / 2]) / 2.0;
            }
            // �f�[�^�̌����
            return data[data.Length / 2];
        }

        /**
         * �ŕp�l
         * @param double[] data �f�[�^�Z�b�g
         * @return IEnumerable<double> �ŕp�l
         */
        private IEnumerable<double> modes(double[] data)
        {
            var groups = data.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() });  // �l�Ƃ��̏o���񐔂̎����쐬
            int maxCount = groups.Max(g => g.Count);  // �o���񐔂̍ő�l���擾
            return groups.Where(g => g.Count == maxCount).Select(g => g.Value);  // �o���񐔂��ő�l�̒l���擾
        }

        /**
         * ���U�i��(xi - x����) ** 2 / ���a�j
         * @param double[] data �f�[�^�Z�b�g
         * @return double ���U
         */
        private double variance(double[] data)
        {
            // ���U�̌v�Z���̕��q���Z�o
            double numerator = varianceNumerator(data);
            return numerator / data.Length;
        }

        /**
         * ���U�̌v�Z���̕��q���Z�o�i��(xi - x����) ** 2�j
         * @param double[] data �f�[�^�Z�b�g
         * @return double ���q�̒l
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
         * �W���΍��i���U�̕������j
         * @param variance ���U
         * @return double �W���΍�
         */
        private double standardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }
    }
}
