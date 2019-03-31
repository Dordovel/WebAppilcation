window.onload = function ()
{
    var butt = $("input[value='Подробнее']");

    for (var a = 0; a < butt.length; a++)
    {
        butt.eq(a).on("click",
            function ()
            {
                window.location.replace("WebForm1.aspx?id=" + $(this).attr("id"));
            }
        );
    }
}

$(document).ready(

    function ()
    {
        var image = $('img');

        for (var b = 0; b < image.length; ++b)
        {
            image.eq(b).mouseenter(
                function () 
                {

                    $(this).animate(
                        {
                            height: '+=100px',
                            width: "+=100px"
                        }
                    );
                }
            );

            image.eq(b).mouseout(
                function ()
                {

                    $(this).animate(
                        {
                            height: '-=100px',
                            width: "-=100px"
                        }
                    );
                }
            );
        }
    }
);