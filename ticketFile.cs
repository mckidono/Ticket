using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace Ticket
{
    public class TicketFile
    {
        public string filePath { get; set;}
        public List<Ticket> Tickets {get; set;}
//        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string filePath){
            this.filePath=filePath;
            Tickets = new List<Ticket>();

            try{
                using(StreamReader sr= new StreamReader(filePath)){
                    sr.ReadLine();
                    while(!sr.EndOfStream){
    //                    ticket ticket = new ticket();
                    }
                }
            }catch{

            }
        }
    }
}