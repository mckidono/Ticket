using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ticketLibrary
{
    public class ticketFile
    {
        // public property
        public string filePath { get; set; }
        public List<ticket> Tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        // constructor is a special method that is invoked
        // when an instance of a class is created
        public ticketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<ticket>();

            // to populate the list with data, read from the data file
            try
            {
                StreamReader sr = new StreamReader(filePath);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    // create instance of ticket class
                    ticket ticket = new ticket();
                    string line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in ticket title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in ticket title
                        // ticket details are separated with comma(,)
                        string[] ticketDetails = line.Split(',');
                        ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                        ticket.title = ticketDetails[1];
                        ticket.genres = ticketDetails[2].Split('|').ToList();
                    }
                    else
                    {
                        // quote = comma in ticket title
                        // extract the ticketId
                        ticket.ticketId = UInt64.Parse(line.Substring(0, idx - 1));
                        // remove ticketId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the ticketTitle
                        ticket.title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        ticket.genres = line.Split('|').ToList();
                    }
                    Tickets.Add(ticket);
                }
                // close file when done
                sr.Close();
                logger.Info("Tickets in file {Count}", Tickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
       

        public void Addticket(ticket ticket)
        {
            try
            {
                // first generate ticket id
                ticket.ticketId = Tickets.Max(m => m.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId},{ticket.title},{string.Join("|", ticket.genres)}");
                sw.Close();
                // add ticket details to Lists
                Tickets.Add(ticket);
                // log transaction
                logger.Info("ticket id {Id} added", ticket.ticketId);
            } 
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
