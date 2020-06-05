using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class Supermarket : Form
    {
        Dictionary<string, int> productsDict = new Dictionary<string, int>();
        public Supermarket()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbProduct.Text) && !string.IsNullOrEmpty(tbAmount.Text))
            {
                int amount = 0;
                string product = tbProduct.Text;
                bool success = Int32.TryParse(tbAmount.Text, out amount);
                if (success)
                {
                    if (productsDict.ContainsKey(product))
                    {
                        productsDict[product] += amount;
                    }
                    else
                    {
                        productsDict.Add(product, amount);
                    } 
                }
                else
                {
                    Console.WriteLine("Fehler beim Umwandeln in eine Zahl.");
                }

                UpdateChanges();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbProduct.Text) && !string.IsNullOrEmpty(tbAmount.Text))
            {
                int amount = 0;
                string product = tbProduct.Text;
                bool isRemoved = false;
                bool success = Int32.TryParse(tbAmount.Text, out amount);
                if (success)
                {
                    if (productsDict.ContainsKey(product))
                    {
                        if(amount < productsDict[product] && amount > 0)
                        {
                            productsDict[product] -= amount;
                        }
                        if(amount == productsDict[product])
                        {
                            isRemoved = productsDict.Remove(product);
                        }
                    }
                 
                }
                else
                {
                    Console.WriteLine("Fehler beim Umwandeln in eine Zahl.");
                }

                UpdateChanges();
            }

        }

        private void UpdateChanges()
        {
            ///listBox.DataSource needs a List...i could have used also productsDict.ToList() Method,
            ///but this solution looks nicer
            List<string> productList = new List<string>();
            foreach (var item in productsDict)
            {
                productList.Add(item.Key + "(" + item.Value + ")");
            }
            listBox.DataSource = productList;
        }
    }
}
