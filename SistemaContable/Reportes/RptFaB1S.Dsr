VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptFaB1S 
   Caption         =   "SIGC - RptFaB1S (ActiveReport)"
   ClientHeight    =   10695
   ClientLeft      =   -255
   ClientTop       =   1020
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   18865
   SectionData     =   "RptFaB1S.dsx":0000
End
Attribute VB_Name = "RptFaB1S"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim tNum2Text As cNum2Text

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
   If Len(ParCerosCant) > 0 Then
      txthis_cantidad.OutputFormat = "0." & ParCerosCant
   End If
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
   Menu.Dialog1.ShowSave
   If right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".pdf"
   End If
   pdf.FileName = Menu.Dialog1.FileName
   pdf.Export Me.Pages
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   Menu.Dialog1.FileName = "Comprobantes.xls"
   Menu.Dialog1.ShowSave
   If right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_BeforePrint()
   On Error Resume Next
   
   CtrlCad txthis_articulo
   
   If CDec(Trim(txthis_cantidad.Text)) = 0 Then
      txthis_cantidad.Text = ""
      txthis_aliva.Text = ""
      txthis_punitario.Text = ""
      txthis_total.Text = ""
   End If
   
End Sub

Private Sub PageHeader_Format()
   CtrlCad Me.txtvta_cliente, 0
End Sub