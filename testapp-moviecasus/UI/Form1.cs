using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Models;

namespace UI
{
    public partial class Form1 : Form
    {
        private Order _order;

        public Form1()
        {
            InitializeComponent();

            // Goede code niks mis mee
            try
            {
                Movie movie = new Movie("Film");
                MovieScreening screening = new MovieScreening(movie, DateTime.Now, 10);
                _order = new Order(1, true);
                _order.AddTicket(new MovieTicket(screening, true, 1, 1));
                _order.AddTicket(new MovieTicket(screening, true, 1, 2));
                _order.AddTicket(new MovieTicket(screening, true, 1, 3));
                _order.AddTicket(new MovieTicket(screening, true, 1, 4));
                _order.AddTicket(new MovieTicket(screening, true, 1, 5));
                _order.AddTicket(new MovieTicket(screening, true, 1, 6));
            }
            catch
            {
                MessageBox.Show("Er is een fout opgetreden", "Failed successfully", MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Question);
            }
            
        }

        private void JsonButton_Click(object sender, EventArgs e)
        {
            _order.Export(TicketExportFormat.Json);
            MessageBox.Show("Exported to JSON!", "Exported to JSON!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            _order.Export(TicketExportFormat.Plaintext);
            MessageBox.Show("Exported to text!", "Exported to text!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
