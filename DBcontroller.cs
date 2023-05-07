using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsFromDB_dotnet_4._7._2
{
    public static class DBcontroller
    {
        public static void Insert(string name, string number, byte[] image) 
        { 
            ContactsDBDataContext dataContext = new ContactsDBDataContext();
            contact c = new contact();
            c.Name = name;
            c.Number = number;
            c.Picture = image;
            c.IsDeleted = false;
            dataContext.contacts.InsertOnSubmit(c);
            dataContext.SubmitChanges();
        }
        public static IEnumerable<contact> GetContacts(bool ShowAll)
        {
            if (ShowAll)
            {
                ContactsDBDataContext dataContext = new ContactsDBDataContext();
                var table = from contact in dataContext.contacts select contact;
                return table;
            }
            else
            {
                ContactsDBDataContext dataContext = new ContactsDBDataContext();
                var table = from contact in dataContext.contacts where contact.IsDeleted == false select contact;
                return table;
            }

        }
        public static contact GetContactByID(int ID)
        {
            ContactsDBDataContext dataContext = new ContactsDBDataContext();
            var table = (from contact in dataContext.contacts where contact.ID == ID select contact).SingleOrDefault();
            return table;
        }
        public static void DeleteRecord(int ID) 
        { 
            ContactsDBDataContext dataContext = new ContactsDBDataContext();
            contact tmp = dataContext.contacts.Single(contact => contact.ID == ID);
            //dataContext.contacts.DeleteOnSubmit(tmp);
            tmp.IsDeleted = true;
            dataContext.SubmitChanges();
        }
        public static void UpdateRecord(int ID, string name, string phone, string path , bool imagechanged)
        {
            ContactsDBDataContext dataContext = new ContactsDBDataContext();
            contact user = dataContext.contacts.Single(x => x.ID == ID);
            user.ID = ID;
            user.Name = name;
            user.Number = phone;
            if (imagechanged)
            {
                byte[] imagebin = File.ReadAllBytes(path);
                user.Picture = imagebin;
            }
            dataContext.SubmitChanges();
        }
        public static IEnumerable<contact> search(string input, bool ShowAll)
        {
            if(ShowAll){ 
                if (!int.TryParse(input, out int i)) {
                    ContactsDBDataContext dataContext = new ContactsDBDataContext();
                    var table = from contact in dataContext.contacts where contact.Name.Contains(input) select contact;
                    return table;
                }
                else
                {
                    ContactsDBDataContext dataContext = new ContactsDBDataContext();
                    var table = from contact in dataContext.contacts where contact.Number.Contains(input) select contact;
                    return table;
                }
            }
            else
            {
                if (!int.TryParse(input, out int i))
                {
                    ContactsDBDataContext dataContext = new ContactsDBDataContext();
                    var table = from contact in dataContext.contacts where (contact.Name.Contains(input) && contact.IsDeleted == false) select contact;
                    return table;
                }
                else
                {
                    ContactsDBDataContext dataContext = new ContactsDBDataContext();
                    var table = from contact in dataContext.contacts where (contact.Number.Contains(input) && contact.IsDeleted == false) select contact;
                    return table;
                }
            }
        }
    }
}