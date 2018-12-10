namespace intent
{
    class DataBase
    {
        public string Res { get; set; }


        public DataBase(string res)
        {
            Res = res;

        }

        public DataBase()
        {

        }

        public DataBase(string[] name)
        {
        }

        public override string ToString()
        {
            return Res;

        }
    }
}