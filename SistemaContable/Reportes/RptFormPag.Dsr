VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptFormPag 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "SIGC - RptFormPag (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   MaxButton       =   0   'False
   MinButton       =   0   'False
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptFormPag.dsx":0000
End
Attribute VB_Name = "RptFormPag"
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
   pdf.FileName = App.Path & "\Exportacion\PDF\" & Me.Name & ".pdf"
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
   Exc.FileName = App.Path & "\Exportacion\EXCEL\" & Me.Name & ".xls"
   Exc.Export Me.Pages
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub


