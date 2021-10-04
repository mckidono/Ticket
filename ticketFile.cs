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
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string filePath){
            this.filePath=filePath;
            Tickets = new List<Ticket>();

            try{
                using(StreamReader sr= new StreamReader(filePath)){
                    sr.ReadLine();
                    while(!sr.EndOfStream){
                        Ticket ticket;
                    }
                }
            }catch{

            }
        }
        public void AddTicket(Ticket ticket)
        {
            try
            {
                ticket.ticketId = Tickets.Max(m => m.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId},{ticket.Summary},{ticket.Status},{ticket.Priority},{ticket.Submitter},{ticket.Assigned},{ticket.Watching}");
                sw.Close();
                Tickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
    }
}
}