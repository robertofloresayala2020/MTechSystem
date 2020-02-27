<%@ Page Language="C#" Inherits="WebEmpleado.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		    
            
                <table>
               
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="Name" Columns="10"  Text="" runat="server"/></td>
                    <td><asp:RequiredFieldValidator 
                              id="RequiredFieldValidator1"
                              ControlToValidate="Name" 
                              ErrorMessage="Nombre requerido. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                     </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                     <td>Last Name:</td>
                     <td><asp:TextBox ID="LastName" Columns="20"  Text="" runat="server"/></td>
                    <td><asp:RequiredFieldValidator 
                              id="RequiredFieldValidator2"
                              ControlToValidate="LastName" 
                              ErrorMessage="Apellido requerido. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                     </asp:RequiredFieldValidator></td>
                </tr>  
                <tr>
                      <td>RFC</td>
                      <td> <asp:TextBox ID="RFC" Columns="15"  Text="" runat="server"/></td>
                    <td><asp:RequiredFieldValidator 
                              id="RequiredFieldValidator3"
                              ControlToValidate="RFC" 
                              ErrorMessage="RFC. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                     </asp:RequiredFieldValidator></td>
                    
                    <td>
                     <asp:RegularExpressionValidator id="RegularExpressionValidator2" 
                     ControlToValidate="RFC"
                     ValidationExpression="^(([ÑA-Z|ña-z|&]{3}|[A-Z|a-z]{4})\d{2}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)(\w{2})([A|a|0-9]{1}))$|^(([ÑA-Z|ña-z|&]{3}|[A-Z|a-z]{4})([02468][048]|[13579][26])0229)(\w{2})([A|a|0-9]{1})$"
                     Display="Static"
                     ErrorMessage="Formato RFC incorrecto"
                    InitialValue="" Width="100%"
                     runat="server">Formato RFC incorrecto</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                     <td>Born Date:</td>
                     <td> <asp:TextBox ID="BornDate" Columns="10"  Text="" runat="server"/></td>
                     <td><asp:RequiredFieldValidator 
                              id="RequiredFieldValidator4"
                              ControlToValidate="BornDate" 
                              ErrorMessage="BornDate. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                     </asp:RequiredFieldValidator>
                      </td>
                    <td>
                     <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                     ControlToValidate="BornDate"
                     ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                     Display="Static"
                     ErrorMessage="Formato fecha dd/mm/yyyy"
                    InitialValue="" Width="100%"
                     runat="server">Formato fecha dd/mm/yyyy</asp:RegularExpressionValidator>
                    </td>
                </tr>
                
                <tr>
                    <td>Status:</td>
                    <td> <asp:DropDownList id="Status"
              
                    runat="server">

                  <asp:ListItem Selected="True" Value=""> - </asp:ListItem>
                  <asp:ListItem Value="0"> Activo </asp:ListItem>
                  <asp:ListItem Value="1"> Inactivo </asp:ListItem>
                 
           
 
               </asp:DropDownList></td>
                    <td><asp:RequiredFieldValidator 
                              id="RequiredFieldValidator5"
                              ControlToValidate="Status" 
                              ErrorMessage="Status requerido. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                     </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <asp:Button id="button1" runat="server" Text="Find!" OnClick="FindClicked" CausesValidation=false/> 
                    
                    <asp:Button id="button2" runat="server" Text="Add!" OnClick="AddClicked" CausesValidation = true />  
                 </tr>
                 <tr>
                    <td>
                        <asp:Label id="LError" Text="" runat="server"/>
                    </td>
                 </tr>
                <tr>
                            
                         <asp:DataGrid id="EmpleadosGrid"
                               BorderColor="black"
                               BorderWidth="1"
                               CellPadding="3"
                               AutoGenerateColumns="true"
                               runat="server">

                             <HeaderStyle BackColor="#00aaaa">
                             </HeaderStyle> 
                     
                          </asp:DataGrid>
                    </tr> 
             </table>
           
            
        
	</form>
</body>
</html>
