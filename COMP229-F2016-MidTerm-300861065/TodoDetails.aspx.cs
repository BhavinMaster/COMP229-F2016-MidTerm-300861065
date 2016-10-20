using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP229_F2016_MidTerm_300861065.Models;
using System.Web.ModelBinding;
namespace COMP229_F2016_MidTerm_300861065
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                this.getTodos();
            }

        }
        protected void getTodos()
        {
            int todoId = Convert.ToInt32(Request.QueryString["TodoID"]);

            //connect
            using (TodoContext db = new TodoContext())
            {
                Todo updetedTodo = (from todo in db.Todos
                                          where todo.TodoID == todoId
                                          select todo).FirstOrDefault();
                //map student property to form control
                if (updetedTodo != null)
                {
                    DescriptionDescriptionBox.Text = updetedTodo.TodoDescription;
                    NotesTextBox.Text = updetedTodo.TodoNotes;
                    
                    Completion.Checked = updetedTodo.Completed;


                }
            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())
            {
                // use the student model to create a new Todo object and 
                // save a new record

                Todo newTodo = new Todo();

                int todoID= 0;

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                    todoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == todoID
                                  select todo).FirstOrDefault();

                }

                // add form data to the new student record
                newTodo.TodoDescription = DescriptionDescriptionBox.Text;
                newTodo.TodoNotes = NotesTextBox.Text;
                bool temp;
                if(Completion.Checked == true)
                {
                    temp = true;
                }
                else
                {
                    temp = false;
                }
                newTodo.Completed = temp;

                // use LINQ to ADO.NET to add / insert new student into the db

                if (todoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/TodoList.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }
    }
}