using System;
using System.Collections.Generic;

namespace Ticket
{
    public class ticket
    {
        public UInt64 ticketId { get; set; }
        // private field
      
        public ticket(string Id, string summary, string status, string priority, string submitter, string assigned, string watching )
        {
            ID = Id;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
        }
        public string ID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }
        public string Display()
        {
            return $"{ID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}";
        }
    }
}
