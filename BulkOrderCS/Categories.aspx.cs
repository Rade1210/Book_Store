using BusinessLogicLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulkOrderCS
{
    public partial class Categories : System.Web.UI.Page
    {
        private BooksBusiness booksBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            booksBusiness = new BooksBusiness();

            string category = Request.QueryString["category"];

            fillSidebar();
            if (category != null)
                fillContent(category);
        }

        private void fillSidebar()
        {
            categoriesSidebar.InnerHtml = "";

            string categorySidebar = @"<a href=""/Categories.aspx?category={0}"" class=""btn d-flex align-items-center justify-content-between"" onClick=""window.location='./Categories.aspx?category={0}';"" runat=""server"">                                    
                <div class=""text-body"">{0}</div>
                <div class=""text-muted"">({1})</div>
            </a>";

            for (int i = 0; i < booksBusiness.GetAllCategories().Count; i++)
            {
                string[] current = booksBusiness.GetAllCategories()[i];
                categoriesSidebar.InnerHtml += string.Format(categorySidebar, current[0], current[1]);

                if (i < booksBusiness.GetAllCategories().Count - 1) //every category has a bottom line
                {
                    categoriesSidebar.InnerHtml += "<hr />";
                }

            }
        }

        public void fillContent(string category) //when you click on a category
        {
            string bookCard = @"<div class=""col-lg-3 col-md-3 col-sm-6 my-2"">
                <div class=""card mx-auto"" style=""width: 16rem;"">
                    <div class=""card-header"">
                        <p class=""text-center mb-0 pb-0 mx-5"" style=""background-color: #F8F8F8"">{0}</p>
                    </div>
                    <img class=""card-img-top img-fluid mh-100"" style=""height: 270px"" src=""/src/img/{1}"" alt=""Card image cap"">
                    <div class=""card-body pb-0 mb-0 pt-1 mt-1"">
                        <h5 class=""card-title text-info"">{2}</h5>
                        <p class=""card-text"">{3}</p>
                        <p class=""text-muted text-right"">by: {4}</p>
                    </div>
                    <div class=""card-footer pt-1 mt-1"">
                        <div class=""row"">
                            <div class=""col-6"">
                                <p class=""text-muted mb-0"">Price:</p>
                                <p class=""text-muted mb-0 text-right"">{5}</p>
                            </div>
                            <div class=""col-6"">
                                <p class=""text-muted mb-0"">Quantity:</p>
                                <p class=""text-muted mb-0 text-right"">{6}</p>
                            </div>
                        </div>
                        <div class=""row mt-2 px-2"" style=""height: 2rem"">
                            <input class=""col-7 form-control"" type=""number"" min=""1"" max=""{6}""/>
                            <div class=""col-1 m-0 p-0""></div>
                            <p class=""btn btn-success col-4"">Buy</p>
                        </div>
                    </div>
                </div>
            </div>";

            foreach (Book book in booksBusiness.GetAllBooks())
            {
                if (book.Category.Equals(category))
                    categoriesContent.InnerHtml += string.Format(bookCard, book.Category, book.Cover, book.Title, book.Description, book.Author, book.Price, book.Quantity);
            }
        }
    }
}