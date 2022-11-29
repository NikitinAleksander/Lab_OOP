
namespace lab_5
{
    class Info
    {
        private double Price;

        private int Count;

        public Info(int tmp_count,double tmp_price)
        {
            Price = tmp_price;
            Count = tmp_count;
        }

        public void Change_info(int tmp_count, double tmp_price)
        {
            Price = tmp_price;
            Count += tmp_count;
        }

        public void Change_info(int tmp_count)
        {
            Count += tmp_count;
        }

        public double Get_price()
        {
            return Price;
        }

        public int Get_count()
        {
            return Count;
        }
    }
}
