using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace Ticket
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\ticket.csv";

            ticketFile ticketFile=new ticketFile(FilePath);

            string input="";
//            do{
            Console.WriteLine("Enter 1 to read all tickets");
            Console.WriteLine("Enter 2 to write a new line");
            Console.WriteLine("Enter to Quit");
                            
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
                ticket ticket;                        
                Console.Write("Enter in ID>");
                string ID = Console.ReadLine();
                
                Console.Write("Enter in summary>");
                string summary = Console.ReadLine();
                

                Console.Write("Enter in status>");
                string status = Console.ReadLine();
                
                Console.Write("Enter in priority>");
                string priority = Console.ReadLine();

                Console.Write("Enter in submitter>");
                string submitter = Console.ReadLine();

                Console.Write("Enter in assigned>");
                string assigned = Console.ReadLine();

                Console.Write("Enter in watching>");
                string watching = Console.ReadLine();

                ticket= new ticket(ID,summary,status,priority,submitter,assigned,watching);
                }
//            }while(input=="1" || input=="2");
        }
    }
}
