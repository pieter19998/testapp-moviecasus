using System.IO;
using System.Text;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public static class Exporter
    {
        public static void ExportToJson(Order order)
        {
            using StreamWriter file = new StreamWriter($@"\Order{order.GetOrderNr()}.json");
            JsonSerializer serializer = new JsonSerializer {Formatting = Formatting.Indented};
            serializer.Serialize(file, order.Tickets);
        }

        public static void ExportToText(Order order)
        {
            StringBuilder builder = new StringBuilder();
            foreach (MovieTicket ticket in order.Tickets)
            {
                builder.AppendLine(ticket.ToString());
            }

            using StreamWriter file = new StreamWriter($@"\Order{order.GetOrderNr()}.txt");
            file.Write(builder.ToString());
        }
    }
}
