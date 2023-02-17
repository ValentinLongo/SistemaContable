VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptLibroMayor 
   Caption         =   "SIGC - RptLibroMayor (ActiveReport)"
   ClientHeight    =   11115
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15240
   StartUpPosition =   3  'Windows Default
   _ExtentX        =   26882
   _ExtentY        =   19606
   SectionData     =   "RptLibroMayor.dsx":0000
End
Attribute VB_Name = "RptLibroMayor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim debe As Double
Dim haber As Double
Dim saldo As Double
Dim totSaldo As Double

Private Sub ActiveReport_ReportStart()
    saldo = txtmva_saldoAnterior.Text

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
   pdf.FileName = App.Path & "\Exportacion\PDF\" & Me.Name & ".pdf"
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
   Exc.FileName = App.Path & "\Exportacion\EXCEL\" & Me.Name & ".xls"
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_BeforePrint()
    debe = txtmva_debe.Text: haber = txtmva_haber.Text
    saldo = saldo + debe - haber
    txtmva_saldo.Text = saldo
    'totSaldo = totSaldo + saldo
    
    If txtmva_debe.Text = 0 Then
        txtmva_debe.Text = ""
    End If
    If txtmva_haber.Text = 0 Then
        txtmva_haber.Text = ""
    End If
End Sub

Private Sub ReportFooter_BeforePrint()
    txtmva_totalSaldo.Text = txtmva_saldo.Text 'totSaldo
End Sub

