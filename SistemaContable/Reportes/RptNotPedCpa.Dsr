VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptNotPedCpa 
   Caption         =   "SIGC - RptNotPedCpa (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptNotPedCpa.dsx":0000
End
Attribute VB_Name = "RptNotPedCpa"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
End Sub

Private Sub ActiveReport_ToolbarClick(ByVal Tool As DDActiveReports2.DDTool)
   Select Case Tool.Caption
      Case Is = "&PDF"
         tbPDFExport
      Case Is = "&Excel"
         tbExcel
   End Select
End Sub

Private Sub tbPDFExport()
On Error GoTo fin
   Dim pdf As New ActiveReportsPDFExport.ARExportPDF
   Set pdf = New ActiveReportsPDFExport.ARExportPDF
   Menu.Dialog1.FileName = "Pedido.pdf"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".pdf"
   End If
   pdf.FileName = Menu.Dialog1.FileName
   pdf.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   Menu.Dialog1.FileName = "Pedido.xls"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_BeforePrint()
   On Error Resume Next
   txtDtos.Text = IIf((txthis_dtoa = 0), "", Format(txthis_dtoa, "0.00")) _
   & IIf((txthis_dtob = 0), "", "-" & Format(txthis_dtob, "0.00")) _
   & IIf((txthis_dtoc = 0), "", "-" & Format(txthis_dtoc, "0.00")) _
   & IIf((txthis_dtod = 0), "", "-" & Format(txthis_dtod, "0.00")) _
   & IIf((txthis_dtoe = 0), "", "-" & Format(txthis_dtoe, "0.00")) _
   & IIf((txthis_dtof = 0), "", "-" & Format(txthis_dtof, "0.00"))
   'If Trim(txtDtos.Text) = "" Then Exit Sub
   'txtDtos.Text = IIf((Left(txtDtos.Text, 1) = "+"), Right(txtDtos.Text, Len(txtDtos.Text) - 1), txtDtos.Text)
   
   If txtart_embalaje.Text = "0" Then txtart_embalaje.Text = ""
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "Página " & hoja.Text
   
   If hoja.Text <> Total.Text Then
      RptNotPedCpa.txthis_preclista.Visible = False
      RptNotPedCpa.Label11.Visible = False
      RptNotPedCpa.txtDtos.Visible = False
      RptNotPedCpa.Label6.Visible = False
      RptNotPedCpa.txthis_punitario.Visible = False
      RptNotPedCpa.Texto2.Visible = False
      RptNotPedCpa.Texto1.Visible = False
      RptNotPedCpa.txthis_total.Visible = False
      RptNotPedCpa.Label4.Visible = False
      RptNotPedCpa.Label5.Visible = False
      RptNotPedCpa.Label3.Visible = False
      RptNotPedCpa.Texto23.Visible = False
      RptNotPedCpa.Texto24.Visible = False
      RptNotPedCpa.Texto25.Visible = False
      RptNotPedCpa.Texto26.Visible = False
      RptNotPedCpa.Texto27.Visible = False
      RptNotPedCpa.lbl_dtosgral.Visible = False
      RptNotPedCpa.Field1.Visible = False
      RptNotPedCpa.Field2.Visible = False
      RptNotPedCpa.Field3.Visible = False
      RptNotPedCpa.neto21.Visible = False
      RptNotPedCpa.neto10.Visible = False
      RptNotPedCpa.iva21.Visible = False
      RptNotPedCpa.iva10.Visible = False
      RptNotPedCpa.txtvta_total.Visible = False
      
      RptNotPedCpa.Line5.Visible = False
      RptNotPedCpa.Field10.Visible = False
      RptNotPedCpa.Field16.Visible = False
      RptNotPedCpa.Field18.Visible = False
      RptNotPedCpa.Field13.Visible = False
      RptNotPedCpa.Transp1.Visible = False
      RptNotPedCpa.Transp2.Visible = False
      RptNotPedCpa.Transp3.Visible = False
      RptNotPedCpa.txtvta_observa.Visible = False
   Else
      If txt_param1.Text <> "1" Then
         RptNotPedCpa.txthis_preclista.Visible = True
         RptNotPedCpa.Label11.Visible = True
         RptNotPedCpa.txtDtos.Visible = True
         RptNotPedCpa.Label6.Visible = True
         RptNotPedCpa.txthis_punitario.Visible = True
         RptNotPedCpa.Texto2.Visible = True
         RptNotPedCpa.Texto1.Visible = True
         RptNotPedCpa.txthis_total.Visible = True
         RptNotPedCpa.Label4.Visible = True
         RptNotPedCpa.Label5.Visible = True
         RptNotPedCpa.Label3.Visible = True
         RptNotPedCpa.Texto23.Visible = True
         RptNotPedCpa.Texto24.Visible = True
         RptNotPedCpa.Texto25.Visible = True
         RptNotPedCpa.Texto26.Visible = True
         RptNotPedCpa.Texto27.Visible = True
         RptNotPedCpa.lbl_dtosgral.Visible = True
         RptNotPedCpa.Field1.Visible = True
         RptNotPedCpa.Field2.Visible = True
         RptNotPedCpa.Field3.Visible = True
         RptNotPedCpa.neto21.Visible = True
         RptNotPedCpa.neto10.Visible = True
         RptNotPedCpa.iva21.Visible = True
         RptNotPedCpa.iva10.Visible = True
         RptNotPedCpa.txtvta_total.Visible = True
      
         RptNotPedCpa.Line5.Visible = True
         RptNotPedCpa.Field10.Visible = True
         RptNotPedCpa.Field16.Visible = True
         RptNotPedCpa.Field18.Visible = True
         RptNotPedCpa.Field13.Visible = True
         RptNotPedCpa.Transp1.Visible = True
         RptNotPedCpa.Transp2.Visible = True
         RptNotPedCpa.Transp3.Visible = True
         RptNotPedCpa.txtvta_observa.Visible = True
      Else
         RptNotPedCpa.txthis_preclista.Visible = False
         RptNotPedCpa.Label11.Visible = False
         RptNotPedCpa.txtDtos.Visible = False
         RptNotPedCpa.Label6.Visible = False
         RptNotPedCpa.txthis_punitario.Visible = False
         RptNotPedCpa.Texto2.Visible = False
         RptNotPedCpa.Texto1.Visible = False
         RptNotPedCpa.txthis_total.Visible = False
         RptNotPedCpa.Label4.Visible = False
         RptNotPedCpa.Label5.Visible = False
         RptNotPedCpa.Label3.Visible = False
         RptNotPedCpa.Texto23.Visible = False
         RptNotPedCpa.Texto24.Visible = False
         RptNotPedCpa.Texto25.Visible = False
         RptNotPedCpa.Texto26.Visible = False
         RptNotPedCpa.Texto27.Visible = False
         RptNotPedCpa.lbl_dtosgral.Visible = False
         RptNotPedCpa.Field1.Visible = False
         RptNotPedCpa.Field2.Visible = False
         RptNotPedCpa.Field3.Visible = False
         RptNotPedCpa.neto21.Visible = False
         RptNotPedCpa.neto10.Visible = False
         RptNotPedCpa.iva21.Visible = False
         RptNotPedCpa.iva10.Visible = False
         RptNotPedCpa.txtvta_total.Visible = False
         
         RptNotPedCpa.Line5.Visible = False
         RptNotPedCpa.Field10.Visible = False
         RptNotPedCpa.Field16.Visible = False
         RptNotPedCpa.Field18.Visible = False
         RptNotPedCpa.Field13.Visible = False
         RptNotPedCpa.Transp1.Visible = False
         RptNotPedCpa.Transp2.Visible = False
         RptNotPedCpa.Transp3.Visible = False
         RptNotPedCpa.txtvta_observa.Visible = False
      End If
   End If
End Sub

Private Sub ReportFooter_BeforePrint()
   If txtiva_condicion.Text = "EXENTO" Or txtiva_condicion.Text = "CONSUMIDOR FINAL" Then
      neto21.Text = "0,00"
      neto10.Text = "0,00"
      iva21.Text = "0,00"
      iva10.Text = "0,00"
   Else
      neto21.Text = txtvta_neto21.Text
      neto10.Text = txtvta_neto10.Text
      iva21.Text = txtvta_iva21.Text
      iva10.Text = txtvta_iva10.Text
   End If
End Sub
