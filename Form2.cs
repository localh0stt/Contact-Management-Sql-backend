using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsFromDB_dotnet_4._7._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(bool EditingStatus)
        {
            InitializeComponent();
            IsEdit = EditingStatus;
        }
        public Form2(string id, string name, string nb, Image pic, bool isEditing, bool ImageEdited, string title)
        {
            InitializeComponent();
            txtname.Text = name;
            txtnb.Text = nb;
            pictureBox1.Image = pic;
            IsEdit = isEditing;
            imageedited = ImageEdited;
            lblid.Visible = true;
            lblid.Text = id;
            label1.Text = title;
        }
/*        public void setnewcontact(string id, string name, string nb, Image pic, bool isEditing, bool ImageEdited)
        {
            txtname.Text = name;
            txtnb.Text = nb;
            pictureBox1.Image = pic;
            IsEdit = isEditing;
            imageedited = ImageEdited;
            lblid.Visible = true;
            lblid.Text = id;
        }*/

        public byte[] imagebin;
        public bool IsEdit = false;
        public bool imageedited = false;

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtnb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public bool ValidateName(TextBox Text_Box)
        {
            if (!string.IsNullOrEmpty(Text_Box.Text))
            {
                string sanitizedtext = Text_Box.Text.Trim();
                if (!Regex.IsMatch(sanitizedtext, @"^[A-Za-z\s]*$"))
                {
                    errorProvider1.SetError(Text_Box, "The \"Name\"is a letters-only field !");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(Text_Box, "");
                    return true;
                }
            }
            else
            {
                errorProvider1.SetError(Text_Box, "The \"Name\" field cannot be empty!");
                return false;
            }
        }
        public bool ValidateNumber(TextBox Text_Box)
        {
            string sanitizedtext = Text_Box.Text.Replace(" ", "");
            int nbparsedValue;
            if (sanitizedtext.Length != 8)
            {
                errorProvider1.SetError(Text_Box, "Number must be 8 digits !");
                return false;
            }
            else if (!int.TryParse(sanitizedtext, out nbparsedValue))
            {
                errorProvider1.SetError(Text_Box, "Number field must only contain numbers !");
                return false;
            }
            else
            {
                errorProvider1.SetError(Text_Box, "");
                return true;
            }
        }
        public void enableupload()
        {
            if (!IsEdit)
            {
                if (ValidateName(txtname) && ValidateNumber(txtnb))
                {
                    btnupload.Enabled = true;
                }
                else btnupload.Enabled = false;
            }
            else
            {
                if (ValidateName(txtname) && ValidateNumber(txtnb))
                {
                    btnupload.Enabled = true;
                    btnsave.Enabled = true;
                }
                else
                {
                    btnupload.Enabled = false;
                    btnsave.Enabled = false;
                }
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            imageedited = false;
            if (IsEdit)
            {
                enableupload();
            }
        }
        public void initfiledialog(OpenFileDialog fdlg)
        {
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = Environment.CurrentDirectory;
            fdlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            fdlg.DefaultExt = ".png";
        }
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            enableupload();
        }
        private void txtnb_TextChanged(object sender, EventArgs e)
        {
            enableupload();
        }
        private void btnupload_Click(object sender, EventArgs e)
        {
            initfiledialog(openFileDialog1);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                lblstatusupload.Text = "Image uploaded successfully";
                imagebin = File.ReadAllBytes(openFileDialog1.FileName);
                if (IsEdit == false)
                {
                    btninsert.Enabled = true;
                    btnsave.Enabled = false;
                    imageedited = false;
                }
                else
                {
                    imageedited = true;
                    btnsave.Enabled = true;
                }
            }
            if (IsEdit == true) btnsave.Enabled = true;
        }
        private void btninsert_Click(object sender, EventArgs e)
        {
            DBcontroller.Insert(txtname.Text, txtnb.Text, imagebin);
            pictureBox1.Image.Dispose();
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DBcontroller.UpdateRecord(int.Parse(lblid.Text), txtname.Text, txtnb.Text, openFileDialog1.FileName, imageedited);
            this.DialogResult= DialogResult.OK;
            this.Dispose();
        }
    }
}
