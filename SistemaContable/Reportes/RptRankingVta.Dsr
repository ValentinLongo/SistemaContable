VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptRankingVta 
   Caption         =   "SIGC - RptRankingVta (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptRankingVta.dsx":0000
End
Attribute VB_Name = "RptRankingVta"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
   'Me.Toolbar.Tools.AddEx("&Grafico").Tooltip = "Imprimir Gráfico"
End Sub

Private Sub ActiveReport_ToolbarClick(ByVal Tool As DDActiveReports2.DDTool)
   Select Case Tool.Caption
      Case Is = "&PDF"
         tbPDFExport
      Case Is = "&Excel"
         tbExcel
      'Case Is = "&Grafico"
      '   Grafic
   End Select
End Sub

Private Sub Grafic()
   Set Rst25 = New ADODB.Recordset
   If Rst25.State = 1 Then Rst25.Close
   Rst25.Open Me.DataControl1.Source, Cnn, adOpenKeyset, adLockReadOnly, adCmdText
   Dim n As Long
   RptGraf.Chart1.ColumnCount = Rst25.RecordCount
   RptGraf.Chart1.Title.Text = "Ranking de Ventas"
   Rst25.MoveFirst
   For n = 1 To Rst25.RecordCount + 1
      RptGraf.Chart1.Column = n
      RptGraf.Chart1.ColumnLabel = Rst25!ran_cliente
      RptGraf.Chart1.Data = CDec(Rst25!ran_total)
      Rst25.MoveNext
      If Rst25.EOF Then Exit For
   Next n
   RptGraf.Show vbModal
End Sub

Private Sub tbPDFExport()
On Error GoTo fin
   Dim pdf As New ActiveReportsPDFExport.ARExportPDF
   Set pdf = New ActiveReportsPDFExport.ARExportPDF
   Menu.Dialog1.FileName = "Ranking de Ventas.pdf"
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
   Menu.Dialog1.FileName = "Ranking de Ventas.xls"
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
   
   If pagina <> Total Then
      Label7.Caption = ""
      TotC.Text = ""
      TotN.Text = ""
      TotT.Text = ""
      TotCob.Text = ""
   End If
End Sub

Private Sub Detail_BeforePrint()
   If Me.txtran_ctrl2.Text = 1 Then
      Me.txtran_pos.BackColor = &HC0C0C0
      Me.txtran_cantidad.BackColor = &HC0C0C0
      Me.txtran_ctapro.BackColor = &HC0C0C0
      Me.txtran_neto.BackColor = &HC0C0C0
      Me.txtran_pos.BackColor = &HC0C0C0
      Me.txtran_proveedor.BackColor = &HC0C0C0
      Me.txtran_total.BackColor = &HC0C0C0
   Else
      Me.txtran_pos.BackColor = &HFFFFFF
      Me.txtran_cantidad.BackColor = &HFFFFFF
      Me.txtran_ctapro.BackColor = &HFFFFFF
      Me.txtran_neto.BackColor = &HFFFFFF
      Me.txtran_pos.BackColor = &HFFFFFF
      Me.txtran_proveedor.BackColor = &HFFFFFF
      Me.txtran_total.BackColor = &HFFFFFF
   End If
End Sub

