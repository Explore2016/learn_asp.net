<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" DeleteCommand="DELETE FROM [产品表] WHERE [产品的编号] = @original_产品的编号 AND (([描述信息] = @original_描述信息) OR ([描述信息] IS NULL AND @original_描述信息 IS NULL)) AND (([库存量] = @original_库存量) OR ([库存量] IS NULL AND @original_库存量 IS NULL)) AND (([类别] = @original_类别) OR ([类别] IS NULL AND @original_类别 IS NULL)) AND (([仓库的编号] = @original_仓库的编号) OR ([仓库的编号] IS NULL AND @original_仓库的编号 IS NULL)) AND (([价格] = @original_价格) OR ([价格] IS NULL AND @original_价格 IS NULL))" InsertCommand="INSERT INTO [产品表] ([产品的编号], [描述信息], [库存量], [类别], [仓库的编号], [价格]) VALUES (@产品的编号, @描述信息, @库存量, @类别, @仓库的编号, @价格)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [产品表]" UpdateCommand="UPDATE [产品表] SET [描述信息] = @描述信息, [库存量] = @库存量, [类别] = @类别, [仓库的编号] = @仓库的编号, [价格] = @价格 WHERE [产品的编号] = @original_产品的编号 AND (([描述信息] = @original_描述信息) OR ([描述信息] IS NULL AND @original_描述信息 IS NULL)) AND (([库存量] = @original_库存量) OR ([库存量] IS NULL AND @original_库存量 IS NULL)) AND (([类别] = @original_类别) OR ([类别] IS NULL AND @original_类别 IS NULL)) AND (([仓库的编号] = @original_仓库的编号) OR ([仓库的编号] IS NULL AND @original_仓库的编号 IS NULL)) AND (([价格] = @original_价格) OR ([价格] IS NULL AND @original_价格 IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_产品的编号" Type="Int32" />
                <asp:Parameter Name="original_描述信息" Type="String" />
                <asp:Parameter Name="original_库存量" Type="Int32" />
                <asp:Parameter Name="original_类别" Type="Int32" />
                <asp:Parameter Name="original_仓库的编号" Type="Int32" />
                <asp:Parameter Name="original_价格" Type="Double" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="产品的编号" Type="Int32" />
                <asp:Parameter Name="描述信息" Type="String" />
                <asp:Parameter Name="库存量" Type="Int32" />
                <asp:Parameter Name="类别" Type="Int32" />
                <asp:Parameter Name="仓库的编号" Type="Int32" />
                <asp:Parameter Name="价格" Type="Double" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="描述信息" Type="String" />
                <asp:Parameter Name="库存量" Type="Int32" />
                <asp:Parameter Name="类别" Type="Int32" />
                <asp:Parameter Name="仓库的编号" Type="Int32" />
                <asp:Parameter Name="价格" Type="Double" />
                <asp:Parameter Name="original_产品的编号" Type="Int32" />
                <asp:Parameter Name="original_描述信息" Type="String" />
                <asp:Parameter Name="original_库存量" Type="Int32" />
                <asp:Parameter Name="original_类别" Type="Int32" />
                <asp:Parameter Name="original_仓库的编号" Type="Int32" />
                <asp:Parameter Name="original_价格" Type="Double" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
