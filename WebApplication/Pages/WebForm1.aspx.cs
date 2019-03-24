using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using WebApplication.Models;
using WebApplication.scripts;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static Database1Entities book;
        private string id=String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("~/Pages/HomePage.aspx");
            }

            else
            {
                if (!IsPostBack)
                {

                    book = new Database1Entities();

                    var element = book.Book;

                    foreach (var a in element)//Получает все элементы из БД которые удовлетворяют индефикатору или же редиректит на главную страницу для повторного выбора книги
                    {
                        try
                        {
                            if (a.Id == Convert.ToInt32(id))
                            {
                                aulbum.ImageUrl = a.Обложка;
                                nameBookLabel.Text = a.Название;
                                annotationLabel.Text = a.Краткое_описание;
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Response.Redirect("~/Pages/HomePage.aspx");
                        }
                    }
                }
            }
        }

        //При нажатии на клавишу выводит содержимое файла книги в окно браузера
        protected void read_OnClick(object sender, EventArgs e)
        {
           var temp = book.Book;
            
            foreach(var a in temp)
            {try
                {
                    if (a.Id == Convert.ToInt32(id))
                    {
                        Response.Redirect("Read.aspx?name=" + a.Путь_к_Файлу);
                    }
                }
                catch (FormatException)
                {
                    Response.Redirect("~/Pages/WebForm1.aspx");
                }
            }
            
        }

        //Скачивание файла книги с сервера
        protected void load_OnClick(object sender, EventArgs e)
        {
            var temp = book.Book;
            string path;

            foreach (var g in temp)
            {
                try
                {
                    if (g.Id == Convert.ToInt32(id))
                    {
                        ClassCombine combine = new ClassCombine();
                        path = combine.combine(Server.MapPath(g.Путь_к_Файлу));

                        FileInfo file = new FileInfo(path);
                        Context.Response.AddHeader("Content-Length", file.Length.ToString());
                        Context.Response.AddHeader("Connection", "Keep-Alive");
                        Context.Response.ContentType = "text/plain";
                        Context.Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name);
                        Context.Response.WriteFile(file.FullName);
                        Context.Response.End();
                    }
                }
                catch (FormatException)
                {
                    Response.Redirect("~/Pages/WebForm1.aspx");
                }
            }
            
        }

        //Переход на страницу редактирования описания
        protected void editing_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AddPage.aspx?id="+id);
        }

        //Удаление книги из БД
        protected void delete_OnClick(object sender, EventArgs e)
        {
            
            var temp = book.Book;
            var deleteBook = from book1 in temp
                where book1.Id.ToString() == id
                select book1;


            ClassCombine combine = new ClassCombine();

            File.Delete(combine.combine(Server.MapPath(deleteBook.FirstOrDefault().Обложка)));
            File.Delete(combine.combine(Server.MapPath(deleteBook.FirstOrDefault().Путь_к_Файлу)));

            temp.RemoveRange(deleteBook);
            book.SaveChanges();

            Response.Redirect("HomePage.aspx");

        }
    }
}