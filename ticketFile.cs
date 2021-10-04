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
    }
}