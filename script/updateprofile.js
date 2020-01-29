< script  >
    alert("hello world");
$(function () {

        $("#Updatepic").change(function () {
            $("#dvPreview").html("");
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
            if (regex.test($(this).val().toLowerCase())) {
                if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                    $("#dvPreview").show();
                    $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
                    $("#dvPreview").show();
                }
                else {

                    if (typeof (FileReader) != "undefined") {
                        $("#dvPreview").show();
                        $("#dvPreview").append("<img />");
                        $("#dvPreview img").attr("class", "showimg");
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $("#updateprofilepic").attr("src", e.target.result);
                        }
                        reader.readAsDataURL($(this)[0].files[0]);
                    } else {

                        alert("This browser does not support FileReader.");
                        $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");
                    }
                }
            } else {
                alert("Please upload a valid image file.");
                $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");

            }
        })};
    </script >