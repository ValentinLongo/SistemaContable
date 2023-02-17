VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptStockEntrVar 
   Caption         =   "SIGC - RptStockEntrVar (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptStockEntrVar.dsx":0000
End
Attribute VB_Name = "RptStockEntrVar"
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
   Menu.Dialog1.FileName = "Comprobante.pdf"
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
   Menu.Dialog1.FileName = "Comprobantes.xls"
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
   
   If txthis_codtex.Text = "0" And txt_his_codnum = "88888888" Then
      txthis_codtex.Text = ""
      txthis_codnum.Text = ""
   End If
   
End Sub

Private Sub PageFooter_BeforePrint()
'   If Not Field15.Text = "" Then
'      Field15.Text = Field15.Text & " DIAS."
'   End If
'   If Not Field14.Text = "" Then
'      Field14.Text = Field14.Text & " DIAS."
'   End If
'
'   If Desde < paginas Then
'      Field2.Text = ""
'      Field3.Text = ""
'      neto21.Text = ""
'      neto10.Text = ""
'      iva21.Text = ""
'      iva10.Text = ""
'      txtvta_total.Text = ""
'      Field1.Text = ""
'      Field15.Text = ""
'      Field14.Text = ""
'      Field8.Text = ""
'      formpag.Text = ""
'      condvta.Text = ""
'      txtvta_observa.Text = ""
'      Field11.Text = ""
'      Field10.Text = ""
'      Field12.Text = ""
'      Field6.Text = ""
'      Field7.Text = ""
'      Field13.Text = ""
'      Label4.Caption = ""
'      Label5.Caption = ""
'      Label3.Caption = ""
'      Texto23.Caption = ""
'      Texto24.Caption = ""
'      Texto25.Caption = ""
'      Texto26.Caption = ""
'      Texto27.Caption = ""
'      Line5.Visible = False
'   End If
'
   hoja.Text = "Hoja " & Desde & " de " & paginas
End Sub


