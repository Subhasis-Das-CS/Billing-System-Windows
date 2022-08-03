using Anystore.BLL;
using Anystore.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Anystore.UI
{
    public partial class frmPurchaseAndSales : Form
    {
        public frmPurchaseAndSales()
        {
            InitializeComponent();
        }
        gstinDAL gdal = new gstinDAL();
        DeaCustDAL dcdal = new DeaCustDAL();
        ProductsDAL pdal = new ProductsDAL();
        userDAL udal = new userDAL();
        transactionDAL tdal = new transactionDAL();
        transactionDetailDAL tddal = new transactionDetailDAL();
        DataTable transactiondt = new DataTable();
         DeaCustBll dc = new DeaCustBll();
        
      

        decimal subTotal;
        decimal discount;

        decimal grandTotal;
       

        decimal vat;

        decimal gst;
        decimal gstAmount;


        decimal grandTotalWIthVat;

       

        decimal cst;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords == "")
            {
                //clear

                txtName.Text = "";
                txtEmail.Text = "";
                txtContact.Text = "";
                txtAddress.Text = "";
                return;
            }

            DeaCustBll dc = dcdal.SearchDealerCustomerForTransaction(keywords);

            txtName.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContact.Text = dc.contact;
            txtAddress.Text = dc.address;

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearchProduct.Text;

            if (keywords =="")
            {
                txtNameProduct.Text = "";
                txtInventoryProduct.Text = "";
                txtRateProduct.Text = "";
                txtProductQuantity.Text = "";
                return;
                                   
            }


            ProductsBll p = pdal.getProductsForTransaction(keywords);
            txtNameProduct.Text = p.name;
            txtInventoryProduct.Text = p.qty.ToString();
            txtRateProduct.Text = p.rate.ToString();
           


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductQuantity.Text != "" && txtRateProduct.Text != "")
            {
                decimal toooootal;
                string productName = txtNameProduct.Text;
                decimal rate = decimal.Parse(txtRateProduct.Text);
                decimal indDiscount = decimal.Parse(Individualdiscount.Text);

                decimal qty = decimal.Parse(txtProductQuantity.Text);
                decimal total = rate * qty;
                decimal ttotal = total - (total * indDiscount / 100);
                subTotal = decimal.Parse(txtSubTotal.Text);


                if (indDiscount != 0)
                {

                    toooootal = ttotal;
                    subTotal = subTotal + ttotal;
                }
                else
                {
                    toooootal = total;
                    subTotal = subTotal + total;
                }



                if (productName == "")
                {


                    MessageBox.Show("Please Enter Product First");
                    txtProductQuantity.Text = "1";
                    Individualdiscount.Text = "0";
                }
                else
                {
                    transactiondt.Rows.Add(productName, rate, qty,  toooootal);

                    dgvAddedProducts.DataSource = transactiondt;

                    txtSubTotal.Text = subTotal.ToString();
                    txtGrandTotal.Text = subTotal.ToString();


                    txtSearchProduct.Text = "";
                    txtNameProduct.Text = "";
                    txtInventoryProduct.Text = "";
                    txtRateProduct.Text = "";
                    txtProductQuantity.Text = "1";
                    Individualdiscount.Text = "0";


                }
            }
            else
            {
                MessageBox.Show("Enter All The Fields");
            }
        }

        private void frmPurchaseAndSales_Load(object sender, EventArgs e)

        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.AcceptButton = btnAdd;
            txtSearchProduct.Select();
            transactiondt.Columns.Add("Name");
            transactiondt.Columns.Add("Rate");
            transactiondt.Columns.Add("Qty");
         
            transactiondt.Columns.Add("Cost");
            
        }
        

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            string value = txtDiscount.Text;

            if (value != "")
            {
                subTotal = decimal.Parse(txtSubTotal.Text);
                discount = decimal.Parse(txtDiscount.Text);

                grandTotal = Math.Round(((100 - discount) / 100)*subTotal,2);

                txtGrandTotal.Text = grandTotal.ToString();
            }
            else
            {
                subTotal = decimal.Parse(txtSubTotal.Text);
                txtGrandTotal.Text = subTotal.ToString();

            }
        }

        private void txtGst_TextChanged(object sender, EventArgs e)
        {
            string check = txtGst.Text;

            if (check == "")
            {
               string value = txtDiscount.Text;

                     if (value != "")
                     {
                            subTotal = decimal.Parse(txtSubTotal.Text);
                            discount = decimal.Parse(txtDiscount.Text);

                            grandTotal = Math.Round(((100 - discount) / 100)*subTotal,2);

                            txtGrandTotal.Text = grandTotal.ToString();
                      }
                      else
                      {
                       subTotal = decimal.Parse(txtSubTotal.Text);
                       txtGrandTotal.Text = subTotal.ToString();

                       }
            }
            else
            {
                string value = txtDiscount.Text;

                if (value == "")
                {
                    subTotal = decimal.Parse(txtSubTotal.Text);
                    gst = decimal.Parse(txtGst.Text);
                    gstAmount = subTotal * gst / 100;
                    grandTotal = subTotal + gstAmount;

                    txtGrandTotal.Text = grandTotal.ToString();
                }
                else
                {

                    subTotal = decimal.Parse(txtSubTotal.Text);
                    discount = decimal.Parse(txtDiscount.Text);

                    grandTotal = ((100 - discount) / 100) * subTotal;


                    vat = decimal.Parse(txtGst.Text);

                    gst = grandTotal * vat / 100;


                    grandTotalWIthVat =grandTotal+gst;
                    txtGrandTotal.Text = grandTotalWIthVat.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String paywithtext = pw.Text;

            DateTime a = new DateTime();
            a = DateTime.Now;
            String b = a.ToString();
          
            //prnting
            int ab = 1;
            gstinBll g = gdal.GetProductIDFromName(ab);
            string gst = g.gstin;
            string phone = g.phone;
            string name = g.name;
            string tagline = g.tagline;
            string address = g.address;
            string website = g.website;

            DGVPrinter printer = new DGVPrinter();

            printer.Title = name;
         //   printer.SubTitle = "Ayurvedic Kendra ";
         //   printer.SubTitle = "Shyamnagar";
          //  printer.SubTitle = "b";
           // printer.SubTitle = "8335898966/ 9230123937";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;


            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.SubTitle = ""+tagline+" \r\n "+address+" \r\n Phone:  "+ phone+" \r\n " + b+" Discount: " + txtDiscount.Text + "% \r\n" + "GSTIN: " + gst + " \r\n" + "Grand Total Rs." + txtGrandTotal.Text + "/- \r\n "+website+"\r\n"+" Paid With: "+ paywithtext+ " \n Powered By eSoft Enterprise";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvAddedProducts);


            dc.type = "Customer";
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;

            bool successs = dcdal.Insert(dc);

            //Get the Values from PurchaseSales Form First
            /* transactionBll transaction = new transactionBll();
              Random random = new Random();
            transaction.id = random.Next();
           transaction.grandTotal = Math.Round(decimal.Parse(txtGrandTotal.Text), 2);
           transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(txtGst.Text);
            transaction.discount = decimal.Parse(txtDiscount.Text);

           */

            //Lets Create a Boolean Variable and set its value to false
            bool success = false;

            //Actual Code to Insert Transaction And Transaction Details
            using (TransactionScope scope = new TransactionScope())
            {
                // int transactionID = 1;
                //Create aboolean value and insert transaction 
                // bool w = tdal.Insert_Transaction(transaction, out transactionID);

                //Use for loop to insert Transaction Details
                for (int i = 0; i < transactiondt.Rows.Count; i++)
                {
                    //Get all the details of the product
                    transactionDetailBll transactionDetail = new transactionDetailBll();
                    //Get the Product name and convert it to id
                    string ProductName = transactiondt.Rows[i][0].ToString();


                    ProductsBll p = pdal.GetProductIDFromName(ProductName);


                    ProductsBll pp = pdal.GetProductIDFromNames(ProductName);

                    Random ranndom = new Random();

                    //  transactionDetail.id = ranndom.Next();

                    transactionDetail.product_id = p.name;



                    transactionDetail.rate = decimal.Parse(transactiondt.Rows[i][1].ToString());
                    transactionDetail.qty = decimal.Parse(transactiondt.Rows[i][2].ToString());
                    transactionDetail.total = Math.Round(decimal.Parse(transactiondt.Rows[i][3].ToString()), 2);
                    transactionDetail.date = DateTime.Now.ToString();

                    transactionDetail.email = txtEmail.Text;
                    transactionDetail.name = txtName.Text;
                    transactionDetail.address = txtAddress.Text;
                    transactionDetail.contact = txtContact.Text;







                    //decrese


                    long c = pp.id;
                    bool x = pdal.DecreaseProduct(c, transactionDetail.qty);




                    //Insert Transaction Details inside the database
                    bool y = tddal.InsertTransactionDetail(transactionDetail);
                    success = y&&x;

                }

                if (success == true)
                {
                    scope.Complete();

                    MessageBox.Show("Transaction Completed Sucessfully");
                    //Celar the Data Grid View and Clear all the TExtboxes

                    dgvAddedProducts.DataSource = null;
                    dgvAddedProducts.Rows.Clear();
                    dgvAddedProducts.Refresh();
                    transactiondt.Rows.Clear();






                    txtSubTotal.Text = "0";
                    txtDiscount.Text = "0";
                    txtGst.Text = "0";
                    txtGrandTotal.Text = "0";

                }
                else
                {


                    dgvAddedProducts.DataSource = null;
                    dgvAddedProducts.Rows.Clear();
                    dgvAddedProducts.Refresh();
                    transactiondt.Rows.Clear();






                    txtSubTotal.Text = "0";
                    txtDiscount.Text = "0";
                    txtGst.Text = "0";
                    txtGrandTotal.Text = "0";
                    //Transaction Failed
                    MessageBox.Show("Transaction Failed");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach(DataGridViewRow row in dgvAddedProducts.SelectedRows)
            {
                
                dgvAddedProducts.Rows.RemoveAt(row.Index);

                subTotal -= cst;
                grandTotal = subTotal;

               

                txtSubTotal.Text = subTotal.ToString();
                txtGrandTotal.Text = grandTotal.ToString();


            }

            dgvAddedProducts.Refresh();


         


        }

        private void dgvAddedProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowIndex = e.RowIndex;
          
           cst = Convert.ToDecimal(dgvAddedProducts.Rows[rowIndex].Cells[3].Value);

          





        

            

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}

