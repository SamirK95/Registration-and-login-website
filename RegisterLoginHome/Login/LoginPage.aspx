<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Login_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <%--Ovo je naslov--%>
    <title>Login Page</title>

    <%--Ovo je putanja do font awesome da bi mogao koristiti ikone --%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"/>
    <link href="../Stil/LoginStil.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="glavniDiv">
            <div class="centarNaslov">
                <h1>Sign in</h1>
            </div>
            <hr />
            
            <div class="glavniSadrzaj">
                <form method="post" runat="server">
                    <div class="text_Field">
                        
                        <input type="text" required="required" id="usernameID" runat="server"/>
                        <span><i class="fa-solid fa-user"></i></span>
                        <asp:Label Text="Username" runat="server" class="pass" />
                        
                    </div>

                    <div class="text_Field">
                        <input type="password" required="required" id="passwordID" runat="server"/>
                        <span><i class="fa-solid fa-lock"></i></span>
                        <asp:Label Text="Password" runat="server"  class="pass"/>
                    </div>

                    
                    <!--<div class="pass">Forgot Password?</div>-->
                    <asp:Button ID="btnLoginPage" Text="Login" runat="server" OnClick="btnLoginPage_Click"/>
                    <%--<input type="submit" value="Login" id="btnLoginPage" />--%>
                    <div class="signup_Link">
                        Not a member? <a href="../Register/RegisterPage.aspx"><strong>Sign up</strong></a>
                        <br />
                        <asp:Label ID="lblIspis" runat="server"></asp:Label>
                        
                    </div> 
                    
                </form>
            

            </div>
        </div>
</body>
</html>
