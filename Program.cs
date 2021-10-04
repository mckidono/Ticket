using System;
//using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\ticket.csv";
            string input;
            string ColumnID="TicketID,Summary,Status,Priority,Submitter,Assigned,Watching";
            string firstLine="1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones";

            Console.WriteLine("Enter 1 to read all tickets");
            Console.WriteLine("Enter 2 to write a new line");

            input= Console.ReadLine();

            if (input=="1"){
                using (StreamReader sr=new StreamReader(FilePath)){
                    while(!sr.EndOfStream){
                        string read= sr.ReadLine();
                        Console.WriteLine(read);                    
                    }                   
                }
            }
            else {
                string combined =""; 
                string[] newRow = new string[7];
                Console.Write("Enter in ID>");
                string ID = Console.ReadLine();
                newRow[0]=ID;

                Console.Write("Enter in summary>");
                string summary = Console.ReadLine();
                newRow[1]=summary;

                Console.Write("Enter in status>");
                string status = Console.ReadLine();
                newRow[2]=status;

                Console.Write("Enter in priority>");
                string priority = Console.ReadLine();
                newRow[3]=priority;

                Console.Write("Enter in submitter>");
                string submitter = Console.ReadLine();
                newRow[4]=submitter;

                Console.Write("Enter in assigned>");
                string assigned = Console.ReadLine();
                newRow[5]=assigned;

                Console.Write("Enter in watching>");
                string watching = Console.ReadLine();
                newRow[6]=watching;

                using(StreamWriter sw = new StreamWriter(FilePath)){
                    sw.WriteLine(ColumnID);
                    sw.WriteLine(firstLine);

                    foreach(var index in newRow){
                        combined += index;
                        combined += ",";
                    }
                    if (combined.Length>1){
                        combined= combined.Substring(0, combined.Length-1);
                    }
                    sw.Write(combined);
                }
            }
        }
    }
}
