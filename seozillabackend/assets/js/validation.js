
       $(function () {
           $("#errormessage").css({ "display": "none" });
           $(".btn-custom").click(function () {
               var password = $("#txtPassword").val();
               var confirmPassword = $("#txtConfirmPassword").val();
               if (password != confirmPassword) {
                   $("#errormessage").css({ "display": "initial" });
                   $("#txtPassword").val(null);
                   $("#txtConfirmPassword").val(null);
                   return false;
                
               }
               return true;
           });
       });
