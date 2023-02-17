VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptListInven1 
   Caption         =   "SIGC - RptListInven1 (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptListInven1.dsx":0000
End
Attribute VB_Name = "RptListInven1"
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
   Menu.Dialog1.FileName = "Inventario.pdf"
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
   Menu.Dialog1.FileName = "Inventario.xls"
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
   If Val(txtart_embalaje.Text) = 0 Then
      txtart_embalaje.Visible = False
   Else
      txtart_embalaje.Visible = True
   End If
   
   If txtart_vigencia.Text <> 1 Then
      Shape2.Visible = True
   Else
      Shape2.Visible = False
   End If
   
   Field1.Text = IIf((CLng(txtaux_dtoa.Text) = 0), "", " -" & Format(txtaux_dtoa.Text, "0.00")) _
   & IIf((CLng(txtaux_dtob.Text) = 0), "", " -" & Format(txtaux_dtob.Text, "0.00")) _
   & IIf((CLng(txtaux_dtoc.Text) = 0), "", " -" & Format(txtaux_dtoc.Text, "0.00")) _
   & IIf((CLng(txtaux_dtod.Text) = 0), "", " -" & Format(txtaux_dtod.Text, "0.00")) _
   & IIf((CLng(txtaux_dtoe.Text) = 0), "", " -" & Format(txtaux_dtoe.Text, "0.00")) _
   & IIf((CLng(txtaux_dtof.Text) = 0), "", " -" & Format(txtaux_dtof.Text, "0.00")) _
   & IIf((CLng(txtaux_dtoad1.Text) = 0), "", " -" & Format(txtaux_dtoad1.Text, "0.00")) _
   & IIf((CLng(txtaux_dtoad2.Text) = 0), "", " -" & Format(txtaux_dtoad2.Text, "0.00")) _
   & IIf((CLng(txtaux_dtoad3.Text) = 0), "", " -" & Format(txtaux_dtoad3.Text, "0.00"))
   
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "Página " & Me.pageNumber
End Sub


