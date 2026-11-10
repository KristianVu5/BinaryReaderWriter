using System;
using System.IO;

class Program
{
    private const string name = "test.dat";
    static void Main()
    {
        if (File.Exists(name))
        {
            Console.WriteLine("The file {0} already exists!", name);

            FileStream ms = new FileStream(name, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(ms);
            for(int i = 0; i < 11; i++)
            {
                Console.WriteLine(r.ReadInt32());
            }
            r.Close();
            ms.Close();
            Console.ReadKey();
            return;
        }
        else
        {
            FileStream fs = new FileStream(name, FileMode.CreateNew);
            BinaryWriter w = new BinaryWriter(fs);
            for(int i = 0; i < 11; i++)
            {
                w.Write(i);
            }
            w.Close();
            fs.Close();

            fs = new FileStream(name, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            for(int i = 0; i < 11; i++)
            {
                Console.WriteLine(r.ReadInt32());
            }
            w.Close();
            fs.Close();
        }
    }
}
