using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51354/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //var response = client.PostAsync("student", new Student() { Id = Convert.ToInt32(txtId.Text), Name = txtName.Text, Email = txtEmail.Text }).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //}
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

    }
}