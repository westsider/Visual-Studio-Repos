namespace ConsignmentShopUI
{
    partial class ConsignmentShop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderText = new System.Windows.Forms.Label();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.itemsLisyBoxLabel = new System.Windows.Forms.Label();
            this.addToCartBtn = new System.Windows.Forms.Button();
            this.shoppingCartLabel = new System.Windows.Forms.Label();
            this.shoppingCartListBox = new System.Windows.Forms.ListBox();
            this.makePurchase = new System.Windows.Forms.Button();
            this.vendoeListBoxLabel = new System.Windows.Forms.Label();
            this.VendorlistBox = new System.Windows.Forms.ListBox();
            this.storeProfitLabel = new System.Windows.Forms.Label();
            this.storeProfitValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.Location = new System.Drawing.Point(29, 39);
            this.HeaderText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(450, 55);
            this.HeaderText.TabIndex = 0;
            this.HeaderText.Text = "Consignment Shop";
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.ItemHeight = 29;
            this.ItemsListBox.Location = new System.Drawing.Point(39, 154);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(380, 207);
            this.ItemsListBox.TabIndex = 1;
            // 
            // itemsLisyBoxLabel
            // 
            this.itemsLisyBoxLabel.AutoSize = true;
            this.itemsLisyBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsLisyBoxLabel.Location = new System.Drawing.Point(34, 122);
            this.itemsLisyBoxLabel.Name = "itemsLisyBoxLabel";
            this.itemsLisyBoxLabel.Size = new System.Drawing.Size(146, 29);
            this.itemsLisyBoxLabel.TabIndex = 2;
            this.itemsLisyBoxLabel.Text = "Store Items";
            // 
            // addToCartBtn
            // 
            this.addToCartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartBtn.Location = new System.Drawing.Point(444, 227);
            this.addToCartBtn.Name = "addToCartBtn";
            this.addToCartBtn.Size = new System.Drawing.Size(211, 50);
            this.addToCartBtn.TabIndex = 3;
            this.addToCartBtn.Text = "Add To Cart ->";
            this.addToCartBtn.UseVisualStyleBackColor = true;
            this.addToCartBtn.Click += new System.EventHandler(this.addToCartBtn_Click);
            // 
            // shoppingCartLabel
            // 
            this.shoppingCartLabel.AutoSize = true;
            this.shoppingCartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingCartLabel.Location = new System.Drawing.Point(674, 122);
            this.shoppingCartLabel.Name = "shoppingCartLabel";
            this.shoppingCartLabel.Size = new System.Drawing.Size(180, 29);
            this.shoppingCartLabel.TabIndex = 5;
            this.shoppingCartLabel.Text = "Shopping Cart";
            // 
            // shoppingCartListBox
            // 
            this.shoppingCartListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingCartListBox.FormattingEnabled = true;
            this.shoppingCartListBox.ItemHeight = 29;
            this.shoppingCartListBox.Location = new System.Drawing.Point(679, 154);
            this.shoppingCartListBox.Name = "shoppingCartListBox";
            this.shoppingCartListBox.Size = new System.Drawing.Size(380, 207);
            this.shoppingCartListBox.TabIndex = 4;
            // 
            // makePurchase
            // 
            this.makePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makePurchase.Location = new System.Drawing.Point(848, 388);
            this.makePurchase.Name = "makePurchase";
            this.makePurchase.Size = new System.Drawing.Size(211, 50);
            this.makePurchase.TabIndex = 6;
            this.makePurchase.Text = "Purchase";
            this.makePurchase.UseVisualStyleBackColor = true;
            this.makePurchase.Click += new System.EventHandler(this.makePurchase_Click);
            // 
            // vendoeListBoxLabel
            // 
            this.vendoeListBoxLabel.AutoSize = true;
            this.vendoeListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendoeListBoxLabel.Location = new System.Drawing.Point(34, 424);
            this.vendoeListBoxLabel.Name = "vendoeListBoxLabel";
            this.vendoeListBoxLabel.Size = new System.Drawing.Size(110, 29);
            this.vendoeListBoxLabel.TabIndex = 8;
            this.vendoeListBoxLabel.Text = "Vendors";
            // 
            // VendorlistBox
            // 
            this.VendorlistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorlistBox.FormattingEnabled = true;
            this.VendorlistBox.ItemHeight = 29;
            this.VendorlistBox.Location = new System.Drawing.Point(39, 456);
            this.VendorlistBox.Name = "VendorlistBox";
            this.VendorlistBox.Size = new System.Drawing.Size(380, 207);
            this.VendorlistBox.TabIndex = 7;
            // 
            // storeProfitLabel
            // 
            this.storeProfitLabel.AutoSize = true;
            this.storeProfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeProfitLabel.Location = new System.Drawing.Point(674, 456);
            this.storeProfitLabel.Name = "storeProfitLabel";
            this.storeProfitLabel.Size = new System.Drawing.Size(152, 29);
            this.storeProfitLabel.TabIndex = 10;
            this.storeProfitLabel.Text = "Store Profit:";
            // 
            // storeProfitValue
            // 
            this.storeProfitValue.AutoSize = true;
            this.storeProfitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeProfitValue.Location = new System.Drawing.Point(834, 456);
            this.storeProfitValue.Name = "storeProfitValue";
            this.storeProfitValue.Size = new System.Drawing.Size(83, 29);
            this.storeProfitValue.TabIndex = 11;
            this.storeProfitValue.Text = "$ 0.00";
            // 
            // ConsignmentShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(29F, 55F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 1065);
            this.Controls.Add(this.storeProfitValue);
            this.Controls.Add(this.storeProfitLabel);
            this.Controls.Add(this.vendoeListBoxLabel);
            this.Controls.Add(this.VendorlistBox);
            this.Controls.Add(this.makePurchase);
            this.Controls.Add(this.shoppingCartLabel);
            this.Controls.Add(this.shoppingCartListBox);
            this.Controls.Add(this.addToCartBtn);
            this.Controls.Add(this.itemsLisyBoxLabel);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.HeaderText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "ConsignmentShop";
            this.Text = "Consignment  Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label itemsLisyBoxLabel;
        private System.Windows.Forms.Button addToCartBtn;
        private System.Windows.Forms.Label shoppingCartLabel;
        private System.Windows.Forms.ListBox shoppingCartListBox;
        private System.Windows.Forms.Button makePurchase;
        private System.Windows.Forms.Label vendoeListBoxLabel;
        private System.Windows.Forms.ListBox VendorlistBox;
        private System.Windows.Forms.Label storeProfitLabel;
        private System.Windows.Forms.Label storeProfitValue;
    }
}

