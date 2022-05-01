namespace Blocks
{
    public class Arr
    {
        private readonly int[] buf;
        private readonly int rows;
        private readonly int cols;

        public int Rows
        {
            get => rows;
        }

        public int Cols
        {
            get => cols;
        }

        public int this[int r, int c]
        {
            get => buf[cols * r + c];
            set => buf[cols * r + c] = value;
        }

        public Arr(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            buf = new int[this.rows * this.cols];
        }

        public Arr(int[] source, int rows)
        {
            this.rows = rows;
            cols = source.Length / this.rows;
            buf = new int[this.rows * cols];
            source.CopyTo(buf, 0);
        }
    }
}