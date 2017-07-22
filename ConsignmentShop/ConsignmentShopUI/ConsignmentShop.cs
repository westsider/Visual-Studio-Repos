using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();
        private decimal storeProfit = 0;

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            ItemsListBox.DataSource = itemsBinding;

            ItemsListBox.DisplayMember = "Display";
            ItemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            VendorlistBox.DataSource = vendorsBinding;

            VendorlistBox.DisplayMember = "Display";
            VendorlistBox.ValueMember = "Display";
        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });

            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = store.Vendors[0]
            });

            store.Name = "Seconda are Better";
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            // figure out what is selected
            Item selectedItem = (Item)ItemsListBox.SelectedItem;

            // copy that item to the shopping cart
            shoppingCartData.Add(selectedItem);
            // reloading list for Store Items UI
            cartBinding.ResetBindings(false);

            // do we remove that item from the ites list? - no
            // MessageBox.Show(selectedItem.Title);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            // mark each item inn the cart as sold
            foreach(Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                storeProfit += ( 1 - (decimal)item.Owner.Commission) * item.Price;
            }

            // clear the cart
            shoppingCartData.Clear();
            // re establish what items are still in the store after a purchase
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            // update the store profit
            storeProfitValue.Text = string.Format("${0}", storeProfit);

            // reloading list for Shopping Cart UI
            cartBinding.ResetBindings(false);
            // reloading list for Store Items UI
            itemsBinding.ResetBindings(false);
            // reloading list for Vendors UI
            vendorsBinding.ResetBindings(false);
        }
    }
}
