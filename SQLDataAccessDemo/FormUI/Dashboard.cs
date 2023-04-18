using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
  public partial class Dashboard : Form
  {
    List<Person> people = new List<Person>();
    public Dashboard()
    {
      InitializeComponent();
      peopleFoundListbox.DataSource = people;
      peopleFoundListbox.DisplayMember = "FullInfo";
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
      DataAccess db = new DataAccess();
      people = db.GetPeople(lastNameText.Text);
      peopleFoundListbox.DataSource = people;
    }

    private void InsertButton_Click(object sender, EventArgs e)
    {
      DataAccess db = new DataAccess();
      db.InsertPerson(firstNameInsTextbox.Text, lastNameInsTextbox.Text, emailAddressInsTextbox.Text, phoneNumberInsTextbox.Text);
      firstNameInsTextbox.Text = "";
      lastNameInsTextbox.Text = "";
      emailAddressInsTextbox.Text = "";
      phoneNumberInsTextbox.Text = "";
    }
  }
}
