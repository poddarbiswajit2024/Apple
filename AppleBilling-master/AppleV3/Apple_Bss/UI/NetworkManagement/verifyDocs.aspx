<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="verifyDocs.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.verifyDocs"
    Title="Verify Documents" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">--%>

    <style type="text/css" />
    iframe.docu
    {
        height:400px;
        width:95%;
        border:none;
    }

    p
    {
        font-weight:bold;
        font-size:14px;
    }

    .radioButtonList
    {
        width:280px;
        
    }
    .radioButtonList input
    {    
      float: left;
      height:15px;
    }

    .radioButtonList label
    {    
      margin-left: 20px;
      display: block;
      text-align: left;
      font-weight:bold;
     font-size:15px;
   
    }

    .myImage
    {
        padding:0px;
        border:2px solid red;
    }
    table td
    {
        padding-left:10px;
    }
    .myFilesDisplay td
    {
         vertical-align:top;
    }
</style>

    <script type="text/javascript">
        //This is to maintain scroll position after postback
        window.onload = function () {
            var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
        if (!isNaN(scrollY)) {
            window.scrollTo(0, scrollY);
        }
    };
    window.onscroll = function () {
        var scrollY = document.body.scrollTop;
        if (scrollY == 0) {
            if (window.pageYOffset) {
                scrollY = window.pageYOffset;
            }
            else {
                scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
            }
        }
        if (scrollY > 0) {
            var input = document.getElementById("scrollY");
            if (input == null) {
                input = document.createElement("input");
                input.setAttribute("type", "hidden");
                input.setAttribute("id", "scrollY");
                input.setAttribute("name", "scrollY");
                document.forms[0].appendChild(input);
            }
            input.value = scrollY;
        }
    };
    </script>





    <%--  <asp:UpdatePanel ID="UpdatePanel1"  runat="server">

        <ContentTemplate>--%>

    <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">Verify Documents</td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellspacing="0" cellpadding="0" align="left" class="tableStyle">
                    <tr>
                        <td class="tdStyle" width="15%">&nbsp;
                        </td>
                        <td class="tdStyle" width="78%" colspan="2">
                            <asp:Label ID="_lblMsg" runat="server" Font-Bold="True" Font-Names="Arial"
                                Font-Size="9pt" ForeColor="Maroon"></asp:Label>&nbsp;
                        </td>

                        <td width="7%" class="backbtn">
                            <asp:ImageButton ID="_iBtnBack" runat="server" CausesValidation="False"
                                OnClick="_iBtnBack_Click" ImageUrl="~/Images/Buttons/back.png" />
                        </td>

                    </tr>
                </table>

                <table cellspacing="0" cellpadding="0" align="left" class="tableStyle" style=" width:100%">
                    <tr>
                        <td>
                            <p>Customer's Name</p>
                            <p id="CustomerName" runat="server"></p>
                        </td>
                        <td>
                            <p>CAFNUMBER</p>
                            <p id="IdCAFNUMBER" runat="server"></p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Customer's Photo</p>

                            <div style="width: 200px; height: 200px; position: relative;">
                                <%--<iframe id="Customer_Photo" runat="server"  style="border: none;"></iframe>--%>
                                <asp:Image ID="Customer_Photo" runat="server" Height="200" BorderColor="red" />
                                <a runat="server" href="#" id="myPhoto" target="_blank" style="width: 200px; height: 200px; position: absolute; top: 0; left: 0; z-index: 1"></a>
                            </div>
                        </td>
                        <td>
                            <p>Customer's Signature</p>
                            <div style="width: 200px; height: 200px; position: relative;">
                                <asp:Image ID="Cust_Signature" runat="server" Height="200" Width="200" BorderColor="red" />
                                <a runat="server" href="#" id="MySignature" target="_blank" style="width: 200px; height: 200px; position: absolute; top: 0; left: 0; z-index: 1"></a>
                            </div>
                        </td>
                    </tr>
                </table>
               
                <table style="width:100%;" class="myFilesDisplay">
                    <tr>
                        <td colspan="2" style="width:100%;">
                            <p style="display: inline-block;">ID Proof Type:</p>
                            &nbsp;&nbsp;<span id="idproofName" runat="server" style="display: inline-block; font-weight: bold; font-size: 12px;"></span>
                             
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50%;"> <p>ID Proof Front Side</p> </td>
                        <td style="width:50%"> <p>ID Proof Back Side</p> </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">
                           
                              <div style="width: 80%;">
                                <asp:Image ID="Customer_idProof_Front_Image" Width="100%" runat="server"  BorderColor="red"  />
                                <%--<a runat="server" href="#" id="A1" target="_blank" style="width: 200px; height: 200px; position: absolute; top: 0; left: 0; z-index: 1"></a>--%>
                            </div>

                             <div style="width: 80%; ">
                                <iframe class="docu" id="Customer_idProof_Front" width="100%" runat="server" src="#" ></iframe>
                             </div>
                          
                        </td>
                        <td>
                             <div style="width: 80%;">
                                <iframe class="docu" id="Customer_idProof_Back" width="100%" runat="server" src="#"></iframe>
                            </div>
                             <div style="width: 80%;" >
                                <asp:Image ID="Customer_idProof_Back_Image" width="100%" runat="server" BorderColor="red" />
                             </div>
                        </td>
                    </tr>
                    <tr>
                        
                        <td colspan="2">
                            <p style="display: inline-block;">Address Proof Type:</p>
                            &nbsp;&nbsp;<span id="addressproofname" runat="server" style="font-weight: bold; font-size: 12px;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p style="display: inline-block;">Address Provided By Customer:</p>
                            &nbsp;&nbsp;<span id="AddressGiven" runat="server" style="font-weight: bold; font-size: 12px;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td><p>Address Proof Front Side</p></td>
                        <td><p>Address Proof Back Side</p> </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 80%; ">
                                <iframe class="docu" id="Customer_addProof_Front" runat="server" src="#"  style="width: 100%;"></iframe>
                             </div>
                            <div style="width: 80%;">
                                <asp:Image ID="Customer_addProof_Front_Image" Width="100%" runat="server"  BorderColor="red" />
                            </div>
                        </td>
                        <td>
                           
                            <iframe class="docu" id="Customer_addProof_Back2" runat="server" src="#" style="width: 100%;"></iframe>
                              <div style="width: 80%;">
                                <asp:Image ID="Customer_addProof_Back2_Image"  Width="100%" runat="server" CssClass="myImage"  BorderColor="red"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left">
                            <br />
                            <br />
                            <br />
                            <h3 style="font-weight: bold; font-size: 28px;">Documents Verification</h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                <ContentTemplate>
                                    <%--<asp:Panel ID="Panel2" runat="server" BackColor="LightPink" BorderColor="DarkBlue" BorderStyle="Solid">--%>

                                        <table style="width: 100%; border-top: 1px solid black">
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:RadioButtonList ID="RadioButtonList1" CssClass="radioButtonList" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Value="verified" Selected="True">Documents Verified</asp:ListItem>
                                                        <asp:ListItem Value="rejected">Documents Rejected</asp:ListItem>
                                                    </asp:RadioButtonList>


                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:Label ID="lbl_rejection" runat="server" Font-Bold="true" Text="Reasons for rejection:" Font-Size="Large"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <asp:DropDownList ID="ddl_Reason" runat="server" AutoPostBack="true" ValidationGroup="two" Enabled="False" OnSelectedIndexChanged="ddl_Reason_SelectedIndexChanged" Font-Bold="true" Font-Size="Larger">
                                                        <asp:ListItem Selected="True">--Select Reasons For the Rejections--</asp:ListItem>
                                                        <asp:ListItem>Photo/Face not clear/too small</asp:ListItem>
                                                        <asp:ListItem>ID proof not clear</asp:ListItem>
                                                        <asp:ListItem>Signature not clear/too small</asp:ListItem>
                                                        <asp:ListItem>Address proof not clear</asp:ListItem>
                                                        <asp:ListItem>Photo mismatch with provided ID proof</asp:ListItem>
                                                        <asp:ListItem>ID proof mismatch with name</asp:ListItem>
                                                        <asp:ListItem>Address proof mismatch with provided address</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="Select_reason" runat="server" ControlToValidate="ddl_Reason" InitialValue="--Select Reasons For the Rejections--" ErrorMessage="Select a Proper Reason" ValidationGroup="two"></asp:RequiredFieldValidator>

                                                    <asp:TextBox ID="txt_Reason" Visible="false" ValidationGroup="two" runat="server" Height="100px" Width="550px" TextMode="MultiLine" Text=""></asp:TextBox>
                                                    <br />

                                                    <asp:RequiredFieldValidator ID="Reasons_required" Enabled="false" ValidationGroup="two" runat="server" ControlToValidate="txt_Reason" ErrorMessage="Reasons are Required"></asp:RequiredFieldValidator>
                                                    <br />


                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="bnt_varified" runat="server" Text="Documents Verified & Add Connection Details" Font-Size="Larger" OnClick="bnt_varified_Click" BackColor="#33CC33" BorderColor="#009933" Height="50px" Width="550px" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="bnt_reject" ValidationGroup="two" runat="server" Text="Reject Documents" Enabled="False" Font-Size="Larger" OnClick="bnt_reject_Click" BackColor="Red" BorderColor="#CC3300" Height="50px" Width="550px" />
                                                </td>
                                            </tr>
                                        </table>
                                    <%--</asp:Panel>--%>
                                </ContentTemplate>
                                <%-- <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddl_Reason" EventName="SelectedIndexChanged" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                    </tr>

                </table>


            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
