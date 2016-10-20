using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// using statements to connect to EF DB
using COMP229_F2016_MidTerm_300861065.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_MidTerm_300861065
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GetTodos();
        }

        private void GetTodos()
        {
            // connect to EF DB
            using (TodoContext db = new TodoContext())
            {
                // query the Todo Table using EF and LINQ
                var Todos = (from allTodos in db.Todos
                                select allTodos);

                // bind the result to the Todos GridView
                TodoGridView.DataSource = Todos.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected Todo in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object ot the Todo clas and store the query inside of it
                Todo deletedTodo = (from todoRecords in db.Todos
                                          where todoRecords.TodoID == TodoID
                                          select todoRecords).FirstOrDefault();

                // remove the selected Todo from the db
                db.Todos.Remove(deletedTodo);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetTodos();
            }


        }
    }
}