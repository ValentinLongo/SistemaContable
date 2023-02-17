VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptLibroDiario 
   Caption         =   "SIGC - RptLibroDiario (ActiveReport)"
   ClientHeight    =   11115
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15240
   StartUpPosition =   3  'Windows Default
   _ExtentX        =   26882
   _ExtentY        =   19606
   SectionData     =   "RptLibroDiario.dsx":0000
End
Attribute VB_Name = "RptLibroDiario"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim ultimoDebe As Double
Dim ultimoHaber As Double

Private Sub ActiveReport_ReportStart()
    'Me.PageSettings.PaperSize = 9 'Hoja A4
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
    If txtmva_haber.Text <> 0 Then
        txtmva_descri.Text = "a      " & txtmva_descri.Text
    Else
        txtmva_haber.Text = ""
    End If
    If txtmva_debe.Text = 0 Then
        txtmva_debe.Text = ""
    End If
End Sub
       
Private Sub GroupFooter1_BeforePrint()
    TotDebe = TotDebe + txtmva_totalDebe.Text
    TotHaber = TotHaber + txtmva_totalHaber.Text
End Sub

Private Sub PageFooter_BeforePrint()
    If totalPaginas.Text > 1 Then
        If numPagina.Text < totalPaginas.Text Then
            txtmva_transpFinDebe.Visible = True
            txtmva_transpFinHaber.Visible = True
            Label7.Visible = True
            txtmva_transpIniDebe.Text = txtmva_transpFinDebe.Text
            txtmva_transpIniHaber.Text = txtmva_transpFinHaber.Text
        Else
            txtmva_transpFinDebe.Visible = False
            txtmva_transpFinHaber.Visible = False
            Label7.Visible = False
        End If
    Else
        txtmva_transpFinDebe.Visible = False
        txtmva_transpFinHaber.Visible = False
        Label7.Visible = False
    End If
End Sub

Private Sub PageHeader_BeforePrint()
    If numPagina.Text = 1 Then
        txtmva_transpIniDebe.Visible = False
        txtmva_transpIniHaber.Visible = False
        Label8.Visible = False
    Else
        txtmva_transpIniDebe.Visible = True
        txtmva_transpIniHaber.Visible = True
        Label8.Visible = True
    End If
End Sub

Private Sub ReportFooter_BeforePrint()
    txtmva_totFinDebe.Text = TotDebe
    txtmva_totFinHaber.Text = TotHaber
    TotDebe = 0: TotHaber = 0

    If totalPaginas.Text > 1 Then
        If numPagina.Text < totalPaginas.Text Then
            txtmva_totFinDebe.Visible = False
            txtmva_totFinHaber.Visible = False
            Label11.Visible = False
        Else
            txtmva_totFinDebe.Visible = True
            txtmva_totFinHaber.Visible = True
            Label11.Visible = True
        End If
    Else
        txtmva_totFinDebe.Visible = True
        txtmva_totFinHaber.Visible = True
        Label11.Visible = True
    End If
End Sub
