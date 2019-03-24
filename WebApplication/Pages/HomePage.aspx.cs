using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication.Models;
using Image = System.Web.UI.WebControls.Image;

namespace WebApplication
{
    public partial class HomePage : System.Web.UI.Page
    {
        private static bool _filterFlag=true;
        private static Database1Entities _entitiesBook;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _entitiesBook = new Database1Entities();

                foreach (var book in _entitiesBook.Book)
                {
                    PrintBookMethod(book.Название, book.Обложка, book.Id, book.Жанр, book.Автор);
                }
                
            }
            HangrFilter();
        }


//Формирование разметки страницы для вывода информации о книгах на страницу
        private void PrintBookMethod(string nameBook, string imagePath, int id, string hangr, string author)
        {
            //Вывод информации о обложке
            Image image = new Image();
            image.ImageUrl = imagePath.TrimEnd();
            image.Width = 150;
            image.Height = 200;
            
                Panel p1 = new Panel();
                p1.ID = "newsImageConponentsImage";
                p1.Controls.Add(image);
            
            //Вывод информации о авторе
            Label labelAuthor = new Label();
            labelAuthor.Style["font-size"] = 12 + "px";
            labelAuthor.Text = author.TrimEnd() + "</br></br>";
            labelAuthor.ID = "Author";

                Label labelAuthorBlock = new Label();
                labelAuthorBlock.Text = "<p>Автор:</p>";
            
                    Panel authorPanel = new Panel();
                    authorPanel.ID = "authorPanel";
                    authorPanel.Controls.Add(labelAuthorBlock);
                    authorPanel.Controls.Add(labelAuthor);



            //Вывод информации о жанре
            Label labelHangr = new Label();
            labelHangr.Style["font-size"] = 12 + "px";
            labelHangr.Text = hangr.TrimEnd();
            labelHangr.ID = "Hangr";

                Label labelHangrBlock = new Label();
                labelHangrBlock.Text = "<p>Жанр:</p>";
            
                    Panel hangrPanel = new Panel();
                    authorPanel.ID = "hangrPanel";
                    authorPanel.Controls.Add(labelHangrBlock);
                    authorPanel.Controls.Add(labelHangr);




            Panel p2 = new Panel();
            p2.ID = "newsImageConponentsInfo";
            p2.Controls.Add(authorPanel);
            p2.Controls.Add(hangrPanel);



            Panel row = new Panel();
            row.CssClass = "row";
            row.Controls.Add(p1);
            row.Controls.Add(p2);


            //Вывод названия книги
            Label label = new Label();
            label.Text = nameBook.TrimEnd();

                Panel name = new Panel();
                name.ID = "nameBook";
                name.Controls.Add(label);



            Panel container = new Panel();
            container.CssClass = "container";
            container.ID = "container";
            container.Controls.Add(name);
            container.Controls.Add(row);


            Button button = new Button();
            button.CssClass = "btn btn-outline-primary";
            button.Text = "Подробнее";
            button.ID = id.ToString();

                Panel buPanel = new Panel();
                buPanel.ID = "newsImageConponentsButton";
                buPanel.Controls.Add(button);


            Panel newsImage = new Panel();
            newsImage.ID = "newsImage";
            newsImage.Controls.Add(container);
            newsImage.Controls.Add(buPanel);

            placeHolder.Controls.Add(newsImage);
        }

        //Обработчик нажатия кнопки в форме поиска
        //Осуществляет нахождение искомой пользователем книги в БД и их вывод
        protected void buttonFormSearch_OnClick(object sender, EventArgs e)
        {
            
                foreach (var VARIABLE in _entitiesBook.Book)
                {
                    if (VARIABLE.Название.TrimEnd().ToLower().Contains(search.Text.Trim().ToLower()) ||
                        VARIABLE.Автор.TrimEnd().ToLower().Contains(search.Text.Trim().ToLower()))
                    {
                        PrintBookMethod(VARIABLE.Название, VARIABLE.Обложка, VARIABLE.Id, VARIABLE.Жанр,
                            VARIABLE.Автор);
                    }
                }
        }

        protected void buttonFilter_OnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
                foreach (var VARIABLE in _entitiesBook.Book)
                {
                    if (VARIABLE.Жанр.TrimEnd().ToLower().Contains(button.Text.Trim().ToLower()))
                    {
                        PrintBookMethod(VARIABLE.Название, VARIABLE.Обложка, VARIABLE.Id, VARIABLE.Жанр,
                            VARIABLE.Автор);
                    }
                }
        }

        //Находит все жанры книг,формирует массив неповторяющихся жанров и вывод кнопок в соответствии с найденным жанром
        private void HangrFilter()
        {

            List<string> list = new List<string>();
            string hangr=String.Empty;

            foreach (var VARIABLE in _entitiesBook.Book)
            {
                int position = 0;

                char[]array = (VARIABLE.Жанр.Trim()+".").ToCharArray();

                for (int a = 0; a <array.Length ; a++)
                {
                    if (array[a]==',' || a==array.Length-1)
                    {
                        if (!list.Contains(hangr.Trim()))
                        {
                            list.Add(hangr.Trim());
                        }

                        hangr = String.Empty;
                    }
                    else
                    {
                        hangr += array[a];
                    }

                }

            }
            

            foreach (var VARIABLE in list)
            {
                Button button=new Button();
                button.Text = VARIABLE;
                button.UseSubmitBehavior = false;
                button.CssClass = "buttonFilter btn btn-outline-warning";
                button.Click += new EventHandler(buttonFilter_OnClick); 
                filter.Controls.Add(button);
            }

        }

    }
    
}