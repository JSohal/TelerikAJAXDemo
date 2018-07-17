<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="TelerikWebSiteDemo.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
   
</head>
<body>
     <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" CssClass="demo-containers">
 
        <div class="demo-container size-thin">
            <telerik:RadListBox RenderMode="Lightweight" ID="RadListBox1" runat="server" AutoPostBack="true" CheckBoxes="true" Width="300" OnItemCheck ="RadListBox1_ItemCheck"
                
                Height="200">
               

            </telerik:RadListBox>
          
        </div>

        <telerik:RadGrid ID="RadGrid2" runat="server" PageSize="10" PagerStyle-PageButtonCount="5"
            OnNeedDataSource="RadGrid2_NeedDataSource"   OnPreRender="RadGrid2_PreRender"
            AllowPaging="false" AllowSorting="true" ShowGroupPanel="false" RenderMode="Lightweight">
            <GroupingSettings ShowUnGroupButton="true" />
            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
            <MasterTableView AutoGenerateColumns="true" EditMode="Batch" 
                AllowFilteringByColumn="false" TableLayout="Fixed"
                DataKeyNames="ID" CommandItemDisplay="None"
                InsertItemPageIndexAction="ShowItemOnFirstPage">
                <CommandItemSettings ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="true" />
               
            </MasterTableView>
            <ClientSettings AllowColumnsReorder="true" AllowColumnHide="true" AllowDragToGroup="true">
                <Selecting AllowRowSelect="true" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
        </telerik:RadGrid>
        </telerik:RadAjaxPanel>
    </form>
</body>
</html>
