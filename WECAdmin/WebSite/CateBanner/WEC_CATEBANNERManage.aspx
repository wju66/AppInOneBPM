<%@ Page Language="C#" MasterPageFile="~/Themes/Blank.master" AutoEventWireup="true" CodeFile="WEC_CATEBANNERManage.aspx.cs" Inherits="WEC_CATEBANNERManage" %>
<%@ Import Namespace="AgileFrame.Orm.PersistenceLayer.Model" %>
<%@ Import Namespace="AgileFrame.Core"%>
<%@ Import Namespace="AgileFrame.Core.WebSystem"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var manager = new ListManager();
    $(function () {
        manager.initBodyRows();
        manager.initFindDL();
        //manager.initPageSizeEvt("txtPageNum");
        bindWinResize(40);
        $("#display_search").click(function () {
            $(".topfind").toggleClass("hide");   if($("#display_search").val()=="显示查询")$("#display_search").val("隐藏查询");else $("#display_search").val("显示查询"); 
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
<input id="hidCondition" type="hidden" runat="server" />
<div class="main">
   <div class="titnav">
    <dl><dt><b><%=title %></b></dt></dl>
   </div>
   <div class="warn"><asp:Literal ID="litWarn" runat="server"></asp:Literal></div>
   <div class="topfind hide"><!--需要隐去时，用 style="display:none;"-->        
         
            <dl colname="WEC_CATEBANNER.ID" class="hide">
               <dt><%=WEC_CATEBANNER.Attribute.ID.ZhName %>：</dt><!--编号-->
               <dd><span>
               
                    <input id="txtID" type="text" runat="server"  ck="{len:18,type:1}" />
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.AID" class="hide">
               <dt><%=WEC_CATEBANNER.Attribute.AID.ZhName %>：</dt><!--公众号编号-->
               <dd><span>
               
                    <input id="txtAID" type="text" runat="server"  ck="{len:18,type:1}" />
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.PIC_URL" class="hide">
               <dt><%=WEC_CATEBANNER.Attribute.PIC_URL.ZhName %>：</dt><!--图片地址-->
               <dd><span>
               
                    <input id="txtPIC_URL" type="text" runat="server" />
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.OUT_URL">
               <dt><%=WEC_CATEBANNER.Attribute.OUT_URL.ZhName %>：</dt><!--链接地址-->
               <dd><span>
               
                    <input id="txtOUT_URL" type="text" runat="server" />
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.SORT_ID" class="hide">
               <dt><%=WEC_CATEBANNER.Attribute.SORT_ID.ZhName %>：</dt><!--排序-->
               <dd><span>
               
                    <input id="txtSORT_ID" type="text" runat="server"  ck="{len:4,type:1}" />
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.STATUS">
               <dt><%=WEC_CATEBANNER.Attribute.STATUS.ZhName %>：</dt><!--状态-->
               <dd><span>
               
                    <select id="txtSTATUS" runat="server" >
                    </select>
               </span></dd>
               
        </dl>
         
            <dl colname="WEC_CATEBANNER.ADDTIME">
               <dt><%=WEC_CATEBANNER.Attribute.ADDTIME.ZhName %>：</dt><!--添加时间-->
               <dd><span>
               
                    <input id="txtADDTIME" type="text" readonly="readonly" onclick="setday(this)" runat="server" />
               </span></dd>
               
        </dl>
         <dl class="btn"><dd>
                <span><asp:Button ID="btnFind" runat="server" Text="查询" onclick="btnFind_Click" /></span>
               <span><input id="btnClear" type="button" value="清空" onclick="_topFindClear(this);"/></span>
               </dd></dl>
         <div class="clear"></div>
    </div>
    <div class="tool">
        <ul>
            <li><span><input power="newWEC_CATEBANNER" id="btn_New" type="button" value="新建" onclick="manager.newRecord('WEC_CATEBANNEREdit.aspx','','1',900,700);" /></span></li>
            <li><span><input power="editWEC_CATEBANNER" id="btn_Edit" type="button" value="编辑" onclick="manager.editRecord('WEC_CATEBANNEREdit.aspx','','1',900,700);" /></span></li>
<%--            <li><span class="btn"><input power="newWEC_CATEBANNER" id="btn_NewSub" type="button" value="新建下级" onclick="manager.newRecord('STORAGEEdit.aspx','PID');" /></span></li>--%>
            <li><span><input id="btn_Dels" type="button" value="删除" onclick="manager.delBySelIDS('WEC_CATEBANNERBack.aspx');" /></span></li>
            <li><span><input type="button" value="显示查询" id="display_search"/></span></li>
        </ul>
        <ol>
            <li><b>每页显示</b></li>
            <li><input id="txtPageSize" type="text" runat="server" style="width:25px;" /><b>条</b></li>
            <li><span><asp:Button ID="Button4" runat="server" Text="设置" OnClick="btnSetPageSize_Click" /></span></li>
            <li class="colist hide"><a onclick="_hideColsSel(this);">更多列</a><ol id="ol1"></ol></li>
        </ol>
    </div>
    <div class="tblist">
         <table cellpadding="0" cellspacing="0" id="tbList">
            <thead>
                <tr keyname="ID">
                    <td class="first"><input type="checkbox" onclick="_selAll(this);" /></td>
                   <%-- <td><a href="Manage.aspx" id="a_top" runat="server"><b>顶级</b></a></td>--%>
                    
                    
                   <%-- <td data="{colname:'<%=WEC_CATEBANNER.Attribute.ID.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.ID._ZhName %></td><!--编号-->
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.AID.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.AID._ZhName %></td><!--公众号编号-->--%>
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.PIC_URL.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.PIC_URL._ZhName %></td><!--图片地址-->
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.OUT_URL.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.OUT_URL._ZhName %></td><!--链接地址-->
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.SORT_ID.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.SORT_ID._ZhName %></td><!--排序-->
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.STATUS.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.STATUS._ZhName %></td><!--状态-->
                    
                    
                    <td data="{colname:'<%=WEC_CATEBANNER.Attribute.ADDTIME.LongName%>',show:1}"><%=WEC_CATEBANNER.Attribute.ADDTIME._ZhName %></td><!--添加时间-->
            </tr>
            </tbody>
            <tbody>
                <asp:Repeater ID="repList" runat="server" onitemdatabound="repList_ItemDataBound">
                <ItemTemplate>
                <tr>
                    <td class="first"><input type="checkbox" value="<%#((WEC_CATEBANNER)Container.DataItem).ID%>" /></td>
                   <%-- <td><%#showLeftLinks(((WEC_CATEBANNER)Container.DataItem).PATH, ((WEC_CATEBANNER)Container.DataItem).PNAME, Container.ItemIndex)%></td>--%>
                    
                    
                <%--    <td><%#((WEC_CATEBANNER)Container.DataItem).ID %></td>
                    
                    
                    <td><%#((WEC_CATEBANNER)Container.DataItem).AID %></td>--%>
                    
                    
                    <td><img src="<%#((WEC_CATEBANNER)Container.DataItem).PIC_URL %>" style="width:50px;height:50px;"/></td>
                    
                    
                    <td><%#((WEC_CATEBANNER)Container.DataItem).OUT_URL %></td>
                    
                    
                    <td><%#((WEC_CATEBANNER)Container.DataItem).SORT_ID %></td>
                    
                    
                    <td><%#FormHelper.GetText(WEC_CATEBANNER.Attribute.STATUS, ((WEC_CATEBANNER)Container.DataItem).STATUS)%></td>
                    
                    
                    <td><%#(((WEC_CATEBANNER)Container.DataItem).ADDTIME == DateTime.MinValue) ? "" : ((WEC_CATEBANNER)Container.DataItem).ADDTIME.ToString("yyyy-MM-dd HH:mm") %></td>
                    
                </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
         </table>
    </div>
    <div class="path-url hide">
        <strong>当前路径：</strong><asp:Literal ID="litPathLink" runat="server"></asp:Literal>
    </div>
    <div class="pages">
        <WebCtrl:AspNetPager ID="aspPager" runat="server" onpagechanged="aspPager_PageChanged"></WebCtrl:AspNetPager>
    </div>
</div>
</asp:Content>