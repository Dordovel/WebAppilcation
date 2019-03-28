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

        var infoPanel = $('[id=newsImageConponentsInfo]');

        for (var b = 0; b < image.length; ++b)
        {
            image.eq(b).mouseenter(
                function () 
                {
                    alert(infoPanel.css("right"));

                    infoPanel.eq(b).animate(
                        {
                            right:"+=100px"
                        }
                    );

                    alert(infoPanel.css("right"));

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
                    infoPanel.eq(b).animate(
                        {
                            right: "-=100px"
                        }
                    );

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