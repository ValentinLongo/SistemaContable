VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptDescuentosPro 
   Caption         =   "SIGC - RptDescuentosPro (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptDescuentosPro.dsx":0000
End
Attribute VB_Name = "RptDescuentosPro"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   If txtpra_fabrica.Text = "0" Then
      txtpra_fabrica.Text = ""
      txtfab_descri.Text = ""
   End If
   If txtpra_linea.Text = "0" Then
      txtpra_linea.Text = ""
      txtlin_descri.Text = ""
   End If
   If txtpra_rubro.Text = "0" Then
      txtpra_rubro.Text = ""
      txtrub_descri.Text = ""
   End If

End Sub

Private Sub GroupHeader1_BeforePrint()
   Select Case txtpra_secuencia.Text
      Case Is = 1
         secuencia.Caption = "Descuentos por Fabrica"
      Case Is = 2
         secuencia.Caption = "Descuentos por Fabrica y Línea"
      Case Is = 3
         secuencia.Caption = "Descuentos por Fabrica, Línea y Rubro"
      Case Is = 4
         secuencia.Caption = "Descuentos por Artículo"
      Case Is = 5
         secuencia.Caption = "Descuentos por Proveedor"
   End Select
End Sub


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
   Menu.Dialog1.FileName = "Descuentos por Proveedor.pdf"
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
   Menu.Dialog1.FileName = "Descuentos por Proveedor.xls"
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

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "Página " & Me.pageNumber
End Sub






