<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="Componente.Web.Supero.Paginas.Task" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <script src="../Scripts/jquery-1.10.2.js"></script>
  <script src="../Scripts/jquery-1.10.2.min.js"></script>
  <script src="../Scripts/bootstrap.js"></script>
  <script src="../Scripts/bootstrap.min.js"></script>
  <link href="../Content/bootstrap.css" rel="stylesheet" />
  <link href="../Content/Site.css" rel="stylesheet" />
  <link href="../Content/GridView.css" rel="stylesheet" />

  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css" />

  <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
  <script>
    $(document).ready(function () {
      $('#btnNovo').click(function () {
        $('#modalTask').modal('show');

      });

      $(".date").datetimepicker({
        locale: 'pt-br',
        ignoreReadonly: true
      });
    });
  </script>
</head>

<body>
  <form id="form1" runat="server">
    <fieldset>
      <div class="form-group">
        <div class="col-xs-12">
          <fieldset>
            <legend id="Legend1" class="titulo_geral" runat="server"><%:Componente.Supero.Dicionario.Resource.GerenciarTask %></legend>
          </fieldset>
        </div>
      </div>
      <div class="formulario">
        <div class="form-group linha">
          <div class="col-xs-3">
            <label for="txtCodigo" id="lblCodigo" runat="server"><%:Componente.Supero.Dicionario.Resource.Codigo %></label>
            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="col-xs-6">
            <label for="txtDescricao" id="lblDescricao" runat="server"><%:Componente.Supero.Dicionario.Resource.Descricao %></label>
            <asp:TextBox ID="txtDescricaoInicio" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="col-xs-3">
            <label for="ddlTaskStatus" id="lblTaskStatus" runat="server"><%:Componente.Supero.Dicionario.Resource.TaskStatus %></label>
            <asp:DropDownList ID="ddlTaskStatus" CssClass="form-control" runat="server"></asp:DropDownList>
          </div>
        </div>
        <div class="form-group linha">
          <div class="col-xs-3">
            <label for="txtDataCriacao" id="lblDataCriacao" runat="server"><%:Componente.Supero.Dicionario.Resource.DataCriacao %></label>
            <div class="form-group">
              <div class='input-group date'>
                <input type='text' id='txtDataCriacao' runat="server" class="form-control date" />
                <span class="input-group-addon">
                  <span class="glyphicon glyphicon-calendar"></span>
                </span>
              </div>
            </div>
          </div>
          <div class="col-xs-3">
            <label for="txtDataEdicao" id="lblDataEdicao" runat="server"><%:Componente.Supero.Dicionario.Resource.DataEdicao %></label>
            <div class="form-group">
              <div class='input-group date'>
                <input type='text' id='txtDataEdicao' runat="server" class="form-control date" />
                <span class="input-group-addon">
                  <span class="glyphicon glyphicon-calendar"></span>
                </span>
              </div>
            </div>
          </div>
          <div class="col-xs-3">
            <label for="txtDataRemocao" id="lblDataRemocao" runat="server"><%:Componente.Supero.Dicionario.Resource.DataRemocao %></label>
            <div class="form-group">
              <div class='input-group date'>
                <input type='text' id='txtDataRemocao' runat="server" class="form-control date" />
                <span class="input-group-addon">
                  <span class="glyphicon glyphicon-calendar"></span>
                </span>
              </div>
            </div>
          </div>
          <div class="col-xs-3">
            <label for="txtDataConclusao" id="lblDataConclusao" runat="server"><%:Componente.Supero.Dicionario.Resource.DataConclusao %></label>
            <div class="form-group">
              <div class='input-group date'>
                <input type='text' id='txtDataConclusao' runat="server" class="form-control date" />
                <span class="input-group-addon">
                  <span class="glyphicon glyphicon-calendar"></span>
                </span>
              </div>
            </div>
          </div>
        </div>
        <div class="form-group linha linhaBotao">
          <div class="col-xs-12">
            <asp:LinkButton ID="btnPesquisa"
              runat="server"
              CssClass="btn btn-primary new_buttom Pagina"
              OnClick="btnPesquisa_Click">
            <span class="glyphicon glyphicon-search"></span>&nbsp&nbsp
                  <span runat="server" class="image-preview-input-title"><%:Componente.Supero.Dicionario.Resource.Pesquisar %></span>
            </asp:LinkButton>

            <asp:LinkButton ID="btnNovo"
              runat="server"
              OnClientClick="return false"
              CssClass="btn btn-primary new_buttom Pagina">
            <span class="glyphicon glyphicon-plus"></span>&nbsp&nbsp
                  <span runat="server" class="image-preview-input-title"><%:Componente.Supero.Dicionario.Resource.Novo %></span>
            </asp:LinkButton>
          </div>
        </div>

        <div class="form-group linha">
          <div class="col-xs-12">
            <asp:GridView ID="gvTask" runat="server" CssClass="data_table" Width="100%"
              AutoGenerateColumns="false" DataKeyNames="Codigo" OnRowDataBound="gvTask_RowDataBound"
              ShowHeaderWhenEmpty="true" OnRowCommand="gvTask_RowCommand" AllowSorting="true">
              <Columns>
                <asp:BoundField HeaderText="<%$ Code: Resource.Codigo %>"></asp:BoundField>
                <asp:BoundField HeaderText="<%$ Code: Resource.Descricao %>"></asp:BoundField>
                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" HeaderText="<%$ Code: Resource.DataCriacao %>"></asp:BoundField>
                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" HeaderText="<%$ Code: Resource.DataEdicao %>"></asp:BoundField>
                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" HeaderText="<%$ Code: Resource.DataRemocao %>"></asp:BoundField>
                <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" HeaderText="<%$ Code: Resource.DataConclusao %>" HtmlEncode="false"></asp:BoundField>
                <asp:BoundField HeaderText="<%$ Code: Resource.TaskStatus %>"></asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                  <ItemTemplate>
                    <%--<div style="float: right">--%>
                    <asp:LinkButton ID="btnEditar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="btnEditar" runat="server" CssClass="btn btn-warning btn-sm Pagina Editar" data-toggle="tooltip" data-placement="bottom" title="<%$ Code: Resource.Editar %>" data-original-title="<%$ Code: Resource.Editar %>">
  <span runat="server" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnExcluir" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="btnExcluir" runat="server" CssClass="btn btn-danger btn-sm Pagina Excluir" data-toggle="tooltip" data-placement="bottom" title="<%$ Code: Resource.Excluir %>" data-original-title="<%$ Code: Resource.Excluir %>">
  <span runat="server" class="glyphicon glyphicon-remove"></span>
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnAprovar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="btnAprovar" runat="server" CssClass="btn btn-success btn-sm Pagina Aprovar" data-toggle="tooltip" data-placement="bottom" title="<%$ Code: Resource.Aprovar %>" data-original-title="<%$ Code: Resource.Aprovar %>">
  <span runat="server" class="glyphicon glyphicon-thumbs-up"></span>
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnReprovar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="btnReprovar" runat="server" CssClass="btn btn-danger btn-sm Pagina Reprovar" data-toggle="tooltip" data-placement="bottom" title="<%$ Code: Resource.Reprovar %>" data-original-title="<%$ Code: Resource.Reprovar %>">
  <span runat="server" class="glyphicon glyphicon-ban-circle"></span>
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnConcluir" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="btnConcluir" runat="server" CssClass="btn btn-primary btn-sm Pagina Concluir" data-toggle="tooltip" data-placement="bottom" title="<%$ Code: Resource.Concluir %>" data-original-title="<%$ Code: Resource.Concluir %>">
  <span runat="server" class="glyphicon glyphicon-ok"></span>
                    </asp:LinkButton>

                    <%--</div>--%>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
              <HeaderStyle Font-Bold="True" CssClass="GridViewCabecalho"></HeaderStyle>
              <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
              <AlternatingRowStyle CssClass="line_table_even" Height="22px" />
              <RowStyle CssClass="line_table_odd" Height="22px" />
              <EditRowStyle BackColor="#999999" />
              <SelectedRowStyle CssClass="LinhaSelecionada" />
              <PagerStyle CssClass="Pager"></PagerStyle>
            </asp:GridView>
          </div>
        </div>
      </div>

      <div class="modal fade modal-Item" id="modalTask" tabindex="-1" role="dialog" data-backdrop="static" aria-hidden="true">
        <div class="modal-dialog modal-sm" style="width: 80% !important">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title"><%:Resource.CadastrarTask %></h4>
            </div>
            <div id="divCorpoModal" runat="server" class="modal-body" style="min-height: 100px">
              <div class="form-group linha">
                <div class="col-xs-12">
                  <label for="txtDescricaoCadastro" id="Label1" runat="server"><%:Componente.Supero.Dicionario.Resource.Descricao %></label>
                  <asp:TextBox ID="txtDescricaoCadastro" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
            </div>
            <div id="divRodaPeModal" runat="server" style="padding: 0" class="modal-footer">
              <div class="form-group linhaBotao">
                <div class="col-xs-12">
                  <asp:Button ID="btnSalvarTask" Text="<%$ Code: Resource.Salvar %>" OnClick="btnSalvarTask_Click" CssClass="btn btn-primary" runat="server" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </fieldset>
  </form>
</body>
</html>
