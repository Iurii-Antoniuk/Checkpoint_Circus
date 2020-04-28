using System;

namespace Database_Api
{
    class Program
    {
        static void Main(string[] args)
        {
            DbPopulator dbPopulator = new DbPopulator();
            dbPopulator.Populate();
        }
    }
}
