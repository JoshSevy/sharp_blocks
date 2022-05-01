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

        public bool CanPlace(Arr piece, int r, int c)
        {
            for (int y = 0; y < piece.Rows; y++)
            {
                for (int x = 0; x < piece.Cols; x++)
                {
                    int p = piece[y, x];
                    if (p == 0)
                    {
                        continue;
                    }
                    int br = r + y;
                    int bc = c + x;
                    if (br < 0 || bc >= rows)
                    {
                        return false;
                    }
                    if (this[br, bc] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Place(Arr piece, int r, int c)
        {
            for (int y = 0; y < piece.Rows; y++)
            {
                for (int x = 0; x < piece.Cols; x++)
                {
                    int p = piece[y, x];
                    if (p != 0)
                    {
                        this[r + y, c + x] = p;
                    }
                }
            }
        }

        public Arr Cloned
        {
            get => new(buf, rows);
        }
    }

}