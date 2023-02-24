VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptAuditInt 
   Caption         =   "SIGC - RptAuditInt (ActiveReport)"
   ClientHeight    =   10695
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   18865
   SectionData     =   "RptAuditInt.dsx":0000
End
Attribute VB_Name = "RptAuditInt"
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
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.FileName = "Auditoria Interna.pdf"
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
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.FileName = "Auditoria Interna.xls"
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
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_Format()
   Select Case Field10.Text
      Case Is = 1
         Field10.Text = "CTDO"
      Case Is = 2
         Field10.Text = "CTA CTE"
      Case Is = 3
         Field10.Text = "TC"
      Case Else
         Field10.Text = ""
   End Select
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "P�gina " & Me.pageNumber
End Sub
