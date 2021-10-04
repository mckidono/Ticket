using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace Ticket
{
    public class ticketFile
    {
        public string filePath { get; set;}
        public List<ticket> Tickets {get; set;}
//        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public ticketFile(string filePath){
            this.filePath=filePath;
            Tickets = new List<ticket>();

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