namespace Cours05_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Debug backlog
            int result = 0; 
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"TXT地址", true))
            {
                file.WriteLine(result);
            }

        }
    }
}