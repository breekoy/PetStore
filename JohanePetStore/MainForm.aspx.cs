using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JohanePetStore
{
    public partial class MainForm : System.Web.UI.Page
    {

        //creates an sql connection instance using a connection string
        SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=johanepetstore;User ID=sa;Password=*********");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
            
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadRecord()
        {
            SqlCommand command = new SqlCommand("SELECT * from Pets", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            gridviewPets.DataSource = dataTable;
            gridviewPets.DataBind();
        }

        private void ResetInputs()
        {
            //clear textbox
            txtPetID.Text = "";
            txtPetName.Text = "";
            txtPetAge.Text = "";
            dropdownSex.Text = "";
            txtPetBreed.Text = "";
            txtPetStatus.Text = "";
            txtPetPrice.Text = "";

            //clear the selected row from data table/grid
            gridviewPets.SelectedIndex = -1;

            //reset the buttons
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //stores values from textbox to variables
            string petName = txtPetName.Text;
            string petAge = txtPetAge.Text;
            string petSex = dropdownSex.Text;
            string petBreed = txtPetBreed.Text;
            string petStatus = txtPetStatus.Text;
            string petPrice = txtPetPrice.Text;

            /*
             * VALIDATIONS
             * 
             * Before we insert to database, we must first validate the values.
             * This is to make sure that all of the values are correct.
             * 
             * Below are the following validations
             * 
             */

            /*
             * Validation #1: Pet name must have a value!
             */
            if (string.IsNullOrEmpty(petName)) 
            {
                //inserts and executes a javascript alert() to the page
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You must fill up the pet name!')", true);

                //stops the code execution
                return;
            }

            /*
             * Validation #2: Pet age must have a value!
             */
            if (string.IsNullOrEmpty(petAge))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You must fill up the pet age!')", true);

                //stops the code execution
                return;
            }

            /*
             * Validation #3: Pet age must be a number!
             */
            if (!double.TryParse(petAge, out double petAgeDoubleResult))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pet age must be a number!')", true);

                //stops the code execution
                return;
            }

            /*
             * Validation #4: Pet breed must have a value!
             */
            if (string.IsNullOrEmpty(petBreed))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You must fill up the pet breed!')", true);

                //stops the code execution
                return;
            }

            /*
             * Validation #5: Pet status must have a value!
             */
            if (string.IsNullOrEmpty(petStatus))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You must fill up the pet status!')", true);

                //stops the code execution
                return;
            }


            /*
             * Validation #6: Pet price must have a value!
             */
            if (string.IsNullOrEmpty(petPrice))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('You must fill up the pet price!')", true);

                //stops the code execution
                return;
            }

            /*
             * Validation #7: Pet price must be a number!
             */
            if (!double.TryParse(petPrice, out double petPriceDoubleResult))
            {
                //javascript alert
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Pet price must be a number!')", true);

                //stops the code execution
                return;
            }

            /*
             * ACTUAL INSERTION TO DATABASE
             * 
             * If all validations are met, we are now ready to insert the values to database.
             * 
             */

            //opens the sql connection
            connection.Open();

            //creates an sql insert command
            SqlCommand command = new SqlCommand(@"INSERT into Pets (Pet_Name, Pet_Age, Pet_Sex, Pet_Breed, Pet_Status, Pet_Price) 
                VALUES ('" + petName + "', " + petAge + ", '" + petSex + "', '" + petBreed + "', '" + petStatus + "', '" + petPrice + "')", 
             connection);
            
            //executes the command
            command.ExecuteNonQuery();

            //closes the sql connection
            connection.Close();

            //javascript success alert
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "alert('Record has been added to database!')", true);

            //resets all inputs (textboxes, buttons, grid)
            ResetInputs();

            //refresh the data table
            LoadRecord();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //stores values from textbox to variables
            string petId = txtPetID.Text;
            string petName = txtPetName.Text;
            string petAge = txtPetAge.Text;
            string petSex = dropdownSex.Text;
            string petBreed = txtPetBreed.Text;
            string petStatus = txtPetStatus.Text;
            string petPrice = txtPetPrice.Text;

            connection.Open();

            //sql update command
            SqlCommand command = new SqlCommand(@"UPDATE Pets SET " +
                @"Pet_Name = '" + petName + "', " +
                @"Pet_Age = '" + petAge + "', " + 
                @"Pet_Sex = '" + petSex + "', " + 
                @"Pet_Breed = '" + petBreed + "', " + 
                @"Pet_Status = '" + petStatus + "', " + 
                @"Pet_Price = '" + petPrice + "' " + 
                @"WHERE Pet_ID = " + petId,
             connection);

            //executes the command
            command.ExecuteNonQuery();

            connection.Close();

            ScriptManager.RegisterStartupScript(this, GetType(), "script", "alert('Record successfully updated!')", true);


            //resets all inputs (textboxes, buttons, grid)
            ResetInputs();

            //refresh the data table/grid
            LoadRecord();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string petId = txtPetID.Text;

            connection.Open();

            SqlCommand command = new SqlCommand(@"DELETE from Pets WHERE Pet_ID = " + petId, connection);

            command.ExecuteNonQuery();

            connection.Close();

            ScriptManager.RegisterStartupScript(this, GetType(), "script", "alert('Record successfully deleted!')", true);

            //resets all inputs (textboxes, buttons, grid)
            ResetInputs();

            //refresh the data table/grid
            LoadRecord();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetInputs();
        }

        protected void gridviewPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //assigns the selected row values from the data table (grid) to the textboxes
            txtPetID.Text = gridviewPets.SelectedRow.Cells[1].Text;
            txtPetName.Text = gridviewPets.SelectedRow.Cells[2].Text;
            txtPetAge.Text = gridviewPets.SelectedRow.Cells[3].Text;
            dropdownSex.Text = gridviewPets.SelectedRow.Cells[4].Text;
            txtPetBreed.Text = gridviewPets.SelectedRow.Cells[5].Text;
            txtPetStatus.Text = gridviewPets.SelectedRow.Cells[6].Text;
            txtPetPrice.Text = gridviewPets.SelectedRow.Cells[7].Text;

            //disables add button, enables update and delete buttons
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
