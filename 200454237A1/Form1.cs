using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200454237A1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private decimal total;
        private decimal paid;
        private decimal change;
        private Int64 toonies;
        private Int64 loonies;      //HUGE NUMBERS POSSIBLE SO INT64
        private Int64 quarters;
        private Int64 dimes;
        private Int64 nickels;


        private void frm_main_Load(object sender, EventArgs e)
        {
            this.total = 0m;
            this.paid = 0m;
            this.change = 0m;
        }

        private void calculate_coins()
        {
            /*Calculates every coin and their respective amounts.
             * 
             * :args -> None
             * 
             * :returns -> void
             */

            decimal temp = change;

            this.toonies = Convert.ToInt64(Math.Floor(temp/2)); // 17.38 / 2 = 8
            temp -= toonies * 2; // 17.38 - 16 = 1.38

            this.loonies = Convert.ToInt64(Math.Floor(temp / 1)); //1.38 / 1 = 1
            temp -= loonies * 1;    //1.38 - 1 = 0.38

            this.quarters = Convert.ToInt64(Math.Floor(temp / 0.25m)); // 0.38 / 0.25 = 1
            temp -=  quarters * 0.25m;    // 0.38 - 0.25 = 0.13

            this.dimes = Convert.ToInt64(Math.Floor(temp / 0.10m));
            temp -= quarters * 0.10m; // 0.3

            this.nickels = Convert.ToInt64(Math.Floor(temp / 0.05m));
            temp -= quarters * 0.05m;

            txt_toonies.Text = this.toonies.ToString();
            txt_loonies.Text = this.loonies.ToString();
            txt_quarters.Text = this.quarters.ToString();
            txt_dimes.Text = this.dimes.ToString();
            txt_nickels.Text = this.nickels.ToString();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            /*
             * When the Calculate button is clicked, this handler is called.
             *
             *:arg sender (object)
             *:arg e (EventArgs)
             * 
             * :returns -> None
             */
            this.total = Convert.ToDecimal(txt_total.Text);
            this.paid = Convert.ToDecimal(txt_paid.Text);
            this.change = paid - total;
            txt_change.Text = change.ToString(); // need to typecast to string cause it wont take int type
            calculate_coins();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            /*Resets the boxes and all values.
             * 
             * 
             */
            this.paid = 0m;
            this.total = 0m;
            this.change = 0m;
            this.toonies = 0;
            this.loonies = 0;
            this.quarters = 0;
            this.dimes = 0;
            this.nickels = 0;

            txt_paid.Text = "";
            txt_total.Text = "";
            txt_change.Text = "";
            txt_toonies.Text = "";
            txt_loonies.Text = "";
            txt_quarters.Text = "";
            txt_dimes.Text = "";
            txt_nickels.Text = "";
        }
    }
}
