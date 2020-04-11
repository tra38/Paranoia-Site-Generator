using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Paranoia_Site_Generator
{
    class Program
    {
        /*
        static public List<string> GetList(MySqlDataReader mySqlDataReader)
        {
            var list = new List<string>();

            DataTable dt = new DataTable();
            dt.Load(MySql);


            var counter = mySqlDataReader.

            foreach (var item in mySqlDataReader )
            {
                Console.WriteLine(item.ToString());
                list.Add( item.ToString( ) );
            }

            return list;
        }
        */

            //Stories:
            //1) Gather data.
            //2) Populate static site with data.

            //Should the data simply be transformed into txt files? And then
            //I transfer said txt files to a static site generator?
            //Or do I roll my own static site generator?

            //Seems there's too many specific limits, and I need the practice,
            //so I'll generate my own static site generator. Time to look
            //at the pattern book.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var list = ForumFactory.Build();

            var list = Factory.Build<Forum>();

            foreach (var element in list)
            {
                Console.WriteLine($"{element.ForumName} - { element.ForumDesc }; topics: { element.ForumTopics }");
            }

            //string connStr = "server=localhost;user=root;database=alphacomplex;port=3306;";
            //MySqlConnection conn = new MySqlConnection(connStr);
            //try
            //{
            //    Console.WriteLine("Connecting to MySQL...");
            //    conn.Open();

            //    string sql = "SELECT * FROM phpbb_forums";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    MySqlDataReader rdr = cmd.ExecuteReader();

            //    DataTable dt = new DataTable();

            //    dt.Load(rdr);
            //    foreach (DataColumn col in dt.Columns)
            //    {
            //        Console.WriteLine($"{col.ColumnName} Info:");

            //        var counter = dt.Rows.Count;
            //        for (int i = 1; i < counter; i++)
            //        {
            //            Console.WriteLine($"{col.ColumnName}:{dt.Rows[i][col]}");
            //        }
            //        //TODO: create a static site using 'col.ColumnName', displaying all forums' info

            //        /*
            //        foreach (DataRowCollection row in dt.Rows[0])
            //        {

            //            Console.WriteLine(row[col.ColumnName]);
            //        }*/
            //    }

            //    /*

            //    while (rdr.Read( ) )
            //    {
            //        var list = GetList(rdr);
            //        Console.WriteLine(rdr[0]);
            //        Console.WriteLine(rdr[1]);
            //        Console.WriteLine(rdr[2]);
            //        Console.WriteLine(string.Join( "---", GetList( rdr ) ) );
            //    }
            //    */
            //    rdr.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //conn.Close();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
