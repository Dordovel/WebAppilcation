using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;
using WebApplication.scripts;

namespace WebApplication.Pages
{
    public partial class AddPage : System.Web.UI.Page
    {
        private static string id;
        private static bool BookEditFlag;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                using (Database1Entities entities = new Database1Entities())
                {

                    id = Request.QueryString["id"];

                    if (!String.IsNullOrEmpty(id))
                    {
                        var book = (from value in entities.Book
                            where value.Id.ToString().Equals(id)
                            select value).ToList();


                        if (book.Count != 0)
                        {
                            nameBook.Text = book.ElementAt(0).Название.TrimEnd();
                            author.Text = book.ElementAt(0).Автор.TrimEnd();
                            hangr.Text = book.ElementAt(0).Жанр.TrimEnd();
                            annotation.Text = book.ElementAt(0).Краткое_описание.TrimEnd() ;
                            BookEditFlag = true;
                        }
                        else
                        {
                            BookEditFlag = false;
                        }

                    }
                }
            }

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.3.1.min.js",

            });
        }

        private void fileLoad(string fileFormat, string path, FileUpload fileUpload)
        {
            int fileSize = (2 * 1024 * 1024);
            
                string format = Path.GetExtension(fileUpload.PostedFile.FileName);
                int size = fileUpload.PostedFile.ContentLength;

                if (!format.Equals(fileFormat))
                {
                    error.Text = "Неподдерживаемое расширение файла";
                }
                else
                {

                    if (size > fileSize)
                    {
                        error.Text = "Неожиданно большой размер файла";
                    }
                    else
                    {

                        ClassCombine combine = new ClassCombine();

                        path = combine.combine(Server.MapPath(path))+fileUpload.PostedFile.FileName;
                    
                        fileUpload.SaveAs(path);

                        error.Style["color"] = "yellow";

                        error.Text += "Файл успешно загружен: " + fileUpload.PostedFile.FileName + "</br></br>";

                    }
              }
        }

        protected void upload_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!BookEditFlag)
                {
                    error.Text += "BookEditFlag=False";
                    if (uploadFile.HasFile && uploadPictures.HasFile)
                    {
                        using (Database1Entities entities = new Database1Entities())
                        {

                            fileLoad(".jpg", "~/Book/album/", uploadPictures);
                            fileLoad(".txt", "~/Book/", uploadFile);

                            Book book = new Book()
                            {
                                Id = Convert.ToInt32(id),
                                Название = nameBook.Text,
                                Краткое_описание = annotation.Text,
                                Обложка = "~/Book/album/" + uploadPictures.PostedFile.FileName,
                                Жанр = hangr.Text,
                                Автор = author.Text,
                                Путь_к_Файлу = "~/Book/" + uploadFile.PostedFile.FileName

                            };
                            entities.Book.Add(book);
                            entities.SaveChanges();
                        }

                        Response.Redirect("HomePage.aspx");
                    }

                    else
                    {
                        error.Text += "Файл не найден";
                    }
                }

                else
                    {
                        SaveEdit();
                    }
                }
            }

        private void SaveEdit()
        {
            using (Database1Entities entities = new Database1Entities())
            {
                var connection = (from value in entities.Book
                    where value.Id.ToString().Equals(id)
                    select value).FirstOrDefault();

                connection.Название = nameBook.Text;
                connection.Автор = author.Text;
                connection.Жанр = hangr.Text;
                connection.Краткое_описание = annotation.Text;

                if (uploadFile.HasFile)
                {
                    connection.Путь_к_Файлу = "~/Book/" + uploadFile.PostedFile.FileName;
                    fileLoad(".txt", "~/Book/", uploadFile);
                }

                if (uploadPictures.HasFile)
                {
                    fileLoad(".jpg", "~/Book/album/", uploadPictures);
                    connection.Обложка = "~/Book/album/" + uploadPictures.PostedFile.FileName;
                }

                entities.SaveChanges();
                Response.Redirect("HomePage.aspx");
            }

        }
    }

}